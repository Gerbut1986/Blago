namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class OrdersRepository : IRepository<Order>
    {
        readonly DataContext db;

        public OrdersRepository(DataContext db) => this.db = db;

        public async Task CreateAsync(Order entity)
        {
            db.Orders.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var en = await db.Orders.FindAsync(id);
            db.Orders.Remove(en);
            await db.SaveChangesAsync();
        }

        public void Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await db.Orders.FindAsync(id);
        }

        public IQueryable<Order> GetAll()
        {
            return db.Orders;
        }

        public async Task<System.Collections.Generic.List<Order>> GetAllAsync()
        {
            var lst = (from ci in db.Orders select ci);
            return await lst.ToListAsync();
        }

        public void Update(Order entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.Orders.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public Order Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
        }
    }
}
