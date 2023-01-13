using Authentication.Models;
using Authentication.Repository.Abstractions;
using Authentication.Repository.Implementations;
using Authentication.Services.Abstraction;
using Authentication.Services.Implementation;
using Authentication.WebApp.MappingProfiles;
using AutoMapper;
using JWTUtil;
using JWTUtil.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Authentication.WebApp.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositorices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureJWTToken(this IServiceCollection services)
        {
            services.AddTransient<ICreateJWTToken, CreateJWTToken>();

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString:JWTAuthenticationWebAppDB").Value;
            services.AddDbContext<AuthenticationDBContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection ConfigureJWT(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jWTTokenConfiguration = configuration.GetSection("JWTToken"); // Json JWTToken
            services.Configure<JWTToken>(jWTTokenConfiguration); // class JWTToken

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            return services;
        }
    }
}