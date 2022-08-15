namespace Blago.DAL.EF
{
    using System.Data.Entity;
    using Blago.DAL.Entities;

    public class DataContext : DbContext
    {
        public DataContext(string connection) : base(connection)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ShopingCart> ShopingCarts { get; set; }
        public virtual DbSet<Withdrawal> Withdrawals { get; set; }
        public virtual DbSet<RefMember> RefMembers { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MainBalance> MainBalances { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
