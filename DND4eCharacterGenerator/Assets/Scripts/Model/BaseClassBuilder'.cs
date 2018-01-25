using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    class BaseClassBuilder_ : INotifyPropertyChanged
    {
        #region Fields
        private string _build;
        #endregion

        #region Properties
        public string Build
        {
            get
            {
                return _build;
            }
            set
            {
                _build = value;
                NotifyPropertyChanged("Build");
            }
        }
        #endregion

        #region Constructors
        public BaseClassBuilder_()
        {

        }
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
