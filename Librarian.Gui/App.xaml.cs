using Librarian.Gui.App_Start;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels;
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
            MainViewModel context = new MainViewModel(container.Resolve<IBookModelService>(), 
                                                      container.Resolve<IAuthorModelService>(), 
                                                      container.Resolve<IReaderModelService>(),
                                                      container.Resolve<IRecordModelService>());
            main.DataContext = context;
            main.Show();
        }

    }
}
