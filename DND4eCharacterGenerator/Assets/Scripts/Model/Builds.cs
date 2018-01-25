using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class Builds : INotifyPropertyChanged
    {
        #region Fields
        private string _build;
        private string _subclass;
        private string _description;
        private string _feat;
        private string _humanFeat;
        private List<string> _skills;
        private List<string> _atwills;
        private string _encounter;
        private string _daily;
        private string _option;
        private string _shortDescription;
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
        public string Subclass
        {
            get
            {
                return _subclass;
            }
            set
            {
                _subclass = value;
                NotifyPropertyChanged("Subclass");
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
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                _shortDescription = value;
                NotifyPropertyChanged("ShortDescription");
            }
        }
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
        public string HumanFeat
        {
            get
            {
                return _humanFeat;
            }
            set
            {
                _humanFeat = value;
                NotifyPropertyChanged("HumanFeat");
            }
        }
        public List<string> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                NotifyPropertyChanged("Skills");
            }
        }
        public List<string> Atwills
        {
            get
            {
                return _atwills;
            }
            set
            {
                _atwills = value;
                NotifyPropertyChanged("Atwills");
            }
        }
        public string Encounter
        {
            get
            {
                return _encounter;
            }
            set
            {
                _encounter = value;
                NotifyPropertyChanged("Encounter");
            }
        }
        public string Daily
        {
            get
            {
                return _daily;
            }
            set
            {
                _daily = value;
                NotifyPropertyChanged("Daily");
            }
        }
        public string Option
        {
            get
            {
                return _option;
            }
            set
            {
                _option = value;
                NotifyPropertyChanged("Option");
            }
        }
        #endregion

        #region Constructors
        public Builds()
        {
            Build = "Build";
            ShortDescription = "Click to pick a Build";
        }

        public Builds(string class_subclass_build_build, string class_subclass_build_subclass, string class_subclass_build_description, string class_subclass_build_feat, string class_subclass_build_humanFeat, List<string> class_subclass_build_skills, List<string> class_subclass_build_atwills, string class_subclass_build_encounter, string class_subclass_build_daily, string class_subclass_build_option, string class_subclass_build_shortDescription)
        {
            _build = class_subclass_build_build;
            _subclass = class_subclass_build_subclass;
            _description = class_subclass_build_description;
            _feat = class_subclass_build_feat;
            _humanFeat = class_subclass_build_humanFeat;
            _skills = class_subclass_build_skills;
            _atwills = class_subclass_build_atwills;
            _encounter = class_subclass_build_encounter;
            _daily = class_subclass_build_daily;
            _option = class_subclass_build_option;
            _shortDescription = class_subclass_build_shortDescription;
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

