using YTCSearcherApi.Models;
using System.Threading.Tasks;

namespace YTCSearcherApi.Services
{
    public interface IDbOperationsService
    {
        Task Create(RequestDataModel data);
    }
}
