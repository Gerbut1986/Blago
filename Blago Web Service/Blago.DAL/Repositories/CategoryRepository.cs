namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class CategoryRepository : IRepository<Category>
    {
        readonly DataContext db;

        public CategoryRepository(DataContext db) => this.db = db;

        public async Task CreateAsync(Category entity)
        {
            db.Categories.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var en = await db.Categories.FindAsync(id);
            db.Categories.Remove(en);
            await db.SaveChangesAsync();
        }

        public void Delete(Category entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await db.Categories.FindAsync(id);
        }

        public IQueryable<Category> GetAll()
        {
            return db.Categories;
        }

        public async Task<System.Collections.Generic.List<Category>> GetAllAsync()
        {
            var lst = (from ci in db.Categories select ci);
            return await lst.ToListAsync();
        }

        public void Update(Category entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.Categories.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public Category Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
