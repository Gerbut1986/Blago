namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class WithdrawRepository : IRepository<Withdrawal>
    {
        readonly DataContext db;

        public WithdrawRepository(DataContext db) => this.db = db;

        public async Task CreateAsync(Withdrawal entity)
        {
            db.Withdrawals.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var en = await db.Withdrawals.FindAsync(id);
            db.Withdrawals.Remove(en);
            await db.SaveChangesAsync();
        }

        public void Delete(Withdrawal entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Withdrawal> GetAsync(int id)
        {
            return await db.Withdrawals.FindAsync(id);
        }

        public IQueryable<Withdrawal> GetAll()
        {
            return db.Withdrawals;
        }

        public async Task<System.Collections.Generic.List<Withdrawal>> GetAllAsync()
        {
            var lst = (from ci in db.Withdrawals select ci);
            return await lst.ToListAsync();
        }

        public void Update(Withdrawal entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.Withdrawals.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public Withdrawal Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Withdrawal entity)
        {
            db.Withdrawals.Add(entity);
            db.SaveChanges();
        }
    }
}
