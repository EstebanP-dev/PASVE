using Microsoft.EntityFrameworkCore;
using PASVE.Models;

namespace PASVE.Services
{
    public class LoginService
    {
        PASVEContext db = new PASVEContext();

        public async Task<AuthorizationResponse<User>> LoginAsync(Credentials credentials)
        {
            var response = new AuthorizationResponse<User>();

            try
            {
                var auth = await db.Users
                    .AnyAsync(u => u.Email == credentials.Email
                    && u.Password == credentials.Password);

                if (auth)
                {
                    var user = await db.Users.Where(u => u.Email == credentials.Email
                        && u.Password == credentials.Password)
                    .Include(u => u.UserType)
                    .FirstOrDefaultAsync();
                    user.Password = "";
                    response.Authorized = true;
                    response.Response = user;
                    GlobalVariables.UserInfo = user;
                }
                else
                {
                    response.Authorized = false;
                    response.Message = "El correo o la contraseña, son erroneos.";
                }

            }
            catch (Exception ex)
            {
                response.Authorized = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
