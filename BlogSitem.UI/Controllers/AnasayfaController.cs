using BlogSitem.BLL.FakeDatalar;
using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Controllers
{
    public class AnasayfaController : Controller
    {
        MerveBlogSiteDB _db;
        KategoriRepository _kategoriRepository;
        public AnasayfaController()
        {
            _db = new MerveBlogSiteDB();
            _kategoriRepository = new KategoriRepository(_db);
        }
        // GET: Anasayfa
        public ActionResult AnasayfaIndex()
        {
            ViewBag.kategoriList = _kategoriRepository.GetAll();
            //KullanicilarFakeData kullanicilarFakeData = new KullanicilarFakeData();
            //kullanicilarFakeData.EkleKullaniciFakeData();

            //YazarFakeData yazarFakeData = new YazarFakeData();
            //yazarFakeData.EkleYazarFakeData();

            //MakaleFakeData makaleFakeData = new MakaleFakeData();
            //makaleFakeData.EkleMakaleFakeData();

            return View();
        }
    }
}