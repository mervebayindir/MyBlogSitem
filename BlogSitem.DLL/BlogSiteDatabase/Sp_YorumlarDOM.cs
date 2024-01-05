using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Sp_YorumlarDOM
    {
        public int YorumID { get; set; }
        public int KullaniciID { get; set; }
        public int Makale_MakaleID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool YazarMi { get; set; }
        public bool AktifMi { get; set; }
        public int Yetki_YetkiID { get; set; }
        public string Yorum { get; set; }
        public int YorumUstID { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
