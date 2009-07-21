using System.Windows;
using Autofac.Builder;

namespace Tyler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterTypesAssignableTo<Window>().FactoryScoped();
            using (var container = builder.Build())
            {
                var gameWindow = container.Resolve<GameWindow>();
                gameWindow.Show();
            }
        }
    }
}
