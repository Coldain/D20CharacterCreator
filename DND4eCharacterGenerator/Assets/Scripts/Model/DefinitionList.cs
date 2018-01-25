using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class DefinitionList : INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private List<string> _mainList;
        private List<string> _description;
        private List<string> _subList;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public List<string> MainList
        {
            get
            {
                return _mainList;
            }
            set
            {
                _mainList = value;
                NotifyPropertyChanged("MainList");
            }
        }
        public List<string> Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public List<string> SubList
        {
            get
            {
                return _subList;
            }
            set
            {
                _subList = value;
                NotifyPropertyChanged("SubList");
            }
        }
        #endregion

        #region Constructors

        #endregion

        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}