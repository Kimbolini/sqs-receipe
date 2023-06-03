using backend.Models;
using Microsoft.EntityFrameworkCore;
using log4net;

namespace backend
{
    public class Startup
    {
        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(builder =>
            {
            builder.AddLog4Net();
        });*/

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
