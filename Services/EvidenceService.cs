using Microsoft.EntityFrameworkCore;
using PASVE.Interfaces;
using PASVE.Models;
using System.Net;

namespace PASVE.Services
{
    public class EvidenceService : IGenericService<Evidence, Guid>
    {
        PASVEContext db = new PASVEContext();

        public Task<BaseResponse<Evidence>> CreateAsync(Evidence entity)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseResponse<Evidence>> CreateAsync(Evidence entity, string serverRoute)
        {
            var response = new BaseResponse<Evidence>();
            var route = Path.Combine(serverRoute, entity.File.FileName);

            try
            {
                using(FileStream file = File.Create(route))
                {
                    entity.File.CopyTo(file);
                    file.Flush();
                }

                var id = Guid.NewGuid();

                db.Evidences.Add(new Evidence()
                {
                    Id = id,
                    Name = entity.Name,
                    Path = route,
                    FkInstallment = GlobalVariables.Installment,
                    Active = true,
                    LoadFor = GlobalVariables.UserInfo.Id,
                    UpdateAt = DateTime.Now,
                    CreateAt = DateTime.Now,
                });

                foreach (var author in entity.Authors)
                {
                    db.EvidencesAuthors.Add(new EvidencesAuthor
                    {
                        FkAuthor = author,
                        FkEvidence = id,
                        Active = true,
                    });
                }

                await db.SaveChangesAsync();

                var evidence = await db.Evidences.Where(e => e.Id == id).FirstOrDefaultAsync();

                response.Success = true;
                response.Code = (int)HttpStatusCode.OK;
                response.Data = evidence;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Code = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }

            return response;
        }

        public Task<BaseResponse<Evidence>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<Evidence>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<Evidence>>> GetAllAsync(Guid idInstallment)
        {
            var response = new BaseResponse<IEnumerable<Evidence>> ();

            try
            {
                var list = await db.Evidences
                    .Where(e => e.Active == true && e.FkInstallment == idInstallment)
                    .Include(e => e.LoadForNavigation)
                    .ToListAsync();

                if (list != null)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Success = true;
                    response.Data = list;
                }
                else
                {
                    response.Success = true;
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "No se encontraron registros";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Code = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
            }

            return response;
        }

        public Task<BaseResponse<Evidence>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Evidence>> UpdateAsync(Evidence entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
