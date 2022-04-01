using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TpeParameters.Model;
using System.Windows;
using TpeBuilder.Model;
using System.Collections.ObjectModel;
using System.Reflection;
using TpeBuilder.Events;
using TpeBuilder.Helpers;

namespace TpeBuilder.ViewModel
{
    public class TableTreeViewModel : ViewModelBase
    {
        public TableTreeViewModel()
        {
            Storage.Data.Instance.OnDataChanged += DataChangedEventHandler;

            CurrentTpeTable = Storage.Data.Instance.CurrentTpeTable;
            
        }

        private void DataChangedEventHandler(object sender, EventArgs e)
        {
            CurrentTpeTable = Storage.Data.Instance.CurrentTpeTable;
            CurrentTpeGroup = Storage.Data.Instance.CurrentTpeGroup;
       
        }

        public void TreeViewItemSelected(object item)
        {
            /*
            TpeModelTypes tpeModelType = TpeModelTypes.None;

            if (t.FullName.Contains(TpeModelTypes.TpeTable.ToString()))
            {
                tpeModelType = TpeModelTypes.TpeTable;
            }
            else if (t.FullName.Contains(TpeModelTypes.TpeGroup.ToString()))
            {
                tpeModelType = TpeModelTypes.TpeGroup;
            }
            else if (t.FullName.Contains(TpeModelTypes.TpeParameter.ToString()))
            {
                tpeModelType = TpeModelTypes.TpeParameter;
            }
            */

            Storage.Data.Instance.RaiseOnTreeViewItemSelected(this, new TreeViewItemSelectedEventArgs(item));

        }

        public void SortParamAuto()
        {
               int count = _currentTpeTable[0].TpeGroups.Count;

                if (count < 1)
                    return;

                ObservableCollection<TpeParameter> sort = new ObservableCollection<TpeParameter>(CurrentTpeGroup.TpeParameters.OrderBy(x => x.Address));

                CurrentTpeGroup.TpeParameters = sort;

            

        }

     


        private TpeGroup _currentTpeGroup;
        public TpeGroup CurrentTpeGroup
        {
            get { return _currentTpeGroup; }
            set
            {
                _currentTpeGroup = value;
                NotifyPropertyChanged("TpeGroups");
            }
        }

        private ObservableCollection<TpeTable> _currentTpeTable;
        public ObservableCollection<TpeTable> CurrentTpeTable
        {
            get { return _currentTpeTable; }
            set
            {
                _currentTpeTable = value;
                NotifyPropertyChanged("CurrentTpeTable");
            }
        }
    }



}
