using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Module.Core.Extensions
{
    public static class StaticFilesExtensions
    {

        public static IApplicationBuilder UseStaticFilesService(this IApplicationBuilder app)
        {

            var dir = Path.Combine(ProjectManager.StoragePath);
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch
                {

                }

            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(dir)),
                RequestPath = $"/UserContents"
            });
            return app;
        }

    }
}
