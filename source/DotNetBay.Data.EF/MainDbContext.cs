using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    class MainDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Member> Members { get; set; }
        public MainDbContext() : base("DatabaseConnection")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            DbModelBuilder asdf = new DbModelBuilder();
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Entity<Auction>().HasRequired(p => p.Seller).WithMany(p => p.Auctions);
            modelBuilder.Entity<Bid>().HasRequired(p => p.Bidder).WithMany(p => p.Bids);
        }


    }
}
