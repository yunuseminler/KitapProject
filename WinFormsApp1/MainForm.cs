using StokProject.Entities;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private string fileName = "siparisKayit.txt"; //Siparis Dosyas�n�n dosya yolu
        private List<Siparis> Siparisler; //Sistemde kullan�lacak sipari�ler listesi
        public MainForm()
        {
            InitializeComponent();

        }

        //Form y�klenirken siparis dosyas�ndan veriler okunuyor ve datagride ekleniyor.
        private void Form1_Load(object sender, EventArgs e)
        {
            siparisDosyaOku();
            siparisDataGuncelle();
        }

        //Stok Kart Liste butonuna bas�nca ilgili form a��l�yor
        private void kitapStokForm_Button_Click(object sender, EventArgs e)
        {
            var stokForm = new KitapForm();
            stokForm.Show();

        }

        //Siparis butonuna bas�nca ilgili form a��l�yor
        private void siparisForm_Button_Click(object sender, EventArgs e)
        {
            var siparisForm = new SiparisForm(this, new Siparis());
            siparisForm.Show();
        }
        

        //Siparisler listesinde de�i�iklik yap�l�nca DatagridView g�ncellenmesi i�in bu fonksiyon �a�r�l�yor.
        //Siparisler listesinin elemanlar�n� s�ras�yla datagridView'e ekleme yap�yor.
        private void siparisDataGuncelle()
        {

            siparisDatagrid.Rows.Clear();
            foreach (Siparis siparis in Siparisler)
            {
                siparisDatagrid.Rows.Add(siparis.EvrakNo, siparis.SiparisTarihi, siparis.ToplamFiyat);
            }

            //En sonda tarihe g�re s�ral�yor.
            siparisDatagrid.Sort(siparisDatagrid.Columns["siparisTarihi"],
            System.ComponentModel.ListSortDirection.Descending);
            
        }


        //Siparis formundan gelen siparis nesnesini i�leyen fonksiyon.
        //Evrak numaras� daha �nceki sipari�lerde var ise eski de�eri de�i�tiriyor.
        //Yok ise yeni bir sipari� olarak ekliyor.
        //En sonda DaragridView de�erleri g�ncelleniyor.
        public void siparisEkle(Siparis siparis)
        {
            int index = Siparisler.FindIndex(x => x.EvrakNo == siparis.EvrakNo);
            if (index >= 0)
            {
                Siparisler[index] = siparis;
            }
            else
            {
                Siparisler.Add(siparis);
            }
            siparisDataGuncelle();
        }
        //Dosyaya yaz�lan siparisler de�erlerini kendi yazd���m parser ile okuyup Siparisler listesine atama yap�yor.
        private void siparisDosyaOku()
        {
            siparisDatagrid.Rows.Clear();
            Siparisler = new List<Siparis>();
            foreach (var line in File.ReadLines(fileName))
            {
                if (line != null)
                {
                    string[] parsed = line.Split(",");
                    Siparis tempSiparis = new Siparis();
                    tempSiparis.EvrakNo = parsed[0];
                    tempSiparis.SiparisTarihi = Convert.ToDateTime(parsed[1]);
                    tempSiparis.ToplamFiyat = Convert.ToDouble(parsed[2]);
                    string[] elemanlar = parsed[3].Split("-");
                    for (int i = 0; i < elemanlar.Length - 1; i++)
                    {
                        SiparisEleman eleman = new SiparisEleman();
                        string[] parsedElemanlar = elemanlar[i].Split("_");
                        eleman.StokKodu = parsedElemanlar[0];
                        eleman.Miktar = Convert.ToInt32(parsedElemanlar[1]);
                        tempSiparis.Elemanlar.Add(eleman);
                    }
                    Siparisler.Add(tempSiparis);
                }
            }
        }

        //Siparisler listesini belirli bir desen ile metin dosyas�na ay�r�yor.
        //Sipari� nesne elemanlar� , ile
        //Siparis elemanlar� - ile
        //Siparis elemanlar�n�n de�erleri ise _ ile ayr�l�yor.
        private void siparisDosyaYaz()
        {
            using (Stream s = File.Open(fileName, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(s))
            {
                foreach (Siparis siparis in Siparisler)
                {
                    sw.Write(siparis.EvrakNo + "," + siparis.SiparisTarihi + "," + siparis.ToplamFiyat + ",");
                    foreach (SiparisEleman eleman in siparis.Elemanlar)
                    {
                        sw.Write(eleman.StokKodu + "_" + eleman.Miktar + "-");
                    }
                    sw.WriteLine("");

                }

            }
        }
        
        //Sipari�lerden birine t�kland��� zaman ilgili Sipari� objesi buluyor ve sipari� formuna g�nderiliyor. 
        //Sipari� Formu gelen objenin de�erlerini formda g�steriyor.
        private void siparisDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string evrakNo = "";
            if (siparisDatagrid.CurrentCell != null)
            {
                evrakNo = (string)siparisDatagrid.CurrentRow.Cells[0].Value;
            }

            var siparis = Siparisler.Find(x => x.EvrakNo == evrakNo);
            if (siparis != null)
            {
                var siparisForm = new SiparisForm(this, siparis);
                siparisForm.Show();

            }
        }


        //Form Kapan�rken b�t�n sipari�leri dosyaya yaz�yor.
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            siparisDosyaYaz();
        }
    }
}