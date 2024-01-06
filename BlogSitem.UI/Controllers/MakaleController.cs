using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.UnitOfWork;
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
        UnitOfWork _unitOfWork;

        public MakaleController()
        {
            _db = new MerveBlogSiteDB();
            _kategoriRepository = new KategoriRepository(_db);
            _makaleRepository = new MakaleRepository(_db);
            _yorumRepository = new YorumRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
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

        [HttpGet]
        public ActionResult MakaleYorum()//Yorum ekler
        {
            var yorumList = _yorumRepository.YorumListesi();

            return View(yorumList);
        }

        [HttpPost]
        public ActionResult MakaleYorum(string yorumIcerik, int makaleId)//Yorum ekler
        {
            var ekle = _yorumRepository.YorumEkle(yorumIcerik, 0, 4, makaleId);
            _unitOfWork.SaveChanges();

            Sp_YorumlarDOM yorumData = new Sp_YorumlarDOM();
            yorumData.YorumTarihi = DateTime.Now;
            yorumData.Adi = ViewBag.userAdiSoyadi;
            yorumData.Soyadi = KullaniciSoyadi;
            yorumData.Yorum = yorumIcerik;
            yorumData.YorumUstID = 0;

            return Json(yorumData, JsonRequestBehavior.AllowGet);
        }


    }
}