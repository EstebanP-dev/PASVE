using Microsoft.AspNetCore.Http;
using PASVE.Interfaces;
using PASVE.Models;
using PASVE.Services;
using System.Web.Http;

namespace PASVE.Controllers
{
    public class ApiEvidenceController : ApiController, IGenericApiController<Evidence, Guid>
    {
        private readonly EvidenceService service = new EvidenceService();

        [Route("api/Evidence/{id}")]
        public Task<BaseResponse<Evidence>> ConsultAsync([FromUri] Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("api/Evidence/{id}/Delete")]
        public Task<BaseResponse<Evidence>> DeleteAsync([FromUri] Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("api/Evidence")]
        public Task<BaseResponse<List<Evidence>>> GetAllAsync(int page, int rows)
        {
            throw new NotImplementedException();
        }

        [Route("api/Evidence")]
        public Task<BaseResponse<Evidence>> InsertAsync([FromBody] Evidence model)
        {
            throw new NotImplementedException();
        }

        [Route("api/Evidence")]
        public Task<BaseResponse<Evidence>> UpdateAsync([FromBody] Evidence model)
        {
            throw new NotImplementedException();
        }
    }
}
