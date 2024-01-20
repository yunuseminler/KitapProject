namespace WinFormsApp1
{
    partial class SiparisForm
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
            groupBox1 = new GroupBox();
            yeniSatirButton = new Button();
            siparisDataGrid = new DataGridView();
            sira = new DataGridViewTextBoxColumn();
            stokAdi = new DataGridViewTextBoxColumn();
            stokKodu = new DataGridViewTextBoxColumn();
            birimFiyat = new DataGridViewTextBoxColumn();
            miktar = new DataGridViewTextBoxColumn();
            araToplam = new DataGridViewTextBoxColumn();
            datetimePicker = new DateTimePicker();
            evrakNoText = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            kaydetButton = new Button();
            toplamFiyat_Label = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)siparisDataGrid).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(yeniSatirButton);
            groupBox1.Controls.Add(siparisDataGrid);
            groupBox1.Controls.Add(datetimePicker);
            groupBox1.Controls.Add(evrakNoText);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(674, 289);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sipariş Temel Bilgileri";
            // 
            // yeniSatirButton
            // 
            yeniSatirButton.Location = new Point(493, 83);
            yeniSatirButton.Name = "yeniSatirButton";
            yeniSatirButton.Size = new Size(145, 23);
            yeniSatirButton.TabIndex = 6;
            yeniSatirButton.Text = "Yeni Satır Ekle";
            yeniSatirButton.UseVisualStyleBackColor = true;
            yeniSatirButton.Click += yeniSatirButton_Click;
            // 
            // siparisDataGrid
            // 
            siparisDataGrid.AllowUserToAddRows = false;
            siparisDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            siparisDataGrid.Columns.AddRange(new DataGridViewColumn[] { sira, stokAdi, stokKodu, birimFiyat, miktar, araToplam });
            siparisDataGrid.Location = new Point(20, 125);
            siparisDataGrid.Name = "siparisDataGrid";
            siparisDataGrid.RowTemplate.Height = 25;
            siparisDataGrid.Size = new Size(643, 150);
            siparisDataGrid.TabIndex = 5;
            siparisDataGrid.RowsAdded += siparisDataGrid_RowsAdded;
            siparisDataGrid.SelectionChanged += siparisDataGrid_SelectionChanged;
            siparisDataGrid.MouseClick += siparisDataGrid_MouseClick;
            // 
            // sira
            // 
            sira.HeaderText = "Sıra";
            sira.Name = "sira";
            sira.ReadOnly = true;
            // 
            // stokAdi
            // 
            stokAdi.HeaderText = "Stok Adı";
            stokAdi.Name = "stokAdi";
            stokAdi.ReadOnly = true;
            // 
            // stokKodu
            // 
            stokKodu.HeaderText = "Stok Kodu";
            stokKodu.Name = "stokKodu";
            // 
            // birimFiyat
            // 
            birimFiyat.HeaderText = "Birim Fiyat";
            birimFiyat.Name = "birimFiyat";
            birimFiyat.ReadOnly = true;
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            // 
            // araToplam
            // 
            araToplam.HeaderText = "Ara Toplam";
            araToplam.Name = "araToplam";
            araToplam.ReadOnly = true;
            // 
            // datetimePicker
            // 
            datetimePicker.Location = new Point(105, 64);
            datetimePicker.Name = "datetimePicker";
            datetimePicker.Size = new Size(200, 23);
            datetimePicker.TabIndex = 3;
            // 
            // evrakNoText
            // 
            evrakNoText.Location = new Point(105, 31);
            evrakNoText.Name = "evrakNoText";
            evrakNoText.Size = new Size(200, 23);
            evrakNoText.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Tarih : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 34);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Evrak No :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(kaydetButton);
            groupBox2.Controls.Add(toplamFiyat_Label);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 320);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(674, 127);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sirapiş Toplam Bilgileri";
            // 
            // kaydetButton
            // 
            kaydetButton.Location = new Point(348, 60);
            kaydetButton.Name = "kaydetButton";
            kaydetButton.Size = new Size(304, 40);
            kaydetButton.TabIndex = 2;
            kaydetButton.Text = "Sipariş Bilgilerimi Kaydet";
            kaydetButton.UseVisualStyleBackColor = true;
            kaydetButton.Click += kaydetButton_Click;
            // 
            // toplamFiyat_Label
            // 
            toplamFiyat_Label.AutoSize = true;
            toplamFiyat_Label.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            toplamFiyat_Label.ForeColor = SystemColors.MenuHighlight;
            toplamFiyat_Label.Location = new Point(118, 33);
            toplamFiyat_Label.Name = "toplamFiyat_Label";
            toplamFiyat_Label.Size = new Size(63, 46);
            toplamFiyat_Label.TabIndex = 1;
            toplamFiyat_Label.Text = "0,0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 47);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 0;
            label3.Text = "Toplam Fiyat :";
            // 
            // SiparisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SiparisForm";
            Text = "Form3";
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)siparisDataGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView siparisDataGrid;
        private DateTimePicker datetimePicker;
        private TextBox evrakNoText;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label toplamFiyat_Label;
        private Label label3;
        private Button kaydetButton;
        private DataGridViewTextBoxColumn sira;
        private DataGridViewTextBoxColumn stokAdi;
        private DataGridViewTextBoxColumn stokKodu;
        private DataGridViewTextBoxColumn birimFiyat;
        private DataGridViewTextBoxColumn miktar;
        private DataGridViewTextBoxColumn araToplam;
        private Button yeniSatirButton;
    }
}