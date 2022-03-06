using DAL;
using System;

namespace InitDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var context = new DiagramsDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            };
        }
    }
}
