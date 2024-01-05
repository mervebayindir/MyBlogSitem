using BlogSitem.BLL.Repositories;
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

        public BaseController()
        {
            _db = new MerveBlogSiteDB();
            _kullaniciRepository = new KullaniciRepository(_db);
            _kategoriRepository = new KategoriRepository(_db);
        }

        // GET: AdminManager/Base
        public ActionResult Index()
        {

            return View();
        }
      
    }
}