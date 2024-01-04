using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Sp_MakaleListesiDOM
    {
        public int MakaleID { get; set; }
        public string KategoriAdi { get; set; }
        public string Baslik { get; set; }
        public string MakaleIcerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string OnaylayanAdSoyad { get; set; }
        public string YazarAdSoyad { get; set; }
    }
}
