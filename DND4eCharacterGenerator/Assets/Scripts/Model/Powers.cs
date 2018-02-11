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
        public string _origin;
        public string _originType;
        public string _powerType;
        public string _powerUsage;
        public string _actionType;
        public string _attackType;
        public string _attackVsType;
        public string _hit;
        public List<string> _hits;
        public List<string> _hitLevels;
        public List<string> _methodTypes;
        public List<string> _methodRanges;
        public string _target;
        public string _prerequisite;
        public string _prerequisiteType;
        public string _requirement;
        public string _requirementType;
        public List<string> _headers;
        public List<string> _bodies;
        public string _additionalEffectName;
        public string _additionalEffectDescription;
        public List<string> _feats;
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
        public string Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
                NotifyPropertyChanged("Origin");
            }
        }
        public string OriginType
        {
            get
            {
                return _originType;
            }
            set
            {
                _originType = value;
                NotifyPropertyChanged("OriginType");
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
        public string Hit
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
        public List<string> Hits
        {
            get
            {
                return _hits;
            }
            set
            {
                _hits = value;
                NotifyPropertyChanged("Hits");
            }
        }
        public List<string> HitLevels
        {
            get
            {
                return _hitLevels;
            }
            set
            {
                _hitLevels = value;
                NotifyPropertyChanged("HitLevels");
            }
        }
        public List<string> MethodTypes
        {
            get
            {
                return _methodTypes;
            }
            set
            {
                _methodTypes = value;
                NotifyPropertyChanged("MethodTypes");
            }
        }
        public List<string> MethodRanges
        {
            get
            {
                return _methodRanges;
            }
            set
            {
                _methodRanges = value;
                NotifyPropertyChanged("MethodRanges");
            }
        }
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
                NotifyPropertyChanged("Target");
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
        public string AdditionalEffectName
        {
            get
            {
                return _additionalEffectName;
            }
            set
            {
                _additionalEffectName = value;
                NotifyPropertyChanged("AdditionalEffectName");
            }
        }
        public string AdditionalEffectDescription
        {
            get
            {
                return _additionalEffectDescription;
            }
            set
            {
                _additionalEffectDescription = value;
                NotifyPropertyChanged("AdditionalEffectDescription");
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
        #endregion

        #region Contstructors
        public Powers()
        {
            _power = "";
            _source = "";
            _origin = "";
            _originType = "";
            _powerType = "";
            _powerUsage = "";
            _actionType = "";
            _attackType = "";
            _attackVsType = "";
            _hit = "";
            _hits = new List<string>();
            _hitLevels = new List<string>();
            _methodTypes = new List<string>();
            _methodRanges = new List<string>();
            _target = "";
            _prerequisite = "";
            _prerequisiteType = "";
            _requirement = "";
            _requirementType = "";
            _headers = new List<string>();
            _bodies = new List<string>();
            _additionalEffectName = "";
            _additionalEffectDescription = "";
            _feats = new List<string>();
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
