using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkFree.Areas.Identity.Data;
using WorkFree.Data;

[assembly: HostingStartup(typeof(WorkFree.Areas.Identity.IdentityHostingStartup))]
namespace WorkFree.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WorkFreeContext>(options =>
                    options.UseMySQL(
                        context.Configuration.GetConnectionString("WorkFreeContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WorkFreeContext>();
            });
        }
    }
}