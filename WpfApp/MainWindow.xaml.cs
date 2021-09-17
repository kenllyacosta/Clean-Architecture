using Application.Queries.Products;
using IoC;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMediator? Mediator;
        public MainWindow()
        {
            InitializeComponent();
            Mediator = ConfigureServices(new ServiceCollection(), Configure()).GetService<IMediator>();

            MessageBox.Show(Mediator.Send(new GetProductQuery(x => x.Id == 2)).Result.Name);
        }

        private static IConfiguration Configure()
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        private static ServiceProvider ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMediatR(Assembly.Load("Application"));
            services.AddRepositories(Configuration);

            return services.BuildServiceProvider();
        }
    }
}
