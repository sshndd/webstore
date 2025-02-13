using Microsoft.EntityFrameworkCore;
using webstore.api.Data;

namespace webstore.api.Extension
{
    public static class MsSqlServerServiceExtension
    {
        public static void AddMsSqlServerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MsSQLServerConnection"));
            });
        }
    }
}
