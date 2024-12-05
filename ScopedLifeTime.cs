using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet
{
    public interface IScoped
    {
        void GetData();
        Guid guid();
    }

    public interface ITranisent
    {
        public Guid _guid { get; }
    }

    public class EmployeeDetails : IScoped
    {
        Guid _guid = Guid.NewGuid();
        public void GetData()
        {
            Console.WriteLine("Data fetched from DB");
        }
        public Guid guid()
        {
            return _guid;
        }
    }


    public class OrderDetails : ITranisent
    {
        public Guid _guid { get; set; }

        public OrderDetails()
        {
            _guid = Guid.NewGuid();
        }
        public Guid guid()
        {
            return _guid;
        }
    }

    public class ScopedClient
    {
        IScoped scoped;
        public ScopedClient(IScoped scoped)
        {
            this.scoped = scoped;
        }
        public void Print()
        {
            scoped.GetData();
        }
        public Guid guid()
        {
            return scoped.guid();
        }

    }

    public class TransientClient
    {
        ITranisent transient;

        public TransientClient(ITranisent transient)
        {
            this.transient = transient;
        }

        public Guid GetInstance()
        {
            return transient._guid;
        }
    }

    internal class ScopedLifeTime
    {
        public static void Main(string[] args)
        {
            var Services = new ServiceCollection()
                .AddScoped<IScoped, EmployeeDetails>()
                .AddScoped<ScopedClient>()
                .AddTransient<ITranisent, OrderDetails>()
                .AddTransient<TransientClient>()
                .BuildServiceProvider();

            using (var scope = Services.CreateScope())
            {
                // Resolve ScopedClient within the scope
                var GetService = scope.ServiceProvider.GetService<ScopedClient>();
                var GetService2 = scope.ServiceProvider.GetService<ScopedClient>();

                GetService.Print();
                Guid instanceId = GetService.guid();
                Guid instanceId1 = GetService2.guid();

                Console.WriteLine("Scoped Service GUIDs:");
                Console.WriteLine(instanceId);
                Console.WriteLine(instanceId1);

                Console.WriteLine("Transient Service GUIDs:");
                var TransientService1 = scope.ServiceProvider.GetService<TransientClient>();
                var TransientService2 = scope.ServiceProvider.GetService<TransientClient>();
                var TransientId1 = TransientService1.GetInstance();
                var TransientId2 = TransientService2.GetInstance();

                Console.WriteLine(TransientId1 == TransientId2);
                Console.WriteLine(TransientId1);
                Console.WriteLine(TransientId2);
            }

            Console.WriteLine();

            using (var scope = Services.CreateScope())
            {
                // Resolve ScopedClient within the new scope
                var GetService = scope.ServiceProvider.GetService<ScopedClient>();
                var GetService2 = scope.ServiceProvider.GetService<ScopedClient>();

                GetService.Print();
                Guid instanceId = GetService.guid();
                Guid instanceId1 = GetService2.guid();

                Console.WriteLine("Scoped Service GUIDs (new scope):");
                Console.WriteLine(instanceId);
                Console.WriteLine(instanceId1);

                Console.WriteLine("Transient Service GUIDs (new scope):");
                var TransientService = scope.ServiceProvider.GetService<TransientClient>();
                var TransientService2 = scope.ServiceProvider.GetService<TransientClient>();
                var TransientId1 = TransientService.GetInstance();
                var TransientId2 = TransientService2.GetInstance();
                Console.WriteLine(TransientId1);
                Console.WriteLine(TransientId2);
            }
        }


    }
}
