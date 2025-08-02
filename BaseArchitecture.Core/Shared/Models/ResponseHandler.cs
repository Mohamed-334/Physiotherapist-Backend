using System.Net;

namespace BaseArchitecture.Core.Shared.Models
{
    public class ResponseHandler
    {

        public ResponseHandler() { }
        public Response<T> Deleted<T>(string? msg)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = msg ?? "Deleted Successfully"
            };
        }
        public Response<T> Success<T>(T entity, string? msg = null, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = msg ?? "Success",
                Meta = Meta
            };
        }
        public Response<T> Unauthorized<T>(string? msg = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = msg ?? "UnAuthorized"
            };
        }
        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }
        public Response<T> UnprocessableContent<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableContent,
                Succeeded = false,
                Message = Message == null ? "Validation Error" : Message
            };
        }
        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Response<T> Created<T>(T entity, string? msg = null, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = msg ?? "Created Successfully",
                Meta = Meta
            };
        }
    }
}
