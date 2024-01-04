using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Yorumlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumID { get; set; }

        [Required]
        public string Yorum { get; set; }

        [Required]
        public DateTime YorumTarihi { get; set; }

        [Required]
        public int YorumUstID { get; set; }

        public virtual Kullanicilar Kullanici { get; set; }
        public virtual Makaleler Makale { get; set; }

    }
}
