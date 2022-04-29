using System;
using PASVE.Models;
using PASVE.Interfaces;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace PASVE.Services
{
    public class InstallmentService : IGenericService<Installment, Guid>
    {
        PASVEContext db = new PASVEContext();

        public Task<BaseResponse<Installment>> CreateAsync(Installment entity)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Installment>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<Installment>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<Installment>>> GetAllAsync(Guid idUser)
        {
            var response = new BaseResponse<IEnumerable<Installment>>();

            try
            {
                var project = db.ProjectsClassesUsers.Where(pcu => pcu.FkUser == idUser).FirstOrDefault();

                if(project != null)
                {
                    var list = await db.Installments
                        .Where(i => i.FkProject == project.FkProject)
                        .Include(i => i.Project)
                        .ToListAsync();

                    if (list != null)
                    {
                        response.Code = (int)HttpStatusCode.OK;
                        response.Success = true;
                        response.Data = list;
                    }
                    else
                    {
                        response.Success = false;
                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = "Error de conección y obtención de datos";
                    }
                }
                else
                {
                    response.Success = true;
                    response.Code = (int)HttpStatusCode.NotFound;
                    response.Message = "No se encontraron datos";
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

        public Task<BaseResponse<Installment>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Installment>> UpdateAsync(Installment entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
