using DnD4e.Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.CharacterOOP
{
    public class Character : INotifyPropertyChanged
    {
        #region Fields
        #region Details
        public Campaigns _campaign;
        public string _size;
        public int _speed;
        public int _initiative;
        public int _passiveInsight;
        public int _passivePerception;
        public int _maxAP;
        public int _capacity;
        public string _name;
        public Deities _deity;
        public string _player;
        public string _alignment;
        public string _gender;
        public Classes _class;
        public Races _race;
        public List<Languages> _knownLanguages;
        public string _description;
        public string _background;
        public string _theme;
        public string _mannerisms;
        public string _personality;
        public string _company;
        public string _companions;
        public string _notes;
        public List<Powers> _powerList;
        #endregion
        #region Defenses
        public int _armorClass;
        public int _fortitude;
        public int _reflexes;
        public int _willpower;
        public int _maxHP;
        public int _bloodiedHP;
        public int _powerPoints;
        public int _healingSurges;
        public int _healingSurgeValue;
        #endregion
        #region Abilities 
        public int _strengthRaw;
        public int _constitutionRaw;
        public int _dexterityRaw;
        public int _intelligenceRaw;
        public int _wisdomRaw;
        public int _charismaRaw;
        public int _strength;
        public int _constitution;
        public int _dexterity;
        public int _intelligence;
        public int _wisdom;
        public int _charisma;
        public int _strengthMod;
        public int _constitutionMod;
        public int _dexterityMod;
        public int _intelligenceMod;
        public int _wisdomMod;
        public int _charismaMod;
        public int _strengthCheck;
        public int _constitutionCheck;
        public int _dexterityCheck;
        public int _intelligenceCheck;
        public int _wisdomCheck;
        public int _charismaCheck;
        public int _level;
        public int _totalXP;
        public string _weight;
        public string _age;
        public string _height;
        public bool _racialStrength;
        public bool _racialConstitution;
        public bool _racialDexterity;
        public bool _racialIntelligence;
        public bool _racialWisdom;
        public bool _racialCharisma;
        #endregion
        #region Skills
        public List<string> _trainedSkills;
        public int _acrobaticsBonus;
        public int _arcanaBonus;
        public int _athleticsBonus;
        public int _bluffBonus;
        public int _diplomacyBonus;
        public int _dungeoneeringBonus;
        public int _enduranceBonus;
        public int _healBonus;
        public int _historyBonus;
        public int _insightBonus;
        public int _intimidateBonus;
        public int _natureBonus;
        public int _perceptionBonus;
        public int _religionBonus;
        public int _stealthBonus;
        public int _streetwiseBonus;
        public int _thieveryBonus;
        public bool _acrobaticsTraining;
        public bool _arcanaTraining;
        public bool _athleticsTraining;
        public bool _bluffTraining;
        public bool _diplomacyTraining;
        public bool _dungeoneeringTraining;
        public bool _enduranceTraining;
        public bool _healTraining;
        public bool _historyTraining;
        public bool _insightTraining;
        public bool _intimidateTraining;
        public bool _natureTraining;
        public bool _perceptionTraining;
        public bool _religionTraining;
        public bool _stealthTraining;
        public bool _streetwiseTraining;
        public bool _thieveryTraining;
        public int _acrobaticsPenalty;
        public int _arcanaPenalty;
        public int _athleticsPenalty;
        public int _bluffPenalty;
        public int _diplomacyPenalty;
        public int _dungeoneeringPenalty;
        public int _endurancePenalty;
        public int _healPenalty;
        public int _historyPenalty;
        public int _insightPenalty;
        public int _intimidatePenalty;
        public int _naturePenalty;
        public int _perceptionPenalty;
        public int _religionPenalty;
        public int _stealthPenalty;
        public int _streetwisePenalty;
        public int _thieveryPenalty;
        public int _acrobaticsMisc;
        public int _arcanaMisc;
        public int _athleticsMisc;
        public int _bluffMisc;
        public int _diplomacyMisc;
        public int _dungeoneeringMisc;
        public int _enduranceMisc;
        public int _healMisc;
        public int _historyMisc;
        public int _insightMisc;
        public int _intimidateMisc;
        public int _natureMisc;
        public int _perceptionMisc;
        public int _religionMisc;
        public int _stealthMisc;
        public int _streetwiseMisc;
        public int _thieveryMisc;
        #endregion
        #endregion

        #region Properties        
        #region Details
        public Campaigns Campaign
        {
            get
            {
                return _campaign;
            }
            set
            {
                _campaign = value;
                NotifyPropertyChanged("Campaign");
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
        public int Initiative
        {
            get
            {
                return _initiative;
            }
            set
            {
                _initiative = value;
                NotifyPropertyChanged("Initiative");
            }
        }
        public int PassiveInsight
        {
            get
            {
                return _passiveInsight;
            }
            set
            {
                _passiveInsight = value;
                NotifyPropertyChanged("PassiveInsight");
            }
        }
        public int PassivePerception
        {
            get
            {
                return _passivePerception;
            }
            set
            {
                _passivePerception = value;
                NotifyPropertyChanged("PassivePerception");
            }
        }
        public int MaxAP
        {
            get
            {
                return _maxAP;
            }
            set
            {
                _maxAP = value;
                NotifyPropertyChanged("MaxAP");
            }
        }
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
                NotifyPropertyChanged("Capacity");
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public Deities Deity
        {
            get
            {
                return _deity;
            }
            set
            {
                _deity = value;
                NotifyPropertyChanged("Deity");
            }
        }
        public string Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                NotifyPropertyChanged("Player");
            }
        }
        public string Alignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
                NotifyPropertyChanged("Alignment");
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                NotifyPropertyChanged("Gender");
            }
        }
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                NotifyPropertyChanged("Weight");
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
        public string Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                NotifyPropertyChanged("Height");
            }
        }
        public Classes Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
                NotifyPropertyChanged("Class");
                NotifyPropertyChanged("Strength");
                NotifyPropertyChanged("Constitution");
                NotifyPropertyChanged("Dexterity");
                NotifyPropertyChanged("Intelligence");
                NotifyPropertyChanged("Wisdom");
                NotifyPropertyChanged("Charisma");
                NotifyPropertyChanged("Fortitude");
                NotifyPropertyChanged("Reflexes");
                NotifyPropertyChanged("Willpower");
                NotifyPropertyChanged("MaxHP");
            }
        }
        public Races Race
        {
            get
            {
                return _race;
            }
            set
            {
                _race = value;
                NotifyPropertyChanged("Race");
                NotifyPropertyChanged("Strength");
                NotifyPropertyChanged("Constitution");
                NotifyPropertyChanged("Dexterity");
                NotifyPropertyChanged("Intelligence");
                NotifyPropertyChanged("Wisdom");
                NotifyPropertyChanged("Charisma");
                NotifyPropertyChanged("Fortitude");
                NotifyPropertyChanged("Reflexes");
                NotifyPropertyChanged("Willpower");
            }
        }
        public List<Languages> KnownLanguages
        {
            get
            {
                return _knownLanguages;
            }
            set
            {
                _knownLanguages = value;
                NotifyPropertyChanged("KnownLanguages");
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
        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                NotifyPropertyChanged("Background");
            }
        }
        public string Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
                NotifyPropertyChanged("Theme");
            }
        }
        public string Mannerisms
        {
            get
            {
                return _mannerisms;
            }
            set
            {
                _mannerisms = value;
                NotifyPropertyChanged("Mannerisms");
            }
        }
        public string Personality
        {
            get
            {
                return _personality;
            }
            set
            {
                _personality = value;
                NotifyPropertyChanged("Personality");
            }
        }
        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
                NotifyPropertyChanged("Company");
            }
        }
        public string Companions
        {
            get
            {
                return _companions;
            }
            set
            {
                _companions = value;
                NotifyPropertyChanged("Companions");
            }
        }
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                NotifyPropertyChanged("Notes");
            }
        }
        public List<Powers> PowerList
        {
            get
            {
                return _powerList;
            }
            set
            {
                _powerList = value;
                NotifyPropertyChanged("PowerList");
            }
        }
        #endregion
        #region Defenses
        public int ArmorClass
        {
            get
            {
                // + Equipment.Armor.AC + Equipment.Shield.AC + Equipment.DEXAC + Feat.AC + Race.AC;
                _armorClass = 10 + (int)Math.Floor((double)(Level / 2));
                if (DexterityMod >= IntelligenceMod)
                    _armorClass = _armorClass + DexterityMod;
                else
                    _armorClass = _armorClass + IntelligenceMod;
                return _armorClass;
            }
            set
            {
                _armorClass = value;
                NotifyPropertyChanged("ArmorClass");
            }
        }
        public int Fortitude
        {
            get
            {
                // + Feat.Fort;                
                _fortitude = 10 + (int)Math.Floor((double)(Level / 2)) + Race.Defences[0] + Class.Subclass.Defences[0];
                if (StrengthMod >= ConstitutionMod)
                    _fortitude = _fortitude + StrengthMod;
                else
                    _fortitude = _fortitude + ConstitutionMod;
                return _fortitude;
            }
            set
            {
                _fortitude = value;
                NotifyPropertyChanged("Fortitude");
            }
        }
        public int Reflexes
        {
            get
            {
                // + Feat.Ref + Equipment.Shield.Ref;                
                _reflexes = 10 + (int)Math.Floor((double)(Level / 2)) + Race.Defences[1] + Class.Subclass.Defences[1];
                if (DexterityMod >= IntelligenceMod)
                    _reflexes = _reflexes + DexterityMod;
                else
                    _reflexes = _reflexes + IntelligenceMod;
                return _reflexes;
            }
            set
            {
                _reflexes = value;
                NotifyPropertyChanged("Reflexes");
            }
        }
        public int Willpower
        {
            get
            {
                // + Feat.Will;              
                _willpower = 10 + (int)Math.Floor((double)(Level / 2)) + Race.Defences[2] + Class.Subclass.Defences[2];
                if (WisdomMod >= CharismaMod)
                    _willpower = _willpower + WisdomMod;
                else
                    _willpower = _willpower + CharismaMod;
                return _willpower;
            }
            set
            {
                _willpower = value;
                NotifyPropertyChanged("Willpower");
            }
        }
        public int MaxHP
        {
            get
            {
                _maxHP = Class.Subclass.HPStart + Constitution + (Class.Subclass.HPLvl * Level);
                return _maxHP;
            }
            set
            {
                _maxHP = value;
                NotifyPropertyChanged("MaxHP");
            }
        }
        public int BloodiedHP
        {
            get
            {
                _bloodiedHP = (int)Math.Floor(((double)MaxHP / 2));
                return _bloodiedHP;
            }
            set
            {
                _bloodiedHP = value;
                NotifyPropertyChanged("BloodiedHP");
            }
        }
        public int PowerPoints
        {
            get
            {
                if (Class.Subclass.PP)
                {
                    if (Level >= 0 && Level < 3)
                        _powerPoints = 2;
                    if (Level >= 3 && Level < 7)
                        _powerPoints = 4;
                    if (Level >= 7 && Level < 13)
                        _powerPoints = 6;
                    if (Level >= 13 && Level < 17)
                        _powerPoints = 7;
                    if (Level >= 17 && Level < 21)
                        _powerPoints = 9;
                    if (Level >= 21 && Level < 23)
                        _powerPoints = 11;
                    if (Level >= 23 && Level < 27)
                        _powerPoints = 13;
                    if (Level >= 27 && Level < 31)
                        _powerPoints = 15;
                }
                else
                    _powerPoints = 0;
                // + feats.pp + path.pp
                return _powerPoints;
            }
            set
            {
                _powerPoints = value;
                NotifyPropertyChanged("PowerPoints");
            }
        }
        public int HealingSurges
        {
            get
            {
                _healingSurges = ConstitutionMod + Class.Subclass.Surges;
                return _healingSurges;
            }
            set
            {
                NotifyPropertyChanged("HealingSurges");
            }
        }
        public int HealingSurgeValue
        {
            get
            {
                _healingSurgeValue = (int)Math.Floor((double)(MaxHP / 4));
                return _healingSurgeValue;
            }
            set
            {
                NotifyPropertyChanged("HealingSurgeValue");
            }

        }

        #endregion
        #region Abilities 
        public int StrengthRaw
        {
            get
            {
                return _strengthRaw;
            }
            set
            {
                _strengthRaw = value;
                NotifyPropertyChanged("StrengthRaw");
                NotifyPropertyChanged("Strength");
                NotifyPropertyChanged("StrengthMod");
                NotifyPropertyChanged("StrengthCheck");
            }
        }
        public int ConstitutionRaw
        {
            get
            {
                return _constitutionRaw;
            }
            set
            {
                _constitutionRaw = value;
                NotifyPropertyChanged("ConstitutionRaw");
                NotifyPropertyChanged("Constitution");
                NotifyPropertyChanged("ConstitutionMod");
                NotifyPropertyChanged("ConstitutionCheck");
            }
        }
        public int DexterityRaw
        {
            get
            {
                return _dexterityRaw;
            }
            set
            {
                _dexterityRaw = value;
                NotifyPropertyChanged("DexterityRaw");
                NotifyPropertyChanged("Dexterity");
                NotifyPropertyChanged("DexterityMod");
                NotifyPropertyChanged("DexterityCheck");
            }
        }
        public int IntelligenceRaw
        {
            get
            {
                return _intelligenceRaw;
            }
            set
            {
                _intelligenceRaw = value;
                NotifyPropertyChanged("IntelligenceRaw");
                NotifyPropertyChanged("Intelligence");
                NotifyPropertyChanged("IntelligenceMod");
                NotifyPropertyChanged("IntelligenceCheck");
            }
        }
        public int WisdomRaw
        {
            get
            {
                return _wisdomRaw;
            }
            set
            {
                _wisdomRaw = value;
                NotifyPropertyChanged("WisdomRaw");
                NotifyPropertyChanged("Wisdom");
                NotifyPropertyChanged("WisdomMod");
                NotifyPropertyChanged("WisdomCheck");
            }
        }
        public int CharismaRaw
        {
            get
            {
                return _charismaRaw;
            }
            set
            {
                _charismaRaw = value;
                NotifyPropertyChanged("CharismaRaw");
                NotifyPropertyChanged("Charisma");
                NotifyPropertyChanged("CharismaMod");
                NotifyPropertyChanged("CharismaCheck");
            }
        }

        public bool RacialStrength
        {
            get
            {
                return _racialStrength;
            }
            set
            {
                _racialStrength = value;
                NotifyPropertyChanged("RacialStrength");
                NotifyPropertyChanged("Strength");
                NotifyPropertyChanged("StrengthMod");
                NotifyPropertyChanged("StrengthCheck");
                NotifyPropertyChanged("Fortitude");
            }
        }

        public bool RacialConstitution
        {
            get
            {
                return _racialConstitution;
            }
            set
            {
                _racialConstitution = value;
                NotifyPropertyChanged("RacialConstitution");
                NotifyPropertyChanged("Constitution");
                NotifyPropertyChanged("ConstitutionMod");
                NotifyPropertyChanged("ConstitutionCheck");
                NotifyPropertyChanged("Fortitude");
                NotifyPropertyChanged("MaxHP");
                NotifyPropertyChanged("BloodiedHP");
            }
        }

        public bool RacialDexterity
        {
            get
            {
                return _racialDexterity;
            }
            set
            {
                _racialDexterity = value;
                NotifyPropertyChanged("RacialDexterity");
                NotifyPropertyChanged("Dexterity");
                NotifyPropertyChanged("DexterityMod");
                NotifyPropertyChanged("DexterityCheck");
                NotifyPropertyChanged("ArmorClass");
                NotifyPropertyChanged("Reflexes");
            }
        }

        public bool RacialIntelligence
        {
            get
            {
                return _racialIntelligence;
            }
            set
            {
                _racialIntelligence = value;
                NotifyPropertyChanged("RacialIntelligence");
                NotifyPropertyChanged("Intelligence");
                NotifyPropertyChanged("IntelligenceMod");
                NotifyPropertyChanged("IntelligenceCheck");
                NotifyPropertyChanged("ArmorClass");
                NotifyPropertyChanged("Reflexes");
            }
        }

        public bool RacialWisdom
        {
            get
            {
                return _racialWisdom;
            }
            set
            {
                _racialWisdom = value;
                NotifyPropertyChanged("RacialWisdom");
                NotifyPropertyChanged("Wisdom");
                NotifyPropertyChanged("WisdomMod");
                NotifyPropertyChanged("WisdomCheck");
                NotifyPropertyChanged("Willpower");
            }
        }

        public bool RacialCharisma
        {
            get
            {
                return _racialCharisma;
            }
            set
            {
                _racialCharisma = value;
                NotifyPropertyChanged("RacialCharisma");
                NotifyPropertyChanged("Charisma");
                NotifyPropertyChanged("CharismaMod");
                NotifyPropertyChanged("CharismaCheck");
                NotifyPropertyChanged("Willpower");
            }
        }

        public int Strength
        {
            get
            {
                _strength = StrengthRaw;
                if (RacialStrength)
                {
                    _strength = _strength + 2;
                }
                return _strength;
            }
            set
            {
                NotifyPropertyChanged("Strength");
                NotifyPropertyChanged("StrengthMod");
                NotifyPropertyChanged("StrengthCheck");
                NotifyPropertyChanged("Fortitude");
            }
        }
        public int Constitution
        {
            get
            {
                _constitution = ConstitutionRaw;
                if (RacialConstitution)
                {
                    _constitution = _constitution + 2;
                }
                return _constitution;
            }
            set
            {
                NotifyPropertyChanged("Constitution");
                NotifyPropertyChanged("ConstitutionMod");
                NotifyPropertyChanged("ConstitutionCheck");
                NotifyPropertyChanged("Fortitude");
                NotifyPropertyChanged("MaxHP");
                NotifyPropertyChanged("BloodiedHP");
            }
        }
        public int Dexterity
        {
            get
            {
                _dexterity = DexterityRaw;
                if (RacialDexterity)
                {
                    _dexterity = _dexterity + 2;
                }
                return _dexterity;
            }
            set
            {
                NotifyPropertyChanged("Dexterity");
                NotifyPropertyChanged("DexterityMod");
                NotifyPropertyChanged("DexterityCheck");
                NotifyPropertyChanged("ArmorClass");
                NotifyPropertyChanged("Reflexes");
            }
        }
        public int Intelligence
        {
            get
            {
                _intelligence = IntelligenceRaw;
                if (RacialIntelligence)
                {
                    _intelligence = _intelligence + 2;
                }
                return _intelligence;
            }
            set
            {
                NotifyPropertyChanged("Intelligence");
                NotifyPropertyChanged("IntelligenceMod");
                NotifyPropertyChanged("IntelligenceCheck");
                NotifyPropertyChanged("ArmorClass");
                NotifyPropertyChanged("Reflexes");
            }
        }
        public int Wisdom
        {
            get
            {
                _wisdom = WisdomRaw;
                if (RacialWisdom)
                {
                    _wisdom = _wisdom + 2;
                }
                return _wisdom;
            }
            set
            {

                NotifyPropertyChanged("Wisdom");
                NotifyPropertyChanged("WisdomMod");
                NotifyPropertyChanged("WisdomCheck");
                NotifyPropertyChanged("Willpower");
            }
        }
        public int Charisma
        {
            get
            {
                _charisma = CharismaRaw;
                if (RacialCharisma)
                {
                    _charisma = _charisma + 2;
                }
                return _charisma;
            }
            set
            {
                NotifyPropertyChanged("Charisma");
                NotifyPropertyChanged("CharismaMod");
                NotifyPropertyChanged("CharismaCheck");
                NotifyPropertyChanged("Willpower");
            }
        }
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                NotifyPropertyChanged("Level");
                Strength = Strength;
                Constitution = Constitution;
                Dexterity = Dexterity;
                Intelligence = Intelligence;
                Wisdom = Wisdom;
                Charisma = Charisma;
                NotifyPropertyChanged("PowerPoints");
            }
        }
        public int TotalXP
        {
            get
            {
                return _totalXP;
            }
            set
            {
                _totalXP = value;
                NotifyPropertyChanged("TotalXP");
            }
        }
        public int StrengthMod
        {
            get
            {
                _strengthMod = (int)Math.Floor((double)((Strength - 10) / 2));
                return _strengthMod;
            }
            set
            {
                _strengthMod = value;
                NotifyPropertyChanged("StrengthMod");
            }
        }
        public int ConstitutionMod
        {
            get
            {
                _constitutionMod = (int)Math.Floor((double)((Constitution - 10) / 2));
                return _constitutionMod;
            }
            set
            {
                _constitutionMod = value;
                NotifyPropertyChanged("ConstitutionMod");
            }
        }
        public int DexterityMod
        {
            get
            {
                _dexterityMod = (int)Math.Floor((double)((Dexterity - 10) / 2));
                return _dexterityMod;
            }
            set
            {
                _dexterityMod = value;
                NotifyPropertyChanged("DexterityMod");
            }
        }
        public int IntelligenceMod
        {
            get
            {
                _intelligenceMod = (int)Math.Floor((double)((Intelligence - 10) / 2));
                return _intelligenceMod;
            }
            set
            {
                _intelligence = value;
                NotifyPropertyChanged("IntelligenceMod");
            }
        }
        public int WisdomMod
        {
            get
            {
                _wisdomMod = (int)Math.Floor((double)((Wisdom - 10) / 2));
                return _wisdomMod;
            }
            set
            {
                _wisdomMod = value;
                NotifyPropertyChanged("WisdomMod");
            }
        }
        public int CharismaMod
        {
            get
            {
                _charismaMod = (int)Math.Floor((double)((Charisma - 10) / 2));
                return _charismaMod;
            }
            set
            {
                _charismaMod = value;
                NotifyPropertyChanged("CharismaMod");
            }
        }
        public int StrengthCheck
        {
            get
            {
                _strengthCheck = (int)Math.Floor((double)((Strength - 10) / 2)) + (int)Math.Floor((double)(Level / 2));
                return _strengthCheck;
            }
            set
            {
                _strengthCheck = value;
                NotifyPropertyChanged("StrengthCheck");
            }
        }
        public int ConstitutionCheck
        {
            get
            {
                _constitutionCheck = (int)Math.Floor((double)((Constitution - 10) / 2)) + (int)Math.Floor((double)(Level / 2));
                return _constitutionCheck;
            }
            set
            {
                _constitutionCheck = value;
                NotifyPropertyChanged("ConstitutionCheck");
            }
        }
        public int DexterityCheck
        {
            get
            {
                _dexterityCheck = (int)Math.Floor((double)((Dexterity - 10) / 2)) + (int)Math.Floor((double)(Level / 2));
                return _dexterityCheck;
            }
            set
            {
                _dexterityCheck = value;
                NotifyPropertyChanged("DexterityCheck");
            }
        }
        public int IntelligenceCheck
        {
            get
            {
                _intelligenceCheck = (int)Math.Floor((double)((Intelligence - 10) / 2)) + (int)Math.Floor((double)(Level / 2));
                return _intelligenceCheck;
            }
            set
            {
                _intelligenceCheck = value;
                NotifyPropertyChanged("IntelligenceCheck");
            }
        }
        public int WisdomCheck
        {
            get
            {
                _wisdomCheck = (int)Math.Floor((double)((Wisdom - 10) / 2)) + (int)Math.Floor((double)(Level / 2));
                return _wisdomCheck;
            }
            set
            {
                _wisdomCheck = value;
                NotifyPropertyChanged("WisdomCheck");
            }
        }
        public int CharismaCheck
        {
            get
            {
                _charismaCheck = (int)Math.Floor((double)((Charisma - 10) / 2)) + (int)Math.Floor((double)(Level / 2));
                return _charismaCheck;
            }
            set
            {
                _charismaCheck = value;
                NotifyPropertyChanged("CharismaCheckCharismaCheck");
            }
        }
        #endregion
        #region Skills
        public List<string> TrainedSkills
        {
            get
            {
                return _trainedSkills;
            }
            set
            {
                _trainedSkills = value;
                NotifyPropertyChanged("TrainedSkills");
            }
        }
        public int AcrobaticsBonus
        {
            get
            {
                _acrobaticsBonus = (int)Math.Floor((double)(Level / 2)) + DexterityMod + AcrobaticsPenalty + AcrobaticsMisc;
                if (AcrobaticsTraining == true)
                    return _acrobaticsBonus + 5;
                else
                    return _acrobaticsBonus;
            }
            set
            {
                _acrobaticsBonus = value;
                NotifyPropertyChanged("AcrobaticsBonus");
            }
        }
        public int ArcanaBonus
        {
            get
            {
                _arcanaBonus = (int)Math.Floor((double)(Level / 2)) + IntelligenceMod + ArcanaPenalty + ArcanaMisc;
                if (ArcanaTraining == true)
                    return _arcanaBonus + 5;
                else
                    return _arcanaBonus;
            }
            set
            {
                _arcanaBonus = value;
                NotifyPropertyChanged("ArcanaBonus");
            }
        }
        public int AthleticsBonus
        {
            get
            {
                _athleticsBonus = (int)Math.Floor((double)(Level / 2)) + StrengthMod + AthleticsPenalty + AthleticsMisc;
                if (AthleticsTraining == true)
                    return _athleticsBonus + 5;
                else
                    return _athleticsBonus;
            }
            set
            {
                _athleticsBonus = value;
                NotifyPropertyChanged("AthleticsBonus");
            }
        }
        public int BluffBonus
        {
            get
            {
                _bluffBonus = (int)Math.Floor((double)(Level / 2)) + CharismaMod + BluffPenalty + BluffMisc;
                if (BluffTraining == true)
                    return _bluffBonus + 5;
                else
                    return _bluffBonus;
            }
            set
            {
                _bluffBonus = value;
                NotifyPropertyChanged("BluffBonus");
            }
        }
        public int DiplomacyBonus
        {
            get
            {
                _diplomacyBonus = (int)Math.Floor((double)(Level / 2)) + CharismaMod + DiplomacyPenalty + DiplomacyMisc;
                if (DiplomacyTraining == true)
                    return _diplomacyBonus + 5;
                else
                    return _diplomacyBonus;
            }
            set
            {
                _diplomacyBonus = value;
                NotifyPropertyChanged("DiplomacyBonus");
            }
        }
        public int DungeoneeringBonus
        {
            get
            {
                _dungeoneeringBonus = (int)Math.Floor((double)(Level / 2)) + WisdomMod + DungeoneeringPenalty + DungeoneeringMisc;
                if (DungeoneeringTraining == true)
                    return _dungeoneeringBonus + 5;
                else
                    return _dungeoneeringBonus;
            }
            set
            {
                _dungeoneeringBonus = value;
                NotifyPropertyChanged("DungeoneeringBonus");
            }
        }
        public int EnduranceBonus
        {
            get
            {
                _enduranceBonus = (int)Math.Floor((double)(Level / 2)) + ConstitutionMod + EndurancePenalty + EnduranceMisc;
                if (EnduranceTraining == true)
                    return _enduranceBonus + 5;
                else
                    return _enduranceBonus;
            }
            set
            {
                _enduranceBonus = value;
                NotifyPropertyChanged("EnduranceBonus");
            }
        }
        public int HealBonus
        {
            get
            {
                _healBonus = (int)Math.Floor((double)(Level / 2)) + WisdomMod + HealPenalty + HealMisc;
                if (HealTraining == true)
                    return _healBonus + 5;
                else
                    return _healBonus;
            }
            set
            {
                _healBonus = value;
                NotifyPropertyChanged("HealBonus");
            }
        }
        public int HistoryBonus
        {
            get
            {
                _historyBonus = (int)Math.Floor((double)(Level / 2)) + IntelligenceMod + HistoryPenalty + HistoryMisc;
                if (HistoryTraining == true)
                    return _historyBonus + 5;
                else
                    return _historyBonus;
            }
            set
            {
                _historyBonus = value;
                NotifyPropertyChanged("HistoryBonus");
            }
        }
        public int InsightBonus
        {
            get
            {
                _insightBonus = (int)Math.Floor((double)(Level / 2)) + WisdomMod + InsightPenalty + InsightMisc;
                if (InsightTraining == true)
                    return _insightBonus + 5;
                else
                    return _insightBonus;
            }
            set
            {
                _insightBonus = value;
                NotifyPropertyChanged("InsightBonus");
            }
        }
        public int IntimidateBonus
        {
            get
            {
                _intimidateBonus = (int)Math.Floor((double)(Level / 2)) + CharismaMod + IntimidatePenalty + IntimidateMisc;
                if (IntimidateTraining == true)
                    return _intimidateBonus + 5;
                else
                    return _intimidateBonus;
            }
            set
            {
                _intimidateBonus = value;
                NotifyPropertyChanged("IntimidateBonus");
            }
        }
        public int NatureBonus
        {
            get
            {
                _natureBonus = (int)Math.Floor((double)(Level / 2)) + WisdomMod + NaturePenalty + NatureMisc;
                if (NatureTraining == true)
                    return _natureBonus + 5;
                else
                    return _natureBonus;
            }
            set
            {
                _natureBonus = value;
                NotifyPropertyChanged("NatureBonus");
            }
        }
        public int PerceptionBonus
        {
            get
            {
                _perceptionBonus = (int)Math.Floor((double)(Level / 2)) + WisdomMod + PerceptionPenalty + PerceptionMisc;
                if (PerceptionTraining == true)
                    return _perceptionBonus + 5;
                else
                    return _perceptionBonus;
            }
            set
            {
                _perceptionBonus = value;
                NotifyPropertyChanged("PerceptionBonus");
            }
        }
        public int ReligionBonus
        {
            get
            {
                _religionBonus = (int)Math.Floor((double)(Level / 2)) + IntelligenceMod + ReligionPenalty + ReligionMisc;
                if (ReligionTraining == true)
                    return _religionBonus + 5;
                else
                    return _religionBonus;
            }
            set
            {
                _religionBonus = value;
                NotifyPropertyChanged("ReligionBonus");
            }
        }
        public int StealthBonus
        {
            get
            {
                _stealthBonus = (int)Math.Floor((double)(Level / 2)) + DexterityMod + StealthPenalty + StealthMisc;
                if (StealthTraining == true)
                    return _stealthBonus + 5;
                else
                    return _stealthBonus;
            }
            set
            {
                _stealthBonus = value;
                NotifyPropertyChanged("StealthBonus");
            }
        }
        public int StreetwiseBonus
        {
            get
            {
                _streetwiseBonus = (int)Math.Floor((double)(Level / 2)) + CharismaMod + StreetwisePenalty + StreetwiseMisc;
                if (StreetwiseTraining == true)
                    return _streetwiseBonus + 5;
                else
                    return _streetwiseBonus;
            }
            set
            {
                _streetwiseBonus = value;
                NotifyPropertyChanged("StreetwiseBonus");
            }
        }
        public int ThieveryBonus
        {
            get
            {
                _thieveryBonus = (int)Math.Floor((double)(Level / 2)) + DexterityMod + ThieveryPenalty + ThieveryMisc;
                if (ThieveryTraining == true)
                    return _thieveryBonus + 5;
                else
                    return _thieveryBonus;
            }
            set
            {
                _thieveryBonus = value;
                NotifyPropertyChanged("ThieveryBonus");
            }
        }
        public bool AcrobaticsTraining
        {
            get
            {
                return _acrobaticsTraining;
            }
            set
            {
                _acrobaticsTraining = value;
                NotifyPropertyChanged("AcrobaticsTraining");
                NotifyPropertyChanged("AcrobaticsBonus");
            }
        }
        public bool ArcanaTraining
        {
            get
            {
                return _arcanaTraining;
            }
            set
            {
                _arcanaTraining = value;
                NotifyPropertyChanged("ArcanaTraining");
                NotifyPropertyChanged("ArcanaBonus");
            }
        }
        public bool AthleticsTraining
        {
            get
            {
                return _athleticsTraining;
            }
            set
            {
                _athleticsTraining = value;
                NotifyPropertyChanged("AthleticsTraining");
                NotifyPropertyChanged("AthleticsBonus");
            }
        }
        public bool BluffTraining
        {
            get
            {
                return _bluffTraining;
            }
            set
            {
                _bluffTraining = value;
                NotifyPropertyChanged("BluffTraining");
                NotifyPropertyChanged("BluffBonus");
            }
        }
        public bool DiplomacyTraining
        {
            get
            {
                return _diplomacyTraining;
            }
            set
            {
                _diplomacyTraining = value;
                NotifyPropertyChanged("DiplomacyTraining");
                NotifyPropertyChanged("DiplomacyBonus");
            }
        }
        public bool DungeoneeringTraining
        {
            get
            {
                return _dungeoneeringTraining;
            }
            set
            {
                _dungeoneeringTraining = value;
                NotifyPropertyChanged("DungeoneeringTraining");
                NotifyPropertyChanged("DungeoneeringBonus");
            }
        }
        public bool EnduranceTraining
        {
            get
            {
                return _enduranceTraining;
            }
            set
            {
                _enduranceTraining = value;
                NotifyPropertyChanged("EnduranceTraining");
                NotifyPropertyChanged("EnduranceBonus");
            }
        }
        public bool HealTraining
        {
            get
            {
                return _healTraining;
            }
            set
            {
                _healTraining = value;
                NotifyPropertyChanged("HealTraining");
                NotifyPropertyChanged("HealBonus");
            }
        }
        public bool HistoryTraining
        {
            get
            {
                return _historyTraining;
            }
            set
            {
                _historyTraining = value;
                NotifyPropertyChanged("HistoryTraining");
                NotifyPropertyChanged("HistoryBonus");
            }
        }
        public bool InsightTraining
        {
            get
            {
                return _insightTraining;
            }
            set
            {
                _insightTraining = value;
                NotifyPropertyChanged("InsightTraining");
                NotifyPropertyChanged("InsightBonus");
            }
        }
        public bool IntimidateTraining
        {
            get
            {
                return _intimidateTraining;
            }
            set
            {
                _intimidateTraining = value;
                NotifyPropertyChanged("IntimidateTraining");
                NotifyPropertyChanged("IntimidateBonus");
            }
        }
        public bool NatureTraining
        {
            get
            {
                return _natureTraining;
            }
            set
            {
                _natureTraining = value;
                NotifyPropertyChanged("NatureTraining");
                NotifyPropertyChanged("NatureBonus");
            }
        }
        public bool PerceptionTraining
        {
            get
            {
                return _perceptionTraining;
            }
            set
            {
                _perceptionTraining = value;
                NotifyPropertyChanged("PerceptionTraining");
                NotifyPropertyChanged("PerceptionBonus");
            }
        }
        public bool ReligionTraining
        {
            get
            {
                return _religionTraining;
            }
            set
            {
                _religionTraining = value;
                NotifyPropertyChanged("ReligionTraining");
                NotifyPropertyChanged("ReligionBonus");
            }
        }
        public bool StealthTraining
        {
            get
            {
                return _stealthTraining;
            }
            set
            {
                _stealthTraining = value;
                NotifyPropertyChanged("StealthTraining");
                NotifyPropertyChanged("StealthBonus");
            }
        }
        public bool StreetwiseTraining
        {
            get
            {
                return _streetwiseTraining;
            }
            set
            {
                _streetwiseTraining = value;
                NotifyPropertyChanged("StreetwiseTraining");
                NotifyPropertyChanged("StreetwiseBonus");
            }
        }
        public bool ThieveryTraining
        {
            get
            {
                return _thieveryTraining;
            }
            set
            {
                _thieveryTraining = value;
                NotifyPropertyChanged("ThieveryTraining");
                NotifyPropertyChanged("ThieveryBonus");
            }
        }
        public int AcrobaticsPenalty
        {
            get
            {
                return _acrobaticsPenalty;
            }
            set
            {
                _acrobaticsPenalty = value;
                NotifyPropertyChanged("AcrobaticsPenalty");
            }
        }
        public int ArcanaPenalty
        {
            get
            {
                return _arcanaPenalty;
            }
            set
            {
                _arcanaPenalty = value;
                NotifyPropertyChanged("ArcanaPenalty");
            }
        }
        public int AthleticsPenalty
        {
            get
            {
                return _athleticsPenalty;
            }
            set
            {
                _athleticsPenalty = value;
                NotifyPropertyChanged("AthleticsPenalty");
            }
        }
        public int BluffPenalty
        {
            get
            {
                return _bluffPenalty;
            }
            set
            {
                _bluffPenalty = value;
                NotifyPropertyChanged("BluffPenalty");
            }
        }
        public int DiplomacyPenalty
        {
            get
            {
                return _diplomacyPenalty;
            }
            set
            {
                _diplomacyPenalty = value;
                NotifyPropertyChanged("DiplomacyPenalty");
            }
        }
        public int DungeoneeringPenalty
        {
            get
            {
                return _dungeoneeringPenalty;
            }
            set
            {
                _dungeoneeringPenalty = value;
                NotifyPropertyChanged("DungeoneeringPenalty");
            }
        }
        public int EndurancePenalty
        {
            get
            {
                return _endurancePenalty;
            }
            set
            {
                _endurancePenalty = value;
                NotifyPropertyChanged("EndurancePenalty");
            }
        }
        public int HealPenalty
        {
            get
            {
                return _healPenalty;
            }
            set
            {
                _healPenalty = value;
                NotifyPropertyChanged("HealPenalty");
            }
        }
        public int HistoryPenalty
        {
            get
            {
                return _historyPenalty;
            }
            set
            {
                _historyPenalty = value;
                NotifyPropertyChanged("HistoryPenalty");
            }
        }
        public int InsightPenalty
        {
            get
            {
                return _insightPenalty;
            }
            set
            {
                _insightPenalty = value;
                NotifyPropertyChanged("InsightPenalty");
            }
        }
        public int IntimidatePenalty
        {
            get
            {
                return _intimidatePenalty;
            }
            set
            {
                _intimidatePenalty = value;
                NotifyPropertyChanged("IntimidatePenalty");
            }
        }
        public int NaturePenalty
        {
            get
            {
                return _naturePenalty;
            }
            set
            {
                _naturePenalty = value;
                NotifyPropertyChanged("NaturePenalty");
            }
        }
        public int PerceptionPenalty
        {
            get
            {
                return _perceptionPenalty;
            }
            set
            {
                _perceptionPenalty = value;
                NotifyPropertyChanged("PerceptionPenalty");
            }
        }
        public int ReligionPenalty
        {
            get
            {
                return _religionPenalty;
            }
            set
            {
                _religionPenalty = value;
                NotifyPropertyChanged("ReligionPenalty");
            }
        }
        public int StealthPenalty
        {
            get
            {
                return _stealthPenalty;
            }
            set
            {
                _stealthPenalty = value;
                NotifyPropertyChanged("StealthPenalty");
            }
        }
        public int StreetwisePenalty
        {
            get
            {
                return _streetwisePenalty;
            }
            set
            {
                _streetwisePenalty = value;
                NotifyPropertyChanged("StreetwisePenalty");
            }
        }
        public int ThieveryPenalty
        {
            get
            {
                return _thieveryPenalty;
            }
            set
            {
                _thieveryPenalty = value;
                NotifyPropertyChanged("ThieveryPenalty");
            }
        }
        public int AcrobaticsMisc
        {
            get
            {
                return _acrobaticsMisc;
            }
            set
            {
                _acrobaticsMisc = value;
                NotifyPropertyChanged("AcrobaticsMisc");
            }
        }
        public int ArcanaMisc
        {
            get
            {
                return _arcanaMisc;
            }
            set
            {
                _arcanaMisc = value;
                NotifyPropertyChanged("ArcanaMisc");
            }
        }
        public int AthleticsMisc
        {
            get
            {
                return _athleticsMisc;
            }
            set
            {
                _athleticsMisc = value;
                NotifyPropertyChanged("AthleticsMisc");
            }
        }
        public int BluffMisc
        {
            get
            {
                return _bluffMisc;
            }
            set
            {
                _bluffMisc = value;
                NotifyPropertyChanged("BluffMisc");
            }
        }
        public int DiplomacyMisc
        {
            get
            {
                return _diplomacyMisc;
            }
            set
            {
                _diplomacyMisc = value;
                NotifyPropertyChanged("DiplomacyMisc");
            }
        }
        public int DungeoneeringMisc
        {
            get
            {
                return _dungeoneeringMisc;
            }
            set
            {
                _dungeoneeringMisc = value;
                NotifyPropertyChanged("DungeoneeringMisc");
            }
        }
        public int EnduranceMisc
        {
            get
            {
                return _enduranceMisc;
            }
            set
            {
                _enduranceMisc = value;
                NotifyPropertyChanged("EnduranceMisc");
            }
        }
        public int HealMisc
        {
            get
            {
                return _healMisc;
            }
            set
            {
                _healMisc = value;
                NotifyPropertyChanged("HealMisc");
            }
        }
        public int HistoryMisc
        {
            get
            {
                return _historyMisc;
            }
            set
            {
                _historyMisc = value;
                NotifyPropertyChanged("HistoryMisc");
            }
        }
        public int InsightMisc
        {
            get
            {
                return _insightMisc;
            }
            set
            {
                _insightMisc = value;
                NotifyPropertyChanged("InsightMisc");
            }
        }
        public int IntimidateMisc
        {
            get
            {
                return _intimidateMisc;
            }
            set
            {
                _intimidateMisc = value;
                NotifyPropertyChanged("IntimidateMisc");
            }
        }
        public int NatureMisc
        {
            get
            {
                return _natureMisc;
            }
            set
            {
                _natureMisc = value;
                NotifyPropertyChanged("NatureMisc");
            }
        }
        public int PerceptionMisc
        {
            get
            {
                return _perceptionMisc;
            }
            set
            {
                _perceptionMisc = value;
                NotifyPropertyChanged("PerceptionMisc");
            }
        }
        public int ReligionMisc
        {
            get
            {
                return _religionMisc;
            }
            set
            {
                _religionMisc = value;
                NotifyPropertyChanged("ReligionMisc");
            }
        }
        public int StealthMisc
        {
            get
            {
                return _stealthMisc;
            }
            set
            {
                _stealthMisc = value;
                NotifyPropertyChanged("StealthMisc");
            }
        }
        public int StreetwiseMisc
        {
            get
            {
                return _streetwiseMisc;
            }
            set
            {
                _streetwiseMisc = value;
                NotifyPropertyChanged("StreetwiseMisc");
            }
        }
        public int ThieveryMisc
        {
            get
            {
                return _thieveryMisc;
            }
            set
            {
                _thieveryMisc = value;
                NotifyPropertyChanged("ThieveryMisc");
            }
        }
        #endregion
        #endregion

        #region Constructors
        public Character()
        {
            Deity = new Deities();
            Class = new Classes();
            Race = new Races();
            TrainedSkills = new List<string>();
            StrengthRaw = 8;
            ConstitutionRaw = 10;
            DexterityRaw = 10;
            IntelligenceRaw = 10;
            WisdomRaw = 10;
            CharismaRaw = 10;
            RacialStrength = false;
            RacialConstitution = false;
            RacialDexterity = false;
            RacialIntelligence = false;
            RacialWisdom = false;
            RacialCharisma = false;
            PowerList = new List<Powers>();
    }

        public Character(JSONCharacter buffer)
        {
            Campaign = new Campaigns(buffer._campaign_setting, buffer._campaign_image, buffer._campaign_shortdescription, buffer._campaign_tidbits, buffer._campaign_description, buffer._campaign_background);
            Size = buffer._size;
            Speed = buffer._speed;
            Initiative = buffer._initiative;
            PassiveInsight = buffer._passiveInsight;
            PassivePerception = buffer._passivePerception;
            MaxAP = buffer._maxAP;
            Capacity = buffer._capacity;
            _name = buffer._name;
            Deity = new Deities(buffer._deity_deity, buffer._deity_domains, buffer._deity_domainDescriptions, buffer._deity_setting, buffer._deity_image, buffer._deity_description, buffer._deity_shortDescription, buffer._deity_alignment, buffer._deity_laws);
            _player = buffer._player;
            _alignment = buffer._alignment;
            _gender = buffer._gender;
            Class = new Classes(buffer._class_class, buffer._class_subclasses, buffer._class_primaryRoles, buffer._class_secondaryRoles, buffer._class_shortDescription, buffer._class_source, buffer._class_image, buffer.class_preferedRaces);
            Class.Subclass = new SubClasses(buffer._class_subclass_subClass, buffer._class_subclass_shortDescription, buffer._class_subclass_description, buffer._class_subclass_source, buffer._class_subclass_power, buffer._class_subclass_role, buffer._class_subclass_abilities,
                buffer._class_subclass_hPStart, buffer._class_subclass_hPLvl, buffer._class_subclass_defences, buffer._class_subclass_attack, buffer._class_subclass_surges, buffer._class_subclass_proficiencies, buffer._class_subclass_skillTraining, buffer._class_subclass_skills, buffer._class_subclass_paths,
                buffer._class_subclass_defaultFeat, buffer._class_subclass_implements, buffer._class_subclass_special, buffer._class_subclass_encounter, buffer._class_subclass_builds, buffer._class_subclass_feats, buffer._class_subclass_headers, buffer._class_subclass_bodies, buffer._class_subclass_listOptions,
                buffer._class_subclass_pp);
            Class.Subclass.Build = new Builds(buffer._class_subclass_build_build, buffer._class_subclass_build_subclass, buffer._class_subclass_build_description, buffer._class_subclass_build_feat, buffer._class_subclass_build_humanFeat, buffer._class_subclass_build_skills,
                buffer._class_subclass_build_atwills, buffer._class_subclass_build_encounter, buffer._class_subclass_build_daily, buffer._class_subclass_build_option, buffer._class_subclass_build_shortDescription);
            Class.Subclass.OptionPicked1 = new ClassOption(buffer._class_subclass_optionPicked1_optionName, buffer._class_subclass_optionPicked1_optionDetails);
            Class.Subclass.OptionPicked1 = new ClassOption(buffer._class_subclass_optionPicked2_optionName, buffer._class_subclass_optionPicked2_optionDetails);
            Race = new Races(buffer._race_race, buffer._race_size, buffer._race_speedType, buffer._race_vision, buffer._race_shortDescription, buffer._race_description, buffer._race_heightFeet, buffer._race_heightCM, buffer._race_weightKG, buffer._race_weightLBS, 
                buffer._race_age, buffer._race_source, buffer._race_image, buffer._race_speed, buffer._race_subRaces, buffer._race_traits, buffer._race_abilities, buffer._race_defences, buffer._race_skills, buffer._race_resistances, buffer._race_powers, 
                buffer._race_languages, buffer._race_feats, buffer._race_headers, buffer._race_bodies, buffer._race_physical, buffer._race_playing, buffer._race_adventure, buffer._race_maleNames, buffer._race_femaleNames, buffer._race_abilityChoice);
            Race.SubRace = new SubRaces(buffer._race_subrace_subRace, buffer._race_subrace_description);
            _knownLanguages = buffer._knownLanguages;
            _description = buffer._description;
            _background = buffer._background;
            _theme = buffer._theme;
            _mannerisms = buffer._mannerisms;
            _personality = buffer._personality;
            _company = buffer._company;
            _companions = buffer._companions;
            _notes = buffer._notes;
            _armorClass = buffer._armorClass;
            _fortitude = buffer._fortitude;
            _reflexes = buffer._reflexes;
            _willpower = buffer._willpower;
            _maxHP = buffer._maxHP;
            _bloodiedHP = buffer._bloodiedHP;
            _powerPoints = buffer._powerPoints;
            _healingSurges = buffer._healingSurges;
            _healingSurgeValue = buffer._healingSurgeValue;
            _strengthRaw = buffer._strengthRaw;
            _constitutionRaw = buffer._constitutionRaw;
            _dexterityRaw = buffer._dexterityRaw;
            _intelligenceRaw = buffer._intelligenceRaw;
            _wisdomRaw = buffer._wisdomRaw;
            _charismaRaw = buffer._charismaRaw;
            _strength = buffer._strength;
            _constitution = buffer._constitution;
            _dexterity = buffer._dexterity;
            _intelligence = buffer._intelligence;
            _wisdom = buffer._wisdom;
            _charisma = buffer._charisma;
            _strengthMod = buffer._strengthMod;
            _constitutionMod = buffer._constitutionMod;
            _dexterityMod = buffer._dexterityMod;
            _intelligenceMod = buffer._intelligenceMod;
            _wisdomMod = buffer._wisdomMod;
            _charismaMod = buffer._charismaMod;
            _strengthCheck = buffer._strengthCheck;
            _constitutionCheck = buffer._constitutionCheck;
            _dexterityCheck = buffer._dexterityCheck;
            _intelligenceCheck = buffer._intelligenceCheck;
            _wisdomCheck = buffer._wisdomCheck;
            _charismaCheck = buffer._charismaCheck;
            _level = buffer._level;
            _totalXP = buffer._totalXP;
            _weight = buffer._weight;
            _age = buffer._age;
            _height = buffer._height;
            _racialStrength = buffer._racialStrength;
            _racialConstitution = buffer._racialConstitution;
            _racialDexterity = buffer._racialDexterity;
            _racialIntelligence = buffer._racialIntelligence;
            _racialWisdom = buffer._racialWisdom;
            _racialCharisma = buffer._racialCharisma;
            _trainedSkills = buffer._trainedSkills;
            _acrobaticsBonus = buffer._acrobaticsBonus;
            _arcanaBonus = buffer._arcanaBonus;
            _athleticsBonus = buffer._athleticsBonus;
            _bluffBonus = buffer._bluffBonus;
            _diplomacyBonus = buffer._diplomacyBonus;
            _dungeoneeringBonus = buffer._dungeoneeringBonus;
            _enduranceBonus = buffer._enduranceBonus;
            _healBonus = buffer._healBonus;
            _historyBonus = buffer._historyBonus;
            _insightBonus = buffer._insightBonus;
            _intimidateBonus = buffer._intimidateBonus;
            _natureBonus = buffer._natureBonus;
            _perceptionBonus = buffer._perceptionBonus;
            _religionBonus = buffer._religionBonus;
            _stealthBonus = buffer._stealthBonus;
            _streetwiseBonus = buffer._streetwiseBonus;
            _thieveryBonus = buffer._thieveryBonus;
            _acrobaticsTraining = buffer._acrobaticsTraining;
            _arcanaTraining = buffer._arcanaTraining;
            _athleticsTraining = buffer._athleticsTraining;
            _bluffTraining = buffer._bluffTraining;
            _diplomacyTraining = buffer._diplomacyTraining;
            _dungeoneeringTraining = buffer._dungeoneeringTraining;
            _enduranceTraining = buffer._enduranceTraining;
            _healTraining = buffer._healTraining;
            _historyTraining = buffer._historyTraining;
            _insightTraining = buffer._insightTraining;
            _intimidateTraining = buffer._intimidateTraining;
            _natureTraining = buffer._natureTraining;
            _perceptionTraining = buffer._perceptionTraining;
            _religionTraining = buffer._religionTraining;
            _stealthTraining = buffer._stealthTraining;
            _streetwiseTraining = buffer._streetwiseTraining;
            _thieveryTraining = buffer._thieveryTraining;
            _acrobaticsPenalty = buffer._acrobaticsPenalty;
            _arcanaPenalty = buffer._arcanaPenalty;
            _athleticsPenalty = buffer._athleticsPenalty;
            _bluffPenalty = buffer._bluffPenalty;
            _diplomacyPenalty = buffer._diplomacyPenalty;
            _dungeoneeringPenalty = buffer._dungeoneeringPenalty;
            _endurancePenalty = buffer._endurancePenalty;
            _healPenalty = buffer._healPenalty;
            _historyPenalty = buffer._historyPenalty;
            _insightPenalty = buffer._insightPenalty;
            _intimidatePenalty = buffer._intimidatePenalty;
            _naturePenalty = buffer._naturePenalty;
            _perceptionPenalty = buffer._perceptionPenalty;
            _religionPenalty = buffer._religionPenalty;
            _stealthPenalty = buffer._stealthPenalty;
            _streetwisePenalty = buffer._streetwisePenalty;
            _thieveryPenalty = buffer._thieveryPenalty;
            _acrobaticsMisc = buffer._acrobaticsMisc;
            _arcanaMisc = buffer._arcanaMisc;
            _athleticsMisc = buffer._athleticsMisc;
            _bluffMisc = buffer._bluffMisc;
            _diplomacyMisc = buffer._diplomacyMisc;
            _dungeoneeringMisc = buffer._dungeoneeringMisc;
            _enduranceMisc = buffer._enduranceMisc;
            _healMisc = buffer._healMisc;
            _historyMisc = buffer._historyMisc;
            _insightMisc = buffer._insightMisc;
            _intimidateMisc = buffer._intimidateMisc;
            _natureMisc = buffer._natureMisc;
            _perceptionMisc = buffer._perceptionMisc;
            _religionMisc = buffer._religionMisc;
            _stealthMisc = buffer._stealthMisc;
            _streetwiseMisc = buffer._streetwiseMisc;
            _thieveryMisc = buffer._thieveryMisc;
            if (buffer._powerList != null)
                foreach (JSONPower bufferPower in buffer._powerList)
                {
                    Powers tempPower = new Powers();
                    tempPower.Power = bufferPower._power;
                    tempPower.Source = bufferPower._source;
                    tempPower.Origin = bufferPower._origin;
                    tempPower.OriginType = bufferPower._originType;
                    tempPower.PowerType = bufferPower._powerType;
                    tempPower.PowerUsage = bufferPower._powerUsage;
                    tempPower.ActionType = bufferPower._actionType;
                    tempPower.AttackType = bufferPower._attackType;
                    tempPower.AttackVsType = bufferPower._attackVsType;
                    tempPower.Hit = bufferPower._hit;
                    tempPower.Hits = bufferPower._hits;
                    tempPower.HitLevels = bufferPower._hitLevels;
                    tempPower.MethodTypes = bufferPower._methodTypes;
                    tempPower.MethodRanges = bufferPower._methodRanges;
                    tempPower.Target = bufferPower._target;
                    tempPower.Prerequisite = bufferPower._prerequisite;
                    tempPower.PrerequisiteType = bufferPower._prerequisiteType;
                    tempPower.Requirement = bufferPower._requirement;
                    tempPower.RequirementType = bufferPower._requirementType;
                    tempPower.Headers = bufferPower._headers;
                    tempPower.Bodies = bufferPower._bodies;
                    tempPower.AdditionalEffectName = bufferPower._additionalEffectName;
                    tempPower.AdditionalEffectDescription = bufferPower._additionalEffectDescription;
                    tempPower.Feats = bufferPower._feats;
                    PowerList.Add(tempPower);
                }
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
      
        public JSONCharacter SaveCharacter()
        {
            JSONCharacter buffer = new JSONCharacter();
            buffer._campaign_setting = Campaign.Setting;
            buffer._campaign_image = Campaign.Image;
            buffer._campaign_shortdescription = Campaign.Shortdescription;
            buffer._campaign_tidbits = Campaign.Tidbits;
            buffer._campaign_description = Campaign.Description;
            buffer._campaign_background = Campaign.Background;
            buffer._size = Size;
            buffer._speed = Speed;
            buffer._initiative = Initiative;
            buffer._passiveInsight = PassiveInsight;
            buffer._passivePerception = PassivePerception;
            buffer._maxAP = MaxAP;
            buffer._capacity = Capacity;
            buffer._name = _name;
            buffer._deity_deity = Deity.Deity;
            buffer._deity_domains = Deity.Domains;
            buffer._deity_domainDescriptions = Deity.DomainDescriptions;
            buffer._deity_setting = Deity.Setting;
            buffer._deity_image = Deity.Image;
            buffer._deity_description = Deity.Description;
            buffer._deity_shortDescription = Deity.ShortDescription;
            buffer._deity_alignment = Deity.Alignment;
            buffer._deity_laws = Deity.Laws;
            buffer._player = _player;
            buffer._alignment = _alignment;
            buffer._gender = _gender;
            buffer._class_class = Class.Class;
            buffer._class_subclasses = Class.Subclasses;
            buffer._class_primaryRoles = Class.PrimaryRoles;
            buffer._class_secondaryRoles = Class.SecondaryRoles;
            buffer._class_shortDescription = Class.ShortDescription;
            buffer._class_source = Class.Source;
            buffer._class_image = Class.Image;
            buffer.class_preferedRaces = Class.PreferredRaces;
            buffer._class_subclass_subClass = Class.Subclass.SubClass;
            buffer._class_subclass_shortDescription = Class.Subclass.ShortDescription;
            buffer._class_subclass_description = Class.Subclass.Description;
            buffer._class_subclass_source = Class.Subclass.Source;
            buffer._class_subclass_power = Class.Subclass.Power;
            buffer._class_subclass_role = Class.Subclass.Role;
            buffer._class_subclass_abilities = Class.Subclass.Abilities;
            buffer._class_subclass_hPStart = Class.Subclass.HPStart;
            buffer._class_subclass_hPLvl = Class.Subclass.HPLvl;
            buffer._class_subclass_defences = Class.Subclass.Defences;
            buffer._class_subclass_attack = Class.Subclass.Attack;
            buffer._class_subclass_surges = Class.Subclass.Surges;
            buffer._class_subclass_proficiencies = Class.Subclass.Proficiencies;
            buffer._class_subclass_skillTraining = Class.Subclass.SkillTraining;
            buffer._class_subclass_skills = Class.Subclass.Skills;
            buffer._class_subclass_paths = Class.Subclass.Paths;
            buffer._class_subclass_defaultFeat = Class.Subclass.DefaultFeat;
            buffer._class_subclass_implements = Class.Subclass.Implements;
            buffer._class_subclass_special = Class.Subclass.Special;
            buffer._class_subclass_encounter = Class.Subclass.Encounter;
            buffer._class_subclass_build_build = Class.Subclass.Build.Build;
            buffer._class_subclass_build_subclass = Class.Subclass.Build.Subclass;
            buffer._class_subclass_build_description = Class.Subclass.Build.Description;
            buffer._class_subclass_build_feat = Class.Subclass.Build.Feat;
            buffer._class_subclass_build_humanFeat = Class.Subclass.Build.HumanFeat;
            buffer._class_subclass_build_skills = Class.Subclass.Build.Skills;
            buffer._class_subclass_build_atwills = Class.Subclass.Build.Atwills;
            buffer._class_subclass_build_encounter = Class.Subclass.Build.Encounter;
            buffer._class_subclass_build_daily = Class.Subclass.Build.Daily;
            buffer._class_subclass_build_option = Class.Subclass.Build.Option;
            buffer._class_subclass_build_shortDescription = Class.Subclass.Build.ShortDescription;
            buffer._class_subclass_builds = Class.Subclass.Builds;
            buffer._class_subclass_feats = Class.Subclass.Feats;
            buffer._class_subclass_headers = Class.Subclass.Headers;
            buffer._class_subclass_bodies = Class.Subclass.Bodies;
            buffer._class_subclass_listOptions = Class.Subclass.ListOptions;
            buffer._class_subclass_optionPicked1_optionName = Class.Subclass.OptionPicked1.OptionName;
            buffer._class_subclass_optionPicked1_optionDetails = Class.Subclass.OptionPicked1.OptionDetails;
            buffer._class_subclass_optionPicked2_optionName = Class.Subclass.OptionPicked2.OptionName;
            buffer._class_subclass_optionPicked2_optionDetails = Class.Subclass.OptionPicked2.OptionDetails;
            buffer._class_subclass_pp = Class.Subclass.PP;
            buffer._race_race = Race.Race;
            buffer._race_size = Race.Size;
            buffer._race_speedType = Race.SpeedType;
            buffer._race_vision = Race.Vision;
            buffer._race_shortDescription = Race.ShortDescription;
            buffer._race_description = Race.Description;
            buffer._race_heightFeet = Race.HeightFeet;
            buffer._race_heightCM = Race.HeightCM;
            buffer._race_weightKG = Race.WeightKG;
            buffer._race_weightLBS = Race.WeightLBS;
            buffer._race_age = Race.Age;
            buffer._race_source = Race.Source;
            buffer._race_image = Race.Image;
            buffer._race_speed = Race.Speed;
            buffer._race_subRaces = Race.SubRaces;
            buffer._race_traits = Race.Traits;
            buffer._race_abilities = Race.Abilities;
            buffer._race_defences = Race.Defences;
            buffer._race_skills = Race.Skills;
            buffer._race_resistances = Race.Resistances;
            buffer._race_powers = Race.Powers;
            buffer._race_languages = Race.Languages;
            buffer._race_feats = Race.Feats;
            buffer._race_headers = Race.Headers;
            buffer._race_bodies = Race.Bodies;
            buffer._race_physical = Race.Physical;
            buffer._race_playing = Race.Playing;
            buffer._race_adventure = Race.Adventure;
            buffer._race_maleNames = Race.MaleNames;
            buffer._race_femaleNames = Race.FemaleNames;
            buffer._race_subrace_subRace = Race.SubRace.SubRace;
            buffer._race_subrace_description = Race.SubRace.Description;
            buffer._race_abilityChoice = Race.AbilityChoice;
            buffer._knownLanguages = _knownLanguages;
            buffer._description = _description;
            buffer._background = _background;
            buffer._theme = _theme;
            buffer._mannerisms = _mannerisms;
            buffer._personality = _personality;
            buffer._company = _company;
            buffer._companions = _companions;
            buffer._notes = _notes;
            buffer._armorClass = _armorClass;
            buffer._fortitude = _fortitude;
            buffer._reflexes = _reflexes;
            buffer._willpower = _willpower;
            buffer._maxHP = _maxHP;
            buffer._bloodiedHP = _bloodiedHP;
            buffer._powerPoints = _powerPoints;
            buffer._healingSurges = _healingSurges;
            buffer._healingSurgeValue = _healingSurgeValue;
            buffer._strengthRaw = _strengthRaw;
            buffer._constitutionRaw = _constitutionRaw;
            buffer._dexterityRaw = _dexterityRaw;
            buffer._intelligenceRaw = _intelligenceRaw;
            buffer._wisdomRaw = _wisdomRaw;
            buffer._charismaRaw = _charismaRaw;
            buffer._strength = _strength;
            buffer._constitution = _constitution;
            buffer._dexterity = _dexterity;
            buffer._intelligence = _intelligence;
            buffer._wisdom = _wisdom;
            buffer._charisma = _charisma;
            buffer._strengthMod = _strengthMod;
            buffer._constitutionMod = _constitutionMod;
            buffer._dexterityMod = _dexterityMod;
            buffer._intelligenceMod = _intelligenceMod;
            buffer._wisdomMod = _wisdomMod;
            buffer._charismaMod = _charismaMod;
            buffer._strengthCheck = _strengthCheck;
            buffer._constitutionCheck = _constitutionCheck;
            buffer._dexterityCheck = _dexterityCheck;
            buffer._intelligenceCheck = _intelligenceCheck;
            buffer._wisdomCheck = _wisdomCheck;
            buffer._charismaCheck = _charismaCheck;
            buffer._level = _level;
            buffer._totalXP = _totalXP;
            buffer._weight = _weight;
            buffer._age = _age;
            buffer._height = _height;
            buffer._racialStrength = _racialStrength;
            buffer._racialConstitution = _racialConstitution;
            buffer._racialDexterity = _racialDexterity;
            buffer._racialIntelligence = _racialIntelligence;
            buffer._racialWisdom = _racialWisdom;
            buffer._racialCharisma = _racialCharisma;
            buffer._trainedSkills = _trainedSkills;
            buffer._acrobaticsBonus = _acrobaticsBonus;
            buffer._arcanaBonus = _arcanaBonus;
            buffer._athleticsBonus = _athleticsBonus;
            buffer._bluffBonus = _bluffBonus;
            buffer._diplomacyBonus = _diplomacyBonus;
            buffer._dungeoneeringBonus = _dungeoneeringBonus;
            buffer._enduranceBonus = _enduranceBonus;
            buffer._healBonus = _healBonus;
            buffer._historyBonus = _historyBonus;
            buffer._insightBonus = _insightBonus;
            buffer._intimidateBonus = _intimidateBonus;
            buffer._natureBonus = _natureBonus;
            buffer._perceptionBonus = _perceptionBonus;
            buffer._religionBonus = _religionBonus;
            buffer._stealthBonus = _stealthBonus;
            buffer._streetwiseBonus = _streetwiseBonus;
            buffer._thieveryBonus = _thieveryBonus;
            buffer._acrobaticsTraining = _acrobaticsTraining;
            buffer._arcanaTraining = _arcanaTraining;
            buffer._athleticsTraining = _athleticsTraining;
            buffer._bluffTraining = _bluffTraining;
            buffer._diplomacyTraining = _diplomacyTraining;
            buffer._dungeoneeringTraining = _dungeoneeringTraining;
            buffer._enduranceTraining = _enduranceTraining;
            buffer._healTraining = _healTraining;
            buffer._historyTraining = _historyTraining;
            buffer._insightTraining = _insightTraining;
            buffer._intimidateTraining = _intimidateTraining;
            buffer._natureTraining = _natureTraining;
            buffer._perceptionTraining = _perceptionTraining;
            buffer._religionTraining = _religionTraining;
            buffer._stealthTraining = _stealthTraining;
            buffer._streetwiseTraining = _streetwiseTraining;
            buffer._thieveryTraining = _thieveryTraining;
            buffer._acrobaticsPenalty = _acrobaticsPenalty;
            buffer._arcanaPenalty = _arcanaPenalty;
            buffer._athleticsPenalty = _athleticsPenalty;
            buffer._bluffPenalty = _bluffPenalty;
            buffer._diplomacyPenalty = _diplomacyPenalty;
            buffer._dungeoneeringPenalty = _dungeoneeringPenalty;
            buffer._endurancePenalty = _endurancePenalty;
            buffer._healPenalty = _healPenalty;
            buffer._historyPenalty = _historyPenalty;
            buffer._insightPenalty = _insightPenalty;
            buffer._intimidatePenalty = _intimidatePenalty;
            buffer._naturePenalty = _naturePenalty;
            buffer._perceptionPenalty = _perceptionPenalty;
            buffer._religionPenalty = _religionPenalty;
            buffer._stealthPenalty = _stealthPenalty;
            buffer._streetwisePenalty = _streetwisePenalty;
            buffer._thieveryPenalty = _thieveryPenalty;
            buffer._acrobaticsMisc = _acrobaticsMisc;
            buffer._arcanaMisc = _arcanaMisc;
            buffer._athleticsMisc = _athleticsMisc;
            buffer._bluffMisc = _bluffMisc;
            buffer._diplomacyMisc = _diplomacyMisc;
            buffer._dungeoneeringMisc = _dungeoneeringMisc;
            buffer._enduranceMisc = _enduranceMisc;
            buffer._healMisc = _healMisc;
            buffer._historyMisc = _historyMisc;
            buffer._insightMisc = _insightMisc;
            buffer._intimidateMisc = _intimidateMisc;
            buffer._natureMisc = _natureMisc;
            buffer._perceptionMisc = _perceptionMisc;
            buffer._religionMisc = _religionMisc;
            buffer._stealthMisc = _stealthMisc;
            buffer._streetwiseMisc = _streetwiseMisc;
            buffer._thieveryMisc = _thieveryMisc;
            foreach (Powers tempPower in PowerList)
            {
                JSONPower bufferPower = new JSONPower();
                bufferPower._power = tempPower.Power;
                bufferPower._source = tempPower.Source;
                bufferPower._origin = tempPower.Origin;
                bufferPower._originType = tempPower.OriginType;
                bufferPower._powerType = tempPower.PowerType;
                bufferPower._powerUsage = tempPower.PowerUsage;
                bufferPower._actionType = tempPower.ActionType;
                bufferPower._attackType = tempPower.AttackType;
                bufferPower._attackVsType = tempPower.AttackVsType;
                bufferPower._hit = tempPower.Hit;
                bufferPower._hits = tempPower.Hits;
                bufferPower._hitLevels = tempPower.HitLevels;
                bufferPower._methodTypes = tempPower.MethodTypes;
                bufferPower._methodRanges = tempPower.MethodRanges;
                bufferPower._target = tempPower.Target;
                bufferPower._prerequisite = tempPower.Prerequisite;
                bufferPower._prerequisiteType = tempPower.PrerequisiteType;
                bufferPower._requirement = tempPower.Requirement;
                bufferPower._requirementType = tempPower.RequirementType;
                bufferPower._headers = tempPower.Headers;
                bufferPower._bodies = tempPower.Bodies;
                bufferPower._additionalEffectName = tempPower.AdditionalEffectName;
                bufferPower._additionalEffectDescription = tempPower.AdditionalEffectDescription;
                bufferPower._feats = tempPower.Feats;
                buffer._powerList.Add(bufferPower);
            }
            return buffer;
        }
        #endregion
    }
}
