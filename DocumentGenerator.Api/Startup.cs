using DocumentGenerator.Api.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentGenerator.Api.Services;
using DocumentGenerator.Api.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentGenerator
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
            services.AddControllers();
            services.AddCors(options =>
           {
               options.AddPolicy("AllowAnyOrigin", police => police.AllowAnyOrigin());
               options.AddPolicy("AllowAnyMethod", police => police.AllowAnyMethod());
           });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DocumentGenerator", Version = "v1" });
            });
            services.AddDbContext<AppDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ILogRegisterService, LogRegisterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseService database)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentGenerator v1"));
            }
            database.BackupDataBase(Configuration.GetConnectionString("DefaultConnection"));

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
