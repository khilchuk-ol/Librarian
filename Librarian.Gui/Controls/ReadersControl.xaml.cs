﻿using Librarian.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Librarian.Gui.Controls
{
    /// <summary>
    /// Interaction logic for ReadersControl.xaml
    /// </summary>
    public partial class ReadersControl : UserControl
    {
        public ReadersControl()
        {
            InitializeComponent();
            SizeChanged += OnWindowSizeChanged;
        }

        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var vm = (ReadersViewModel)DataContext;
            vm.AmountToDisplay = (int)((e.NewSize.Height - 60) / 40);
        }
    }
}
