using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Areas.AdminManager.Controllers
{
    public class BaseController : Controller
    {
        MerveBlogSiteDB _db;
        KullaniciRepository _kullaniciRepository;
        KategoriRepository _kategoriRepository;
        public string KullaniciSoyadi;
        public string _kullaniciBilgileri;

        public BaseController()
        {
            _db = new MerveBlogSiteDB();
            _kullaniciRepository = new KullaniciRepository(_db);
            _kategoriRepository = new KategoriRepository(_db);
            ViewBag.kategoriList = _kategoriRepository.GetAll();
            if (TempData["userAdiSoyadi"] != null)
            {
                _kullaniciBilgileri = TempData["userAdiSoyadi"].ToString();
                TempData["userAdiSoyadi"] = TempData["adSoyad"];
            }

        }

        // GET: AdminManager/Base
        public ActionResult Index()
        {
            TempData[""] = null;
            return View();
        }

        public Kullanicilar KullaniciGiris(string kullaniciAdi, string sifre)
        {
            var kullaniciVarMi = _kullaniciRepository.Giris(kullaniciAdi, sifre);
            if (kullaniciVarMi == null)
            {
                return null;
            }
            _kullaniciBilgileri = kullaniciVarMi.Adi + " " + kullaniciVarMi.Soyadi;
            TempData["adSoyad"] = _kullaniciBilgileri;

            kullaniciAdi = kullaniciVarMi.Adi;

            return kullaniciVarMi;
        }

        public void KullaniciBilgileri(out string kullaniciAdiSoyadi)
        {
            if (TempData["adSoyad"] != null)
            {
                kullaniciAdiSoyadi = TempData["adSoyad"].ToString();
            }
            kullaniciAdiSoyadi = string.Empty;

        }

    }
}