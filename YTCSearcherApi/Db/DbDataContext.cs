using Microsoft.EntityFrameworkCore;
using YTCSearcherApi.Models;

namespace YTCSearcherApi.Db
{
    public class DbDataContext : DbContext
    {
        public DbSet<RequestModel> Requests { get; set; }

        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options) { }
    }
}
