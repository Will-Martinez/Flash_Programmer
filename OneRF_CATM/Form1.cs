using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;

namespace OneRF_CATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ClearBtn.Enabled = false;
            logBox.Enabled = false;
            printBtn.Enabled = false;
            macTextBox.ReadOnly = true;
            statusText.ReadOnly = true;
            logBox.ReadOnly = true;
        }

        private async void RunBtn_Click(object sender, EventArgs e)
        {
            if (imeiTextBox.Text == "" || imeiTextBox.Text == null)
            {
                MessageBox.Show("Type a IMEI number to program execution.");
                return;
            }
            bool isImeiValid = ValidateImeiInput(imeiTextBox.Text);
            if (isImeiValid == false)
            {
                MessageBox.Show("Imei does not match with pattern.");
                return;
            }
            printBtn.Enabled = false;
            logBox.Clear();
            logBox.Enabled = true;
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string batFilePath = Path.Combine(appDirectory, "uniflash_windows", "dslite.bat");
            string outputFilePath = Path.Combine(appDirectory, "uniflash_windows", "output.txt");

            if (File.Exists(batFilePath))
            {
                // Cria um novo processo para execução de um arquivo .bat
                Process process = new Process();

                // Define as informações de inicialização do processo
                process.StartInfo.FileName = batFilePath;
                process.StartInfo.WorkingDirectory = Path.Combine(appDirectory, "uniflash_windows");
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                // Inicia o processo
                process.Start();
                statusText.Text = "Flashing memory...";
                string mac = "";

                // Configura o FileSystemWatcher para monitorar alterações no arquivo output.txt
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(outputFilePath);
                watcher.Filter = Path.GetFileName(outputFilePath);
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Changed += (s, args) =>
                {
                    // Executa a lógica em uma nova thread usando Task.Run
                    Task.Run(() =>
                    {
                        // Lê as novas linhas adicionadas no arquivo output.txt
                        string[] newLines = File.ReadAllLines(outputFilePath);

                        // Atualiza o logBox na thread de interface do usuário e verifica se o mac existe
                        logBox.BeginInvoke(new Action(() =>
                        {
                            foreach (string line in newLines)
                            {
                                if (line.Contains("ReadPriIeee:"))
                                {
                                    int startIndex = line.IndexOf("ReadPriIeee:") + "ReadPriIeee:".Length;
                                    mac = line.Substring(startIndex).Trim();
                                }
                                logBox.AppendText(line + Environment.NewLine);
                            }
                            string messageResult = newLines[newLines.Length - 1];
                            if (messageResult == "Success" && mac != "")
                            {
                                statusText.Text = messageResult;
                                macTextBox.Text = mac;
                                printBtn.Enabled = true;
                            }
                            else
                            {
                                statusText.Text = "Error";
                                macTextBox.Text = "Not founded";
                            }
                        }));
                    });
                };
                watcher.EnableRaisingEvents = true;

                // Aguarda a conclusão do processo
                await Task.Run(() => process.WaitForExit());

                // Fecha o FileSystemWatcher
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();

                // Deleta o arquivo output.txt
                File.Delete(outputFilePath);

                // Cria os logs para os dispositivos
                CreateLogFiles(macTextBox.Text, imeiTextBox.Text, statusText.Text);

                ClearBtn.Enabled = true;
                // Fecha e libera os recursos do processo
                process.Close();
                process.Dispose();
            }
        }

        private bool ValidateData(string mac, string imei)
        {
            try
            {
                if (mac != "" && imei != "")
                {
                    string imeiPattern = @"\b\d{15}\b"; // Padrão para IMEI: 15 dígitos numéricos
                    string macPattern = @"\b([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})\b"; // Padrão para MAC: formato xx:xx:xx:xx:xx:xx ou xx-xx-xx-xx-xx-xx
                    bool isMacValid = Regex.IsMatch(mac, macPattern);
                    bool isImeiValid = Regex.IsMatch(imei, imeiPattern);
                    return isMacValid && isImeiValid;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to validate mac and imei pattern: {error.Message}");
                return false;
            }
        }

        private bool ValidateImeiInput(string imei)
        {
            try
            {
                if (imei != "")
                {
                    string imeiPattern = @"\b\d{15}\b"; // Padrão para IMEI: 15 dígitos numéricos
                    bool isImeiValid = Regex.IsMatch(imei, imeiPattern);
                    return isImeiValid;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to valiade IMEI input: ${error.Message}");
                return false;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (imeiTextBox.Text != "" && macTextBox.Text != "")
            {
                bool isValidData = ValidateData(macTextBox.Text, imeiTextBox.Text);
                if (isValidData == false)
                {
                    MessageBox.Show("Mac or imei does not match with their pattern");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mac or imei can not be empty for priting.");
                return;
            }
            List<DiscoveredUsbPrinter> printers = discoverUsbPrinters();
            StringBuilder message = new StringBuilder();
            string printerSymbolicName = "";
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string zplFilePath = Path.Combine(appDirectory, "OneRF_label_3x20x20mm_will.zpl");

            foreach (DiscoveredUsbPrinter printer in printers)
            {
                printerSymbolicName = printer.ToString();
            }
            UsbConnection printerIsConnected = connectUsbPrinter(printerSymbolicName);
            if (printerIsConnected != null)
            {
                PrintZplFile(printerIsConnected, zplFilePath);
            }
            else
            {
                MessageBox.Show("Error trying to connect printer.");
            }
        }

        private List<DiscoveredUsbPrinter> discoverUsbPrinters()
        {

            try
            {
                List<DiscoveredUsbPrinter> usbPrinters = UsbDiscoverer.GetZebraUsbPrinters();
                if (usbPrinters.Count > 0)
                {
                    return usbPrinters;
                }
                else
                {
                    return new List<DiscoveredUsbPrinter>();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error trying to find usb printers: {error.Message}");
                //retorna uma lista vazia caso a lista de impressoras disponiveis não exista
                return null;
            }
        }

        private UsbConnection connectUsbPrinter(string symbolicPrinterName)
        {
            try
            {
                UsbConnection usbPrinterConnection = new UsbConnection(symbolicPrinterName);
                usbPrinterConnection.Open();
                ZebraPrinterLinkOs linkOsPrinter = ZebraPrinterFactory.GetLinkOsPrinter(usbPrinterConnection);
                linkOsPrinter.GetAllSettings();
                return usbPrinterConnection;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error trying to connect printer: {error.Message}");
                return null;
            }
        }

        private string DefinePrintParameters(string zplFileCode)
        {
            try
            {
                string macValue = macTextBox.Text;
                string imeiValue = imeiTextBox.Text;
                string dateTimeFormat = "dd/mm/yyyy HH:mm:ss";
                string formatedDateTime = DateTime.Now.ToString(dateTimeFormat);
                if (macValue != null && imeiValue != null)
                {
                    zplFileCode = zplFileCode.Replace("mac macqrcode_0D_0A", $"mac {macValue}_0D_0A");
                    zplFileCode = zplFileCode.Replace("imei imeiqrcode^FS", $"imei {imeiValue}^FS");
                    zplFileCode = zplFileCode.Replace(@"^FT9,106^A0N,18,16^FH\^FDimei_value^FS", $@"^FT9,106^A0N,18,16^FH\^FD{imeiValue}^FS");
                    zplFileCode = zplFileCode.Replace(@"^FT193,106^A0N,18,16^FH\^FDimei_value^FS", $@"^FT193,106^A0N,18,16^FH\^FD${imeiValue}^FS");
                    zplFileCode = zplFileCode.Replace(@"^FT377,106^A0N,18,16^FH\^FDimei_value^FS", $@"^FT377,106^A0N,18,16^FH\^FD{imeiValue}^FS");
                }
                return zplFileCode;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to define print parameters: {error.Message}");
                return null;
            }
        }

        private void PrintZplFile(UsbConnection usbConnection, string zplFilePath)
        {
            try
            {
                ZebraPrinter zebraPrinter = ZebraPrinterFactory.GetInstance(usbConnection);
                if (zebraPrinter != null)
                {
                    string zplFileCode = File.ReadAllText(zplFilePath);
                    string formatedZplFileCode = DefinePrintParameters(zplFileCode);
                    zebraPrinter.SendCommand(formatedZplFileCode);
                    MessageBox.Show($"File printed.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to print tag: {error.Message}");
            }
            ClearFormData();
        }

        private void CreateLogFiles(string deviceMac, string imei, string statusMessage)
        {
            try
            {
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string logDirectory = Path.Combine(appDirectory, "logs");
                string directoryName = $"mac_{deviceMac}_imei_{imei}";
                string logDevice = (DateTime.Now.ToString().Replace(':', '-').Replace('/', '-').Replace(' ', '_')) + ".txt";
                string creatingDeviceDirectory = Path.Combine(logDirectory, directoryName);
                string creatingLogDevice = Path.Combine(creatingDeviceDirectory, logDevice);

                if (!Directory.Exists(creatingDeviceDirectory))
                {
                    Directory.CreateDirectory(creatingDeviceDirectory);
                }

                if (!File.Exists(creatingLogDevice))
                {
                    using (StreamWriter sw = File.CreateText(creatingLogDevice))
                    {
                        string timestamp = DateTime.Now.ToString();

                        // Escrever os dados iniciais de log
                        sw.WriteLine($"Status: {statusMessage}");
                        sw.WriteLine($"MAC: {deviceMac}");
                        sw.WriteLine($"IMEI: {imei}");
                        sw.WriteLine($"Timestamp: {timestamp}");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to create log files: {error.Message}");
                Debug.WriteLine(error.Message);
            }
        }

        private void ClearFormData()
        {
            try
            {
                imeiTextBox.Text = "";
                statusText.Text = "";
                macTextBox.Text = "";
                logBox.Clear();
                printBtn.Enabled = false;
                ClearBtn.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to clear data form: {error.Message}");
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFormData();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Failed trying to run clear function: {error.Message}");
            }
        }
    }
}