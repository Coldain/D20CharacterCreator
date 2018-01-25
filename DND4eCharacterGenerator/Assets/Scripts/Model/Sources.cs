using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Sources : INotifyPropertyChanged
    {
        #region Fields
        private string _source;
        private string _definition;
        private string _shorthand;
        #endregion

        #region Properties
        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                NotifyPropertyChanged("Source");
            }
        }
        public string Definition
        {
            get
            {
                return _definition;
            }
            set
            {
                _definition = value;
                NotifyPropertyChanged("Definition");
            }
        }
        public string Shorthand
        {
            get
            {
                return _shorthand;
            }
            set
            {
                _shorthand = value;
                NotifyPropertyChanged("Shorthand");
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
