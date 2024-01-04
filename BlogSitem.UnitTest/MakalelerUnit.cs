using BlogSitem.BLL.Repositories;
using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.UnitTest
{
    public class MakalelerUnit
    {
        MerveBlogSiteDB _db = new MerveBlogSiteDB();
        MakaleRepository makaleRepository;
        public MakalelerUnit()
        {
            _db = new MerveBlogSiteDB();
            makaleRepository = new MakaleRepository(_db);
        }

        public IEnumerable<Makaleler> MakaleListesi()
        {
            var list = makaleRepository.GetAll();

            return list;
        }
    }
}
