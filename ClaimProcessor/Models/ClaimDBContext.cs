using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Transactions;


namespace ClaimProcessor.Models
{
    public class ClaimDBContext : DbContext
    {
        public ClaimDBContext(DbContextOptions<ClaimDBContext> options) : base(options)
        {
            LoadNdcs();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void LoadNdcs()
        {
            NdcPrice ndc1 = new NdcPrice() { Ndc = "1", Price = 10.5m };
            NdcPrice ndc2 = new NdcPrice() { Ndc = "2", Price = 110.2m };
            NdcPrice ndc3 = new NdcPrice() { Ndc = "3", Price = 3.25m };
            NdcPrice ndc4 = new NdcPrice() { Ndc = "4", Price = 66.12m };
            NdcPrices.Add(ndc1);
            NdcPrices.Add(ndc2);
            NdcPrices.Add(ndc3);
            NdcPrices.Add(ndc4);
            SaveChanges();

        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
            optionsBuilder.EnableDetailedErrors(true);
        }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<NdcPrice> NdcPrices
        {
            get; set;

        }
    }
}


