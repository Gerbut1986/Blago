namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class RefMemberRepository : IRepository<RefMember>
    {
        readonly DataContext db;

        public RefMemberRepository(DataContext db) => this.db = db;

        public async Task CreateAsync(RefMember entity)
        {
            db.RefMembers.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var en = await db.RefMembers.FindAsync(id);
            db.RefMembers.Remove(en);
            await db.SaveChangesAsync();
        }

        public void Delete(RefMember entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RefMember> GetAsync(int id)
        {
            return await db.RefMembers.FindAsync(id);
        }

        public IQueryable<RefMember> GetAll()
        {
            return db.RefMembers;
        }

        public async Task<System.Collections.Generic.List<RefMember>> GetAllAsync()
        {
            var lst = (from ci in db.RefMembers select ci);
            return await lst.ToListAsync();
        }

        public void Update(RefMember entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.RefMembers.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public RefMember Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(RefMember entity)
        {
            db.RefMembers.Add(entity);
            db.SaveChanges();
        }
    }
}
