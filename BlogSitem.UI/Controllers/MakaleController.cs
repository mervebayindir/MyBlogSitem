﻿using BlogSitem.BLL.Repositories;
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
            //TempData["makaleSayisi"] = _kategoriRepository.MakaleSayisi(kategoriID);
            TempData["kategoriList"] = _kategoriRepository.GetAll();
            TempData["makaleGetir"] = _makaleRepository.Sp_MakaleListesi(true);
            return View();
        }

        public ActionResult MakaleDetayIndex()
        {
            return View();
        }


    }
}