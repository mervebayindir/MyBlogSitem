using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Resimler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResimID { get; set; }

        public string BuyukResimYolu { get; set; }
        public string KucukResimYolu { get; set; }

        [Required, StringLength(250)]
        public string Baslik { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        public virtual Makaleler Makale { get; set; }

    }
}
