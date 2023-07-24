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
            ClearBtn = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(441, 56);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 0;
            label1.Text = "IMEI";
            // 
            // imeiTextBox
            // 
            imeiTextBox.Location = new Point(441, 84);
            imeiTextBox.Name = "imeiTextBox";
            imeiTextBox.Size = new Size(141, 23);
            imeiTextBox.TabIndex = 1;
            // 
            // RunBtn
            // 
            RunBtn.BackgroundImageLayout = ImageLayout.Center;
            RunBtn.Dock = DockStyle.Top;
            RunBtn.FlatAppearance.BorderSize = 0;
            RunBtn.FlatStyle = FlatStyle.Flat;
            RunBtn.ForeColor = Color.Gainsboro;
            RunBtn.Image = Properties.Resources.botao_play4;
            RunBtn.Location = new Point(0, 112);
            RunBtn.Name = "RunBtn";
            RunBtn.RightToLeft = RightToLeft.No;
            RunBtn.Size = new Size(158, 55);
            RunBtn.TabIndex = 2;
            RunBtn.TextAlign = ContentAlignment.MiddleLeft;
            RunBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            RunBtn.UseVisualStyleBackColor = true;
            RunBtn.Click += RunBtn_Click;
            // 
            // logBox
            // 
            logBox.Location = new Point(164, 174);
            logBox.Name = "logBox";
            logBox.Size = new Size(624, 264);
            logBox.TabIndex = 3;
            logBox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(225, 116);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 5;
            label2.Text = "Status";
            // 
            // statusText
            // 
            statusText.Location = new Point(225, 144);
            statusText.Name = "statusText";
            statusText.Size = new Size(141, 23);
            statusText.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(225, 56);
            label3.Name = "label3";
            label3.Size = new Size(115, 25);
            label3.TabIndex = 7;
            label3.Text = "Device Mac";
            // 
            // macTextBox
            // 
            macTextBox.Location = new Point(225, 84);
            macTextBox.Name = "macTextBox";
            macTextBox.Size = new Size(167, 23);
            macTextBox.TabIndex = 8;
            // 
            // printBtn
            // 
            printBtn.Dock = DockStyle.Top;
            printBtn.FlatAppearance.BorderSize = 0;
            printBtn.FlatStyle = FlatStyle.Flat;
            printBtn.Image = Properties.Resources.printer;
            printBtn.Location = new Point(0, 56);
            printBtn.Name = "printBtn";
            printBtn.Size = new Size(158, 56);
            printBtn.TabIndex = 9;
            printBtn.UseVisualStyleBackColor = true;
            printBtn.Click += printBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.Dock = DockStyle.Top;
            ClearBtn.FlatStyle = FlatStyle.Flat;
            ClearBtn.Image = Properties.Resources.clear;
            ClearBtn.Location = new Point(0, 0);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(158, 56);
            ClearBtn.TabIndex = 10;
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(51, 51, 76);
            panel1.Controls.Add(RunBtn);
            panel1.Controls.Add(printBtn);
            panel1.Controls.Add(ClearBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(158, 445);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(158, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(634, 35);
            panel2.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(205, 9);
            label4.Name = "label4";
            label4.Size = new Size(183, 25);
            label4.TabIndex = 13;
            label4.Text = "OneRF CATM Tool";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 445);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(macTextBox);
            Controls.Add(label3);
            Controls.Add(statusText);
            Controls.Add(label2);
            Controls.Add(logBox);
            Controls.Add(imeiTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "OneRF CATM Tool";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Button ClearBtn;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
    }
}