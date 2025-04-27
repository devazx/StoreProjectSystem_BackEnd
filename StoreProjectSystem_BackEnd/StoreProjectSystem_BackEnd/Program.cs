
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StoreProjectSystem_BackEnd.Authorization;
using StoreProjectSystem_BackEnd.Data;
using StoreProjectSystem_BackEnd.Models;
using StoreProjectSystem_BackEnd.Services;
using System.Reflection;

namespace StoreProjectSystem_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("UserConnection");

            builder.Services.AddDbContext<StorageContext>(Opt => Opt.UseMySql(connString, ServerVersion.AutoDetect(connString)));

            builder.Services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<StorageContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSingleton<IAuthorizationHandler, HiredAuthorization>();

            builder.Services.AddControllers().AddNewtonsoftJson();

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreProjectSystem API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<EndProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
