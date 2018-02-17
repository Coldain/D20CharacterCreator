using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class ClassOption : INotifyPropertyChanged
    {
        #region Fields
        private string _optionName;
        private string _optionDetails;
        private string _optionType;
        private List<string> _optionBenefits;
        private List<string> _optionBenefitTypes;
        #endregion

        #region Properties
        public string OptionName
        {
            get
            {
                return _optionName;
            }
            set
            {
                _optionName = value;
                NotifyPropertyChanged("OptionName");
            }
        }
        public string OptionDetails
        {
            get
            {
                return _optionDetails;
            }
            set
            {
                _optionDetails = value;
                NotifyPropertyChanged("OptionDetails");
            }
        }
        public string OptionType
        {
            get
            {
                return _optionType;
            }
            set
            {
                _optionType = value;
                NotifyPropertyChanged("OptionType");
            }
        }
        public List<string> OptionBenefits
        {
            get
            {
                return _optionBenefits;
            }
            set
            {
                _optionBenefits = value;
                NotifyPropertyChanged("OptionBenefits");
            }
        }
        public List<string> OptionBenefitTypes
        {
            get
            {
                return _optionBenefitTypes;
            }
            set
            {
                _optionBenefitTypes = value;
                NotifyPropertyChanged("OptionBenefitTypes");
            }
        }
        #endregion

        #region Constructors
        public  ClassOption()
        {
            OptionName = "Option";
            OptionDetails = "";
        }
        public ClassOption(string _optionPicked_optionName, string _optionPicked_optionDetails, List<string> _optionPicked_optionBenefits, List<string> _optionPicked_optionBenefitTypes)
        {
            _optionName = _optionPicked_optionName;
            _optionDetails = _optionPicked_optionDetails;
            _optionBenefits = _optionPicked_optionBenefits;
            _optionBenefitTypes = _optionPicked_optionBenefitTypes;
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
