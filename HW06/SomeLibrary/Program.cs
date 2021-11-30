using Autofac;

namespace MyLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Scanner>().As<IScanner>();
            builder.RegisterType<ScanManager>().AsSelf();

            IContainer container = builder.Build();
            var scanner = container.Resolve<IScanner>();
            var scanManager = container.Resolve<ScanManager>();

            scanner.Attach(scanManager);

            var a = scanner.Scan();

            // вызовы метода для иммитации изменения состояния процессора и оперативной памяти
            for (int i = 0; i < 10; i++)
            {
                scanner.ChangeLoadState();
            }

            scanManager.SaveAsJpg(a);
            scanManager.SaveAsBmp(a);
        }
    }
}
