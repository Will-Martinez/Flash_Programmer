namespace OneRF_CATM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            imeiTextBox = new TextBox();
            RunBtn = new Button();
            logBox = new RichTextBox();
            label2 = new Label();
            statusText = new TextBox();
            label3 = new Label();
            macTextBox = new TextBox();
            printBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 34);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "IMEI";
            // 
            // imeiTextBox
            // 
            imeiTextBox.Location = new Point(72, 52);
            imeiTextBox.Name = "imeiTextBox";
            imeiTextBox.Size = new Size(141, 23);
            imeiTextBox.TabIndex = 1;
            // 
            // RunBtn
            // 
            RunBtn.Location = new Point(447, 52);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(75, 23);
            RunBtn.TabIndex = 2;
            RunBtn.Text = "Run";
            RunBtn.UseVisualStyleBackColor = true;
            RunBtn.Click += RunBtn_Click;
            // 
            // logBox
            // 
            logBox.Location = new Point(12, 163);
            logBox.Name = "logBox";
            logBox.Size = new Size(776, 275);
            logBox.TabIndex = 3;
            logBox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 101);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Status";
            // 
            // statusText
            // 
            statusText.Location = new Point(72, 119);
            statusText.Name = "statusText";
            statusText.Size = new Size(100, 23);
            statusText.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 101);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 7;
            label3.Text = "Device Mac";
            // 
            // macTextBox
            // 
            macTextBox.Location = new Point(265, 119);
            macTextBox.Name = "macTextBox";
            macTextBox.Size = new Size(167, 23);
            macTextBox.TabIndex = 8;
            // 
            // printBtn
            // 
            printBtn.Location = new Point(653, 119);
            printBtn.Name = "printBtn";
            printBtn.Size = new Size(75, 23);
            printBtn.TabIndex = 9;
            printBtn.Text = "Print";
            printBtn.UseVisualStyleBackColor = true;
            printBtn.Click += printBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(printBtn);
            Controls.Add(macTextBox);
            Controls.Add(label3);
            Controls.Add(statusText);
            Controls.Add(label2);
            Controls.Add(logBox);
            Controls.Add(RunBtn);
            Controls.Add(imeiTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "OneRF CATM Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox imeiTextBox;
        private Button RunBtn;
        private RichTextBox logBox;
        private Label label2;
        private TextBox statusText;
        private Label label3;
        private TextBox macTextBox;
        private Button printBtn;
    }
}