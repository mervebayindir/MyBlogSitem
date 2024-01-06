using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.UI.Areas.AdminManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Controllers
{
    public class KullaniciController : BaseController
    {
        MerveBlogSiteDB _db;
        KullaniciRepository _kullaniciRepository;

        public KullaniciController()
        {
            _db = new MerveBlogSiteDB();
            _kullaniciRepository = new KullaniciRepository(_db);
        }

        // GET: Kullanici
        public ActionResult GirisIndex(int? id = null)
        {
            if (id != null)
            {
                TempData["makaleId"] = id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult GirisIndex(string kullaniciAdi, string sifre)
        {
            var kullaniciGiris = _kullaniciRepository.Giris(kullaniciAdi, sifre);

            if (kullaniciGiris != null)
            {
                string adSoyad = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;

                string yetki = kullaniciGiris.Yetki.YetkiID.ToString();
                Session.Add("userName", adSoyad);
                Session.Add("userYetki", yetki);
                string kullaniciAdSoyad = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;
                TempData["userAdiSoyadi"] = kullaniciAdSoyad;
                TempData["kullaniciID"] = kullaniciGiris.KullaniciID;

                if (TempData["makaleID"] != null)
                {
                    return RedirectToAction("MakaleDetayIndex", "Makale", new { id = TempData["makaleID"] });
                }
                return RedirectToAction("AnasayfaIndex", "Anasayfa");
            }
            ViewBag.hataMesaji = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        public ActionResult KullaniciCikis()
        {
            Session.Clear();
            return RedirectToAction("GirisIndex");
        }
    }
}