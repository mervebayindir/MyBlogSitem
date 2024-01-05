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

        public IEnumerable<Sp_YorumlarDOM> MakaleYorumlari(int makaleID)
        {
            var getir = _db.Sp_YorumListesi().Where(k => k.Makale_MakaleID == makaleID).ToList();
            return getir;
        }

        public IEnumerable<Sp_YorumlarDOM> MakaleAltYorumlari(int makaleID)
        {
            var getir = _db.Sp_YorumListesi().Where(k => k.YorumUstID != 0 && k.Makale_MakaleID == makaleID).ToList();
            return getir;
        }
        public List<Yorumlar> MakaleYorumSayisi(int makaleID)
        {
            var yorumSayisi = _db.Yorum.Where(y => y.Makale.MakaleID == makaleID).ToList();
            return yorumSayisi;
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

        public string YorumGuncelle(int yorumID, string yorum)
        {
            var yorumGuncelle = Find(k => k.YorumID == yorumID).FirstOrDefault();
            try
            {
                yorumGuncelle.Yorum = yorum;
                yorumGuncelle.YorumTarihi = DateTime.Now;
                return "Güncelleme başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme işlemi esnasında hata oluştu";
            }
        }

        public IEnumerable<Yorumlar> YorumListesi()
        {
            return GetAll();
        }

        public string YorumSil(int yorumID)
        {
            try
            {
                var yorumSil = Get(yorumID);
                if (yorumSil != null)
                {
                    Remove(yorumSil);
                }
                return "Silme işlemi başarılı";
            }
            catch (Exception)
            {
                return "Silme işlemi başarısız";
            }
        }
    }
}
