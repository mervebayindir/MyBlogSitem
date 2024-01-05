using BlogSitem.BLL.IRepositories;
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
    public class YorumRepository : Repository<Yorumlar>, IYorumRepository
    {
        MerveBlogSiteDB _db;

        public YorumRepository(MerveBlogSiteDB db) : base(db)
        {
            _db = db;
        }

        public int AltYorumSayisi(int yorumId)
        {
            return Find(k => k.YorumID == yorumId).Count();
        }

        public IEnumerable<Yorumlar> MakaleYorumListesi(int makaleID)
        {
            var getir = Find(k => k.Makale.MakaleID == makaleID);
            return getir;
        }

        public string YorumEkle(string yorum, int yorumUstID, int kullaniciID, int makalelerID)
        {
            try
            {
                Yorumlar yorumEkle = new Yorumlar();
                yorumEkle.Yorum = yorum;
                yorumEkle.YorumTarihi = DateTime.Now;
                yorumEkle.YorumUstID = yorumUstID;
                yorumEkle.Kullanici = _db.Kullanici.Where(k => k.KullaniciID == kullaniciID).FirstOrDefault();
                yorumEkle.Makale = _db.Makale.Where(m => m.MakaleID == makalelerID).FirstOrDefault();
                Add(yorumEkle);
                return "Ekleme başarılı";

            }
            catch (Exception)
            {
                return "Ekleme işlemi esnasında hata oluştu";
            }
        }

        //public IEnumerable<Sp_YorumlarDOM> MakaleAltYorumlari(int makaleID)
        //{
        //    var getir =_db.Sp_MakaleListesi().Where(k=>k.)
        //}

        public string YorumGuncelle(int yorumlarID, string yorum, int yorumUstID, int kullaniciID, int makalelerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Yorumlar> YorumListesi()
        {
            return GetAll();
        }

        public string YorumSil(int yorumlarID)
        {
            throw new NotImplementedException();
        }
    }
}
