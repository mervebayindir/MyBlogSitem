using BlogSitem.BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitem.UI.Areas.AdminManager.Controllers
{
    public class AdminMakalelerController : Controller
    {
        // GET: AdminManager/AdminMakaleler
        public ActionResult AdminMakalelerIndex()
        {
            MakaleManager makale = new MakaleManager();
            var list = makale.MakaleListele();

            return View(list);
        }

    }
}