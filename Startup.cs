using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using AtlasP.Data;
using AtlasP.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AtlasP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string conexao = Configuration.GetConnectionString("Conexao");
            services.AddDbContext<Contexto>(options =>
                options.UseMySql(conexao, ServerVersion.AutoDetect(conexao)));
            services.AddIdentity<User, IdentityRole>(
                options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Contexto>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Compressao de respostas (Brotli/Gzip) - acarrega paginas mais rapido
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes
                    .Concat(new[] { "image/svg+xml", "application/javascript", "text/css" });
            });
            services.Configure<BrotliCompressionProviderOptions>(o => o.Level = CompressionLevel.Fastest);
            services.Configure<GzipCompressionProviderOptions>(o => o.Level = CompressionLevel.Fastest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            // Compressao antes de servir arquivos estaticos
            app.UseResponseCompression();

            // Cache de 7 dias para assets estaticos (imagens/css/js)
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers["Cache-Control"] = "public, max-age=604800";
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            // Cria o schema do banco (tabelas + Identity) na primeira execução.
            // O projeto não tem migrations, então usamos EnsureCreated().
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var contexto = scope.ServiceProvider.GetRequiredService<Contexto>();
                contexto.Database.EnsureCreated();
            }
        }
    }
}
