using Microsoft.EntityFrameworkCore;
using PASVE.Interfaces;
using PASVE.Models;
using System.Net;

namespace PASVE.Services
{
    public class GeneralService
    {
        PASVEContext db = new PASVEContext();

        public async Task<BaseResponse<IEnumerable<Chapter>>> GetChaptersAsync()
        {
            var response = new BaseResponse<IEnumerable<Chapter>>();

            try
            {
                var list = await db.Chapters
                    .Where(c => c.Active == true)
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
                    response.Message = "Error en la información al intentar cargar los datos.";
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
        public async Task<BaseResponse<IEnumerable<Article>>> GetArticlesAsync()
        {
            var response = new BaseResponse<IEnumerable<Article>>();

            try
            {
                var list = await db.Articles
                    .Where(c => c.Active == true)
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
                    response.Message = "Error en la información al intentar cargar los datos.";
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
        public async Task<BaseResponse<IEnumerable<Paragraph>>> GetParagraphsAsync()
        {
            var response = new BaseResponse<IEnumerable<Paragraph>>();

            try
            {
                var list = await db.Paragraphs
                    .Where(c => c.Active == true && c.FkParagraph == null)
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
                    response.Message = "Error en la información al intentar cargar los datos.";
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
        public async Task<BaseResponse<IEnumerable<Section>>> GetSectionsAsync()
        {
            var response = new BaseResponse<IEnumerable<Section>>();

            try
            {
                var list = await db.Sections
                    .Where(c => c.Active == true)
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
                    response.Message = "Error en la información al intentar cargar los datos.";
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
        public async Task<BaseResponse<IEnumerable<Numeral>>> GetNumeralsAsync()
        {
            var response = new BaseResponse<IEnumerable<Numeral>>();

            try
            {
                var list = await db.Numerals
                    .Where(c => c.Active == true)
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
                    response.Message = "Error en la información al intentar cargar los datos.";
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
    }
}
