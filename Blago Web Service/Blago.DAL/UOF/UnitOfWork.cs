namespace Blago.DAL.UOF
{
    using Repositories;
    using Interfaces;
    using Entities;
    using EF;

    public class UnitOfWork : IUnitOfWork
    {
        readonly DataContext db;

        #region All Repos:    
        OrdersRepository orderRepo;
        CartRepository cartRepo;
        ProductRepository productRepo;
        CategoryRepository categoryRepo;
        WithdrawRepository withdrawRepo;
        RefMemberRepository refMemberRepo;
        MessageRepository messageRepo;
        MainBalanceRepository mBalRepo;
        #endregion

        public UnitOfWork(string conn) => db = new DataContext(conn);

        public IRepository<Product> Products
        {
            get
            {
                if (productRepo == null)
                    productRepo = new ProductRepository(db);
                return productRepo;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepo == null)
                    categoryRepo = new CategoryRepository(db);
                return categoryRepo;
            }
        }

        public IRepository<ShopingCart> Carts
        {
            get
            {
                if (cartRepo == null)
                    cartRepo = new CartRepository(db);
                return cartRepo;
            }
        }

        public IRepository<Withdrawal> Withdrawals
        {
            get
            {
                if (withdrawRepo == null)
                    withdrawRepo = new WithdrawRepository(db);
                return withdrawRepo;
            }
        }

        public IRepository<RefMember> RefMembers
        {
            get
            {
                if (refMemberRepo == null)
                    refMemberRepo = new RefMemberRepository(db);
                return refMemberRepo;
            }
        }

        public IRepository<Messages> Messages
        {
            get
            {
                if (messageRepo == null)
                    messageRepo = new MessageRepository(db);
                return messageRepo;
            }
        }

        public IRepository<MainBalance> MainBalances
        {
            get
            {
                if (mBalRepo == null)
                    mBalRepo = new MainBalanceRepository(db);
                return mBalRepo;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepo == null)
                    orderRepo = new OrdersRepository(db);
                return orderRepo;
            }
        }

        #region Dispose:
        bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion

        public async System.Threading.Tasks.Task<int> SaveAsync() => await db.SaveChangesAsync();
    }
}
