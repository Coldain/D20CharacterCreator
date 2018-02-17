using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class SubClasses : INotifyPropertyChanged
    {
        #region Fields
        private string _subClass;
        private string _shortDescription;
        private string _description;
        private string _source;
        private List<string> _keywords;
        private string _role;
        private List<string> _abilities;
        private int _hPStart;
        private int _hPLvl;
        private List<int> _defences = new List<int>(new int[] { 0, 0, 0 });
        private int _attack;
        private int _surges;
        private List<bool> _proficiencies;
        private int _skillTraining;
        private List<int> _skills;
        private List<string> _paths;
        private string _defaultFeat;
        private List<string> _implements;
        private List<string> _powers;
        private string _encounter;
        private Builds _build = new Builds();
        private List<string> _builds;
        private List<string> _feats;
        private List<string> _headers;
        private List<string> _bodies;
        private List<OptionChoices> _listOptions;
        private ClassOption _optionPicked1 = new ClassOption();
        private ClassOption _optionPicked2 = new ClassOption();
        private bool _pp;
        #endregion

        #region Properties
        public string SubClass
        {
            get
            {
                return _subClass;
            }
            set
            {
                _subClass = value;
                NotifyPropertyChanged("SubClass");
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
        public List<string> Keywords
        {
            get
            {
                return _keywords;
            }
            set
            {
                _keywords = value;
                NotifyPropertyChanged("Keywords");
            }
        }
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
        public List<string> Abilities
        {
            get
            {
                return _abilities;
            }
            set
            {
                _abilities = value;
                NotifyPropertyChanged("Abilities");
            }
        }
        public int HPStart
        {
            get
            {
                return _hPStart;
            }
            set
            {
                _hPStart = value;
                NotifyPropertyChanged("HPStart");
            }
        }
        public int HPLvl
        {
            get
            {
                return _hPLvl;
            }
            set
            {
                _hPLvl = value;
                NotifyPropertyChanged("HPLvl");
            }
        }
        public List<int> Defences
        {
            get
            {
                return _defences;
            }
            set
            {
                _defences = value;
                NotifyPropertyChanged("Defences");
            }
        }
        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
                NotifyPropertyChanged("Attack");
            }
        }
        public int Surges
        {
            get
            {
                return _surges;
            }
            set
            {
                _surges = value;
                NotifyPropertyChanged("Surges");
            }
        }
        public List<bool> Proficiencies
        {
            get
            {
                return _proficiencies;
            }
            set
            {
                _proficiencies = value;
                NotifyPropertyChanged("Proficiencies");
            }
        }
        public int SkillTraining
        {
            get
            {
                return _skillTraining;
            }
            set
            {
                _skillTraining = value;
                NotifyPropertyChanged("SkillTraining");
            }
        }
        public List<int> Skills
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
        public List<string> Paths
        {
            get
            {
                return _paths;
            }
            set
            {
                _paths = value;
                NotifyPropertyChanged("Paths");
            }
        }
        public string DefaultFeat
        {
            get
            {
                return _defaultFeat;
            }
            set
            {
                _defaultFeat = value;
                NotifyPropertyChanged("DefaultFeat");
            }
        }
        public List<string> Implements
        {
            get
            {
                return _implements;
            }
            set
            {
                _implements = value;
                NotifyPropertyChanged("Implements");
            }
        }
        public List<string> Powers
        {
            get
            {
                return _powers;
            }
            set
            {
                _powers = value;
                NotifyPropertyChanged("Powers");
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
        public List<string> Feats
        {
            get
            {
                return _feats;
            }
            set
            {
                _feats = value;
                NotifyPropertyChanged("Feats");
            }
        }
        public Builds Build
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
        public List<string> Builds
        {
            get
            {
                return _builds;
            }
            set
            {
                _builds = value;
                NotifyPropertyChanged("Builds");
            }
        }
        public List<string> Headers
        {
            get
            {
                return _headers;
            }
            set
            {
                _headers = value;
                NotifyPropertyChanged("Headers");
            }
        }
        public List<string> Bodies
        {
            get
            {
                return _bodies;
            }
            set
            {
                _bodies = value;
                NotifyPropertyChanged("Bodies");
            }
        }
        public ClassOption OptionPicked1
        {
            get
            {
                return _optionPicked1;
            }
            set
            {
                _optionPicked1 = value;
                NotifyPropertyChanged("OptionPicked1");
            }
        }
        public ClassOption OptionPicked2
        {
            get
            {
                return _optionPicked2;
            }
            set
            {
                _optionPicked2 = value;
                NotifyPropertyChanged("OptionPicked2");
            }
        }
        public List<OptionChoices> ListOptions
        {
            get
            {
                return _listOptions;
            }
            set
            {
                _listOptions = value;
                NotifyPropertyChanged("ListOptions");
            }
        }
        public bool PP
        {
            get
            {
                return _pp;
            }
            set
            {
                _pp = value;
                NotifyPropertyChanged("PP");
            }
        }
        #endregion

        #region Constructors
        public SubClasses()
        {
            SubClass = "Subclass";
            ShortDescription = "Click to pick a Subclass";
        }

        public SubClasses(SubClasses copySubClass)
        {
            SubClass = copySubClass.SubClass;
            Description = copySubClass.Description;
            ShortDescription = copySubClass.ShortDescription;
            Source = copySubClass.Source;
            Keywords = copySubClass.Keywords;
            Role = copySubClass.Role;
            Abilities = copySubClass.Abilities;
            HPStart = copySubClass.HPStart;
            HPLvl = copySubClass.HPLvl;
            Defences = copySubClass.Defences;
            Attack = copySubClass.Attack;
            Surges = copySubClass.Surges;
            Proficiencies = copySubClass.Proficiencies;
            SkillTraining = copySubClass.SkillTraining;
            Skills = copySubClass.Skills;
            Paths = copySubClass.Paths;
            DefaultFeat = copySubClass.DefaultFeat;
            Implements = copySubClass.Implements;
            Powers = copySubClass.Powers;
            Encounter = copySubClass.Encounter;
            Feats = copySubClass.Feats;
            Build = copySubClass.Build;
            Builds = copySubClass.Builds;
            Headers = copySubClass.Headers;
            Bodies = copySubClass.Bodies;
            OptionPicked1 = copySubClass.OptionPicked1;
            OptionPicked2 = copySubClass.OptionPicked2;
            ListOptions = copySubClass.ListOptions;
            PP = copySubClass.PP;
        }

        public SubClasses(string class_subclass_subClass, string class_subclass_shortDescription, string class_subclass_description, string class_subclass_source, List<string> class_subclass_keywords, string class_subclass_role, List<string> class_subclass_abilities, int class_subclass_hPStart, int class_subclass_hPLvl, List<int> class_subclass_defences, int class_subclass_attack, int class_subclass_surges, List<bool> class_subclass_proficiencies, int class_subclass_skillTraining, List<int> class_subclass_skills, List<string> class_subclass_paths, string class_subclass_defaultFeat, List<string> class_subclass_implements, List<string> class_subclass_powers, string class_subclass_encounter, List<string> class_subclass_builds, List<string> class_subclass_feats, List<string> class_subclass_headers, List<string> class_subclass_bodies, List<SubClasses.OptionChoices> class_subclass_listOptions, bool class_subclass_pp)
        {
            _subClass = class_subclass_subClass;
            _shortDescription = class_subclass_shortDescription;
            _description = class_subclass_description;
            _source = class_subclass_source;
            _keywords = class_subclass_keywords;
            _role = class_subclass_role;
            _abilities = class_subclass_abilities;
            _hPStart = class_subclass_hPStart;
            _hPLvl = class_subclass_hPLvl;
            _defences = class_subclass_defences;
            _attack = class_subclass_attack;
            _surges = class_subclass_surges;
            _proficiencies = class_subclass_proficiencies;
            _skillTraining = class_subclass_skillTraining;
            _skills = class_subclass_skills;
            _paths = class_subclass_paths;
            _defaultFeat = class_subclass_defaultFeat;
            _implements = class_subclass_implements;
            _powers = class_subclass_powers;
            _encounter = class_subclass_encounter;
            _builds = class_subclass_builds;
            _feats = class_subclass_feats;
            _headers = class_subclass_headers;
            _bodies = class_subclass_bodies;
            _listOptions = class_subclass_listOptions;            
            _pp = class_subclass_pp;
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

        public class OptionChoices : INotifyPropertyChanged
        {
            #region Fields
            private List<string> _optionDetails;
            private List<string> _options;
            private List<string> _optionSelections;
            private List<string> _optionsBenefits;
            private List<string> _optionBenefitTypes;
            private string _optionType;
            #endregion

            #region Properties
            public List<string> OptionDetails
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
            public List<string> Options
            {
                get
                {
                    return _options;
                }
                set
                {
                    _options = value;
                    NotifyPropertyChanged("Options");
                }
            }
            public List<string> OptionSelections
            {
                get
                {
                    return _optionSelections;
                }
                set
                {
                    _optionSelections = value;
                    NotifyPropertyChanged("OptionSelections");
                }
            }
            public List<string> OptionsBenefits
            {
                get
                {
                    return _optionsBenefits;
                }
                set
                {
                    _optionSelections = value;
                    NotifyPropertyChanged("OptionsBenefits");
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
}
