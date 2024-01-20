using StokProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace WinFormsApp1
{

    public partial class KitapForm : Form
    {
        private List<Kitap> kitaplar = new List<Kitap>();
        private Kitap selectedKitap;
        private string? name;
        private bool isClick = false;
        private string fileName = "kitaplarKayit.txt";
        public KitapForm()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            kitaplarıYukle();
            listeYenile();

        }

        //Kitapları txt dosyasından okuyup Kitaplar Listesine ekler.
        private void kitaplarıYukle()
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

        //Yeni kitap objesi oluşturulup Kitaplar listesine ekler ve listbox değerlerini günceller.
        private void yeniKitapButton_Click(object sender, EventArgs e)
        {
            Kitap newKitap = new Kitap();
            newKitap.StokKodu = stokKoduText.Text;
            newKitap.StokAdi = stokAdiText.Text;
            newKitap.BirimFiyat = Convert.ToDouble(fiyatNumeric.Value);
            kitaplar.Add(newKitap);
            listeYenile();
        }

        //Listbox değerlerini günceller.
        private void listeYenile()
        {
            kitapList.Items.Clear();
            foreach (var kitap in kitaplar)
            {
                kitapList.Items.Add(kitap.StokAdi);
            }
            stokKoduText.Text = "";
            stokAdiText.Text = "";
            fiyatNumeric.Value = 0;

        }

        //Listboxta tıklanılan değere sahip kitap özellikleri textboxlara eklenir.
        private void kitapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = kitapList.Text;
            selectedKitap = kitaplar.Find(x => x.StokAdi == selected);
            if (selectedKitap != null)
            {
                stokAdiText.Text = selectedKitap.StokAdi;
                name = selectedKitap.StokAdi;
                stokKoduText.Text = selectedKitap.StokKodu;
                fiyatNumeric.Value = Convert.ToDecimal(selectedKitap.BirimFiyat);
                isClick = true;
            }
        }

        //Eğer düzenleme yapıldıysa değerleri değiştirir.
        private void duzenle_Button_Click(object sender, EventArgs e)
        {
            if (isClick)
            {
                Kitap newKitap = new Kitap();
                newKitap.StokKodu = stokKoduText.Text;
                newKitap.StokAdi = stokAdiText.Text;
                newKitap.BirimFiyat = Convert.ToDouble(fiyatNumeric.Value);

                int index = kitaplar.FindIndex(x => x.StokAdi == name);
                if (index >= 0)
                {
                    kitaplar[index] = newKitap;
                }
                isClick = false;
                listeYenile();
            }
        }

        //Form Kapanırken Kitaplar listesini belirli bir formatta text dosyasına yazar.
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (Stream s = File.Open(fileName, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(s))
            {
                foreach (Kitap k in kitaplar)
                {
                    sw.WriteLine(k.StokAdi + "," + k.StokKodu + "," + k.BirimFiyat);
                }
            }
        }
    }
}
