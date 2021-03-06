﻿using Microsoft.EntityFrameworkCore;
using SnoopyDomain;

namespace SnoopyRepository
{
    public class SnoopyContext : DbContext 
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<ThemePark> ThemeParks { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<User> Users { get; set; }

        public SnoopyContext(DbContextOptions<SnoopyContext> options) : base(options)
        {
            // If the controller(s) need change tracking to figure out graph changes
            // the change tracking settings below won't work.
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Pluto");
        }
    }
}
