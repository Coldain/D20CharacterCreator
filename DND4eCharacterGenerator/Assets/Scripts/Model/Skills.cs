using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Skills : INotifyPropertyChanged
    {
        #region Fields
        private string _skill;
        private string _definition;
        private string _ability;
        #endregion

        #region Properties
        public string Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
                NotifyPropertyChanged("Skill");
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
