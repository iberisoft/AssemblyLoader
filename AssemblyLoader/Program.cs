using Autofac;
using Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AssemblyLoader
{
    static class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dict = config.Get<Dictionary<string, Entry>>();
            DoWork(dict["default"]);
            DoWork(dict["optional"]);
        }

        private static void DoWork(Entry entry)
        {
            var assembly = Assembly.LoadFrom(Path.Combine(@"..\..\..\..\ClassLibraryBin\net5.0", entry.AssemblyName));
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyOpenGenericTypes(assembly).Where(type => type.Name.Split('`')[0] == entry.TypeName).As(typeof(IGreetings<>));
            using var container = builder.Build();
            var obj = container.Resolve<IGreetings<string>>();
            Console.WriteLine(obj.Print("xyz"));
        }
    }
}
