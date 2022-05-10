using PASVE.Models;
using System.Web.Http;

namespace PASVE.Interfaces
{
    public interface IGenericApiController<TEntity, TKey> where TEntity : class
    {
        [HttpGet]
        Task<BaseResponse<List<TEntity>>> GetAllAsync(int page, int rows);
        [HttpGet]
        Task<BaseResponse<TEntity>> ConsultAsync([FromUri] TKey id);
        [HttpPost]
        Task<BaseResponse<TEntity>> InsertAsync([FromBody] TEntity model);
        [HttpPut]
        Task<BaseResponse<TEntity>> UpdateAsync([FromBody] TEntity model);
        [HttpGet]
        Task<BaseResponse<TEntity>> DeleteAsync([FromUri] TKey id);
    }
}
