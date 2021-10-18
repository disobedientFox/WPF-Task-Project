using Autofac;
using Prism.Events;
using TestApp.DataAccess;
using TestApp.UI.DataService;
using TestApp.UI.ViewModel;

namespace TestApp.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<TestAppDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<EmployeDataService>().As<IEmployeDataService>();
            builder.RegisterType<EmployeDetailViewModel>().As<IEmployeDetailViewModel>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
