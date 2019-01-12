// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyFirstEfCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>()
                    .AddTransient<Commands>();
            var serviceProvider = services.BuildServiceProvider();
            Console.WriteLine(
                "Commands: l (list), u (change url), s (show sql schema), r (resetDb) and e (exit) - add -l to first two for logs");
            Console.Write(
                "Checking if database exists... ");
            using (var scope = serviceProvider.CreateScope())
            {
                var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                Console.WriteLine(commands.WipeCreateSeed(true) ? "created database and seeded it." : "it exists.");
            }
            do
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "s":
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                            commands.GetSchemaSql();
                        }
                        break;
                    case "l":
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                            commands.ListAll();
                        }
                        break;
                    case "u":
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                            commands.ChangeWebUrl();
                        }
                        break;
                    case "l -l":
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                            commands.ListAllWithLogs();
                        }
                        break;
                    case "u -l":
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                            commands.ChangeWebUrlWithLogs();
                        }
                        break;
                    case "r":
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var commands = scope.ServiceProvider.GetRequiredService<Commands>();
                            commands.WipeCreateSeed(false);
                        }
                        break;
                    case "e":
                        return;
                    default: 
                        Console.WriteLine("Unknown command.");
                        break;
                }
            } while (true);
        }
    }
}
