using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor.Class.PopUps;
using DnD4e.Assets.Scripts.Views.Editor.Race;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Class
{
    
    public partial class EditorClass3 : Page
    {
        bool deselect;
        Canvas canvasSelected;        
        EditorClass2 priorPage;
        EditorClass1 priorPage2;
        bool classPicked = true;
        public bool subclassPicked;
        public bool buildPicked;
        public bool deityPicked;
        public bool optionPicked;
        public bool option2Picked;
        Grid currentGrid;
        CharacterEditor editor;
        SubClasses defaultSubclass = new SubClasses();

        public EditorClass3(CharacterEditor _editor, EditorClass2 _priorPage)
        {            
            priorPage = _priorPage;
            editor = _editor;
            defaultSubclass.Abilities = editor.main.characterCurrent.Class.Subclass.Abilities;
            editor.main.characterCurrent.Class.Subclass = defaultSubclass;
            InitializeComponent();
            ChangeCompleted(true, gridClass, true);
            this.DataContext = editor.main.characterCurrent;
            if (editor.main.characterCurrent.Class.Subclasses.Count == 1)
            {
                ChangeCompleted(true, gridSubClass, false);
                gridSubClass.IsEnabled = false;
                subclassPicked = true;
                foreach (SubClasses tempSubClass in editor.main.listSubClasses)
                {
                    if (tempSubClass.SubClass == editor.main.characterCurrent.Class.Subclasses[0])
                    {                        
                        if (tempSubClass.ListOptions[0].Options.Count > 1)
                        {
                            gridOption.IsEnabled = true;
                            ChangeCompleted(false, gridOption, false);
                            ClassOption tempOption = new ClassOption();
                            tempOption.OptionName = tempSubClass.ListOptions[0].OptionDetails[0];
                            textblockOptionPick.Text = "Click to choose your " + tempSubClass.ListOptions[0].OptionDetails[0] + " option.";
                            tempSubClass.OptionPicked1 = tempOption;
                        }
                        else
                        {
                            if (editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName == "Option")
                                gridOption.IsEnabled = false;
                            optionPicked = true;
                        }
                        if (tempSubClass.ListOptions[1].Options.Count > 1)
                        {
                            gridOption2.IsEnabled = true;
                            ChangeCompleted(false, gridOption2, false);
                            ClassOption tempOption = new ClassOption();
                            tempOption.OptionName = tempSubClass.ListOptions[1].OptionDetails[0];
                            textblockOptionPick2.Text = "Click to choose your " + tempSubClass.ListOptions[1].OptionDetails[0] + " option.";
                            tempSubClass.OptionPicked2 = tempOption;
                        }
                        else
                        {
                            if (editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName == "Option")
                                gridOption2.IsEnabled = false;
                            option2Picked = true;
                        }
                        editor.main.characterCurrent.Class.Subclass = tempSubClass;
                    }
                }
                
            }
            else
                ChangeCompleted(false, gridSubClass, false);
            ChangeCompleted(false, gridDeity, true);
        }

        public EditorClass3(CharacterEditor _editor, EditorClass1 _priorPage2)
        {
            priorPage2 = _priorPage2;
            editor = _editor;       
            InitializeComponent();
            ChangeCompleted(true, gridClass, true);
            this.DataContext = editor.main.characterCurrent;
            if (editor.main.characterCurrent.Class.Subclasses.Count == 1)
            {
                ChangeCompleted(true, gridSubClass, false);
                subclassPicked = true;
            }
            if (editor.main.characterCurrent.Class.Subclass.SubClass == "Subclass")
            {
                ChangeCompleted(false, gridSubClass, false);
            }
            else
            {
                subclassPicked = true;
                gridBuild.IsEnabled = true;
                gridOption.IsEnabled = true;
                gridOption2.IsEnabled = true;
                if (editor.main.characterCurrent.Class.Subclass.Build == null || editor.main.characterCurrent.Class.Subclass.Build.Build == "Build")
                    ChangeCompleted(false, gridBuild, false);
                else
                    buildPicked = true;

                if (editor.main.characterCurrent.Class.Subclass.ListOptions[0].Options[0] != "")
                {
                    ChangeCompleted(false, gridOption, false);
                    editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0];
                    textblockOptionPick.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0] + " option.";
                }
                else
                {
                    if (editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName == "Option")
                        gridOption.IsEnabled = false;
                    optionPicked = true;
                }
                if (editor.main.characterCurrent.Class.Subclass.ListOptions[1].Options[0] != "")
                {
                    ChangeCompleted(false, gridOption2, false);
                           editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0];
                    textblockOptionPick2.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0] + " option.";
                }
                else
                {
                    if (editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName == "Option")
                        gridOption2.IsEnabled = false;
                    option2Picked = true;
                }
            }            
            if (editor.main.characterCurrent.Deity.Deity == "Deity")            
                ChangeCompleted(false, gridDeity, true);
            else
                deityPicked = true;
            if (classPicked && subclassPicked && deityPicked && optionPicked && option2Picked)
            {
                canvasNext.Opacity = 0.2;
                buttonNext.IsEnabled = true;
                editor.pathClassFinished.Visibility = Visibility.Visible;
            }

        }

        private void Class_Selected()
        {
            if (classPicked)
            {
                SelectionDetailsClass classDetails = new SelectionDetailsClass(editor.main.characterCurrent.Class, editor.main);
                editor.framedetails.Content = classDetails;
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
                else
                {
                    editor.frameContainer.Content = priorPage2;
                }
            }
            deselect = true;
        }

        private void Subclass_Selected()
        {
            if (subclassPicked)
            {
                SelectionDetailsSubclass details = new SelectionDetailsSubclass(editor.main.characterCurrent.Class.Subclass, editor.main);
                editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                ChangeSelections(false);
                List<SubClasses> listSubclasses = new List<SubClasses>();
                foreach (string subclassName in editor.main.characterCurrent.Class.Subclasses)
                {
                    foreach (SubClasses subs in editor.main.listSubClasses)
                    {
                        if (subclassName == subs.SubClass)
                            listSubclasses.Add(subs);
                    }
                }
                PopUp popUp = new PopUp();
                Subclass subclass = new Subclass(listSubclasses, popUp, editor, this);
                popUp.Owner = editor;
                popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popUp.frameContainer.Content = subclass;
                popUp.ShowDialog();
                ChangeCompleted(true, gridSubClass, false);
            }
            deselect = true;
        }

        private void Build_Selected()
        {
            if (buildPicked)
            {
                SelectionDetailsBuild details = new SelectionDetailsBuild(editor.main.characterCurrent.Class.Subclass.Build);
                editor.framedetails.Content = details;
                ChangeSelections(true);                
            }
            else
            {
                ChangeSelections(false);
                List<Builds> listBuilds = new List<Builds>();
                foreach (Builds builds in editor.main.listBuilds)
                {
                    if (editor.main.characterCurrent.Class.Subclass.SubClass == builds.Subclass)
                        listBuilds.Add(builds);
                }
                PopUp popUp = new PopUp();
                Build build = new Build(listBuilds, popUp, editor, this);
                popUp.frameContainer.Content = build;
                popUp.Owner = editor;
                popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popUp.ShowDialog();
                ChangeCompleted(true, gridBuild, false);
            }
            deselect = true;
        }

        private void Deity_Selected()
        {
            if (deityPicked)
            {
                SelectionDetailsDeity details = new SelectionDetailsDeity(editor.main.characterCurrent.Deity);
                editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                ChangeSelections(false);
                PopUp popUp = new PopUp();
                Deity deity = new Deity(popUp, editor, this);
                popUp.frameContainer.Content = deity;
                popUp.Owner = editor;
                popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popUp.ShowDialog();
                ChangeCompleted(true, gridDeity, true);
            }
            deselect = true;
        }

        private void Option_Selected()
        {
            if (optionPicked)
            {
                SelectionDetailsRole details = new SelectionDetailsRole(editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName, editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionDetails);
                editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                ChangeSelections(false);
                PopUp popUp = new PopUp();
                Option1 option = new Option1(popUp, editor, this);
                popUp.frameContainer.Content = option;
                popUp.Owner = editor;
                popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popUp.ShowDialog();
                ChangeCompleted(true, gridOption, false);
            }
            deselect = true;
        }

        private void Option2_Selected()
        {
            if (option2Picked)
            {
                SelectionDetailsRole details = new SelectionDetailsRole(editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName, editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionDetails);
                editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                ChangeSelections(false);
                PopUp popUp = new PopUp();
                Option2 option = new Option2(popUp, editor, this);
                popUp.frameContainer.Content = option;
                popUp.Owner = editor;
                popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                popUp.ShowDialog();
                ChangeCompleted(true, gridOption2, false);
            }
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
                        editor.pathClassFinished.Visibility = Visibility.Hidden;
                        editor.classFinished = false;
                    }                       
                }
            }
            else
            {
                canvasClear.Opacity = 0.2;
                if (classPicked && subclassPicked && deityPicked && optionPicked && option2Picked)
                {
                    canvasNext.Opacity = 0.2;
                    buttonNext.IsEnabled = true;
                    editor.pathClassFinished.Visibility = Visibility.Visible;
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
                case "itemClass":
                    Class_Selected();
                    break;
                case "itemSubclass":
                    Subclass_Selected();
                    break;
                case "itemBuild":
                    Build_Selected();
                    break;
                case "itemDeity":
                    Deity_Selected();
                    break;
                case "itemOption":
                    Option_Selected();
                    break;
                case "itemOption2":
                    Option2_Selected();
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
            if(classPicked)
                if (canvasSelected != null)
                {
                    canvasSelected.Opacity = 0.8;
                    var converter = new BrushConverter();
                    var brush = (Brush)converter.ConvertFromString("#FFCBC5A4");
                    canvasSelected.Background = brush;
                    Rectangle rect = (Rectangle)canvasSelected.Children[0];
                    rect.Stroke = Brushes.Transparent;
                    SelectionDetailsClass classDetails = new SelectionDetailsClass(editor.main.characterCurrent.Class, editor.main);
                    editor.framedetails.Content = classDetails;
                }
        }

        private void buttonClear_Click()
        {            
            if (currentGrid != null)
            {
                SelectionDetailsClass classDetails = new SelectionDetailsClass(editor.main.characterCurrent.Class, editor.main);
                editor.framedetails.Content = classDetails;
                buttonDeselect_Click();
                switch (currentGrid.Name)
                {
                    case "gridClass":
                        classPicked = false;
                        subclassPicked = false;
                        buildPicked = false;
                        deityPicked = false;
                        optionPicked = false;
                        option2Picked = false;
                        ChangeCompleted(false, gridClass, true);
                        ChangeCompleted(false, gridSubClass, false);
                        ChangeCompleted(false, gridDeity, true);
                        ChangeCompleted(false, gridBuild, false);
                        ChangeCompleted(false, gridOption, false);
                        ChangeCompleted(true, gridOption2, false);
                        editor.main.characterCurrent.Class = new Classes();
                        editor.main.characterCurrent.Deity = new Deities();
                        gridBuild.IsEnabled = false;
                        gridDeity.IsEnabled = false;
                        gridOption.IsEnabled = false;
                        gridOption2.IsEnabled = false;
                        gridSubClass.IsEnabled = false;
                        Classes newClass = new Classes();
                        editor.main.characterCurrent.Class = newClass;
                        editor.classSelected = false;
                        break;
                    case "gridSubClass":
                        subclassPicked = false;
                        buildPicked = false;
                        optionPicked = false;
                        option2Picked = false;
                        ChangeCompleted(false, gridSubClass, false);
                        ChangeCompleted(true, gridBuild, false);
                        ChangeCompleted(true, gridOption, false);
                        ChangeCompleted(true, gridOption2, false);
                        gridBuild.IsEnabled = false;
                        gridOption.IsEnabled = false;
                        gridOption2.IsEnabled = false;
                        editor.main.characterCurrent.Class.Subclass = defaultSubclass;
                        editor.main.characterCurrent.Class.Class = editor.main.characterCurrent.Class.Subclasses[0];                      
                        break;
                    case "gridDeity":
                        editor.main.characterCurrent.Deity = new Deities();
                        deityPicked = false;
                        ChangeCompleted(false, gridDeity, true);
                        break;
                    case "gridBuild":
                        editor.main.characterCurrent.Class.Subclass.Build = new Builds();
                        buildPicked = false;
                        ChangeCompleted(false, gridBuild, false);
                        break;
                    case "gridOption":
                        optionPicked = false;
                        ChangeCompleted(false, gridOption, false);
                        editor.main.characterCurrent.Class.Subclass.OptionPicked1 = new ClassOption();
                        editor.main.characterCurrent.Class.Subclass.OptionPicked1.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0];
                        textblockOptionPick.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[0].OptionDetails[0] + " option.";
                        break;
                    case "gridOption2":
                        option2Picked = false;
                        ChangeCompleted(false, gridOption2, false);
                        editor.main.characterCurrent.Class.Subclass.OptionPicked2 = new ClassOption();
                        editor.main.characterCurrent.Class.Subclass.OptionPicked2.OptionName = editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0];
                        textblockOptionPick2.Text = "Click to choose your " + editor.main.characterCurrent.Class.Subclass.ListOptions[1].OptionDetails[0] + " option.";
                        break;
                }
            }
            canvasSelected = null;
            currentGrid = null;
        }       

        private void buttonNext_Click()
        {
            editor.classFinished = true;
            EditorRace1 race = new EditorRace1(editor);            
            editor.currentButton = editor.pathRace.Name;
            editor.PathSelected();
            editor.frameContainer.Content = race;
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
