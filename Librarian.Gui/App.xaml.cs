using Librarian.Domain.Services.Abstract;
using Librarian.Gui.App_Start;
using Librarian.Gui.ViewModels;
using Librarian.Mappers.Abstract;
using System.Windows;
using Unity;

namespace Librarian.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = UnityConfig.Container;

            MainWindow main = new MainWindow();
            MainViewModel context = new MainViewModel(container.Resolve<IBookService>(), container.Resolve<IAuthorService>(), container.Resolve<IBookMapper>());
            main.DataContext = context;
            main.Show();
        }

    }
}
