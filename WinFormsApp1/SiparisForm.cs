using StokProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SiparisForm : Form
    {
        public Siparis siparis;
        private MainForm mainForm;
        private List<Kitap> kitaplar = new List<Kitap>();
        private string fileName = "kitaplarKayit.txt";
        private int siraIndex = 0;

        //Mainforma sipariş gönderebilmek için kendisini parametre olarak alıyoruz.
        public SiparisForm(Form callingForm, Siparis siparis)
        {
            mainForm = callingForm as MainForm;
            InitializeComponent();
            this.siparis = siparis;
        }

        //Form Yüklenirken kitaplar dosyadan okunuyor.
        //Daha sonra var ise sipariş bilgileri yükleniyor.
        private void Form3_Load(object sender, EventArgs e)
        {
            siparisDataGrid.Rows.Clear();
            kitaplariYukle();
            if (siparis.EvrakNo != null)
            {
                verileriYukle();
            }
        }
        //Kitapları tek tek dosyadan okuyup Kitaplar listemize ekliyor.
        private void kitaplariYukle()
        {
            foreach (var line in File.ReadLines(fileName))
            {
                if (line != null)
                {
                    Kitap newKitap = new Kitap();
                    string[] parsed = line.Split(",");
                    newKitap.StokAdi = parsed[0];
                    newKitap.StokKodu = parsed[1];
                    newKitap.BirimFiyat = Convert.ToDouble(parsed[2]);
                    kitaplar.Add(newKitap);
                }
            }
        }

        //Siparis detaylarını forma yüklüyor.
        private void verileriYukle()
        {
            evrakNoText.Text = siparis.EvrakNo;
            datetimePicker.Value = siparis.SiparisTarihi;
            toplamFiyat_Label.Text = siparis.ToplamFiyat.ToString();
            for (int i = 0; i < siparis.Elemanlar.Count; i++)
            {

                int index = kitaplar.FindIndex(x => x.StokKodu == siparis.Elemanlar[i].StokKodu);
                if (index >= 0)
                {
                    siparisDataGrid.Rows.Add(
                        siraIndex,
                        kitaplar[index].StokAdi,
                        kitaplar[index].StokKodu,
                        kitaplar[index].BirimFiyat,
                        siparis.Elemanlar[i].Miktar,
                        (siparis.Elemanlar[i].Miktar * kitaplar[index].BirimFiyat));
                }
            }
        }

        //Satir eklendiğinde sira numarasını ekliyor.
        private void siparisDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            siraIndex++;
            siparisDataGrid.Rows[siparisDataGrid.Rows.Count - 1].Cells[0].Value = siraIndex;
        }


        //Yeni Satır Ekliyor
        private void yeniSatirButton_Click(object sender, EventArgs e)
        {
            siparisDataGrid.Rows.Add();
        }

        //Stok kodu veya Miktar değeri girildiğinde değerleri otomatik olarak ayarlayan fonksiyon
        private void degerleriAyarla()
        {
            int value = -1;
            if (siparisDataGrid.CurrentCell != null)
            {
                if (siparisDataGrid.CurrentCell.ColumnIndex == 2)
                {
                    try
                    {
                        value = Convert.ToInt32(siparisDataGrid.CurrentCell.EditedFormattedValue);
                    }
                    catch { }
                    if (0 <= value && value < kitaplar.Count)
                    {
                        siparisDataGrid.CurrentRow.Cells[1].Value = kitaplar[value].StokAdi;
                        siparisDataGrid.CurrentRow.Cells[2].Value = kitaplar[value].StokKodu;
                        siparisDataGrid.CurrentRow.Cells[3].Value = kitaplar[value].BirimFiyat;
                    }
                }

                else if (siparisDataGrid.CurrentCell.ColumnIndex == 4)
                {

                    try
                    {
                        value = Convert.ToInt32(siparisDataGrid.CurrentCell.EditedFormattedValue);
                    }
                    catch { }
                    if (value >= 0)
                    {
                        siparisDataGrid.CurrentRow.Cells[5].Value = value * (Convert.ToDouble(siparisDataGrid.CurrentRow.Cells[3].Value));
                        double toplam = 0;
                        for (int i = 0; i < siparisDataGrid.Rows.Count; i++)
                        {
                            toplam += Convert.ToDouble(siparisDataGrid.Rows[i].Cells[5].Value);
                        }
                        toplamFiyat_Label.Text = toplam.ToString();
                    }

                }
            }
        }

        //DatagridView'de tıklandığında Stok kodu veya Miktar değerine göre ayarlama yapar.
        private void siparisDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            degerleriAyarla();

        }
        
        //DatagridView'de Tab tuşu ile seçim değiştiğinde Stok kodu veya Miktar değerine göre ayarlama yapar.
        private void siparisDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            degerleriAyarla();
        }
        //Siparişi kaydeden fonksiyon. Oluşturulan Sipariş objesini mainForma gönderir. Orada Siparişler listesine eklenir.
        private void kaydetButton_Click(object sender, EventArgs e)
        {
            Siparis siparis = new Siparis();

            siparis.EvrakNo = evrakNoText.Text.ToString();
            siparis.SiparisTarihi = datetimePicker.Value;
            siparis.ToplamFiyat = Convert.ToDouble(toplamFiyat_Label.Text);


            foreach (DataGridViewRow row in siparisDataGrid.Rows)
            {
                SiparisEleman eleman = new SiparisEleman();
                eleman.StokKodu = row.Cells[2].Value.ToString();
                eleman.Miktar = Convert.ToInt32(row.Cells[4].Value);
                siparis.Elemanlar.Add(eleman);
            }


            mainForm.siparisEkle(siparis);
            this.Close();
        }
    }
}
