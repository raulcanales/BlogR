﻿using BlogR.Core.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogR.Data.EntityFramework.MSSQL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlogR(this IServiceCollection services, string sectionName = "BlogR")
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
                configuration = serviceProvider.GetRequiredService<IConfiguration>();

            var settings = new MSSQLBlogRSettings();
            configuration.GetSection(sectionName).Bind(settings);
            settings.ValidateSettings();

            services.AddDbContext<DbContext, MSSQLDbContext>(options =>
            {
                options.UseSqlServer(settings.GetConnectionString());
            });

            services.AddMediatR(Assembly.Load("BlogR.Core"));
            services.AddScoped<IPostRepository, PostRepository>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
