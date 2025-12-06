public class Program
{
    public static void Main(string[] args)
    {
        //CreateHostBuilder(args).Build().Run();

        var builder = WebApplication.CreateBuilder();

        // ConfigureServices => builder.Services

        var app = builder.Build();

        #region Configure
        if (app.Environment.IsDevelopment())
        {
            // ...
        }

        app.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Hello World!");
        });

        #endregion

        app.Run();
    }

    //public static IHostBuilder CreateHostBuilder(string[] args) =>
    //    Host.CreateDefaultBuilder(args)
    //        .ConfigureWebHostDefaults(webBuilder =>
    //        {
    //             webBuilder.UseStartup<Startup>();
    //        });
}