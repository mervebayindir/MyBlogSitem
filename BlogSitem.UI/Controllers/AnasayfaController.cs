using BlogSitem.BLL.FakeDatalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult AnasayfaIndex()
        {

            KullanicilarFakeData kullanicilarFakeData = new KullanicilarFakeData();
            kullanicilarFakeData.EkleKullaniciFakeData();

            YazarFakeData yazarFakeData = new YazarFakeData();
            yazarFakeData.EkleYazarFakeData();

            MakaleFakeData makaleFakeData = new MakaleFakeData();
            makaleFakeData.EkleMakaleFakeData();

            return View();
        }
    }
}