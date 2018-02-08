using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    //[DataContract]
    //public class ClassSubclassListOption
    //{
    //    [DataMember(Name = "OptionDetails")]
    //    public List<string> OptionDetails { get; set; }
    //    [DataMember(Name = "OptionSelections")]
    //    public List<string> OptionSelections { get; set; }
    //    [DataMember(Name = "Options")]
    //    public List<string> Options { get; set; }
    //}

    //[DataContract]
    //public class KnownLanguage
    //{
    //    [DataMember(Name = "Description")]
    //    public string Description { get; set; }
    //    [DataMember(Name = "Image")]
    //    public string Image { get; set; }
    //    [DataMember(Name = "Language")]
    //    public string Language { get; set; }
    //    [DataMember(Name = "Setting")]
    //    public string Setting { get; set; }
    //}

    [DataContract]
    public class JSONConverter
    {
        [DataMember(Name = "_capacity")]
        public int _capacity { get; set; }
        [DataMember(Name = "_initiative")]
        public int _initiative { get; set; }
        [DataMember(Name = "_maxAP")]
        public int _maxAP { get; set; }
        [DataMember(Name = "_passiveInsight")]
        public int _passiveInsight { get; set; }
        [DataMember(Name = "_passivePerception")]
        public int _passivePerception { get; set; }
        [DataMember(Name = "_size")]
        public string _size { get; set; }
        [DataMember(Name = "_speed")]
        public int _speed { get; set; }
        [DataMember(Name = "_acrobaticsBonus")]
        public int _acrobaticsBonus { get; set; }
        [DataMember(Name = "_acrobaticsMisc")]
        public int _acrobaticsMisc { get; set; }
        [DataMember(Name = "_acrobaticsPenalty")]
        public int _acrobaticsPenalty { get; set; }
        [DataMember(Name = "_acrobaticsTraining")]
        public bool _acrobaticsTraining { get; set; }
        [DataMember(Name = "_age")]
        public string _age { get; set; }
        [DataMember(Name = "_alignment")]
        public string _alignment { get; set; }
        [DataMember(Name = "_arcanaBonus")]
        public int _arcanaBonus { get; set; }
        [DataMember(Name = "_arcanaMisc")]
        public int _arcanaMisc { get; set; }
        [DataMember(Name = "_arcanaPenalty")]
        public int _arcanaPenalty { get; set; }
        [DataMember(Name = "_arcanaTraining")]
        public bool _arcanaTraining { get; set; }
        [DataMember(Name = "_armorClass")]
        public int _armorClass { get; set; }
        [DataMember(Name = "_athleticsBonus")]
        public int _athleticsBonus { get; set; }
        [DataMember(Name = "_athleticsMisc")]
        public int _athleticsMisc { get; set; }
        [DataMember(Name = "_athleticsPenalty")]
        public int _athleticsPenalty { get; set; }
        [DataMember(Name = "_athleticsTraining")]
        public bool _athleticsTraining { get; set; }
        [DataMember(Name = "_background")]
        public string _background { get; set; }
        [DataMember(Name = "_bloodiedHP")]
        public int _bloodiedHP { get; set; }
        [DataMember(Name = "_bluffBonus")]
        public int _bluffBonus { get; set; }
        [DataMember(Name = "_bluffMisc")]
        public int _bluffMisc { get; set; }
        [DataMember(Name = "_bluffPenalty")]
        public int _bluffPenalty { get; set; }
        [DataMember(Name = "_bluffTraining")]
        public bool _bluffTraining { get; set; }
        [DataMember(Name = "_campaign_image")]
        public string _campaign_image { get; set; }
        [DataMember(Name = "_campaign_setting")]
        public string _campaign_setting { get; set; }
        [DataMember(Name = "_campaign_shortdescription")]
        public string _campaign_shortdescription { get; set; }
        [DataMember(Name = "_campaign_tidbits")]
        public string _campaign_tidbits { get; set; }
        [DataMember(Name = "_campaign_description")]
        public string _campaign_description { get; set; }
        [DataMember(Name = "_campaign_background")]
        public string _campaign_background { get; set; }
        [DataMember(Name = "_charisma")]
        public int _charisma { get; set; }
        [DataMember(Name = "_charismaCheck")]
        public int _charismaCheck { get; set; }
        [DataMember(Name = "_charismaMod")]
        public int _charismaMod { get; set; }
        [DataMember(Name = "_charismaRaw")]
        public int _charismaRaw { get; set; }
        [DataMember(Name = "_class_class")]
        public string _class_class { get; set; }
        [DataMember(Name = "_class_image")]
        public string _class_image { get; set; }
        [DataMember(Name = "_class_primaryRoles")]
        public string _class_primaryRoles { get; set; }
        [DataMember(Name = "_class_secondaryRoles")]
        public string _class_secondaryRoles { get; set; }
        [DataMember(Name = "_class_shortDescription")]
        public string _class_shortDescription { get; set; }
        [DataMember(Name = "_class_source")]
        public List<string> _class_source { get; set; }
        [DataMember(Name = "class_preferedRaces")]
        public List<string> class_preferedRaces { get; set; }
        [DataMember(Name = "_class_subclass_abilities")]
        public List<string> _class_subclass_abilities { get; set; }
        [DataMember(Name = "_class_subclass_attack")]
        public int _class_subclass_attack { get; set; }
        [DataMember(Name = "_class_subclass_bodies")]
        public List<string> _class_subclass_bodies { get; set; }
        [DataMember(Name = "_class_subclass_build_atwills")]
        public List<string> _class_subclass_build_atwills { get; set; }
        [DataMember(Name = "_class_subclass_build_build")]
        public string _class_subclass_build_build { get; set; }
        [DataMember(Name = "_class_subclass_build_daily")]
        public string _class_subclass_build_daily { get; set; }
        [DataMember(Name = "_class_subclass_build_description")]
        public string _class_subclass_build_description { get; set; }
        [DataMember(Name = "_class_subclass_build_encounter")]
        public string _class_subclass_build_encounter { get; set; }
        [DataMember(Name = "_class_subclass_build_feat")]
        public string _class_subclass_build_feat { get; set; }
        [DataMember(Name = "_class_subclass_build_humanFeat")]
        public string _class_subclass_build_humanFeat { get; set; }
        [DataMember(Name = "_class_subclass_build_option")]
        public string _class_subclass_build_option { get; set; }
        [DataMember(Name = "_class_subclass_build_shortDescription")]
        public string _class_subclass_build_shortDescription { get; set; }
        [DataMember(Name = "_class_subclass_build_skills")]
        public List<string> _class_subclass_build_skills { get; set; }
        [DataMember(Name = "_class_subclass_build_subclass")]
        public string _class_subclass_build_subclass { get; set; }
        [DataMember(Name = "_class_subclass_builds")]
        public List<string> _class_subclass_builds { get; set; }
        [DataMember(Name = "_class_subclass_defaultFeat")]
        public string _class_subclass_defaultFeat { get; set; }
        [DataMember(Name = "_class_subclass_defences")]
        public List<int> _class_subclass_defences { get; set; }
        [DataMember(Name = "_class_subclass_description")]
        public string _class_subclass_description { get; set; }
        [DataMember(Name = "_class_subclass_encounter")]
        public string _class_subclass_encounter { get; set; }
        [DataMember(Name = "_class_subclass_feats")]
        public List<string> _class_subclass_feats { get; set; }
        [DataMember(Name = "_class_subclass_hPLvl")]
        public int _class_subclass_hPLvl { get; set; }
        [DataMember(Name = "_class_subclass_hPStart")]
        public int _class_subclass_hPStart { get; set; }
        [DataMember(Name = "_class_subclass_headers")]
        public List<string> _class_subclass_headers { get; set; }
        [DataMember(Name = "_class_subclass_implements")]
        public List<string> _class_subclass_implements { get; set; }
        [DataMember(Name = "_class_subclass_listOptions")]
        public List<SubClasses.OptionChoices> _class_subclass_listOptions { get; set; }
        [DataMember(Name = "_class_subclass_optionPicked1_optionDetails")]
        public string _class_subclass_optionPicked1_optionDetails { get; set; }
        [DataMember(Name = "_class_subclass_optionPicked1_optionName")]
        public string _class_subclass_optionPicked1_optionName { get; set; }
        [DataMember(Name = "_class_subclass_optionPicked2_optionDetails")]
        public string _class_subclass_optionPicked2_optionDetails { get; set; }
        [DataMember(Name = "_class_subclass_optionPicked2_optionName")]
        public string _class_subclass_optionPicked2_optionName { get; set; }
        [DataMember(Name = "_class_subclass_paths")]
        public List<string> _class_subclass_paths { get; set; }
        [DataMember(Name = "_class_subclass_power")]
        public string _class_subclass_power { get; set; }
        [DataMember(Name = "_class_subclass_pp")]
        public bool _class_subclass_pp { get; set; }
        [DataMember(Name = "_class_subclass_proficiencies")]
        public List<bool> _class_subclass_proficiencies { get; set; }
        [DataMember(Name = "_class_subclass_role")]
        public string _class_subclass_role { get; set; }
        [DataMember(Name = "_class_subclass_shortDescription")]
        public string _class_subclass_shortDescription { get; set; }
        [DataMember(Name = "_class_subclass_skillTraining")]
        public int _class_subclass_skillTraining { get; set; }
        [DataMember(Name = "_class_subclass_skills")]
        public List<int> _class_subclass_skills { get; set; }
        [DataMember(Name = "_class_subclass_source")]
        public string _class_subclass_source { get; set; }
        [DataMember(Name = "_class_subclass_special")]
        public string _class_subclass_special { get; set; }
        [DataMember(Name = "_class_subclass_subClass")]
        public string _class_subclass_subClass { get; set; }
        [DataMember(Name = "_class_subclass_surges")]
        public int _class_subclass_surges { get; set; }
        [DataMember(Name = "_class_subclasses")]
        public List<string> _class_subclasses { get; set; }
        [DataMember(Name = "_companions")]
        public string _companions { get; set; }
        [DataMember(Name = "_company")]
        public string _company { get; set; }
        [DataMember(Name = "_constitution")]
        public int _constitution { get; set; }
        [DataMember(Name = "_constitutionCheck")]
        public int _constitutionCheck { get; set; }
        [DataMember(Name = "_constitutionMod")]
        public int _constitutionMod { get; set; }
        [DataMember(Name = "_constitutionRaw")]
        public int _constitutionRaw { get; set; }
        [DataMember(Name = "_deity_alignment")]
        public string _deity_alignment { get; set; }
        [DataMember(Name = "_deity_deity")]
        public string _deity_deity { get; set; }
        [DataMember(Name = "_deity_description")]
        public string _deity_description { get; set; }
        [DataMember(Name = "_deity_domainDescriptions")]
        public List<string> _deity_domainDescriptions { get; set; }
        [DataMember(Name = "_deity_domains")]
        public List<string> _deity_domains { get; set; }
        [DataMember(Name = "_deity_image")]
        public string _deity_image { get; set; }
        [DataMember(Name = "_deity_laws")]
        public List<string> _deity_laws { get; set; }
        [DataMember(Name = "_deity_setting")]
        public string _deity_setting { get; set; }
        [DataMember(Name = "_deity_shortDescription")]
        public string _deity_shortDescription { get; set; }
        [DataMember(Name = "_description")]
        public string _description { get; set; }
        [DataMember(Name = "_dexterity")]
        public int _dexterity { get; set; }
        [DataMember(Name = "_dexterityCheck")]
        public int _dexterityCheck { get; set; }
        [DataMember(Name = "_dexterityMod")]
        public int _dexterityMod { get; set; }
        [DataMember(Name = "_dexterityRaw")]
        public int _dexterityRaw { get; set; }
        [DataMember(Name = "_diplomacyBonus")]
        public int _diplomacyBonus { get; set; }
        [DataMember(Name = "_diplomacyMisc")]
        public int _diplomacyMisc { get; set; }
        [DataMember(Name = "_diplomacyPenalty")]
        public int _diplomacyPenalty { get; set; }
        [DataMember(Name = "_diplomacyTraining")]
        public bool _diplomacyTraining { get; set; }
        [DataMember(Name = "_dungeoneeringBonus")]
        public int _dungeoneeringBonus { get; set; }
        [DataMember(Name = "_dungeoneeringMisc")]
        public int _dungeoneeringMisc { get; set; }
        [DataMember(Name = "_dungeoneeringPenalty")]
        public int _dungeoneeringPenalty { get; set; }
        [DataMember(Name = "_dungeoneeringTraining")]
        public bool _dungeoneeringTraining { get; set; }
        [DataMember(Name = "_enduranceBonus")]
        public int _enduranceBonus { get; set; }
        [DataMember(Name = "_enduranceMisc")]
        public int _enduranceMisc { get; set; }
        [DataMember(Name = "_endurancePenalty")]
        public int _endurancePenalty { get; set; }
        [DataMember(Name = "_enduranceTraining")]
        public bool _enduranceTraining { get; set; }
        [DataMember(Name = "_fortitude")]
        public int _fortitude { get; set; }
        [DataMember(Name = "_gender")]
        public string _gender { get; set; }
        [DataMember(Name = "_healBonus")]
        public int _healBonus { get; set; }
        [DataMember(Name = "_healMisc")]
        public int _healMisc { get; set; }
        [DataMember(Name = "_healPenalty")]
        public int _healPenalty { get; set; }
        [DataMember(Name = "_healTraining")]
        public bool _healTraining { get; set; }
        [DataMember(Name = "_healingSurgeValue")]
        public int _healingSurgeValue { get; set; }
        [DataMember(Name = "_healingSurges")]
        public int _healingSurges { get; set; }
        [DataMember(Name = "_height")]
        public string _height { get; set; }
        [DataMember(Name = "_historyBonus")]
        public int _historyBonus { get; set; }
        [DataMember(Name = "_historyMisc")]
        public int _historyMisc { get; set; }
        [DataMember(Name = "_historyPenalty")]
        public int _historyPenalty { get; set; }
        [DataMember(Name = "_historyTraining")]
        public bool _historyTraining { get; set; }
        [DataMember(Name = "_insightBonus")]
        public int _insightBonus { get; set; }
        [DataMember(Name = "_insightMisc")]
        public int _insightMisc { get; set; }
        [DataMember(Name = "_insightPenalty")]
        public int _insightPenalty { get; set; }
        [DataMember(Name = "_insightTraining")]
        public bool _insightTraining { get; set; }
        [DataMember(Name = "_intelligence")]
        public int _intelligence { get; set; }
        [DataMember(Name = "_intelligenceCheck")]
        public int _intelligenceCheck { get; set; }
        [DataMember(Name = "_intelligenceMod")]
        public int _intelligenceMod { get; set; }
        [DataMember(Name = "_intelligenceRaw")]
        public int _intelligenceRaw { get; set; }
        [DataMember(Name = "_intimidateBonus")]
        public int _intimidateBonus { get; set; }
        [DataMember(Name = "_intimidateMisc")]
        public int _intimidateMisc { get; set; }
        [DataMember(Name = "_intimidatePenalty")]
        public int _intimidatePenalty { get; set; }
        [DataMember(Name = "_intimidateTraining")]
        public bool _intimidateTraining { get; set; }
        [DataMember(Name = "_knownLanguages")]
        public List<Languages> _knownLanguages { get; set; }
        [DataMember(Name = "_level")]
        public int _level { get; set; }
        [DataMember(Name = "_mannerisms")]
        public string _mannerisms { get; set; }
        [DataMember(Name = "_maxHP")]
        public int _maxHP { get; set; }
        [DataMember(Name = "_name")]
        public string _name { get; set; }
        [DataMember(Name = "_natureBonus")]
        public int _natureBonus { get; set; }
        [DataMember(Name = "_natureMisc")]
        public int _natureMisc { get; set; }
        [DataMember(Name = "_naturePenalty")]
        public int _naturePenalty { get; set; }
        [DataMember(Name = "_natureTraining")]
        public bool _natureTraining { get; set; }
        [DataMember(Name = "_notes")]
        public string _notes { get; set; }
        [DataMember(Name = "_perceptionBonus")]
        public int _perceptionBonus { get; set; }
        [DataMember(Name = "_perceptionMisc")]
        public int _perceptionMisc { get; set; }
        [DataMember(Name = "_perceptionPenalty")]
        public int _perceptionPenalty { get; set; }
        [DataMember(Name = "_perceptionTraining")]
        public bool _perceptionTraining { get; set; }
        [DataMember(Name = "_personality")]
        public string _personality { get; set; }
        [DataMember(Name = "_player")]
        public string _player { get; set; }
        [DataMember(Name = "_powerPoints")]
        public int _powerPoints { get; set; }
        [DataMember(Name = "_race_abilities")]
        public List<string> _race_abilities { get; set; }
        [DataMember(Name = "_race_abilityChoice")]
        public string _race_abilityChoice { get; set; }
        [DataMember(Name = "_race_adventure")]
        public string _race_adventure { get; set; }
        [DataMember(Name = "_race_age")]
        public string _race_age { get; set; }
        [DataMember(Name = "_race_bodies")]
        public List<string> _race_bodies { get; set; }
        [DataMember(Name = "_race_defences")]
        public List<int> _race_defences { get; set; }
        [DataMember(Name = "_race_description")]
        public List<string> _race_description { get; set; }
        [DataMember(Name = "_race_feats")]
        public List<string> _race_feats { get; set; }
        [DataMember(Name = "_race_femaleNames")]
        public List<string> _race_femaleNames { get; set; }
        [DataMember(Name = "_race_headers")]
        public List<string> _race_headers { get; set; }
        [DataMember(Name = "_race_heightCM")]
        public string _race_heightCM { get; set; }
        [DataMember(Name = "_race_heightFeet")]
        public string _race_heightFeet { get; set; }
        [DataMember(Name = "_race_image")]
        public string _race_image { get; set; }
        [DataMember(Name = "_race_languages")]
        public List<string> _race_languages { get; set; }
        [DataMember(Name = "_race_maleNames")]
        public List<string> _race_maleNames { get; set; }
        [DataMember(Name = "_race_physical")]
        public string _race_physical { get; set; }
        [DataMember(Name = "_race_playing")]
        public string _race_playing { get; set; }
        [DataMember(Name = "_race_powers")]
        public List<string> _race_powers { get; set; }
        [DataMember(Name = "_race_race")]
        public string _race_race { get; set; }
        [DataMember(Name = "_race_resistances")]
        public List<string> _race_resistances { get; set; }
        [DataMember(Name = "_race_shortDescription")]
        public string _race_shortDescription { get; set; }
        [DataMember(Name = "_race_size")]
        public string _race_size { get; set; }
        [DataMember(Name = "_race_skills")]
        public List<string> _race_skills { get; set; }
        [DataMember(Name = "_race_source")]
        public string _race_source { get; set; }
        [DataMember(Name = "_race_speed")]
        public int _race_speed { get; set; }
        [DataMember(Name = "_race_speedType")]
        public string _race_speedType { get; set; }
        [DataMember(Name = "_race_subRaces")]
        public List<string> _race_subRaces { get; set; }
        [DataMember(Name = "_race_subrace_description")]
        public string _race_subrace_description { get; set; }
        [DataMember(Name = "_race_subrace_subRace")]
        public string _race_subrace_subRace { get; set; }
        [DataMember(Name = "_race_traits")]
        public List<string> _race_traits { get; set; }
        [DataMember(Name = "_race_vision")]
        public string _race_vision { get; set; }
        [DataMember(Name = "_race_weightKG")]
        public string _race_weightKG { get; set; }
        [DataMember(Name = "_race_weightLBS")]
        public string _race_weightLBS { get; set; }
        [DataMember(Name = "_racialCharisma")]
        public bool _racialCharisma { get; set; }
        [DataMember(Name = "_racialConstitution")]
        public bool _racialConstitution { get; set; }
        [DataMember(Name = "_racialDexterity")]
        public bool _racialDexterity { get; set; }
        [DataMember(Name = "_racialIntelligence")]
        public bool _racialIntelligence { get; set; }
        [DataMember(Name = "_racialStrength")]
        public bool _racialStrength { get; set; }
        [DataMember(Name = "_racialWisdom")]
        public bool _racialWisdom { get; set; }
        [DataMember(Name = "_reflexes")]
        public int _reflexes { get; set; }
        [DataMember(Name = "_religionBonus")]
        public int _religionBonus { get; set; }
        [DataMember(Name = "_religionMisc")]
        public int _religionMisc { get; set; }
        [DataMember(Name = "_religionPenalty")]
        public int _religionPenalty { get; set; }
        [DataMember(Name = "_religionTraining")]
        public bool _religionTraining { get; set; }
        [DataMember(Name = "_stealthBonus")]
        public int _stealthBonus { get; set; }
        [DataMember(Name = "_stealthMisc")]
        public int _stealthMisc { get; set; }
        [DataMember(Name = "_stealthPenalty")]
        public int _stealthPenalty { get; set; }
        [DataMember(Name = "_stealthTraining")]
        public bool _stealthTraining { get; set; }
        [DataMember(Name = "_streetwiseBonus")]
        public int _streetwiseBonus { get; set; }
        [DataMember(Name = "_streetwiseMisc")]
        public int _streetwiseMisc { get; set; }
        [DataMember(Name = "_streetwisePenalty")]
        public int _streetwisePenalty { get; set; }
        [DataMember(Name = "_streetwiseTraining")]
        public bool _streetwiseTraining { get; set; }
        [DataMember(Name = "_strength")]
        public int _strength { get; set; }
        [DataMember(Name = "_strengthCheck")]
        public int _strengthCheck { get; set; }
        [DataMember(Name = "_strengthMod")]
        public int _strengthMod { get; set; }
        [DataMember(Name = "_strengthRaw")]
        public int _strengthRaw { get; set; }
        [DataMember(Name = "_theme")]
        public string _theme { get; set; }
        [DataMember(Name = "_thieveryBonus")]
        public int _thieveryBonus { get; set; }
        [DataMember(Name = "_thieveryMisc")]
        public int _thieveryMisc { get; set; }
        [DataMember(Name = "_thieveryPenalty")]
        public int _thieveryPenalty { get; set; }
        [DataMember(Name = "_thieveryTraining")]
        public bool _thieveryTraining { get; set; }
        [DataMember(Name = "_totalXP")]
        public int _totalXP { get; set; }
        [DataMember(Name = "_trainedSkills")]
        public List<string> _trainedSkills { get; set; }
        [DataMember(Name = "_weight")]
        public string _weight { get; set; }
        [DataMember(Name = "_willpower")]
        public int _willpower { get; set; }
        [DataMember(Name = "_wisdom")]
        public int _wisdom { get; set; }
        [DataMember(Name = "_wisdomCheck")]
        public int _wisdomCheck { get; set; }
        [DataMember(Name = "_wisdomMod")]
        public int _wisdomMod { get; set; }
        [DataMember(Name = "_wisdomRaw")]
        public int _wisdomRaw { get; set; }
        [DataMember(Name = "_powerList")]
        public List<JSONPower> _powerList { get; set; }        
    }
    [DataContract]
    public class JSONPower
    {
        [DataMember(Name = "_power")]
        public string _power { get; set; }
        [DataMember(Name = "_source")]
        public string _source { get; set; }
        [DataMember(Name = "_origin")]
        public string _origin { get; set; }
        [DataMember(Name = "_originType")]
        public string _originType { get; set; }
        [DataMember(Name = "_powerType")]
        public string _powerType { get; set; }
        [DataMember(Name = "_powerUsage")]
        public string _powerUsage { get; set; }
        [DataMember(Name = "_actionType")]
        public string _actionType { get; set; }
        [DataMember(Name = "_attackType")]
        public string _attackType { get; set; }
        [DataMember(Name = "_attackVsType")]
        public string _attackVsType { get; set; }
        [DataMember(Name = "_hit")]
        public string _hit { get; set; }
        [DataMember(Name = "_hits")]
        public List<string> _hits { get; set; }
        [DataMember(Name = "_hitLevels")]
        public List<string> _hitLevels { get; set; }
        [DataMember(Name = "_methodTypes")]
        public List<string> _methodTypes { get; set; }
        [DataMember(Name = "_methodRanges")]
        public List<string> _methodRanges { get; set; }
        [DataMember(Name = "_target")]
        public string _target { get; set; }
        [DataMember(Name = "_prerequisite")]
        public string _prerequisite { get; set; }
        [DataMember(Name = "_prerequisiteType")]
        public string _prerequisiteType { get; set; }       
        [DataMember(Name = "_requirement")]
        public string _requirement { get; set; }
        [DataMember(Name = "_requirementType")]
        public string _requirementType { get; set; }   
        [DataMember(Name = "_headers")]
        public List<string> _headers { get; set; }
        [DataMember(Name = "_bodies")]
        public List<string> _bodies { get; set; }
        [DataMember(Name = "_additionalEffectName")]
        public string _additionalEffectName { get; set; }
        [DataMember(Name = "_additionalEffectDescription")]
        public string _additionalEffectDescription { get; set; }
    }
}
