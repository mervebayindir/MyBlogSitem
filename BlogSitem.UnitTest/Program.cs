using BlogSitem.DLL.BlogSiteDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitem.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(CreateSP());

            Console.Read();
        }

        public static string CreateSP()
        {
            ExistsStoredProcedure createSP = new ExistsStoredProcedure();
            //return createSP.Sp_MakaleListesi();
            //var createMenuSp = createSP.Sp_MenuListesi();

            //var createMakaleSp = createSP.Sp_MakaleListesi();
            //var createYorumSp = createSP.Sp_Yorumlar();


            return createSP.Sp_MakaleListesi();
        }

    }
}
