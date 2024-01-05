using BlogSitem.BLL.Manager;
using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.Enum;
using BlogSitem.DLL.UnitOfWork;
using BlogSitem.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Areas.AdminManager.Controllers
{
    public class AdminMakalelerController : Controller
    {
        MerveBlogSiteDB _db;
        MakaleRepository _makaleRepository;
        KategoriRepository _kategoriRepository;
        UnitOfWork _unitOfWork;
        UyariMesaj uyariMesaj = new UyariMesaj();

        public AdminMakalelerController()
        {
            _db = new MerveBlogSiteDB();
            _makaleRepository = new MakaleRepository(_db);
            _kategoriRepository = new KategoriRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        // GET: AdminManager/AdminMakaleler
        public ActionResult AdminMakalelerIndex()
        {
            return View(_makaleRepository.Sp_MakaleListesi());
        }

        public ActionResult AdminMakaleEkle()
        {
            var kategoriList = _kategoriRepository.KategoriListele();
            return View(kategoriList);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AdminMakaleEkle(string makaleKategori, string makaleIcerik, string baslik)
        {
            var kategoriList = _kategoriRepository.KategoriListele();
            var ekle = _makaleRepository.MakaleEkle(5, Convert.ToInt32(makaleKategori), baslik, makaleIcerik);
            if (ekle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(ekle);
            }
            int kaydet = _unitOfWork.SaveChanges();

            if (kaydet <= (int)DefinationMessages.Failed)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View(kategoriList);
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());

            return View(kategoriList);
        }

        public ActionResult AdminMakaleGuncelle(int id)
        {
            ViewBag.kategori = _kategoriRepository.GetAll();
            var makaleGetir = _makaleRepository.Get(id);
            return View(makaleGetir);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AdminMakaleGuncelle(int id, string baslik, string makaleIcerik, bool AktifMi, int kategoriID)
        {
            ViewBag.kategori = _kategoriRepository.GetAll();
            var guncelle = _makaleRepository.MakaleGuncelle(id, 2, kategoriID, baslik, makaleIcerik, Convert.ToBoolean(AktifMi), 2);
            int sonuc = _unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Guncelleme_Basarili.ToString());
                return RedirectToAction("AdminMakalelerIndex","AdminMakaleler", ViewBag.mesaj);
            }
            
            var makaleGetir = _makaleRepository.Get(id);

            return View(makaleGetir);
        }

        public ActionResult AdminMakaleSil(int id)
        {
            var makaleBul = _makaleRepository.Get(id);
            return View(makaleBul);
        }

        [HttpPost, ActionName("AdminMakaleSil")]
        public ActionResult AdminMakaleDelete(int id)
        {
            _makaleRepository.MakaleSil(id);
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("AdminMakalelerIndex");
            }

            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Pasif_Basarili.ToString());
            var makaleBul = _makaleRepository.Get(id);
            return View(makaleBul);
        }

    }
}