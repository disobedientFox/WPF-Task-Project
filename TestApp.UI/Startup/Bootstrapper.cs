using Autofac;
using Prism.Events;
using TestApp.DataAccess;
using TestApp.UI.DataService;
using TestApp.UI.Tools;
using TestApp.UI.ViewModel;

namespace TestApp.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<TestAppDbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<EmployeDataService>().As<IEmployeDataService>();
            builder.RegisterType<EditViewModel>().As<IEditViewModel>();
            builder.RegisterType<CSVParser>().As<IDataParser>();

            return builder.Build();
        }
    }
}
