using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class Races : INotifyPropertyChanged
    {        
        #region Fields
        private string _race;
        private string _size;
        private string _speedType;
        private string _vision;
        private string _shortDescription;
        private List<string> _description;
        private string _heightFeet;
        private string _heightCM;
        private string _weightKG;
        private string _weightLBS;
        private string _age;
        private string _source;
        private string _image;
        private int _speed;
        private List<string> _subRaces;
        private List<string> _traits;
        private List<string> _abilities;
        private List<int> _defences = new List<int>(new int[] { 0, 0, 0 });
        private List<string> _skills;
        private List<string> _resistances;
        private List<string> _powers;
        private List<string> _languages;
        private List<string> _feats;
        private List<string> _headers;
        private List<string> _bodies;
        private string _physical;
        private string _playing;
        private string _adventure;
        private List<string> _maleNames;
        private List<string> _femaleNames;
        private SubRaces _subrace;
        private string _abilityChoice;
        private string _subrace_subRace;
        private string _subrace_description;
        #endregion

        #region Properties
        public string Race
        {
            get
            {
                return _race;
            }
            set
            {
                _race = value;
                NotifyPropertyChanged("Race");
            }
        }
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                NotifyPropertyChanged("Size");
            }
        }
        public string SpeedType
        {
            get
            {
                return _speedType;
            }
            set
            {
                _speedType = value;
                NotifyPropertyChanged("SpeedType");
            }
        }
        public string Vision
        {
            get
            {
                return _vision;
            }
            set
            {
                _vision = value;
                NotifyPropertyChanged("Vision");
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
        public List<string> Description
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
        public string HeightFeet
        {
            get
            {
                return _heightFeet;
            }
            set
            {
                _heightFeet = value;
                NotifyPropertyChanged("HeightFeet");
            }
        }
        public string HeightCM
        {
            get
            {
                return _heightCM;
            }
            set
            {
                _heightCM = value;
                NotifyPropertyChanged("HeightCM");
            }
        }
        public string WeightKG
        {
            get
            {
                return _weightKG;
            }
            set
            {
                _weightKG = value;
                NotifyPropertyChanged("WeightKG");
            }
        }
        public string WeightLBS
        {
            get
            {
                return _weightLBS;
            }
            set
            {
                _weightLBS = value;
                NotifyPropertyChanged("WeightLBS");
            }
        }
        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                NotifyPropertyChanged("Age");
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
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                NotifyPropertyChanged("Image");
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                NotifyPropertyChanged("Speed");
            }
        }
        public List<string> SubRaces
        {
            get
            {
                return _subRaces;
            }
            set
            {
                _subRaces = value;
                NotifyPropertyChanged("SubRaces");
            }
        }
        public List<string> Traits
        {
            get
            {
                return _traits;
            }
            set
            {
                _traits = value;
                NotifyPropertyChanged("Traits");
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
        public List<string> Resistances
        {
            get
            {
                return _resistances;
            }
            set
            {
                _resistances = value;
                NotifyPropertyChanged("Resistances");
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
        public List<string> Languages
        {
            get
            {
                return _languages;
            }
            set
            {
                _languages = value;
                NotifyPropertyChanged("Languages");
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
        public string Physical
        {
            get
            {
                return _physical;
            }
            set
            {
                _physical = value;
                NotifyPropertyChanged("Physical");
            }
        }
        public string Playing
        {
            get
            {
                return _playing;
            }
            set
            {
                _playing = value;
                NotifyPropertyChanged("Playing");
            }
        }
        public string Adventure
        {
            get
            {
                return _adventure;
            }
            set
            {
                _adventure = value;
                NotifyPropertyChanged("Adventure");
            }
        }
        public List<string> MaleNames
        {
            get
            {
                return _maleNames;
            }
            set
            {
                _maleNames = value;
                NotifyPropertyChanged("MaleNames");
            }
        }
        public List<string> FemaleNames
        {
            get
            {
                return _femaleNames;
            }
            set
            {
                _femaleNames = value;
                NotifyPropertyChanged("FemaleNames");
            }
        }
        public SubRaces SubRace
        {
            get
            {
                return _subrace;
            }
            set
            {
                _subrace = value;
                NotifyPropertyChanged("SubRace");
            }
        }
        public string AbilityChoice
        {
            get
            {
                return _abilityChoice;
            }
            set
            {
                _abilityChoice = value;
                NotifyPropertyChanged("AbilityChoice");
            }
        }
        #endregion

        #region Constructors
        public Races()
        {
            Race = "Race";
            ShortDescription = "Click to pick a Race.";
            SubRace = new SubRaces();
        }
        public Races(Races copyRace)
        {
            Race = copyRace.Race;
            Size = copyRace.Size;
            SpeedType = copyRace.SpeedType;
            Vision = copyRace.Vision;
            ShortDescription = copyRace.ShortDescription;
            Description = copyRace.Description;
            HeightFeet = copyRace.HeightFeet;
            HeightCM = copyRace.HeightCM;
            WeightLBS = copyRace.WeightLBS;
            WeightKG = copyRace.WeightKG;
            Age = copyRace.Age;
            Source = copyRace.Source;
            Image = copyRace.Image;
            Speed = copyRace.Speed;
            SubRaces = copyRace.SubRaces;
            SubRace = copyRace.SubRace;
            Traits = copyRace.Traits;
            Abilities = copyRace.Abilities;
            Defences = copyRace.Defences;
            Skills = copyRace.Skills;
            Resistances = copyRace.Resistances;
            Powers = copyRace.Powers;
            Languages = copyRace.Languages;
            Feats = copyRace.Feats;
            FemaleNames = copyRace.FemaleNames;
            MaleNames = copyRace.MaleNames;
            AbilityChoice = copyRace.AbilityChoice;
        }

        public Races(string race_race, string race_size, string race_speedType, string race_vision, string race_shortDescription, List<string> race_description, string race_heightFeet, string race_heightCM, string race_weightKG, string race_weightLBS, string race_age, string race_source, string race_image, int race_speed, List<string> race_subRaces, List<string> race_traits, List<string> race_abilities, List<int> race_defences, List<string> race_skills, List<string> race_resistances, List<string> race_powers, List<string> race_languages, List<string> race_feats, List<string> race_headers, List<string> race_bodies, string race_physical, string race_playing, string race_adventure, List<string> race_maleNames, List<string> race_femaleNames, string race_abilityChoice)
        {
            _race = race_race;
            _size = race_size;
            _speedType = race_speedType;
            _vision = race_vision;
            _shortDescription = race_shortDescription;
            _description = race_description;
            _heightFeet = race_heightFeet;
            _heightCM = race_heightCM;
            _weightKG = race_weightKG;
            _weightLBS = race_weightLBS;
            _age = race_age;
            _source = race_source;
            _image = race_image;
            _speed = race_speed;
            _subRaces = race_subRaces;
            _traits = race_traits;
            _abilities = race_abilities;
            _defences = race_defences;
            _skills = race_skills;
            _resistances = race_resistances;
            _powers = race_powers;
            _languages = race_languages;
            _feats = race_feats;
            _headers = race_headers;
            _bodies = race_bodies;
            _physical = race_physical;
            _playing = race_playing;
            _adventure = race_adventure;
            _maleNames = race_maleNames;
            _femaleNames = race_femaleNames;
            _abilityChoice = race_abilityChoice;
                 }
        #endregion

        #region Methods

        #region Properties via methods

        public string SetTraits()
        {
            return "tats";
        }
        public string SetSubRaces()
        {
            return "tats";
        }
        public string SetSources()
        {
            return "tats";
        }
        public string SetAbilities()
        {
            return "tats";
        }
        public string SetSkills()
        {
            return "tats";
        }
        public string SetPowers()
        {
            return "tats";
        }
        public string SetLanguages()
        {
            return "tats";
        }
        public string SetFeats()
        {
            return "tats";
        }
        #endregion

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
