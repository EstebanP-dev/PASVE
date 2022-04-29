using PASVE.Models;

namespace PASVE.Interfaces
{
    public interface IGenericService<TEntity, TKey>
    {
        Task<BaseResponse<IEnumerable<TEntity>>> GetAllAsync();
        Task<BaseResponse<TEntity>> GetByIdAsync(TKey id);
        Task<BaseResponse<TEntity>> CreateAsync(TEntity entity);
        Task<BaseResponse<TEntity>> UpdateAsync(TEntity entity, TKey id);
        Task<BaseResponse<TEntity>> DeleteAsync(TKey id);
    }
}
