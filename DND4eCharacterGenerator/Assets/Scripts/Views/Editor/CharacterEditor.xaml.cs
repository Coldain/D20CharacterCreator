using DnD4e.CharacterBuilder.Editor.ViewModels;
using DnD4e.Assets.Scripts.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DnD4e.CharacterBuilder.Editor.View;
using DnD4e.Assets.Scripts.Views.Editor.Class;
using DnD4e.Assets.Scripts.Views.CharacterSheet;
using DnD4e.CharacterOOP;
using DnD4e.Assets.Scripts.Views.Editor.Race;
using DnD4e.Assets.Scripts.Views.Editor.Details;
using DnD4e.Assets.Scripts.Views.Editor.Abilities;
using DnD4e.Assets.Scripts.Views.Editor.Skills;
using DnD4e.Assets.Scripts.Views.Editor.Manager;

namespace DnD4e.Assets.Scripts.Views.Editor
{
    [Serializable]
    public partial class CharacterEditor : Window
    {
        public MainController main;
        public string currentButton;
        public string priorButton;
        public bool mouseBusy;
        public bool classSelected;
        public bool classFinished;
        public bool raceSelected;
        public bool raceFinished;
        public bool detailsFinished;
        public bool abilitiesFinished;
        public bool skillsFinished;
        public bool powersFinished;
        public bool featsFinished;
        public bool equipmentFinished;

        public CharacterEditor(MainController _main)
        {
            main = _main;
            DataContext = new
            {
                abilities = main.listDefinitionLists[1],
                character = main.characterCurrent,
            };
            InitializeComponent();            
            buttonSelectClass_Click(this, null);
        }

        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Back to Editor", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                HomePage homePage = new HomePage();
                homePage.main.dataLoaded = true;
                Character newCharacter = new Character();
                main.characterCurrent = newCharacter;
                homePage.main = main;
                homePage.Show();
                this.Close();
            }
        }

        private void buttonCharacterSheet_Click(object sender, RoutedEventArgs e)
        {
            CS characterSheet = new CS(main,5);
            characterSheet.Owner = this;
            characterSheet.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            characterSheet.Show();
            characterSheet.Width = 765;
            characterSheet.Height = 990;
        }

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming");
        }

        private void buttonSelectClass_Click(object sender, RoutedEventArgs e)
        {
            EditorClass1 editorClass = new EditorClass1(this);
            if (classSelected)
            {
                EditorClass3 editorClass3 = new EditorClass3(this, editorClass);
                currentButton = pathClass.Name;
                PathSelected();
                frameContainer.Content = editorClass3;
            }
            else
            {                
                currentButton = pathClass.Name;
                PathSelected();
                frameContainer.Content = editorClass;
            }                    
        }

        private void buttonSelectRace_Click(object sender, RoutedEventArgs e)
        {
            EditorRace1 raceViewer = new EditorRace1(this);
            if (raceSelected)
            {
                EditorRace2 raceViewer2 = new EditorRace2(this, raceViewer);
                currentButton = pathRace.Name;
                PathSelected();
                frameContainer.Content = raceViewer2;
            }
            else
            {        
                currentButton = pathRace.Name;
                PathSelected();
                frameContainer.Content = raceViewer;
            }
        }

        private void buttonDetails_Click(object sender, RoutedEventArgs e)
        {
            EditorDetails details = new EditorDetails(this);
            currentButton = pathDetails.Name;
            PathSelected();
            frameContainer.Content = details;
        }

        private void buttonAssignAbilities_Click(object sender, RoutedEventArgs e)
        {
            EditorAbilities details = new EditorAbilities(this);
            currentButton = pathAbilities.Name;
            PathSelected();
            frameContainer.Content = details;
        }


        private void buttonTrainSkills_Click(object sender, RoutedEventArgs e)
        {
            EditorSkills details = new EditorSkills(this);
            currentButton = pathSkills.Name;
            PathSelected();
            frameContainer.Content = details;
        }

        private void buttonSelectPowers_Click(object sender, RoutedEventArgs e)
        {
            currentButton = pathPowers.Name;
            PathSelected();
        }

        private void buttonSelectFeats_Click(object sender, RoutedEventArgs e)
        {
            currentButton = pathFeats.Name;
            PathSelected();
        }

        private void buttonGetEquipment_Click(object sender, RoutedEventArgs e)
        {
            currentButton = pathEquipment.Name;
            PathSelected();
        }

        private void buttonManageCharacter_Click(object sender, RoutedEventArgs e)
        {
            EditorManager details = new EditorManager(this);
            currentButton = pathManage.Name;
            PathSelected();
            frameContainer.Content = details;            
        }

        public void PathSelected()
        {
            frameContainer.Content = null;
            framedetails.Content = null;

            switch (priorButton)
            {
                case "pathClass":
                    pathClass.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathClassFinished.Data = pathClass.Data;
                    break;
                case "pathRace":
                    pathRace.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathRaceFinished.Data = pathRace.Data;
                    break;
                case "pathDetails":
                    pathDetails.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathDetailsFinished.Data = pathDetails.Data;
                    break;
                case "pathAbilities":
                    pathAbilities.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathAbilitiesFinished.Data = pathAbilities.Data;
                    break;
                case "pathSkills":
                    pathSkills.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathSkillsFinished.Data = pathSkills.Data;
                    break;
                case "pathPowers":
                    pathPowers.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathPowersFinished.Data = pathPowers.Data;
                    break;
                case "pathFeats":
                    pathFeats.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathFeatsFinished.Data = pathFeats.Data;
                    break;
                case "pathEquipment":
                    pathEquipment.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathEquipmentFinished.Data = pathEquipment.Data;
                    break;
                case "pathManage":
                    pathManage.Data = Geometry.Parse("M10,0 L140,0 150,10 150,30 140,40 10,40 0,30 0,10 10,0");
                    pathManageFinished.Data = pathManage.Data;
                    break;
            }

            switch (currentButton)
            {
                case "pathRace":
                    pathRace.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathRaceFinished.Data = pathRace.Data;
                    break;
                case "pathDetails":
                    pathDetails.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathDetailsFinished.Data = pathDetails.Data;
                    break;
                case "pathAbilities":
                    pathAbilities.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathAbilitiesFinished.Data = pathAbilities.Data;
                    break;
                case "pathSkills":
                    pathSkills.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathSkillsFinished.Data = pathSkills.Data;
                    break;
                case "pathPowers":
                    pathPowers.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathPowersFinished.Data = pathPowers.Data;
                    break;
                case "pathFeats":
                    pathFeats.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathFeatsFinished.Data = pathFeats.Data;
                    break;
                case "pathEquipment":
                    pathEquipment.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathEquipmentFinished.Data = pathEquipment.Data;
                    break;
                case "pathManage":
                    pathManage.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathManageFinished.Data = pathManage.Data;
                    break;
                case "pathClass":
                default:
                    pathClass.Data = Geometry.Parse("M10, 0 L140, 0 175, 20 140, 40 10, 40 0, 30 0, 10 10, 0");
                    pathClassFinished.Data = pathClass.Data;
                    break;
            }
            priorButton = currentButton;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && !mouseBusy && e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
