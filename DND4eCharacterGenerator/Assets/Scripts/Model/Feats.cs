using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Feats : INotifyPropertyChanged
    {
        #region Fields
        private string _feat;
        private string _source;
        private string _benefit;
        private List<string> _prerequisites;
        private List<string> _prerequisitesTypes;
        #endregion

        #region Properties
        public string Feat
        {
            get
            {
                return _feat;
            }
            set
            {
                _feat = value;
                NotifyPropertyChanged("Feat");
            }
        }
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
        public string Benefit
        {
            get
            {
                return _benefit;
            }
            set
            {
                _benefit = value;
                NotifyPropertyChanged("Benefit");
            }
        }
        public List<string> Prerequisites
        {
            get
            {
                return _prerequisites;
            }
            set
            {
                _prerequisites = value;
                NotifyPropertyChanged("Prerequisites");
            }
        }
        public List<string> PrerequisitesTypes
        {
            get
            {
                return _prerequisitesTypes;
            }
            set
            {
                _prerequisitesTypes = value;
                NotifyPropertyChanged("PrerequisitesTypes");
            }
        }
        #endregion

        #region Constructors
        public Feats()
        {
            Feat = "Feat";
            Benefit = "Click to pick a Feat";
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
