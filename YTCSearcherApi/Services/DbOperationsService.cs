using YTCSearcherApi.Db;
using YTCSearcherApi.Models;
using System.Threading.Tasks;

namespace YTCSearcherApi.Services
{
    public class DbOperationsService : IDbOperationsService
    {
        public readonly DbDataContext _context;

        public DbOperationsService(DbDataContext context)
        {
            _context = context;
        }

        public async Task Create(RequestDataModel data)
        {
            var request = new RequestModel(data);
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
    }
}