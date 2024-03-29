﻿using BlogSitem.DLL.BlogSiteDatabase;
using BlogSitem.DLL.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.BLL.IRepositories
{
    public interface IYorumRepository : IRepository<Yorumlar>
    {
        string YorumEkle(string yorum, int yorumUstID, int kullaniciID, int makalelerID);
        string YorumGuncelle(int yorumID, string yorum);
        string YorumSil(int yorumID);
        IEnumerable<Yorumlar> YorumListesi();
        IEnumerable<Yorumlar> MakaleYorumListesi(int makaleID);
    }
}
