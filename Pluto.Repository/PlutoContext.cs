using Microsoft.EntityFrameworkCore;
using Pluto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.Repository
{
    public class PlutoContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<ThemePark> ThemeParks { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<User> Users { get; set; }

        private string ConnectionString { get; set; }

        public PlutoContext()
        {
            this.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Pluto";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }

    }
}
