using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase.ORMManager
{
    public class MerveBlogSiteDB : DbContext
    {
        public DbSet<Makaleler> Makale { get; set; }
        public DbSet<Kullanicilar> Kullanici { get; set; }
        public DbSet<Yorumlar> Yorum { get; set; }
        public DbSet<Yazarlar> Yazar { get; set; }
        public DbSet<MakaleKategoriler> MakaleKategori { get; set; }
        public DbSet<Resimler> Resim { get; set; }
        public DbSet<Yetkiler> Yetki { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi()
        {
            var spGetir = Database.SqlQuery<Sp_MakaleListesiDOM>("EXEC Sp_MakaleListesi");
            return spGetir;
        }

    }



    public class CreateDb : CreateDatabaseIfNotExists<MerveBlogSiteDB>
    {
        public override void InitializeDatabase(MerveBlogSiteDB context)
        {
            base.InitializeDatabase(context);
        }
        protected override void Seed(MerveBlogSiteDB context)
        {
            base.Seed(context);
        }
    }

}
