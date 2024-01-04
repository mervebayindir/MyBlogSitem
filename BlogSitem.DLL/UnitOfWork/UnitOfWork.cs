using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MerveBlogSiteDB _db;

        public UnitOfWork(MerveBlogSiteDB db)
        {
            _db = db;
        }

        public int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return DefinationMessages.Failed.GetHashCode();
            }
        }
    }
}
