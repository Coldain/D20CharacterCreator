using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class SubRaces : INotifyPropertyChanged
    {
        #region Fields
        private string _subRace;
        private string _description;
        #endregion

        #region Properties
        public string SubRace
        {
            get
            {
                return _subRace;
            }
            set
            {
                _subRace = value;
                NotifyPropertyChanged("SubRace");
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
        #endregion

        #region Constructors
        public SubRaces()
        {
            _subRace = "Subrace";
            _description = "";
        }
        public SubRaces(string race_subrace_subRace, string race_subrace_description)
        {
            _subRace = race_subrace_subRace;
            _description = race_subrace_description;
        }
        #endregion

        #region Methods              

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        #endregion
    }
}
