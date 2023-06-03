using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection Services)
        {
            var MySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            Services.AddDbContextPool<DatabaseContext>(options => options.UseMySql(MySqlConnectionStr, ServerVersion.AutoDetect(MySqlConnectionStr)));
        }
    }
}
