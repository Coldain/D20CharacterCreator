using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Roles : INotifyPropertyChanged
    {
        #region Fields
        private string _role;
        private string _description;
        private string _pick;
        #endregion

        #region Properties
        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                NotifyPropertyChanged("Role");
            }
        }
        public string Description
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
        public string Pick
        {
            get
            {
                return _pick;
            }
            set
            {
                _pick = value;
                NotifyPropertyChanged("Pick");
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
