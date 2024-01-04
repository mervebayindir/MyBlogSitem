using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.IRepositories
{
    public interface IMakaleRepository: IRepository<Makaleler>
    {
        string MakaleEkle(int yazarId, int makaleKategorileriId, string makaleBaslik, string makaleIcerik);
        string MakaleGuncelle(int makaleId, int yazarId, int makaleKategorileriId, string makaleBaslik, string makaleIcerik, bool aktifMi, int onaylayanKullaniciId);
        string MakaleSil(int makaleId);

        IEnumerable<Makaleler> MakaleListesi();
        IEnumerable<Makaleler> MakaleListesi(bool aktifMi);
        IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi();
    }
}
