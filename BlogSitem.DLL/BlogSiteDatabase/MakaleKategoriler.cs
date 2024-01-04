using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class MakaleKategoriler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategoriID { get; set; }

        [Required, StringLength(100)]
        public string KategoriAdi { get; set; }

        public string Aciklama { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        public virtual List<Makaleler> MakaleID { get; set; }

    }
}
