using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SehirApi.Data;
using SehirRehberi.API.Data;
using SehirRehberi.API.Helpers;
using System.Configuration;
using System.Text;

namespace SehirApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Configuration oluþturma ve veritabaný
            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //cloudinary
            builder.Services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

            //key okunmasý için
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("Appsettings:Token").Value);


            //automapper
            builder.Services.AddAutoMapper(typeof(Program));

            //sehrin fotosunun fotonun sehri derlen reference looping hatasý için 
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });


            //Containerda IAppRepo kullanýrsak Apprepo da çalýþtýrmaasý için
            builder.Services.AddScoped<IAppRepository, AppRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

            //jwt 
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //key okuma yukarýda
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}