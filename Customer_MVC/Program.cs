using Customer_MVC.Services;
using Microsoft.EntityFrameworkCore;

namespace Customer_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Add service Products
            builder.Services.AddSingleton<IServiceCustomers, ServiceCustomers>();
            builder.Services.AddDbContext<CustomerContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }
                );
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );


            app.Run();
        }
    }
}
