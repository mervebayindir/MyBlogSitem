using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.Repositories
{
    public class KullaniciRepository : Repository<Kullanicilar>
    {
        MerveBlogSiteDB _db;
        public KullaniciRepository(MerveBlogSiteDB db) : base(db)
        {
            _db = db;
        }

        public Kullanicilar Giris(string kullaniciAdi, string sifre)
        {
            var getir = Find(k => k.KullaniciAdi == kullaniciAdi && k.KullaniciSifresi == sifre).FirstOrDefault();
            return getir;
        }

        public Kullanicilar KullaniciGetir(int kullaniciId)
        {
            var getir = Find(k => k.KullaniciID == kullaniciId).FirstOrDefault();
            return getir;
        }

    }
}
