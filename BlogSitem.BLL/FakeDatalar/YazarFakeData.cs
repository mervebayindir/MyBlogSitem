using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.FakeDatalar
{
    public class YazarFakeData
    {
        public void EkleYazarFakeData()
        {
            MerveBlogSiteDB db = new MerveBlogSiteDB();
            if (db.Yazar.ToList().Count > 5)
            {
                return;
            }

            for (int i = 0; i <= 10; i++)
            {
                Yazarlar yazarlar = new Yazarlar();
                yazarlar.Email = FakeData.NetworkData.GetEmail();
                yazarlar.KisacaHakkinda = FakeData.TextData.GetSentences(200);
                yazarlar.CalistigiFirma = FakeData.NameData.GetCompanyName();
                yazarlar.YasadigiUlke = FakeData.PlaceData.GetCountry();
                yazarlar.YasadigiSehir = FakeData.PlaceData.GetCity();
                db.Yazar.Add(yazarlar);
            }
            db.SaveChanges();
        }
    }
}
