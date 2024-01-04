using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.FakeDatalar
{
    public class KullanicilarFakeData
    {
        public void EkleKullaniciFakeData()
        {
            MerveBlogSiteDB db = new MerveBlogSiteDB();

            if (db.Kullanici.ToList().Count > 5)
            {
                return;
            }


            for (int i = 0; i <= 20; i++)
            {
                Kullanicilar kullanicilar = new Kullanicilar();

                string adi = FakeData.NameData.GetFirstName();

                kullanicilar.Adi = adi;
                kullanicilar.Soyadi = FakeData.NameData.GetSurname();
                kullanicilar.KullaniciAdi = adi;
                kullanicilar.KullaniciSifresi = FakeData.ArrayData.GetElement(i).ToString();
                kullanicilar.EklenmeTarihi = DateTime.Now;
                kullanicilar.PasiflikTarihi = DateTime.Now;
                kullanicilar.AktifMi = true;
                kullanicilar.YazarMi = false;
                kullanicilar.Yetki = db.Yetki.FirstOrDefault();
                db.Kullanici.Add(kullanicilar);
            }

            db.SaveChanges();
        }
    }
}
