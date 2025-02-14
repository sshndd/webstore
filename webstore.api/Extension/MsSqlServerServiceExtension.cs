using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using webstore.api.Data;
using webstore.api.Migrations;
using webstore.api.Model;

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

        public static void AddMsSqlServerIdentityContext(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
