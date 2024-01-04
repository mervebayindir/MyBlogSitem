using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KullaniciID { get; set; }

        [Required, StringLength(100)]
        public string Adi { get; set; }

        [Required, StringLength(100)]
        public string Soyadi { get; set; }

        [Required, StringLength(100)]
        public string KullaniciAdi { get; set; }

        [Required]
        public string KullaniciSifresi { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        public DateTime PasiflikTarihi { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        [Required]
        public bool YazarMi { get; set; }

        public virtual Yetkiler Yetki { get; set; }

        public virtual List<Yorumlar> Yorumlar { get; set; }



    }
}
