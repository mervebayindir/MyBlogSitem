using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Yazarlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YazarID { get; set; }

        [Required]
        public string Email { get; set; }
        public string KisacaHakkinda { get; set; }
        public string YasadigiUlke { get; set; }
        public string YasadigiSehir { get; set; }
        public string CalistigiFirma { get; set; }

        public virtual Resimler Resim { get; set; }
        public virtual Kullanicilar Kullanici { get; set; }
        public virtual List<Makaleler> Makaleler { get; set; }
    }
}
