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

namespace OneRF_CATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            logBox.ReadOnly = true;
            logBox.Enabled = false;
        }

        private async void RunBtn_Click(object sender, EventArgs e)
        {
            logBox.Clear();
            logBox.Enabled = true;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "c:/ti/uniflash_8.3.0/dslite.bat";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                // Manipula o evento de OutputDataReceived para ler o output da bat
                process.OutputDataReceived += (s, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        // Exibe o output no RichTextBox (na thread de interface do usuário)
                        logBox.Invoke(new Action(() =>
                        {
                            logBox.AppendText(args.Data + Environment.NewLine);
                        }));
                    }
                };

                // Inicia o processo
                process.Start();

                // Inicia a leitura do output assincronamente
                process.BeginOutputReadLine();

                // Aguarda a conclusão do processo
                await process.WaitForExitAsync();

                // Fecha e libera os recursos do processo
                process.Close();
                process.Dispose();
            }
        }
    }
}
