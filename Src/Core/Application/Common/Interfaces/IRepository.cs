using Domain.Common;

namespace Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<int>
    {

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetListByBool(bool active);

        Task<List<TEntity>> ListAllAsync();

        Task<TEntity> GetByIdAsync(int id);


        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);

    }
}
