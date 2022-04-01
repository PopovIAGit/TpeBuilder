using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TpeParameters.Helpers;
using System.Collections.ObjectModel;

namespace TpeBuilder.Model
{
    public class TpeGroup : ModelBase
    {
        public TpeGroup(int id)
        {
            _id = id;
            _name = "Новая группа";
            _groupType = GroupTypes.None;
            _description = "";
            _groupIndex = "";
            _tpeParameters = null; 
        }


        #region Fields

        private int _id;
        private string _name;
        private GroupTypes _groupType;
        private string _description;
        private string _groupIndex; // буква привязана к группе (А, В, С и тд для автозаполнения параметров)
        private ObservableCollection<TpeParameter> _tpeParameters;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public GroupTypes GroupType
        {
            get { return _groupType; }
            set
            {
                _groupType = value;
                NotifyPropertyChanged("GroupType");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string GroupIndex
        {
            get { return _groupIndex; }
            set
            {
                _groupIndex = value;
                NotifyPropertyChanged("GroupIndex");
            }
        }

        public ObservableCollection<TpeParameter> TpeParameters
        {
            get { return _tpeParameters; }
            set
            {
                _tpeParameters = value;
                NotifyPropertyChanged("TpeParameters");
            }
        }


        #endregion



    }
}
