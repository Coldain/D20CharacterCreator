using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Powers
    {
        #region Fields
        public string _power;
        public string _source;
        public string _class;
        public string _classLevel;
        public string _description;
        public string _powerType;
        public string _powerUsage;
        public List<string> _sourceTypes;
        public string _actionType;
        public List<string> _weaponTypes;
        public string _prerequisite;
        public string _prerequisiteType;
        public string _prerequisiteDescription;
        public string _requirement;
        public string _requirementType;
        public string _requirementDescription;
        public string _targetNumber;
        public string _targetType;
        public string _attackType;
        public string _attackVsType;
        public List<string> _hit;
        public List<string> _hit1;
        public string _hit1Level;
        public string _hitDescription;
        public List<string> _effectDescription;
        #endregion

        #region Properties
        public string Power
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
                NotifyPropertyChanged("Power");
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
    public string Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
                NotifyPropertyChanged("Class");
            }
        }
    public string ClassLevel
        {
            get
            {
                return _classLevel;
            }
            set
            {
                _classLevel = value;
                NotifyPropertyChanged("ClassLevel");
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
    public string PowerType
        {
            get
            {
                return _powerType;
            }
            set
            {
                _powerType = value;
                NotifyPropertyChanged("PowerType");
            }
        }
    public string PowerUsage
        {
            get
            {
                return _powerUsage;
            }
            set
            {
                _powerUsage = value;
                NotifyPropertyChanged("PowerUsage");
            }
        }
    public List<string> SourceTypes
        {
            get
            {
                return _sourceTypes;
            }
            set
            {
                _sourceTypes = value;
                NotifyPropertyChanged("SourceTypes");
            }
        }
    public string ActionType
        {
            get
            {
                return _actionType;
            }
            set
            {
                _actionType = value;
                NotifyPropertyChanged("ActionType");
            }
        }
    public List<string> WeaponTypes
        {
            get
            {
                return _weaponTypes;
            }
            set
            {
                _weaponTypes = value;
                NotifyPropertyChanged("WeaponTypes");
            }
        }
    public string Prerequisite
        {
            get
            {
                return _prerequisite;
            }
            set
            {
                _prerequisite = value;
                NotifyPropertyChanged("Prerequisite");
            }
        }
    public string PrerequisiteType
        {
            get
            {
                return _prerequisiteType;
            }
            set
            {
                _prerequisiteType = value;
                NotifyPropertyChanged("PrerequisiteType");
            }
        }
    public string PrerequisiteDescription
        {
            get
            {
                return _prerequisiteDescription;
            }
            set
            {
                _prerequisiteDescription = value;
                NotifyPropertyChanged("PrerequisiteDescription");
            }
        }
    public string Requirement
        {
            get
            {
                return _requirement;
            }
            set
            {
                _requirement = value;
                NotifyPropertyChanged("Requirement");
            }
        }
    public string RequirementType
        {
            get
            {
                return _requirementType;
            }
            set
            {
                _requirementType = value;
                NotifyPropertyChanged("RequirementType");
            }
        }
    public string RequirementDescription
        {
            get
            {
                return _requirementDescription;
            }
            set
            {
                _requirementDescription = value;
                NotifyPropertyChanged("RequirementDescription");
            }
        } 
    public string TargetNumber
        {
            get
            {
                return _targetNumber;
            }
            set
            {
                _targetNumber = value;
                NotifyPropertyChanged("TargetNumber");
            }
        }
    public string TargetType
        {
            get
            {
                return _targetType;
            }
            set
            {
                _targetType = value;
                NotifyPropertyChanged("TargetType");
            }
        }
    public string AttackType
        {
            get
            {
                return _attackType;
            }
            set
            {
                _attackType = value;
                NotifyPropertyChanged("AttackType");
            }
        }
    public string AttackVsType
        {
            get
            {
                return _attackVsType;
            }
            set
            {
                _attackVsType = value;
                NotifyPropertyChanged("AttackVsType");
            }
        }
    public List<string> Hit
        {
            get
            {
                return _hit;
            }
            set
            {
                _hit = value;
                NotifyPropertyChanged("Hit");
            }
        }
    public List<string> Hit1
        {
            get
            {
                return _hit1;
            }
            set
            {
                _hit1 = value;
                NotifyPropertyChanged("Hit1");
            }
        }
    public string Hit1Level
        {
            get
            {
                return _hit1Level;
            }
            set
            {
                _hit1Level = value;
                NotifyPropertyChanged("Hit1Level");
            }
        }
    public string HitDescription
        {
            get
            {
                return _hitDescription;
            }
            set
            {
                _hitDescription = value;
                NotifyPropertyChanged("HitDescription");
            }
        }
    public List<string> EffectDescription
        {
            get
            {
                return _effectDescription;
            }
            set
            {
                _effectDescription = value;
                NotifyPropertyChanged("EffectDescription");
            }
        }
        #endregion

        #region Contstructors
        public Powers()
        {
        _power = "";
        _source = "";
        _class = "";
        _classLevel = "";
        _description = "";
        _powerType = "";
        _powerUsage = "";
        _sourceTypes = new List<string>();
        _actionType = "";
        _weaponTypes = new List<string>();
        _prerequisite = "";
        _prerequisiteType = "";
        _prerequisiteDescription = "";
        _requirement = "";
        _requirementType = "";
        _requirementDescription = "";
        _targetNumber = "";
        _targetType = "";
        _attackType = "";
        _attackVsType = "";
        _hit = new List<string>();
        _hit1 = new List<string>();
        _hit1Level = "";
        _hitDescription = "";
        _effectDescription = new List<string>();
    }
        #endregion

        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
