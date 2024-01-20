using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokProject.Entities
{
    public class Siparis
    {
        public Siparis() {
            Elemanlar = new List<SiparisEleman>();
        }
        public string? EvrakNo { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public double ToplamFiyat { get; set; }
        public List<SiparisEleman>? Elemanlar { get; set; } 
    }
}
