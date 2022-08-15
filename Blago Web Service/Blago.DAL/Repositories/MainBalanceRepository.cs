namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class MainBalanceRepository : IRepository<MainBalance>
    {
        readonly DataContext db;

        public MainBalanceRepository(DataContext db) => this.db = db;

        public void Create(MainBalance entity)
        {
            db.MainBalances.Add(entity);
            db.SaveChanges();
        }

        public async Task CreateAsync(MainBalance entity)
        {
            db.MainBalances.Add(entity);
            await db.SaveChangesAsync();
        }

        public void Delete(MainBalance entity)
        {
            bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                var mb = new MainBalance { Id = entity.Id };//, Date = entity.Date, Amount = entity.Amount, UserId = entity.UserId };

                db.MainBalances.Attach(mb);
                db.Entry(mb).State = EntityState.Deleted;
                var res = db.SaveChanges();
            }
            catch (System.Exception ex) { string err = ex.Message; }
            finally
            {
                db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            }
        }

        public MainBalance Get(int id)
        {
            return db.MainBalances.Find(id);
        }

        public async Task<MainBalance> GetAsync(int id)
        {
            return await db.MainBalances.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var en = Get(id);
            db.MainBalances.Remove(en);
            await db.SaveChangesAsync();
        }

        public IQueryable<MainBalance> GetAll()
        {
            return db.MainBalances;
        }

        public async Task<System.Collections.Generic.List<MainBalance>> GetAllAsync()
        {
            var lst = (from ci in db.MainBalances select ci);
            return await lst.ToListAsync();
        }

        public void Update(MainBalance entity)
        {
            db.Entry(entity).State = EntityState.Modified; 
            db.SaveChanges();
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.MainBalances.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
