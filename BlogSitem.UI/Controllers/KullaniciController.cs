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
            //var kullaniciGiris = _kullaniciRepository.Giris(kullaniciAdi, sifre);

            if (kullaniciAdi != null)
            {
                Session.Add("userName", kullaniciAdi); //Session oluşturma
                Session.Add("userID", kullaniciGiris.KullanicilarID);
                //var login = Session["username"]; //Oluşturulan Session kullanma

                string kullaniciAdiSoyadi = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;
                TempData["userAdiSoyadi"] = kullaniciAdiSoyadi;

                if ((int)TempData["makaleID"] != 0)
                {
                    return RedirectToAction("MakaleDetayIndex", "Makaleler", new { id = TempData["makaleID"] });
                }
                else if ((int)TempData["makaleID"] == null)
                {
                    return RedirectToAction("AnasayfaIndex", "Anasayfa");

                }

                return RedirectToAction("MakaleIndex", "Makaleler");
            }
            return View();
        }
    }
}