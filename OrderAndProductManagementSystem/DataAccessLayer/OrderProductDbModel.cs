using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;

namespace DataAccessLayer
{
    public class OrderProductDbModel : DbContext
    {
        public OrderProductDbModel(DbContextOptions<OrderProductDbModel> options) : base(options)
        {
        }

        #region Tables
        public virtual DbSet<Product> Products { get; set; }
        #endregion Tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
