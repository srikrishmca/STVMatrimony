using STVMatrimony.APIModels;
using System.Threading.Tasks;

namespace STVMatrimony.Services
{
    public interface ICommonService
    {
        Task<ApiResponse<T>> GetResponseAsync<T>(string url);
        Task<ApiResponse<T1>> PostResponseAsync<T1, T2>(string url, T2 model);
    }
}
