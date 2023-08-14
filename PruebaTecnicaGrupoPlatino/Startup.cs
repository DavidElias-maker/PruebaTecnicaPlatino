using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Models;
using PruebaTecnicaGrupoPlatino.Services.AlumnoServices;
using PruebaTecnicaGrupoPlatino.Services.AulaServices;
using PruebaTecnicaGrupoPlatino.Services.ClaseServices;
using PruebaTecnicaGrupoPlatino.Services.MaestroServices;
using System.Text.Json.Serialization;

namespace PruebaTecnicaGrupoPlatino
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddScoped<CorrelativoAlm>();
            services.AddScoped<CorrelativoMae>();
            services.AddScoped<CorrelativoAu>();
            services.AddScoped<IAlumnoService, AlumnoService>();
            services.AddScoped<IAulaService, AulaService>();
            services.AddScoped<IClaseService, ClaseService>();
            services.AddScoped<IMaestroService, MaestroService>();
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }

    
}
