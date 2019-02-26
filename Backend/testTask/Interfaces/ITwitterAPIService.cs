using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testTask.Interfaces
{
    public interface ITwitterAPIService:ISocialWebService
    {
        void MakeTwitt(string message);
        Task MakeTwittAsync(string message);
    }
}
