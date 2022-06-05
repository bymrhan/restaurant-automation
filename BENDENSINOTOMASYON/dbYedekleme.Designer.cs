namespace BENDENSINOTOMASYON
{
    partial class dbYedekleme
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btndizinguncelle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnyedekle = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.combodbyedek = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.combodbyedek);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.btndizinguncelle);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.btnyedekle);
            this.groupBox5.Controls.Add(this.pictureBox6);
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(658, 234);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Database İşlemleri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Varsayılan Yedek Dizininiz :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 22;
            // 
            // btndizinguncelle
            // 
            this.btndizinguncelle.BackColor = System.Drawing.Color.Black;
            this.btndizinguncelle.Location = new System.Drawing.Point(159, 170);
            this.btndizinguncelle.Name = "btndizinguncelle";
            this.btndizinguncelle.Size = new System.Drawing.Size(125, 34);
            this.btndizinguncelle.TabIndex = 20;
            this.btndizinguncelle.Text = "Dizin Güncelle";
            this.btndizinguncelle.UseVisualStyleBackColor = false;
            this.btndizinguncelle.Click += new System.EventHandler(this.btndizinguncelle_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(377, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(256, 34);
            this.button3.TabIndex = 20;
            this.button3.Text = "Yedek Geri Yükle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnyedekle
            // 
            this.btnyedekle.BackColor = System.Drawing.Color.DarkRed;
            this.btnyedekle.Location = new System.Drawing.Point(28, 170);
            this.btnyedekle.Name = "btnyedekle";
            this.btnyedekle.Size = new System.Drawing.Size(125, 34);
            this.btnyedekle.TabIndex = 20;
            this.btnyedekle.Text = "Şimdi Yedekle";
            this.btnyedekle.UseVisualStyleBackColor = false;
            this.btnyedekle.Click += new System.EventHandler(this.btnyedekle_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::BENDENSINOTOMASYON.Properties.Resources.backup;
            this.pictureBox6.Location = new System.Drawing.Point(109, 34);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(89, 67);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 19;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BENDENSINOTOMASYON.Properties.Resources.upload;
            this.pictureBox1.Location = new System.Drawing.Point(465, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(178, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Son Başarılı Yedekleme Zamanı  : Henuz yedekleme yapmadınız.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // combodbyedek
            // 
            this.combodbyedek.FormattingEnabled = true;
            this.combodbyedek.Location = new System.Drawing.Point(377, 137);
            this.combodbyedek.Name = "combodbyedek";
            this.combodbyedek.Size = new System.Drawing.Size(256, 21);
            this.combodbyedek.TabIndex = 24;
            this.combodbyedek.SelectedIndexChanged += new System.EventHandler(this.combodbyedek_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Alınan Yedekler";
            // 
            // dbYedekleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(685, 304);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Name = "dbYedekleme";
            this.Text = "Database Ayarları";
            this.Load += new System.EventHandler(this.dbYedekleme_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndizinguncelle;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnyedekle;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox combodbyedek;
        private System.Windows.Forms.Label label3;
    }
}