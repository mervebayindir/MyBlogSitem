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
    public class MakaleController : BaseController
    {
        MerveBlogSiteDB _db;
        KategoriRepository _kategoriRepository;
        MakaleRepository _makaleRepository;
        YorumRepository _yorumRepository;

        public MakaleController()
        {
            _db = new MerveBlogSiteDB();
            _kategoriRepository = new KategoriRepository(_db);
            _makaleRepository = new MakaleRepository(_db);
            _yorumRepository = new YorumRepository(_db);
        }

        // GET: Makale
        public ActionResult MakaleIndex()
        {
            //ViewBag.kategoriList = _kategoriRepository.GetAll();
            TempData["kategoriList"] = _kategoriRepository.GetAll();
            TempData["makaleList"] = _makaleRepository.Sp_MakaleListesi(true);
            return View();
        }

        public ActionResult MakaleDetayIndex(int id)
        {
            var makaleGetir = _makaleRepository.Sp_MakaleListesi(true).Where(k => k.MakaleID == id).FirstOrDefault();
            //ViewBag.kategoriList = _kategoriRepository.GetAll();
            TempData["makaleGetir"] = makaleGetir;
            TempData["kategoriList"] = _kategoriRepository.GetAll();
            TempData["makaleYorumlariGetir"] = _yorumRepository.MakaleYorumlari(id);
            TempData["makaleAltYorumlari"] = _yorumRepository.MakaleAltYorumlari(id);
            TempData["makaleID"] = id;
            ViewBag.yorumSayisi = _yorumRepository.MakaleYorumSayisi(id).Count();

            return View(makaleGetir);
        }




    }
}