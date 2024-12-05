namespace YapaySinirAglari
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
            buttonEgit = new Button();
            buttonTest = new Button();
            buttonKaydet = new Button();
            buttonYukle = new Button();
            buttonTemizle = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // buttonEgit
            // 
            buttonEgit.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEgit.Location = new Point(3, 405);
            buttonEgit.Margin = new Padding(4, 3, 4, 3);
            buttonEgit.Name = "buttonEgit";
            buttonEgit.Size = new Size(119, 30);
            buttonEgit.TabIndex = 0;
            buttonEgit.Text = "Eğit";
            buttonEgit.UseVisualStyleBackColor = true;
            buttonEgit.Click += buttonEgit_Click;
            // 
            // buttonTest
            // 
            buttonTest.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTest.Location = new Point(130, 405);
            buttonTest.Margin = new Padding(4, 3, 4, 3);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(119, 30);
            buttonTest.TabIndex = 1;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += buttonTest_Click_1;
            // 
            // buttonKaydet
            // 
            buttonKaydet.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonKaydet.Location = new Point(841, 441);
            buttonKaydet.Margin = new Padding(4, 3, 4, 3);
            buttonKaydet.Name = "buttonKaydet";
            buttonKaydet.Size = new Size(119, 30);
            buttonKaydet.TabIndex = 2;
            buttonKaydet.Text = "Kaydet";
            buttonKaydet.UseVisualStyleBackColor = true;
            buttonKaydet.Click += buttonKaydet_Click;
            // 
            // buttonYukle
            // 
            buttonYukle.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonYukle.Location = new Point(968, 441);
            buttonYukle.Margin = new Padding(4, 3, 4, 3);
            buttonYukle.Name = "buttonYukle";
            buttonYukle.Size = new Size(119, 30);
            buttonYukle.TabIndex = 3;
            buttonYukle.Text = "Yükle";
            buttonYukle.UseVisualStyleBackColor = true;
            buttonYukle.Click += buttonYukle_Click;
            // 
            // buttonTemizle
            // 
            buttonTemizle.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTemizle.Location = new Point(69, 441);
            buttonTemizle.Margin = new Padding(4, 3, 4, 3);
            buttonTemizle.Name = "buttonTemizle";
            buttonTemizle.Size = new Size(119, 30);
            buttonTemizle.TabIndex = 4;
            buttonTemizle.Text = "Temizle";
            buttonTemizle.UseVisualStyleBackColor = true;
            buttonTemizle.Click += buttonTemizle_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = SystemColors.Control;
            lblError.ForeColor = SystemColors.ActiveCaptionText;
            lblError.Location = new Point(308, 287);
            lblError.Name = "lblError";
            lblError.Size = new Size(110, 21);
            lblError.TabIndex = 5;
            lblError.Text = "Hata Oranı:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.yapay_sinir_aglari;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1100, 495);
            Controls.Add(lblError);
            Controls.Add(buttonTemizle);
            Controls.Add(buttonYukle);
            Controls.Add(buttonKaydet);
            Controls.Add(buttonTest);
            Controls.Add(buttonEgit);
            Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEgit;
        private Button buttonTest;
        private Button buttonKaydet;
        private Button buttonYukle;
        private Button buttonTemizle;
        private Label lblError;
    }
}