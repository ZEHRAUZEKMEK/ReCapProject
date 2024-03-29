﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root);
        void Delete(string root);
        string Update(IFormFile file, string filePath, string root);

    }
}