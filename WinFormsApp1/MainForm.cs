using StokProject.Entities;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private string fileName = "siparisKayit.txt"; //Siparis Dosyasýnýn dosya yolu
        private List<Siparis> Siparisler; //Sistemde kullanýlacak sipariþler listesi
        public MainForm()
        {
            InitializeComponent();

        }

        //Form yüklenirken siparis dosyasýndan veriler okunuyor ve datagride ekleniyor.
        private void Form1_Load(object sender, EventArgs e)
        {
            siparisDosyaOku();
            siparisDataGuncelle();
        }

        //Stok Kart Liste butonuna basýnca ilgili form açýlýyor
        private void kitapStokForm_Button_Click(object sender, EventArgs e)
        {
            var stokForm = new KitapForm();
            stokForm.Show();

        }

        //Siparis butonuna basýnca ilgili form açýlýyor
        private void siparisForm_Button_Click(object sender, EventArgs e)
        {
            var siparisForm = new SiparisForm(this, new Siparis());
            siparisForm.Show();
        }
        

        //Siparisler listesinde deðiþiklik yapýlýnca DatagridView güncellenmesi için bu fonksiyon çaðrýlýyor.
        //Siparisler listesinin elemanlarýný sýrasýyla datagridView'e ekleme yapýyor.
        private void siparisDataGuncelle()
        {

            siparisDatagrid.Rows.Clear();
            foreach (Siparis siparis in Siparisler)
            {
                siparisDatagrid.Rows.Add(siparis.EvrakNo, siparis.SiparisTarihi, siparis.ToplamFiyat);
            }

            //En sonda tarihe göre sýralýyor.
            siparisDatagrid.Sort(siparisDatagrid.Columns["siparisTarihi"],
            System.ComponentModel.ListSortDirection.Descending);
            
        }


        //Siparis formundan gelen siparis nesnesini iþleyen fonksiyon.
        //Evrak numarasý daha önceki sipariþlerde var ise eski deðeri deðiþtiriyor.
        //Yok ise yeni bir sipariþ olarak ekliyor.
        //En sonda DaragridView deðerleri güncelleniyor.
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
        //Dosyaya yazýlan siparisler deðerlerini kendi yazdýðým parser ile okuyup Siparisler listesine atama yapýyor.
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

        //Siparisler listesini belirli bir desen ile metin dosyasýna ayýrýyor.
        //Sipariþ nesne elemanlarý , ile
        //Siparis elemanlarý - ile
        //Siparis elemanlarýnýn deðerleri ise _ ile ayrýlýyor.
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
        
        //Sipariþlerden birine týklandýðý zaman ilgili Sipariþ objesi buluyor ve sipariþ formuna gönderiliyor. 
        //Sipariþ Formu gelen objenin deðerlerini formda gösteriyor.
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


        //Form Kapanýrken bütün sipariþleri dosyaya yazýyor.
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            siparisDosyaYaz();
        }
    }
}