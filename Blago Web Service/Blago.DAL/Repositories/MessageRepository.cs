namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class MessageRepository : IRepository<Messages>
    {
        readonly DataContext db;

        public MessageRepository(DataContext db) => this.db = db;

        public async Task CreateAsync(Messages entity)
        {
            db.Messages.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var en = await db.Messages.FindAsync(id);
            db.Messages.Remove(en);
            await db.SaveChangesAsync();
        }

        public void Delete(Messages entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Messages> GetAsync(int id)
        {
            return await db.Messages.FindAsync(id);
        }

        public IQueryable<Messages> GetAll()
        {
            return db.Messages;
        }

        public async Task<System.Collections.Generic.List<Messages>> GetAllAsync()
        {
            var lst = (from ci in db.Messages select ci);
            return await lst.ToListAsync();
        }

        public void Update(Messages entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.Messages.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public Messages Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Messages entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
