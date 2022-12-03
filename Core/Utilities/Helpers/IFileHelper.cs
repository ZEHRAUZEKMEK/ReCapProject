using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string Upload(List<IFormFile> formFile, string root);
        void Delete(string filePath);
        string Update(List<IFormFile> formFile, string filePath, string root);

    }
}