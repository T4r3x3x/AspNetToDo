using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetAsync(int id);        
        public IQueryable<T> GetAll();
        public Task CreateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task UpdateAsync(T entity);
    }
}
