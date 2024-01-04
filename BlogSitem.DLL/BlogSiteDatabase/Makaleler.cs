using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Makaleler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MakaleID { get; set; }

        [Required, StringLength(250)]
        public string Baslik { get; set; }

        [Required]
        public string MakaleIcerik { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        [Required]
        public int OnaylayanKullaniciID { get; set; }

        public virtual Yazarlar Yazar { get; set; }

        public virtual MakaleKategoriler MakaleKategoriID { get; set; }
        public virtual List<Resimler> Resimler { get; set; }
        public virtual List<Yorumlar> Yorumlar { get; set; }


    }
}
