using BlogSitem.BLL.IRepositories;
using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using BlogSitem.DLL.Enum;
using BlogSitem.DLL.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.Repositories
{
    public class MakaleRepository : Repository<Makaleler>, IMakaleRepository
    {
        MerveBlogSiteDB _db;

        public MakaleRepository(MerveBlogSiteDB db) : base(db)
        {
            _db = db;
        }

        public string MakaleEkle(int yazarId, int makaleKategorileriId, string makaleBaslik, string makaleIcerik)
        {
            try
            {
                Makaleler makaleEkle = new Makaleler();
                makaleEkle.Yazar = _db.Yazar.Where(k => k.YazarID == yazarId).FirstOrDefault();
                makaleEkle.MakaleKategoriID = _db.MakaleKategori.Where(k => k.KategoriID == makaleKategorileriId).FirstOrDefault();
                makaleEkle.EklenmeTarihi = DateTime.Now;
                makaleEkle.MakaleIcerik = makaleIcerik;
                makaleEkle.Baslik = makaleBaslik;
                Add(makaleEkle);

                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string MakaleGuncelle(int makaleId, int yazarId, int makaleKategorileriId, string makaleBaslik, string makaleIcerik, bool aktifMi, int onaylayanKullaniciId)
        {
            var makaleGuncelle = Find(k => k.MakaleID == makaleId).FirstOrDefault();
            try
            {
                makaleGuncelle.Yazar = _db.Yazar.Where(k => k.YazarID == yazarId).FirstOrDefault();
                makaleGuncelle.MakaleKategoriID = _db.MakaleKategori.Where(k => k.KategoriID == makaleKategorileriId).FirstOrDefault();
                makaleGuncelle.EklenmeTarihi = DateTime.Now;
                makaleGuncelle.MakaleIcerik = makaleIcerik;
                makaleGuncelle.Baslik = makaleBaslik;
                makaleGuncelle.OnaylayanKullaniciID = onaylayanKullaniciId;
                makaleGuncelle.AktifMi = aktifMi;
                //Update(makaleGuncelle);//????

                return "Güncelleme başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme işlemi esnasında hata oluştu";
            }
        }

        public IEnumerable<Makaleler> MakaleListesi()
        {
            return GetAll();
        }

        public IEnumerable<Makaleler> MakaleListesi(bool aktifMi)
        {
            return Find(k => k.AktifMi == aktifMi);
        }

        public string MakaleSil(int makaleId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi(bool aktifMi)
        {
            var getSP = _db.Sp_MakaleListesi().Where(k => k.AktifMi == aktifMi).ToList();
            //Gerek kalmadı       //yazarlar=> Repo->1
            //Gerek kalmadı       //Kullanıcılar=> Repo->2
            //Gerek kalmadı       //Kategori=> Repo->3
            //Makaleler=> Repo=> 4 deaf repo çağıracağımıza bir sp ile sadece tek makaleler reposu işimizi görecektir
            return getSP;
        }
        public IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi()
        {
            var getSP = _db.Sp_MakaleListesi().ToList();
            return getSP;
        }
    }
}
