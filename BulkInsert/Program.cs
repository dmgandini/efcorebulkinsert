using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;

namespace BulkInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            var entities = new List<BulkInsertTable>();
            for (int i = 0; i < 100000; i++)
            {
                entities.Add(new BulkInsertTable() { Description = $"Item {i}" });
            }

            //método 1
            using (var context = new AppContext())
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                context.BulkInsertTable.AddRange(entities);
                context.SaveChanges();

                watch.Stop();
                Console.WriteLine($"Método 1 - Miliseconds: {watch.ElapsedMilliseconds}");
            }

            //método 2
            using (var context = new AppContext())
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                context.BulkInsertAsync(entities);

                watch.Stop();
                Console.WriteLine($"Método 2 - Miliseconds: {watch.ElapsedMilliseconds}");
            }
            Console.ReadKey();
        }
    }
}
