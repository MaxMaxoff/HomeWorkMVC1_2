﻿using HomeWorkMVC1.DAL.Context;
using HomeWorkMVC1.Data;
using HomeWorkMVC1.Domain.Entities;
using HomeWorkMVC1.Domain.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;

namespace HomeWorkMVC1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<HomeWorkMVC1Context>();
                    DbInitializer.Initialize(context);

                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore,
                        new IRoleValidator<IdentityRole>[] { },
                        new UpperInvariantLookupNormalizer(),
                        new IdentityErrorDescriber(), null);
                    if (!roleManager.RoleExistsAsync(Constants.Roles.User).Result)
                    {
                        var role = new IdentityRole(Constants.Roles.User);
                        var result = roleManager.CreateAsync(role).Result;
                    }

                    if (!roleManager.RoleExistsAsync(Constants.Roles.Administrator).Result)
                    {
                        var role = new IdentityRole(Constants.Roles.Administrator);
                        var result = roleManager.CreateAsync(role).Result;
                    }

                    var userStore = new UserStore<User>(context);
                    var userManager = new UserManager<User>(userStore,
                        new OptionsManager<IdentityOptions>(
                            new OptionsFactory<IdentityOptions>(
                                new IConfigureOptions<IdentityOptions>[] { },
                                new IPostConfigureOptions<IdentityOptions>[] { })),
                        new PasswordHasher<User>(), new IUserValidator<User>[] { },
                        new IPasswordValidator<User>[] { },
                        new UpperInvariantLookupNormalizer(),
                        new IdentityErrorDescriber(), null, null);
                    if (userStore.FindByEmailAsync("admin@mail.com", CancellationToken.None).Result == null)
                    {
                        var user = new User() {UserName = "Admin", Email = "admin@mail.com"};
                        var result = userManager.CreateAsync(user, "admin").Result;
                        if (result == IdentityResult.Success)
                        {
                            var roleResult = userManager.AddToRoleAsync(user, Constants.Roles.Administrator).Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();

            //BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
