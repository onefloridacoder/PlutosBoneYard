using PlutoRepository;
using PlutoDomain;
using System;
using System.Linq;

namespace PlutoHarness
{

    internal class Program
    {
        private static PlutoContext plutoContext = new PlutoContext();
        public static void Main()
        {
            plutoContext.Database.EnsureCreated();
            GetSites("Before Site Add...");
            AddSite();
            GetSites("After Site Add...");

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }


        private static void AddSite()
        {
            var site = new Site { Name = "Walt Disney World", CreatedBy="PlutoHarness", CreatedDate=DateTime.UtcNow };
            plutoContext.Sites.Add(site);
            plutoContext.SaveChanges();
        }

        private static void GetSites(string text)
        {
            var sites = plutoContext.Sites.ToList();
            Console.WriteLine($"{text}: Site count is {sites.Count}");
            foreach (var site in sites)
            {
                Console.WriteLine(site.Name);
            }
        }
    }
};
