using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testTask.Configure;
using testTask.Interfaces;

namespace testTask.Services
{
    public class LocalFileStorage : IFileStorageService
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IOptions<AppOptions> _appOptions;
        public LocalFileStorage(IOptions<AppOptions> appOptions, IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _appOptions = appOptions;
        }

        public async Task<string> Save(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split('.').Last();
            var path = _appOptions.Value.SaveFilePath + fileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
