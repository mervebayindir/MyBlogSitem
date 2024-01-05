using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Controllers
{
    public class KullaniciController : Controller
    {
        MerveBlogSiteDB _db;
        KullaniciRepository _kullaniciRepository;
        // GET: Kullanici
        public ActionResult GirisIndex(int? id = null)
        {
            if (id != null)
            {
                TempData["makaleId"] = id;
            }
            return View();
        }

        public ActionResult GirisIndex(string kullaniciAdi, string sifre)
        {
            var kullaniciGiris = _kullaniciRepository.Giris(kullaniciAdi, sifre);

            if (kullaniciAdi != null)
            {
                Session.Add("userName", kullaniciAdi); 
                Session.Add("userID", kullaniciGiris.KullaniciID);

                string kullaniciAdiSoyadi = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;
                TempData["userAdiSoyadi"] = kullaniciAdiSoyadi;

                if ((int)TempData["makaleID"] != 0)
                {
                    return RedirectToAction("MakaleDetayIndex", "Makaleler", new { id = TempData["makaleID"] });
                }

                return RedirectToAction("MakaleIndex", "Makaleler");
            }
            return View();
        }
    }
}