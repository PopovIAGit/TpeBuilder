﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TpeBuilder.ViewModel;

namespace TpeBuilder.Views
{
    /// <summary>
    /// Interaction logic for TableTreeView.xaml
    /// </summary>
    public partial class TableTreeView : UserControl
    {
        public TableTreeView()
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
                {
                    _dataContext = (TableTreeViewModel)DataContext;
                };
        }

        private TableTreeViewModel _dataContext;

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _dataContext.TreeViewItemSelected(e.NewValue);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _dataContext.SortParamAuto();
        }

        private void MenuAddParam_Click(object sender, RoutedEventArgs e)
        {
          //  _dataContext.AddParam();
        }

        private void MenuDelParam_Click(object sender, RoutedEventArgs e)
        {
           // _dataContext.DelParam();
        }
    }
}
