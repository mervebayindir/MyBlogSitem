using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Controllers
{
    public class MakaleController : Controller
    {
        MerveBlogSiteDB _db;
        KategoriRepository _kategoriRepository;
        MakaleRepository _makaleRepository;

        public MakaleController()
        {
            _db = new MerveBlogSiteDB();
            _kategoriRepository = new KategoriRepository(_db);
            _makaleRepository = new MakaleRepository(_db);
        }

        // GET: Makale
        public ActionResult MakaleIndex()
        {
            //ViewBag.mesaj = _kategoriRepository.MakaleSayisi(kategoriID);
            TempData["kategoriList"] = _kategoriRepository.GetAll();
            TempData["makaleList"] = _makaleRepository.Sp_MakaleListesi(true);
            return View();
        }

        public ActionResult MakaleDetayIndex(int id = 3)
        {
            var makaleGetir = _makaleRepository.Sp_MakaleListesi(true).Where(k => k.MakaleID == id).FirstOrDefault();
            TempData["makaleGetir"] = makaleGetir;
            TempData["kategoriList"] = _kategoriRepository.GetAll();
            return View(makaleGetir);
        }

        


    }
}