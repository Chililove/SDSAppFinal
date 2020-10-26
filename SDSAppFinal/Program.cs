using Microsoft.Extensions.DependencyInjection;
using SDS.Core.ApplicationService;
using SDS.Core.ApplicationService.Service;
using SDS.Core.DomainService;
using SDS.Infrastructure.Data;
using SDS.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDSAppFinal
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IAvatarRepository, AvatarRepo>();
            serviceCollection.AddScoped<IAvatarService, AvatarService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var avatarRepo = serviceProvider.GetRequiredService<IAvatarRepository>();
            var Printer = serviceProvider.GetRequiredService<IPrinter>();
            new DBInitializer(avatarRepo).InitData;
           



            IAvatarRepository aRepo = new AvatarRepo();

            DBInitializer db = new DBInitializer(aRepo);
            db.InitData(); // Mock data
            IAvatarService aService = new AvatarService(aRepo);
            IPrinter print = new Printer(aService);
            Console.WriteLine("Hello fellow Seven Deadly Sins maniac!");

            Console.WriteLine("Welcome to SDS\nBegin your adventure by choosing an option in the menu");
            print.StartUI();
        }
    }
}
