namespace DemoMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddControllers(); // API
            builder.Services.AddControllersWithViews(); // MVC

            var app = builder.Build();

            app.UseStaticFiles(); // wwwroot

            // Minimal API
            // app.MapGet("/", () => "Hello World!");

            app.MapControllerRoute(
                name: "Default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}");

            app.Run();
        }
    }
}