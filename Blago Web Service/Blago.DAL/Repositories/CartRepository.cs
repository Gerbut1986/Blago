﻿namespace Blago.DAL.Repositories
{
    using EF;
    using Entities;
    using Interfaces;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class CartRepository : IRepository<ShopingCart>
    {
        readonly DataContext db;

        public CartRepository(DataContext db) => this.db = db;

        public async Task CreateAsync(ShopingCart entity)
        {
            db.ShopingCarts.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var en = await db.ShopingCarts.FindAsync(id);
            db.ShopingCarts.Remove(en);
            await db.SaveChangesAsync();
        }

        public void Delete(ShopingCart entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ShopingCart> GetAsync(int id)
        {
            return await db.ShopingCarts.FindAsync(id);
        }

        public IQueryable<ShopingCart> GetAll()
        {
            return db.ShopingCarts;
        }

        public async Task<System.Collections.Generic.List<ShopingCart>> GetAllAsync()
        {
            var lst = (from ci in db.ShopingCarts select ci);
            return await lst.ToListAsync();
        }

        public void Update(ShopingCart entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            db.Entry(await db.ShopingCarts.FindAsync(id)).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public ShopingCart Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(ShopingCart entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
