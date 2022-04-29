using Microsoft.EntityFrameworkCore;
using PASVE.Interfaces;
using PASVE.Models;
using System.Net;

namespace PASVE.Services
{
    public class UserService : IGenericService<User, Guid>
    {
        PASVEContext db = new PASVEContext();

        public Task<BaseResponse<User>> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<User>>();

            try
            {
                var usertype = await db.UserTypes
                    .Where(ut => ut.Name == "ESTUDIANTE")
                    .FirstOrDefaultAsync();

                if(usertype != null)
                {
                    var list = await db.Users
                    .Where(u => u.Active == true
                    && u.FkUserType == usertype.Id)
                    .ToListAsync();

                    if(list != null)
                    {
                        response.Code = (int)HttpStatusCode.OK;
                        response.Success = true;
                        response.Data = list;
                    }
                    else
                    {
                        response.Success = false;
                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = "Error en la información al intentar cargar los usuarios";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Error en la información de los tipos de usuario";
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

        public Task<BaseResponse<User>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> UpdateAsync(User entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
