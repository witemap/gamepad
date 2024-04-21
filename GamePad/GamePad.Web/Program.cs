using GamePad.Web.Components;
using GamePad.Web.Components.Games;
using Microsoft.AspNetCore.ResponseCompression;

namespace GamePad.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Add Games
            builder.Services.AddScoped<EmptyGame1>();
            builder.Services.AddScoped<EmptyGame2>();
            builder.Services.AddScoped<TanksTutorial>();

            ConfigureResponseCompression(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }

        private static void ConfigureResponseCompression(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;  // Enable compression for HTTPS connections
                options.Providers.Add<GzipCompressionProvider>();  // Use Gzip compression
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                "text/plain",
                "text/html",
                "text/css",
                "application/javascript",
                "text/javascript",
                "application/xml",
                "text/xml",
                "application/json",
                "text/json",
                "image/svg+xml",
                "image/png",
                "image/jpeg",
                "image/gif",
                "application/wasm",          // Unity WebGL WebAssembly
                "application/octet-stream",  // Unity WebGL Data Files
                "application/x-msdownload",  // Unity WebGL Data Files
                });
            });

            // Other service configurations...
        }
    }
}
