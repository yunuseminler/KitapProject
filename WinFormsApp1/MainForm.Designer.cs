namespace WinFormsApp1
{
    partial class MainForm
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
            siparisForm_Button = new Button();
            kitapStokForm_Button = new Button();
            groupBox1 = new GroupBox();
            siparisDatagrid = new DataGridView();
            evrakNo = new DataGridViewTextBoxColumn();
            siparisTarihi = new DataGridViewTextBoxColumn();
            toplamFiyat = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)siparisDatagrid).BeginInit();
            SuspendLayout();
            // 
            // siparisForm_Button
            // 
            siparisForm_Button.BackColor = Color.LightCoral;
            siparisForm_Button.Location = new Point(6, 12);
            siparisForm_Button.Name = "siparisForm_Button";
            siparisForm_Button.Size = new Size(103, 23);
            siparisForm_Button.TabIndex = 0;
            siparisForm_Button.Text = "Yeni Sipariş Ekle";
            siparisForm_Button.UseVisualStyleBackColor = false;
            siparisForm_Button.Click += siparisForm_Button_Click;
            // 
            // kitapStokForm_Button
            // 
            kitapStokForm_Button.BackColor = Color.Gold;
            kitapStokForm_Button.Location = new Point(276, 12);
            kitapStokForm_Button.Name = "kitapStokForm_Button";
            kitapStokForm_Button.Size = new Size(91, 23);
            kitapStokForm_Button.TabIndex = 1;
            kitapStokForm_Button.Text = "Stok Kart Liste";
            kitapStokForm_Button.UseVisualStyleBackColor = false;
            kitapStokForm_Button.Click += kitapStokForm_Button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(kitapStokForm_Button);
            groupBox1.Controls.Add(siparisForm_Button);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(373, 46);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // siparisDatagrid
            // 
            siparisDatagrid.AllowUserToAddRows = false;
            siparisDatagrid.AllowUserToDeleteRows = false;
            siparisDatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            siparisDatagrid.Columns.AddRange(new DataGridViewColumn[] { evrakNo, siparisTarihi, toplamFiyat });
            siparisDatagrid.Location = new Point(12, 76);
            siparisDatagrid.Name = "siparisDatagrid";
            siparisDatagrid.RowTemplate.Height = 25;
            siparisDatagrid.Size = new Size(373, 347);
            siparisDatagrid.TabIndex = 3;
            siparisDatagrid.CellClick += siparisDatagrid_CellClick;
            // 
            // evrakNo
            // 
            evrakNo.HeaderText = "Evrak No";
            evrakNo.Name = "evrakNo";
            evrakNo.ReadOnly = true;
            // 
            // siparisTarihi
            // 
            siparisTarihi.HeaderText = "Sipariş Tarihi";
            siparisTarihi.Name = "siparisTarihi";
            siparisTarihi.ReadOnly = true;
            siparisTarihi.Width = 135;
            // 
            // toplamFiyat
            // 
            toplamFiyat.HeaderText = "Toplam Fiyat";
            toplamFiyat.Name = "toplamFiyat";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 450);
            Controls.Add(siparisDatagrid);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)siparisDatagrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button siparisForm_Button;
        private Button kitapStokForm_Button;
        private GroupBox groupBox1;
        private DataGridView siparisDatagrid;
        private DataGridViewTextBoxColumn evrakNo;
        private DataGridViewTextBoxColumn siparisTarihi;
        private DataGridViewTextBoxColumn toplamFiyat;
    }
}