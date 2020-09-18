﻿using Autofac;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
            
            Console.ReadLine();
        }
    }
}
