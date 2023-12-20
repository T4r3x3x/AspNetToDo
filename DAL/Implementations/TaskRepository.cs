using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Implementations
{
    public class TaskRepository : IRepository<TaskEntity>
    {
        private readonly DataDbContext _dbContext;


        public TaskRepository(DataDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public async Task CreateAsync(TaskEntity entity)
        {
            await _dbContext.TaskEntities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskEntity entity)
        {
            _dbContext.TaskEntities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TaskEntity> GetAsync(int id)
        {
            var task = await _dbContext.TaskEntities.Where(task => task.Id == id).FirstAsync();
            return task;
        }

        public IQueryable<TaskEntity> GetAll()
        {
            return _dbContext.TaskEntities;
        }

        public async Task UpdateAsync(TaskEntity entity)
        {
            _dbContext.TaskEntities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
