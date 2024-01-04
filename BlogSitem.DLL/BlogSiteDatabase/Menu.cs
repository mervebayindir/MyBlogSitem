using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class Menu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }

        [Required, StringLength(100)]
        public string MenuAdi { get; set; }

        [Required]
        public int MenuUstID { get; set; }

        public string Aciklama { get; set; }
        [Required]
        public bool AktifMi { get; set; }


    }
}
