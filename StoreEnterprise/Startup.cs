using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StoreEnterprise
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Construtor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Configuração dos serviços (DI)
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona suporte a controllers com views (MVC)
            services.AddControllersWithViews();

            // Exemplo: adicionar sessão
            services.AddSession();

            // Exemplo: adicionar CORS
            services.AddCors(options =>
            {
                options.AddPolicy("PermitirTudo",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            // Exemplo: adicionar DbContext
            // services.AddDbContext<SeuDbContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // Configuração do pipeline HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("PermitirTudo");

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}