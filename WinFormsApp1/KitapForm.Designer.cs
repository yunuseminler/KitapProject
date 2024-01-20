namespace WinFormsApp1
{
    partial class KitapForm
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
            kitapList = new ListBox();
            groupBox1 = new GroupBox();
            duzenle_Button = new Button();
            fiyatNumeric = new NumericUpDown();
            yeniKitapButton = new Button();
            stokAdiText = new TextBox();
            stokKoduText = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fiyatNumeric).BeginInit();
            SuspendLayout();
            // 
            // kitapList
            // 
            kitapList.FormattingEnabled = true;
            kitapList.ItemHeight = 15;
            kitapList.Location = new Point(25, 29);
            kitapList.Name = "kitapList";
            kitapList.Size = new Size(119, 334);
            kitapList.TabIndex = 0;
            kitapList.SelectedIndexChanged += kitapList_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(duzenle_Button);
            groupBox1.Controls.Add(fiyatNumeric);
            groupBox1.Controls.Add(yeniKitapButton);
            groupBox1.Controls.Add(stokAdiText);
            groupBox1.Controls.Add(stokKoduText);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(164, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(214, 334);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stok Kart Bilgileri";
            // 
            // duzenle_Button
            // 
            duzenle_Button.Location = new Point(35, 223);
            duzenle_Button.Name = "duzenle_Button";
            duzenle_Button.Size = new Size(122, 29);
            duzenle_Button.TabIndex = 8;
            duzenle_Button.Text = "Düzenle";
            duzenle_Button.UseVisualStyleBackColor = true;
            duzenle_Button.Click += duzenle_Button_Click;
            // 
            // fiyatNumeric
            // 
            fiyatNumeric.Location = new Point(18, 180);
            fiyatNumeric.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            fiyatNumeric.Name = "fiyatNumeric";
            fiyatNumeric.Size = new Size(167, 23);
            fiyatNumeric.TabIndex = 7;
            // 
            // yeniKitapButton
            // 
            yeniKitapButton.Location = new Point(35, 270);
            yeniKitapButton.Name = "yeniKitapButton";
            yeniKitapButton.Size = new Size(122, 31);
            yeniKitapButton.TabIndex = 6;
            yeniKitapButton.Text = "Yeni Kitap Oluştur";
            yeniKitapButton.UseVisualStyleBackColor = true;
            yeniKitapButton.Click += yeniKitapButton_Click;
            // 
            // stokAdiText
            // 
            stokAdiText.Location = new Point(18, 124);
            stokAdiText.Name = "stokAdiText";
            stokAdiText.Size = new Size(167, 23);
            stokAdiText.TabIndex = 5;
            // 
            // stokKoduText
            // 
            stokKoduText.Location = new Point(18, 61);
            stokKoduText.Name = "stokKoduText";
            stokKoduText.Size = new Size(167, 23);
            stokKoduText.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 162);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Birim Fiyat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 106);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Stok Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 43);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Stok Kodu";
            // 
            // KitapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 450);
            Controls.Add(groupBox1);
            Controls.Add(kitapList);
            Name = "KitapForm";
            Text = "FrmStokKart";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fiyatNumeric).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox kitapList;
        private GroupBox groupBox1;
        private Button yeniKitapButton;
        private TextBox stokAdiText;
        private TextBox stokKoduText;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown fiyatNumeric;
        private Button duzenle_Button;
    }
}