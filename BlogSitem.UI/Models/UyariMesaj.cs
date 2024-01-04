using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitem.UI.Models
{
    public class UyariMesaj
    {
        public string Basarili(string mesaj)
        {
            return @"<div class='alert alert-success' style='max-width:300px' role='alert'> " + mesaj + "</div>";
        }

        public string Hatali(string mesaj)
        {
            return @"<div class='alert alert-danger' style='max-width:300px' role='alert'> " + mesaj + "</div>";
        }
    }
}