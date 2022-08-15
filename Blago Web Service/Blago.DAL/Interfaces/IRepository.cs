namespace Blago.DAL.Interfaces
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<IEntity> where IEntity : class
    {
        Task DeleteAsync(int id);
        void Delete(IEntity entity);
        Task<IEntity> GetAsync(int id); 
        IEntity Get(int id);
        void Create(IEntity entity);
        Task CreateAsync(IEntity entity);
        void Update(IEntity entity);
        Task UpdateAsync(int id);
        IQueryable<IEntity> GetAll();
        Task<System.Collections.Generic.List<IEntity>> GetAllAsync();
    }
}
