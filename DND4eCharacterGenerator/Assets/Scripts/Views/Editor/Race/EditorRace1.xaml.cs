using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.Assets.Scripts.Views.Editor.Class;
using DnD4e.Assets.Scripts.Views.Editor.Race;
using DnD4e.CharacterBuilder.Editor.View.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DnD4e.Assets.Scripts.Views.Editor.Race
{
    public partial class EditorRace1 : UserControl
    {
        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Races myRace = new Races();
        CharacterEditor editor;
        public EditorRace1(CharacterEditor _editor)
        {
            editor = _editor;           
            List<raceSelections> choices = new List<raceSelections>();
            InitializeComponent();
            //SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[7].Pick, editor.main.listDefinitions[7].Description);
            // editor.framedetails.Content = details;
            //if (editor.main.characterCurrent.Class.PreferredRaces == null)
            //{
            //    raceSelections races = new raceSelections() { Relevance = "Races" };
            //    races.Options = new ObservableCollection<Races>(editor.main.listRaces);
            //    choices.Add(races); ;
            //    trvFamilies.ItemsSource = choices;
            //}
            //else
            //{
            //    List<Races> otherRaces = new List<Races>();
            //    List<Races> suggestedRaces = new List<Races>();
            //    foreach (string race in editor.main.characterCurrent.Class.PreferredRaces)
            //    {
            //        for (int i = 0; i < editor.main.listRaces.Count; i++)
            //        {
            //            if (race == editor.main.listRaces[i].Race)
            //                suggestedRaces.Add(editor.main.listRaces[i]);
            //        }
            //    }
            //    otherRaces = editor.main.listRaces.Except(suggestedRaces).ToList();           
            //    raceSelections suggested = new raceSelections() { Relevance = "Suggested Races" };
            //    suggested.Options = new ObservableCollection<Races>(suggestedRaces);
            //    choices.Add(suggested);
            //    raceSelections others = new raceSelections() { Relevance = "Other Races" };
            //    others.Options = new ObservableCollection<Races>(otherRaces);
            //    choices.Add(others);
            //    trvFamilies.ItemsSource = choices;
            //}
        }

        //private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        //{
        //    trvFamilies.Tag = e.OriginalSource;
        //    tvi = (trvFamilies.Tag as TreeViewItem);
        //    if (tvi != null)
        //        tvi.IsSelected = false;
        //    if (tvi2 != null)
        //        tvi2.IsSelected = false;
        //}

        private void Item_Selected(object sender, RoutedEventArgs e)
        {
            Grid tempGrid = sender as Grid;
            ContentPresenter tempContent = tempGrid.TemplatedParent as ContentPresenter;
            TreeViewItem temptvi = tempContent.TemplatedParent as TreeViewItem;
            tvi2 = temptvi;
            tvi2.IsSelected = false;
            tvi2.FocusVisualStyle = null;
            if (tvi != null)
                tvi.IsSelected = false;
        }

        private void buttonDeselect_Click(object sender, RoutedEventArgs e)
        {
            Canvas tempCanvase = sender as Canvas;
            tvi = null;
            myRace = null;
            editor.framedetails.Content = null;
            ChangeSelections(false);
            if (canvasSelected != null)
            {
                Rectangle rect = (Rectangle)canvasSelected.Children[0];
                var converter = new BrushConverter();
                rect.Stroke = Brushes.Transparent;
                var brush = (Brush)converter.ConvertFromString("#FFCBC5A4");
                canvasSelected.Background = brush;
                canvasSelected.Opacity = 0.8;
            }
            if (canvasSelected != tempCanvase)
            {
                treeViewItem_MouseUp(canvasSelected, null);
            }
            canvasSelected = null;
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[7].Pick, editor.main.listDefinitions[7].Description);
            editor.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            myRace = editor.main.listRaces[rand.Next(0, editor.main.listRaces.Count)];
            SelectionDetailsRace details = new SelectionDetailsRace(myRace, editor.main);
            editor.framedetails.Content = details;
            ChangeSelections(true);
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            editor.main.characterCurrent.KnownLanguages = new List<Languages>();
            editor.main.characterCurrent.Race = new Races(myRace);
            foreach(string lang in myRace.Languages)
            {
                foreach (Languages langs in editor.main.listLanguages)
                {
                    if (langs.Language == lang)
                        editor.main.characterCurrent.KnownLanguages.Add(langs);                    
                }
            }
            if (myRace.Abilities.Count == 3)
                switch (myRace.Abilities[0])
                {
                    case "Str":
                        editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength + 2;
                        break;
                    case "Con":
                        editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution + 2;
                        break;
                    case "Dex":
                        editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity + 2;
                        break;
                    case "Int":
                        editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence + 2;
                        break;
                    case "Wis":
                        editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom + 2;
                        break;
                    case "Cha":
                        editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma + 2;
                        break;
                }
            else if (myRace.Abilities.Count == 2)
            {
                switch (myRace.Abilities[0])
                {
                    case "Str":
                        editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength + 2;
                        break;
                    case "Con":
                        editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution + 2;
                        break;
                    case "Dex":
                        editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity + 2;
                        break;
                    case "Int":
                        editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence + 2;
                        break;
                    case "Wis":
                        editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom + 2;
                        break;
                    case "Cha":
                        editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma + 2;
                        break;
                }
                switch (myRace.Abilities[1])
                {
                    case "Str":
                        editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength + 2;
                        break;
                    case "Con":
                        editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution + 2;
                        break;
                    case "Dex":
                        editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity + 2;
                        break;
                    case "Int":
                        editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence + 2;
                        break;
                    case "Wis":
                        editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom + 2;
                        break;
                    case "Cha":
                        editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma + 2;
                        break;
                }
            }
            EditorRace2 race2 = new EditorRace2(editor, this);
            editor.frameContainer.Content = race2;
            editor.raceSelected = true;
        }

        private void ChangeSelections(bool switcher)
        {
            if (switcher == false)
            {
                canvasSelect.Opacity = 0.6;                
            }
            else
            {
                canvasDeselect.Opacity = 0.2;
                canvasSelect.Opacity = 0.2;
                deselect = true;
            }

            buttonDeselect.IsEnabled = switcher;
            buttonSelect.IsEnabled = switcher;
            
        }

        private void treeViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            if (canvasSelected != canvas)
                canvas.Opacity = 0;
        }

        private void treeViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas canvas = sender as Canvas;

            if (canvasSelected != canvas)
                canvas.Opacity = 0.8;
            else
            {
                treeViewItem_MouseUp(canvasSelected, null);
            }
        }

        private void treeViewItem_MouseDown(object sender, MouseEventArgs e)
        {
            editor.mouseBusy = true;
            Canvas tempCanvas = sender as Canvas;
            if (canvasSelected != null)
                buttonDeselect_Click(tempCanvas, null);
            canvasSelected = tempCanvas;
            canvasSelected.Background = Brushes.Transparent;
            canvasSelected.Opacity = 100;
            Rectangle rect = (Rectangle)canvasSelected.Children[0];
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF4CC513");
            rect.Stroke = brush;
            Grid grid = (Grid)canvasSelected.Parent;
            TranslateTransform translation = new TranslateTransform(3, 3);
            grid.RenderTransform = translation;
            Mouse.Capture(canvasSelected);
            myRace = grid.DataContext as Races;
            if (myRace != null)
            {
                SelectionDetailsRace details = new SelectionDetailsRace(myRace, editor.main);
                editor.framedetails.Content = details;
                ChangeSelections(true);
            }
        }


        private void treeViewItem_MouseUp(object sender, MouseEventArgs e)
        {
            canvasSelected = sender as Canvas;
            Grid grid = (Grid)canvasSelected.Parent;
            TranslateTransform translation = new TranslateTransform(0, 0);
            grid.RenderTransform = translation;
            Mouse.Capture(null);
            editor.mouseBusy = false;
        }

        private void path_MouseEnter(object sender, MouseEventArgs e)
        {          
            Path tempPath = sender as Path;
            if (tempPath == canvasDeselect)
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
            if (tempPath == canvasDeselect)
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
                case "buttonDeselect":
                    deselect = false;
                    Path path = canvas.Children[2] as Path;
                    path_MouseLeave(path, null);
                    canvasDeselect.Opacity = 0.6;
                    buttonDeselect_Click(canvas, null);
                    break;
                case "buttonChooseForMe":
                    buttonChooseForMe_Click(this, null);
                    break;
                case "buttonSelect":
                    buttonSelect_Click(this, null);
                    break;
            }
        }
    }

    public class raceSelections
    {
        public raceSelections()
        {
            this.Options = new ObservableCollection<Races>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Races> Options { get; set; }
    }
}

