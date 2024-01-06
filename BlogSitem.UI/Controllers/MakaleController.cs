using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.Enum;
using BlogSitem.DLL.UnitOfWork;
using BlogSitem.UI.Areas.AdminManager.Controllers;
using BlogSitem.UI.Models;
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
        UyariMesaj uyariMesaj;

        public MakaleController()
        {
            _db = new MerveBlogSiteDB();
            _kategoriRepository = new KategoriRepository(_db);
            _makaleRepository = new MakaleRepository(_db);
            _yorumRepository = new YorumRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
            uyariMesaj = new UyariMesaj();
        }

        // GET: Makale
        public ActionResult MakaleIndex()
        {
            TempData["kategoriList"] = _kategoriRepository.GetAll();
            TempData["makaleList"] = _makaleRepository.Sp_MakaleListesi(true);

            return View();
        }

        public ActionResult MakaleDetayIndex(int id)
        {
            var makaleGetir = _makaleRepository.Sp_MakaleListesi(true).Where(k => k.MakaleID == id).FirstOrDefault();
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
            yorumData.Adi = ViewBag.kullaniciAdi;
            yorumData.Soyadi = ViewBag.kullaniciSoyadi;
            yorumData.Yorum = yorumIcerik;
            yorumData.YorumUstID = 0;

            return Json(yorumData, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult YorumDuzenle(int yorumId)
        //{
        //    var yorumGetir = _yorumRepository.Get(yorumId);
        //    return View(yorumGetir);
        //}

        //[HttpPost, ActionName("YorumDuzenle")]
        //public ActionResult YorumEdit(int yorumId, string yorum)
        //{
        //    var yorumGuncelle = _yorumRepository.YorumGuncelle(yorumId, yorum);
        //    int sonuc = _unitOfWork.SaveChanges();
        //    if (sonuc > 0)
        //    {
        //        //ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Guncelleme_Basarili.ToString());
        //        return RedirectToAction("MakaleDetayIndex", "Makale", ViewBag.mesaj);
        //    }
        //    var yorumGetir = _yorumRepository.Get(yorumId);
        //    return View(yorumGetir);
        //}

    }
}