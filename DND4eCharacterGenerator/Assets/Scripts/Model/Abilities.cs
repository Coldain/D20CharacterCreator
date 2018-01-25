using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Abilities : INotifyPropertyChanged
    {
        #region Fields
        private string _ability;
        private string _definition;
        private string _shorthand;
        #endregion

        #region Properties
        public string Ability
        {
            get
            {
                return _ability;
            }
            set
            {
                _ability = value;
                NotifyPropertyChanged("Ability");
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