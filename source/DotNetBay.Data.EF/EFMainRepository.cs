using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    class EFMainRepository : IMainRepository
    {
        public MainDbContext Context { get; private set; }
        public Database Database { get; private set; }

        public EFMainRepository()
        {
            this.Context = new MainDbContext();
            Database = this.Context.Database;
        }
       
        public IQueryable<Auction> GetAuctions()
        {
            return this.Context.Auctions.Include(a => a.Bids)
                    .Include(m => m.Seller)
                    .Include(w => w.Winner)
                    .Include(a => a.ActiveBid); ;
        }

        public IQueryable<Member> GetMembers()
        {
            return this.Context.Members.Include(b => b.Bids)
                    .Include(a => a.Auctions); ;
        }

        public Auction Add(Auction auction)
        {
            return this.Context.Auctions.Add(auction);
        }

        public Auction Update(Auction auction)
        {
            this.Context.Auctions.AddOrUpdate(auction);
            return auction;
        }

        public Bid Add(Bid bid)
        {
            
                return this.Context.Bids.Add(bid);
       
        }

        public Bid GetBidByTransactionId(Guid transactionId)
        {
            return this.Context.Bids.Include(b => b.Auction)
                    .Include(b => b.Bidder)
                    .FirstOrDefault(b => b.TransactionId == transactionId);
        }

        public Member Add(Member member)
        {
              return this.Context.Members.Add(member);
            
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
