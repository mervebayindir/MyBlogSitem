using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.Manager
{
    public class MakaleManager
    {
        public List<Makaleler> MakaleListele()
        {
            MerveBlogSiteDB blogSiteDB = new MerveBlogSiteDB();
            var list = blogSiteDB.Makale.ToList();
            return list;
        }
    }
}
