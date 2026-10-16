using AirportOpsMVC.Data;
using AirportOpsMVC.Implementation;
using AirportOpsMVC.Interface;
using AirportOpsMVC.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AirportOpsMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AirportDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Air")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(
                GenericRepository<>));
            builder.Services.AddScoped<IAirportService, AirportService>();
            builder.Services.AddScoped<IAirlineService, AirlineService>();
            builder.Services.AddScoped<ITerminalService, TerminalService>();
            builder.Services.AddScoped<ITerminalGateService, TerminalGateService>();
           
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores
                <AirportDbContext>().AddDefaultTokenProviders();

           
            builder.Services.AddAuthentication().AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT:Key"))
                };
            }
            );
            builder.Services.AddScoped<JwtService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
