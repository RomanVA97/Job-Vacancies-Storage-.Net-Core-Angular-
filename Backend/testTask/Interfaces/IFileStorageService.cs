using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testTask.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> Save(IFormFile file);
    }
}
