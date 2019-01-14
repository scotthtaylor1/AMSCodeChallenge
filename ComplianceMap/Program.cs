using System;
using Microsoft.Extensions.DependencyInjection;
using Contracts;
using Implementations;

namespace ComplianceMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IInputService, ReadInput>()
                .AddSingleton<IComplianceMapService, ComplianceMapping>()
                .BuildServiceProvider();

            var readIn = serviceProvider.GetService<IInputService>();

            //testing only
            //string[] file = { @"large-test.txt"};

            readIn.ReadDataIn(args); //should be passing args, if args.length = 0, user input, otherwise file input
        }
    }
}
