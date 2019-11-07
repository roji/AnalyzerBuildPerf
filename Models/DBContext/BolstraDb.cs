
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bolstra.Api.Models.DBContext
{
    public partial class BolstraDb : DbContext
    {
        private IConfiguration configuration;

        public BolstraDb(DbContextOptions<BolstraDb> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
    }
}
