using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Yetkiler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YetkiID { get; set; }

        [Required, StringLength(200)]
        public string YetkiAdi { get; set; }

        public virtual List<Kullanicilar> Kullanici { get; set; }

    }
}
