using BlogSitem.DLL.BlogSiteDatabase.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.DLL.BlogSiteDatabase
{
    public class ExistsStoredProcedure
    {
        MerveBlogSiteDB _db = new MerveBlogSiteDB();
        public string Sp_MakaleListesi()
        {
            try
            {
                string sql = @"create proc Sp_MakaleListesi
            as
            begin
            select 
            m.MakaleID,
            mk.KategoriAdi,
            m.Baslik,m.MakaleIcerik,m.EklenmeTarihi,m.AktifMi
            ,k.Adi+' '+k.Soyadi as OnaylayanAdSoyad,
            sanalTablo.YazarAdSoyad
            --k.Adi+' '+k.Soyadi as Yazar
            from Makalelers				as m
            join Kullanicilars			as k	on m.OnaylayanKullaniciID=k.KullaniciID
            join MakaleKategorilers	as mk	on mk.KategoriID=m.MakaleKategoriID_KategoriID
            --join Yazarlars				as y	on y.Kullanicilar_KullanicilarID=k.KullanicilarID--bu yapı onaylayan kullanıcı aId değerini referans alır o nedenle yazar adı getiremez. Bu yapıdan dolayı sanal tablo ihtiyacı doğdu
            --sanal tablo
            join 
            (
            ---------------------------start----------
            select 
            k.Adi+' '+k.Soyadi as YazarAdSoyad,
            y.email,
            y.CalistigiFirma,y.YazarID
            from 

		            Yazarlars		as y
            join	Kullanicilars	as k on k.KullaniciID=y.Kullanici_KullaniciID
            --------------------------------End--
            ) as sanalTablo on sanalTablo.YazarID=m.Yazar_YazarID
            end";
                var list = _db.Database.ExecuteSqlCommand(sql);
                return "Sp_MakaleListesi adındaki SP başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }
    }
}
