using BlogSitem.BLL.IRepositories;
using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.Enum;
using BlogSitem.DLL.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.Repositories
{
    public class KategoriRepository : Repository<MakaleKategoriler>, IKategoriRepository
    {
        MerveBlogSiteDB _db;

        public KategoriRepository(MerveBlogSiteDB db) : base(db)
        {
            _db = db;
        }

        public string KategoriEkle(string kategoriAdi, string aciklama)
        {
            try
            {
                MakaleKategoriler kategoriEkle = new MakaleKategoriler();
                kategoriEkle.KategoriAdi = kategoriAdi;
                kategoriEkle.Aciklama = aciklama;
                Add(kategoriEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string KategoriGuncelle(int kategoriID, string kategoriAdi, string aciklama)
        {
            var kategoriGuncelle = Find(k => k.KategoriID == kategoriID).FirstOrDefault();
            try
            {
                kategoriGuncelle.KategoriAdi = kategoriAdi;
                kategoriGuncelle.Aciklama = aciklama;
                Update(kategoriGuncelle);
                return "Kategori guncelleme başarılı";

            }
            catch (Exception)
            {
                return "Kategori guncelleme esnasında bir hata oluştu";
            }
        }

        public IEnumerable<MakaleKategoriler> KategoriListele()
        {
            return GetAll();
        }

        public int KategoriSayisi(int kategoriID)
        {
            return Find(k => k.KategoriID == kategoriID).Count();
        }

        public string KategoriSil(int kategoriID)
        {
            try
            {
                var pasifEt = Get(kategoriID);
                pasifEt.AktifMi = false;
                return DefinationMessages.Pasif_Basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Pasif_Edilirken_Hata_Olustu.ToString();
            }
        }

        public int MakaleSayisi(int kategoriID)
        {
            var makaleSayisi = Find(k => k.KategoriID == kategoriID).Select(k => k.MakaleID).Count();          

            return makaleSayisi;
        }
    }
}
