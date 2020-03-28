using System.Threading.Tasks;

namespace ChoresAPI.Authentication
{
    public interface IGetAllApiKeys
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
