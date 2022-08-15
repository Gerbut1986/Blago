namespace Blago.DAL.Interfaces
{
    using Entities;

    public interface IUnitOfWork : System.IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<ShopingCart> Carts { get; }
        IRepository<Messages> Messages { get; }
        IRepository<RefMember> RefMembers { get; }
        IRepository<Withdrawal> Withdrawals { get; }
        IRepository<MainBalance> MainBalances { get; }
        IRepository<Order> Orders { get; }
        System.Threading.Tasks.Task<int> SaveAsync();
    }
}
