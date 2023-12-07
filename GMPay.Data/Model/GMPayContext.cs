using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Data.Model
{
    public class GMPayContext : DbContext
    {
        public GMPayContext(DbContextOptions<GMPayContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(f => f.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerTransactions> CustomerTransactions { get; set; }

    }
}
