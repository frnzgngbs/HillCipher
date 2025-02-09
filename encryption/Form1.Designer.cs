namespace encryption
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            encryptButton = new Button();
            decryptButton = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(94, 140);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(83, 32);
            encryptButton.TabIndex = 0;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += button1_Click_1;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(416, 143);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(85, 29);
            decryptButton.TabIndex = 1;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += button2_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 369);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Button encryptButton;
        private Button decryptButton;
    }
}
