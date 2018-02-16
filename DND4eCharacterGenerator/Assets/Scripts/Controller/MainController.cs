using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views;
using DnD4e.CharacterOOP;
using System.Collections.Generic;
using System.Windows.Input;

namespace DnD4e.CharacterBuilder.Editor.ViewModels
{
    public class MainController
    {
        public Character characterCurrent = new Character();
        public List<Definitions> listDefinitions = new List<Definitions>();
        public List<DefinitionList> listDefinitionLists = new List<DefinitionList>();
        public List<Campaigns> listCampaings = new List<Campaigns>();
        public List<Roles> listRoles = new List<Roles>();
        public List<Classes> listclassMain = new List<Classes>();
        public List<SubClasses> listSubClasses = new List<SubClasses>();
        public List<Builds> listBuilds = new List<Builds>();
        public List<Deities> listDeities = new List<Deities>();
        public List<Races> listRaces = new List<Races>();
        public List<Languages> listLanguages = new List<Languages>();
        public List<Feats> listFeats = new List<Feats>();
        public List<Powers> listPowers = new List<Powers>();
        public string characterPath;
        public ICommand CheckedInCommand { get; set; }
        public bool dataLoaded = false;
        public bool fromCustom = false;

        public List<int> GetListIDs(List<string> tempList)
        {
            List<int> tempIDs = new List<int>(0);
            for (int i = 1; i <= tempList.Count; i++)
            {
                tempIDs.Add(i);
            }

            return tempIDs;
        }

    }    
}
