using GalaSoft.MvvmLight.Views;
using Librarian.Gui.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Librarian.Gui.Navigation
{
    public class NavigationService : ViewModel, INavigationService
    {
        #region field
        private Dictionary<string, Uri> _pages;
        private string _currentPageKey;
        private List<string> _history;
        #endregion

        #region properties
        public object Parameter { get; private set; }
        public string CurrentPageKey
        {
            get => _currentPageKey;
            private set
            {
                if (_currentPageKey == value) return;

                _currentPageKey = value;
                OnPropertyChanged(nameof(CurrentPageKey));
            }
        }
        #endregion

        public NavigationService()
        {
            _pages = new Dictionary<string, Uri>();
            _history = new List<string>();
        }

        #region INavigationService members
        public void GoBack()
        {
            if(_history.Count > 1)
            {
                _history.RemoveAt(_history.Count - 1);
                NavigateTo(_history.Last());
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (string.IsNullOrEmpty(pageKey))
                return;

            if (!_pages.ContainsKey(pageKey)) 
                throw new ArgumentException($"No registered page with key '{pageKey}' is found");

            if (GetDescendantFromName(System.Windows.Application.Current.MainWindow, "MainFrame") is Frame frame) frame.Source = _pages[pageKey];
            Parameter = parameter;
            CurrentPageKey = pageKey;
            _history.Add(pageKey);
        }
        #endregion

        private FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1) return null;

            for (var i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name) return frameworkElement;

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null) return frameworkElement;
                }
            }

            return null;
        }

        public void Configure(string key, Uri pageType)
        {
            if(_pages.ContainsKey(key))
            {
                _pages[key] = pageType;
            }
            else
            {
                _pages.Add(key, pageType);
            }
        }
    }
}
