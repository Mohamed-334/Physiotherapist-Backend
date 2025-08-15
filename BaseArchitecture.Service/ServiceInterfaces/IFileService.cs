using Microsoft.AspNetCore.Http;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IFileService
    {
        Task<string> UploadImage(string DirectorName, IFormFile file);
    }
}
