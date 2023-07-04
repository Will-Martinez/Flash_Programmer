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
            label1 = new Label();
            textBox1 = new TextBox();
            RunBtn = new Button();
            logBox = new RichTextBox();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 34);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 0;
            label1.Text = "SN";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(141, 23);
            textBox1.TabIndex = 1;
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
            logBox.Location = new Point(12, 210);
            logBox.Name = "logBox";
            logBox.Size = new Size(776, 228);
            logBox.TabIndex = 3;
            logBox.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 181);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(776, 23);
            progressBar1.TabIndex = 4;
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
            // textBox2
            // 
            textBox2.Location = new Point(72, 119);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 6;
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
            // textBox3
            // 
            textBox3.Location = new Point(265, 119);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(126, 23);
            textBox3.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(logBox);
            Controls.Add(RunBtn);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "OneRF CATM Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button RunBtn;
        private RichTextBox logBox;
        private ProgressBar progressBar1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
    }
}