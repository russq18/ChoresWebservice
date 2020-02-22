using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoresAPI.Authentication
{
    public interface IGetAllApiKeys
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
