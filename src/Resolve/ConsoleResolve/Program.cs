using System.Collections.Generic;
using System.Linq;
using Catalog.Models.Entities;
using Catalog.Models.SqlServer;
using static System.Console;

namespace ConsoleResolve
{
    class Program
    {
        static void Main()
        {
            using (var db = new ReadOnlyCatalogContext())
            {
                if (!db.Catalogs.Any())
                {
                    WriteLine("Каталог пуст");
                    ReadKey();
                    return;
                }

                IList<InfoCatalog> list = new List<InfoCatalog>();

//СЮДА ДОБАВЛЯЕМ ВАШЕ РЕШЕНИЕ!!!!!!!!!!!!!!!!!

                //для примера-подсказки выбор товаров вне каталога:
                IList<Good> nullCatalog = db.Goods
                    .Where(g => g.CatalogId == null)
                    .ToArray();
                InfoCatalog nc = new()
                {
                    Count = (uint)nullCatalog.Sum(g => g.Count),
                    Value = nullCatalog.Sum(g => g.Count * g.Price)
                };
                list.Insert(0, nc);

                for (int i = list.Count - 1; i >= 0; i--)
                    WriteLine(list[i]);

                WriteLine("****");

                var res = list
                    .Where(c => c.CatalogId == null)
                    .Select(c => (c.Count, c.Value)).ToArray();

                WriteLine("Итого в каталоге " +
                          $"{res.Sum(c => c.Count)} " +
                          "товаров на общую сумму " +
                          $"{res.Sum(c => c.Value):C}.");
            }
            ReadKey();

            //**************************************************************
            //немного теории ToList vs ToArray:
            //**************************************************************
            IList<int> source = Enumerable.Range(1, 10).ToArray();  

            foreach (var x in source)
            {
                if (x == 5)
                    source[8] *= 100;
                WriteLine(x);
            }
            ReadKey();
            source = Enumerable.Range(1, 10).ToList();  

            foreach (var x in source)
            {
                if (x == 5)
                    source[8] *= 100;
                WriteLine(x);
            }
            ReadKey();
        }
    }
}
