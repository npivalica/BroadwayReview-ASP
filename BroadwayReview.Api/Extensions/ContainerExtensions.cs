using BroadwayReview.Api.Auth;
using BroadwayReview.Application;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.DataAccess;
using BroadwayReview.Implementations.UseCases.Commands;
using BroadwayReview.Implementations.UseCases.Queries;
using BroadwayReview.Implementations.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadwayReview.Api.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddJwt(this IServiceCollection collection, AppSettings settings)
        {
            collection.AddTransient(x =>
            {
                var context = x.GetService<BroadwayReviewContext>();
                var jwtSettings = x.GetService<AppSettings>();

                return new JWTManager(context, jwtSettings.JwtSettings);
            });

            collection.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var request = x.GetService<IHttpContextAccessor>();
                //var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = request.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousUser();
                }

                var user = new JWTUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return user;
            });
        }

        public static void AddUseCases(this IServiceCollection collection)
        {
            collection.AddTransient<IGetAuthorsQuery, EfGetAuthorsQuery>();
            collection.AddTransient<IGetUseCaseLogsQuery, EFGetUseCaseLogsQuery>();
            collection.AddTransient<IGetGenresQuery, EfGetGenresQuery>();
            collection.AddTransient<IGetActorsQuery, EfGetActorsQuery>();
            collection.AddTransient<IGetPlaysQuery, EfGetPlaysQuery>();
            collection.AddTransient<IFindPlayQuery, EfFindPlayQuery>();
            collection.AddTransient<ICreateGenreCommand, EFCreateGenreCommand>();
            collection.AddTransient<ICreateReviewCommand, EFCreateReviewCommand>();
            collection.AddTransient<ICreateActorCommand, EFCreateActorCommand>();
            collection.AddTransient<ICreateAuthorCommand, EFCreateAuthorCommand>();
            collection.AddTransient<ICreatePlayCommand, EFCreatePlayCommand>();
            collection.AddTransient<IUpdateAuthorCommand, EFUpdateAuthorCommand>();
            collection.AddTransient<IUpdatePlayCommand, EFUpdatePlayCommand>();
            collection.AddTransient<IUpdateActorCommand, EFUpdateActorCommand>();
            collection.AddTransient<IUpdateGenreCommand, EFUpdateGenreCommand>();
            collection.AddTransient<IRegisterUserCommand, EFRegisteUserCommand>();
            collection.AddTransient<IUpdateUserUseCaseCommand, EFUpdateUserUseCases>();
            collection.AddTransient<IDeleteAuthorCommand, EFDeleteAuthorCommand>();
            collection.AddTransient<IDeleteActorCommand, EFDeleteActorCommand>();
            collection.AddTransient<IDeleteGenreCommand, EFDeleteGenreCommand>();
            collection.AddTransient<IDeleteReviewCommand, EFDeleteReviewCommand>();
            collection.AddTransient<IDeletePlayCommand, EFDeletePlayCommand>();
            collection.AddTransient<IFindAuthorQuery, EfFindAuthorQuery>();
            collection.AddTransient<IFindGenreQuery, EfFindGenreQuery>();
            collection.AddTransient<IFindActorQuery, EfFindActorQuery>();
            collection.AddTransient<IFindPlayReviewsQuery, EfFindPlayReviewsQuery>();

        }

        public static void AddValidators(this IServiceCollection collection)
        {
            collection.AddTransient<UpdatePlayValidator>();
            collection.AddTransient<CreateUseCaseLogSearchValidator>();
            collection.AddTransient<CreateReviewValidator>();
            collection.AddTransient<CreateAuthorValidator>();
            collection.AddTransient<UpdateActorValidator>();
            collection.AddTransient<CreateGenreValidator>();
            collection.AddTransient<RegisterUserValidator>();
            collection.AddTransient<UpdateAuthorValidator>();
            collection.AddTransient<UpdateGenreValidator>();
            collection.AddTransient<CreatePlayValidator>();
            collection.AddTransient<CreateActorValidator>();
            collection.AddTransient<UpdateUserUseCaseValidator>();
        }

        //public static void AddBroadwayReviewContext(this IServiceCollection collection)
        //{
        //    collection.AddTransient(x =>
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder();

        //        var connection = x.GetService<AppSettings>().ConString;

        //        optionsBuilder.UseSqlServer(connection);
        //        var options = optionsBuilder.Options;
        //        return new BroadwayReviewContext(options);
        //    });
        //}
    }
}
