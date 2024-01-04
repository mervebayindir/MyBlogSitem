using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.FakeDatalar
{
    public class MakaleFakeData
    {
        public void EkleMakaleFakeData()
        {
            MerveBlogSiteDB db = new MerveBlogSiteDB();

            if (db.Makale.ToList().Count > 25)
            {
                return;
            }
            for (int i = 0; i <= 26; i++)
            {
                Makaleler makaleler = new Makaleler();
                makaleler.AktifMi = true;
                makaleler.EklenmeTarihi = DateTime.Now;
                makaleler.MakaleIcerik = FakeData.TextData.GetSentences(1000);
                makaleler.Baslik = FakeData.NameData.GetCompanyName();

                makaleler.OnaylayanKullaniciID = 1;//??

                makaleler.Yazar = db.Yazar.ToList().FirstOrDefault();//??
                makaleler.MakaleKategoriID = db.MakaleKategori.ToList().First();
                db.Makale.Add(makaleler);
            }

            db.SaveChanges();
        }
    }
}
