using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor.Class.PopUps;
using DnD4e.Assets.Scripts.Views.Editor.Details;
using DnD4e.Assets.Scripts.Views.Editor.Race.PopUps;
using DnD4e.CharacterBuilder.Editor.View.Class;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnD4e.Assets.Scripts.Views.Editor.Race
{
    
    public partial class EditorRace2 : Page
    {
        bool deselect;
        Canvas canvasSelected;        
        EditorRace1 priorPage;
        bool racePicked = true;
        public bool subracePicked;
        public bool languagePicked;
        //public bool optionPicked;
        //public bool option2Picked;
        Grid currentGrid;
        CharacterEditor editor;
        SubRaces defaultSubrace = new SubRaces();

        public EditorRace2(CharacterEditor _editor, EditorRace1 _priorPage)
        {
            priorPage = _priorPage;
            editor = _editor;       
            InitializeComponent();
            ChangeCompleted(true, gridRace, true);
            this.DataContext = editor.main.characterCurrent;
            //if (editor.main.characterCurrent.Race.SubRaces.Count == 1 || editor.main.characterCurrent.Race.SubRaces[0] == "")
            //{
            //    ChangeCompleted(true, gridSubrace, false);
            //    subracePicked = true;
            //    gridSubrace.IsEnabled = false;
            //}
            //if (editor.main.characterCurrent.Race.SubRace.SubRace == "Subrace")
            //{
            //    ChangeCompleted(false, gridSubrace, false);
            //}
            //else
            //{
                subracePicked = true; 
            //gridOption.IsEnabled = true;
            //gridOption2.IsEnabled = true;
            bool langaugeChoice = false;
            if (editor.main.characterCurrent.Race.Languages.Count == editor.main.characterCurrent.KnownLanguages.Count)
                    langaugeChoice = true;
                foreach (string language in editor.main.characterCurrent.Race.Languages)
                {
                    if (language == "Any")
                        langaugeChoice = true;
                }
                if (langaugeChoice)
                {
                    ChangeCompleted(false, gridLanguage, false);
                    gridLanguage.IsEnabled = true;
                }
                else
                    languagePicked = true;

                //if (editor.main.characterCurrent.Race.ListOptions[0].Options[0] != "")
                //{
                //    ChangeCompleted(false, gridOption, false);
                //    editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0];
                //    textblockOptionPick.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0] + " option.";
                //}
                //else
                //{
                //    if (editor.main.characterCurrent.Race.OptionPicked1.OptionName == "Option")
                //        gridOption.IsEnabled = false;
                //    optionPicked = true;
                //}
                //if (editor.main.characterCurrent.Race.Subclass.ListOptions[1].Options[0] != "")
                //{
                //    ChangeCompleted(false, gridOption2, false);
                //           editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0];
                //    textblockOptionPick2.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0] + " option.";
                //}
                //else
                //{
                //    if (editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName == "Option")
                //        gridOption2.IsEnabled = false;
                //    option2Picked = true;
                //}                       
            if (racePicked && subracePicked && languagePicked)
            {
                canvasNext.Opacity = 0.2;
                buttonNext.IsEnabled = true;
                editor.pathRaceFinished.Visibility = Visibility.Visible;
            }

        }

        private void Race_Selected()
        {
            if (racePicked)
            {
                SelectionDetailsRace raceDetails = new SelectionDetailsRace(editor.main.characterCurrent.Race);
                editor.framedetails.Content = raceDetails;
                ChangeSelections(true);
            }
            else
            {
                ChangeSelections(false);
                if (priorPage != null)
                {
                    SelectionDetailsRole classDetails = new SelectionDetailsRole(editor.main.listDefinitions[3].Pick, editor.main.listDefinitions[3].Description);
                    editor.framedetails.Content = classDetails;
                    editor.frameContainer.Content = priorPage;
                }
            }
            deselect = true;
        }

        private void Subrace_Selected()
        {
            if (subracePicked)
            {
                //SelectionDetailsRole details = new SelectionDetailsRole("SubRace", "Pick a subrace.");
                //editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                //ChangeSelections(false);
                //List<SubRaces> listSubraces = new List<SubRaces>();
                //foreach (string subraceName in editor.main.characterCurrent.Race.SubRaces)
                //{
                //    //foreach (SubRaces subs in editor.main.listSubRaces)
                //    //{
                //    //    if (subraceName == subs.SubRace)
                //    //        listSubraces.Add(subs);
                //    //}
                //}
                //PopUp popUp = new PopUp();
                //SubRaces subclass = new SubRaces(listSubraces, popUp, editor, this);
                //popUp.Owner = editor;
                //popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //popUp.frameContainer.Content = subclass;
                //popUp.ShowDialog();
                //ChangeCompleted(true, gridSubrace, false);
            }
            deselect = true;
        }

        private void Language_Selected()
        {
            if (languagePicked)
            {
                SelectionDetailsRole details = new SelectionDetailsRole(editor.main.characterCurrent.KnownLanguages[editor.main.characterCurrent.KnownLanguages.Count-1].Language, editor.main.characterCurrent.KnownLanguages[editor.main.characterCurrent.KnownLanguages.Count - 1].Description, editor.main.characterCurrent.KnownLanguages[editor.main.characterCurrent.KnownLanguages.Count - 1].Image);
                editor.framedetails.Content = details;
                ChangeSelections(true);                
            }
            else
            {
                ChangeSelections(false);
                PopUp popUp = new PopUp();
                Language build = new Language(popUp, editor, this);
                popUp.frameContainer.Content = build;
                popUp.Owner = editor;
                popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popUp.ShowDialog();
                ChangeCompleted(true, gridLanguage, false);
            }
            deselect = true;
        }

        private void Option_Selected()
        {
            //if (optionPicked)
            //{
            //    SelectionDetailsRole details = new SelectionDetailsRole(editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName, editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionDetails);
            //    editor.framedetails.Content = details;
            //    ChangeSelections(true);
            //}
            //else
            //{
            //    ChangeSelections(false);
            //    PopUp popUp = new PopUp();
            //    Option1 option = new Option1(popUp, editor, this);
            //    popUp.frameContainer.Content = option;
            //    popUp.Owner = editor;
            //    popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //    popUp.ShowDialog();
            //    ChangeCompleted(true, gridOption, false);
            //}
            deselect = true;
        }

        private void Option2_Selected()
        {
            //if (option2Picked)
            //{
            //    SelectionDetailsRole details = new SelectionDetailsRole(editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName, editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionDetails);
            //    editor.framedetails.Content = details;
            //    ChangeSelections(true);
            //}
            //else
            //{
            //    ChangeSelections(false);
            //    PopUp popUp = new PopUp();
            //    Option2 option = new Option2(popUp, editor, this);
            //    popUp.frameContainer.Content = option;
            //    popUp.Owner = editor;
            //    popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //    popUp.ShowDialog();
            //    ChangeCompleted(true, gridOption2, false);
            //}
            deselect = true;
        }



        public void ChangeSelections(bool switcher)
        {
            if (!switcher)
            {
                canvasClear.Opacity = 0.6;
                if (buttonNext.IsEnabled)
                {
                    if (currentGrid.Name != "gridBuild")
                    {
                        canvasNext.Opacity = 0.6;
                        buttonNext.IsEnabled = false;
                        editor.pathRaceFinished.Visibility = Visibility.Hidden;
                        editor.raceFinished = false;
                    }                       
                }
            }
            else
            {
                canvasClear.Opacity = 0.2;
                if (racePicked && subracePicked && languagePicked)
                {
                    canvasNext.Opacity = 0.2;
                    buttonNext.IsEnabled = true;
                    editor.pathRaceFinished.Visibility = Visibility.Visible;
                    editor.raceFinished = true;
                }
            }
            buttonClear.IsEnabled = switcher;
        }

        public void ChangeCompleted(bool switcher, Grid grid, bool image)
        {
            if (switcher)
            {
                if (image)
                {
                    grid.Children[6].Visibility = Visibility.Visible;
                    grid.Children[7].Visibility = Visibility.Visible;
                    grid.Children[8].Visibility = Visibility.Visible;
                }
                else
                {
                    grid.Children[5].Visibility = Visibility.Visible;
                    grid.Children[6].Visibility = Visibility.Visible;
                    grid.Children[7].Visibility = Visibility.Visible;
                }
            }
            else
            { 
                if (image)
                {
                    grid.Children[6].Visibility = Visibility.Hidden;
                    grid.Children[7].Visibility = Visibility.Hidden;
                    grid.Children[8].Visibility = Visibility.Hidden;                    
                }
                else
                {
                    grid.Children[5].Visibility = Visibility.Hidden;
                    grid.Children[6].Visibility = Visibility.Hidden;
                    grid.Children[7].Visibility = Visibility.Hidden;
                }
            }
        }

        private void Item_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            if (canvasSelected != canvas)
                canvas.Opacity = 0;
        }

        private void Item_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas canvas = sender as Canvas;

            if (canvasSelected != canvas)
                canvas.Opacity = 0.8;
            else
            {
                Item_MouseUp(canvasSelected, null);
            }
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            editor.mouseBusy = true;
            Canvas tempCanvas = sender as Canvas;
            if (canvasSelected != null)
                buttonDeselect_Click();
            canvasSelected = tempCanvas;
            canvasSelected.Background = Brushes.Transparent;
            canvasSelected.Opacity = 100;
            Grid parent = (Grid)canvasSelected.Parent;
            Rectangle rect = (Rectangle)canvasSelected.Children[0];
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF4CC513");
            rect.Stroke = brush;
            TranslateTransform translation = new TranslateTransform(3, 3);
            parent.RenderTransform = translation;
            Mouse.Capture(canvasSelected);
            switch (tempCanvas.Name)
            {
                case "itemRace":
                    Race_Selected();
                    break;                
                case "itemLanguage":
                    Language_Selected();
                    break;
                case "itemOption":
                    Option_Selected();
                    break;
                case "itemOption2":
                    Option2_Selected();
                    break;
                case "itemSubrace":
                    Subrace_Selected();
                    break;
            }
        }

        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            canvasSelected = sender as Canvas;
            Grid parent = (Grid)canvasSelected.Parent;
            TranslateTransform translation = new TranslateTransform(0, 0);
            parent.RenderTransform = translation;
            Mouse.Capture(null);
            currentGrid = parent;
            editor.mouseBusy = false;
        }

        private void buttonDeselect_Click()
        {
            if(racePicked)
                if (canvasSelected != null)
                {
                    canvasSelected.Opacity = 0.8;
                    var converter = new BrushConverter();
                    var brush = (Brush)converter.ConvertFromString("#FFCBC5A4");
                    canvasSelected.Background = brush;
                    Rectangle rect = (Rectangle)canvasSelected.Children[0];
                    rect.Stroke = Brushes.Transparent;
                    SelectionDetailsRace raceDetails = new SelectionDetailsRace(editor.main.characterCurrent.Race);
                    editor.framedetails.Content = raceDetails;
                }
        }

        private void buttonClear_Click()
        {            
            if (currentGrid != null)
            {
                SelectionDetailsRace raceDetails = new SelectionDetailsRace(editor.main.characterCurrent.Race);
                editor.framedetails.Content = raceDetails;
                buttonDeselect_Click();
                switch (currentGrid.Name)
                {
                    case "gridRace":
                        racePicked = false;
                        subracePicked = false;
                        languagePicked = false;
                        //optionPicked = false;
                        //option2Picked = false;
                        ChangeCompleted(false, gridRace, true);
                        //ChangeCompleted(false, gridSubrace, false);
                        ChangeCompleted(false, gridLanguage, false);
                        //ChangeCompleted(false, gridOption, false);
                        //ChangeCompleted(true, gridOption2, false);
                        if (editor.main.characterCurrent.Race.Abilities.Count == 3)
                            switch (editor.main.characterCurrent.Race.Abilities[0])
                            {
                                case "Str":
                                    editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength - 2;
                                    break;
                                case "Con":
                                    editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution - 2;
                                    break;
                                case "Dex":
                                    editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity - 2;
                                    break;
                                case "Int":
                                    editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence - 2;
                                    break;
                                case "Wis":
                                    editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom - 2;
                                    break;
                                case "Cha":
                                    editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma - 2;
                                    break;
                            }
                        else if (editor.main.characterCurrent.Race.Abilities.Count == 2)
                        {
                            switch (editor.main.characterCurrent.Race.Abilities[0])
                            {
                                case "Str":
                                    editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength - 2;
                                    break;
                                case "Con":
                                    editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution - 2;
                                    break;
                                case "Dex":
                                    editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity - 2;
                                    break;
                                case "Int":
                                    editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence - 2;
                                    break;
                                case "Wis":
                                    editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom - 2;
                                    break;
                                case "Cha":
                                    editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma - 2;
                                    break;
                            }
                            switch (editor.main.characterCurrent.Race.Abilities[1])
                            {
                                case "Str":
                                    editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength - 2;
                                    break;
                                case "Con":
                                    editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution - 2;
                                    break;
                                case "Dex":
                                    editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity - 2;
                                    break;
                                case "Int":
                                    editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence - 2;
                                    break;
                                case "Wis":
                                    editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom - 2;
                                    break;
                                case "Cha":
                                    editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma - 2;
                                    break;
                            }
                        }
                        editor.main.characterCurrent.Race = new Races();
                        gridLanguage.IsEnabled = false;
                        //gridOption.IsEnabled = false;
                        //gridOption2.IsEnabled = false;
                        //gridSubrace.IsEnabled = false;
                        editor.main.characterCurrent.KnownLanguages = new List<Languages>();                       
                        Races newRace = new Races();
                        editor.main.characterCurrent.Race = newRace;
                        editor.raceSelected = false;
                        break;
                    case "gridSubRace":
                        subracePicked = false;
                        languagePicked = false;
                        //optionPicked = false;
                        //option2Picked = false;
                        //ChangeCompleted(false, gridSubrace, false);
                        ChangeCompleted(true, gridLanguage, false);
                        //ChangeCompleted(true, gridOption, false);
                        //ChangeCompleted(true, gridOption2, false);
                        gridLanguage.IsEnabled = false;
                        //gridOption.IsEnabled = false;
                        //gridOption2.IsEnabled = false;
                        editor.main.characterCurrent.Race.SubRace = defaultSubrace;
                        //editor.main.characterCurrent.Race.SubRace = editor.main.characterCurrent.Race.SubRaces[0];                      
                        break;
                    case "gridLanguage":
                        editor.main.characterCurrent.KnownLanguages.RemoveAt(editor.main.characterCurrent.KnownLanguages.Count - 1);
                        languagePicked = false;
                        ChangeCompleted(false, gridLanguage, false);
                        break;
                    //case "gridOption":
                    //    //optionPicked = false;
                    //    ChangeCompleted(false, gridOption, false);
                    //    editor.main.characterCurrent.Class.Subclass.OptionPicked1 = new ClassOption();
                    //    editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0];
                    //    textblockOptionPick.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0] + " option.";
                    //    break;
                    //case "gridOption2":
                    //    //option2Picked = false;
                    //    ChangeCompleted(false, gridOption2, false);
                    //    editor.main.characterCurrent.Class.Subclass.OptionPicked2 = new ClassOption();
                    //    editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0];
                    //    textblockOptionPick2.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0] + " option.";
                    //    break;
                }
            }
            canvasSelected = null;
            currentGrid = null;
        }       

        private void buttonNext_Click()
        {
            EditorDetails details = new EditorDetails(editor);            
            editor.currentButton = editor.pathDetails.Name;
            editor.PathSelected();
            editor.frameContainer.Content = details;
        }

        private void path_MouseEnter(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            if (tempPath == canvasClear)
            {
                if (deselect)
                {
                    tempPath.Opacity = 0;
                }
            }
            else
            {
                tempPath.Opacity = 0;
            }
        }

        private void path_MouseLeave(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            if (tempPath == canvasClear)
            {
                if (deselect)
                {
                    tempPath.Opacity = 0.2;
                }
                else
                {
                    tempPath.Opacity = 0.6;
                }
            }
            else
            {
                tempPath.Opacity = 0.2;
            }
        }

        private void path_MouseDown(object sender, MouseEventArgs e)
        {
            editor.mouseBusy = true;
            Path tempPath = sender as Path;
            tempPath.Opacity = 0;
            Canvas canvas = (Canvas)tempPath.Parent;
            TranslateTransform translation = new TranslateTransform(3, 3);
            canvas.RenderTransform = translation;
            Mouse.Capture(tempPath);
        }


        private void path_MouseUp(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            Canvas canvas = (Canvas)tempPath.Parent;
            TranslateTransform translation = new TranslateTransform(0, 0);
            canvas.RenderTransform = translation;
            Mouse.Capture(null);
            ButtonOption(canvas);
            editor.mouseBusy = false;
        }

        private void ButtonOption(Canvas canvas)
        {            
            switch (canvas.Name)
            {
                case "buttonClear":
                    ChangeSelections(false);
                    deselect = false;
                    Path path = canvas.Children[2] as Path;
                    path_MouseLeave(path, null);
                    canvasClear.Opacity = 0.6;
                    buttonClear_Click();
                    break;
                case "buttonNext":
                    buttonNext_Click();
                    break;
            }
        }
    }
}
