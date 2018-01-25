using DnD4e.Assets.Scripts.Views.Editor.Abilities;
using DnD4e.CharacterBuilder.Editor.View.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Details
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class EditorDetails : UserControl
    {
        bool deselect;
        Canvas canvasSelected;
        bool namePicked;
        bool genderPicked;
        bool alignmentPicked;
        bool heightPicked;
        bool weightPicked;
        bool agePicked;
        bool backgroundPicked;
        bool backgroundOptionPicked;
        Grid currentGrid;
        CharacterEditor editor;
        public EditorDetails(CharacterEditor _editor)
        {
            editor = _editor;
            int align = -1;
            int gend = -1;
            if (editor.main.characterCurrent.Alignment == editor.main.listDefinitionLists[5].MainList[0])            
                    align = 0;
            else if (editor.main.characterCurrent.Alignment == editor.main.listDefinitionLists[5].MainList[1])
                align = 1;
            else if (editor.main.characterCurrent.Alignment == editor.main.listDefinitionLists[5].MainList[2])
                align = 2;
            else if (editor.main.characterCurrent.Alignment == editor.main.listDefinitionLists[5].MainList[3])
                align = 3;
            else if (editor.main.characterCurrent.Alignment == editor.main.listDefinitionLists[5].MainList[4])
                align = 4;
            else
                align = -1;            
            if (editor.main.characterCurrent.Gender == editor.main.listDefinitionLists[4].MainList[0])    
                gend = 0;
            else if (editor.main.characterCurrent.Gender == editor.main.listDefinitionLists[4].MainList[1])
                gend = 1;
            else
                gend = -1;

            InitializeComponent();
            ChangeCompleted(true, gridBackground, false);
            DataContext = new
            {
                genders = editor.main.listDefinitionLists[4],
                alignments = editor.main.listDefinitionLists[5],
                character = editor.main.characterCurrent,
            };
            if (editor.main.characterCurrent.Race != null && editor.main.characterCurrent.Race.Race != "Race")
            {
                buttonRandomName.IsEnabled = true;
                canvasRandomName.Opacity = 0.2;
            }
            if (editor.main.characterCurrent.Name != null)
            {
                namePicked = true;
                textboxName.Text = editor.main.characterCurrent.Name;
            }
            if (gend != -1)
            {
                genderPicked = true;
                textboxGender.SelectedIndex = gend; 
            }
            if (align != -1)
            {
                alignmentPicked = true;
                textboxAlignment.SelectedIndex = align;
            }
            if (editor.main.characterCurrent.Height != null)
                heightPicked = true;
            if (editor.main.characterCurrent.Weight != null)
                weightPicked = true;
            if (editor.main.characterCurrent.Age != null)
                agePicked = true;

        }

        private void Background_Selected()
        {
            if (backgroundPicked)
            {
                //SelectionDetailsRole details = new SelectionDetailsRole("Background", "Pick a background.");
                //editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                ChangeCompleted(true, gridBackground, false);
            }
            deselect = true;
        }

        private void BackgroundOptions_Selected()
        {
            if (backgroundOptionPicked)
            {
                //SelectionDetailsBuild details = new SelectionDetailsBuild(editor.main.characterCurrent.Class.Subclass.Build);
                //editor.framedetails.Content = details;
                ChangeSelections(true);
            }
            else
            {
                //SelectionDetailsBuild details = new SelectionDetailsBuild(editor.main.characterCurrent.Class.Subclass.Build);
                //editor.framedetails.Content = details;
                ChangeCompleted(true, gridBackgroundOption, false);
            }
            deselect = true;
        }  

        public void ChangeSelections(bool switcher)
        {
            if (!switcher)
            {
                canvasClear.Opacity = 0.6;
            }
            else
            {
                canvasClear.Opacity = 0.2;
            }
            buttonClear.IsEnabled = switcher;
        }

        private void TextUpdated(bool switcher)
        {
            if (!switcher)
            {
                if (buttonNext.IsEnabled)
                {
                    {
                        canvasNext.Opacity = 0.6;
                        buttonNext.IsEnabled = false;
                        editor.pathDetailsFinished.Visibility = Visibility.Hidden;
                        editor.detailsFinished = false;
                    }
                }
            }
            else
            {
                if (namePicked && genderPicked && alignmentPicked && heightPicked && weightPicked && agePicked)
                {
                    canvasNext.Opacity = 0.2;
                    buttonNext.IsEnabled = true;
                    editor.pathDetailsFinished.Visibility = Visibility.Visible;
                    editor.detailsFinished = true;
                }
            }        
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
                case "itemBackground":
                    Background_Selected();
                    break;
                case "itemBackgroundOptions":
                    BackgroundOptions_Selected();
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
            if (canvasSelected != null)
            {
                canvasSelected.Opacity = 0.8;
                var converter = new BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#FFCBC5A4");
                canvasSelected.Background = brush;
                Rectangle rect = (Rectangle)canvasSelected.Children[0];
                rect.Stroke = Brushes.Transparent;
                SelectionDetailsRole raceDetails = new SelectionDetailsRole(editor.main.listDefinitions[10].Name, editor.main.listDefinitions[10].Description);
                editor.framedetails.Content = raceDetails;
            }
        }

        private void buttonClear_Click()
        {
            if (currentGrid != null)
            {
                SelectionDetailsRole raceDetails = new SelectionDetailsRole(editor.main.listDefinitions[10].Name, editor.main.listDefinitions[10].Description);
                editor.framedetails.Content = raceDetails;
                buttonDeselect_Click();
                switch (currentGrid.Name)
                {
                    case "gridBackground":
                        backgroundPicked = false;
                        backgroundOptionPicked = false;                     
                        ChangeCompleted(false, gridBackground, false);
                        ChangeCompleted(false, gridBackgroundOption, false);
                        //editor.main.characterCurrent.Background = new Background();
                        gridBackgroundOption.IsEnabled = false;
                        break;
                    case "gridBackgroundOption":
                        backgroundOptionPicked = false;
                        ChangeCompleted(false, gridBackgroundOption, false);
                        //editor.main.characterCurrent.Background.Option = null;
                        break;                   
                }
            }
            canvasSelected = null;
            currentGrid = null;
        }
           
        private void buttonNext_Click()
        {
            EditorAbilities details = new EditorAbilities(editor);
            editor.currentButton = editor.pathAbilities.Name;
            editor.PathSelected();
            editor.frameContainer.Content = details;
        }

        private void buttonRandomName_Click()
        {
            Random rand = new Random();
            if(!genderPicked)
            {
                List<string> names = new List<string>();
                names = editor.main.characterCurrent.Race.MaleNames.Concat(editor.main.characterCurrent.Race.FemaleNames).ToList();
                int r = rand.Next(0, names.Count);
                editor.main.characterCurrent.Name = names[r];
            }
            else
            {
                if (editor.main.characterCurrent.Gender == "Male")
                {
                    int r = rand.Next(0, editor.main.characterCurrent.Race.MaleNames.Count);
                    editor.main.characterCurrent.Name = editor.main.characterCurrent.Race.MaleNames[r];
                }
                else
                {
                    int r = rand.Next(0, editor.main.characterCurrent.Race.FemaleNames.Count);
                    editor.main.characterCurrent.Name = editor.main.characterCurrent.Race.FemaleNames[r];
                }
            }
        }

        private void buttonSetPortrait_Click()
        {

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
                case "buttonRandomName":
                    buttonRandomName_Click();
                    break;
                case "buttonSetPortrait":
                    buttonSetPortrait_Click();
                    break;
                    
            }
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool switcher = false;
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "textboxName":
                    if (tb.Text != null || tb.Text != "")
                    {
                        namePicked = true;
                        switcher = true;
                    }
                    else
                        namePicked = false;
                    break;
                case "textboxHeight":
                    if (tb.Text != null || tb.Text != "")
                    {
                        heightPicked = true;
                        switcher = true;
                    }
                    else
                        heightPicked = false;
                    break;
                case "textboxWeight":
                    if (tb.Text != null || tb.Text != "")
                    {
                        weightPicked = true;
                        switcher = true;
                    }
                    else
                        weightPicked = false;
                    break;
                case "textboxAge":
                    if (tb.Text != null || tb.Text != "")
                    {
                        agePicked = true;
                        switcher = true;
                    }
                    else
                        agePicked = false;
                    break;
            }
            TextUpdated(switcher);
        }

        private void textNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Name == "textboxWeight")
                NumberWeightValidationTextBox(e);
            else
                NumberValidationTextBox(e);
        }

        private void textHeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            HeightValidationTextBox(e);
        }

        private void NumberValidationTextBox(TextCompositionEventArgs e)
        {
            var patten = @"[0-9]{4}";
            Regex regex = new Regex(patten);
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void NumberWeightValidationTextBox(TextCompositionEventArgs e)
        {
            var patten = @"(\d*\.?\d+)\s?(\w+)";
            Regex regex = new Regex(patten);
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void HeightValidationTextBox(TextCompositionEventArgs e)
        {
            char qoute = '"';
            var patten = @"/^(3-7)'(?:\s*(?:1[01]|0-9)(''|" + qoute + "))?$/";
            Regex regex = new Regex(patten);
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool switcher = true;
            ComboBox cb = sender as ComboBox;            
            if (cb.Name == "textboxGender")
            {
                switch (cb.SelectedItem)
                {
                    case "Male":
                        editor.main.characterCurrent.Gender = "Male";
                        genderPicked = true;
                        break;
                    case "Female":
                        editor.main.characterCurrent.Gender = "Female";
                        genderPicked = true;
                        break;
                    default:
                        editor.main.characterCurrent.Gender = null;
                        genderPicked = false;
                        switcher = false;
                        break;
                }
            }
            else if (cb.Name == "textboxAlignment")
            {
                switch (cb.SelectedItem)
                {
                    case "Unaligned":
                        editor.main.characterCurrent.Alignment = "Unaligned";
                        alignmentPicked = true;
                        break;
                    case "Lawful Good":
                        editor.main.characterCurrent.Alignment = "Lawful Good";
                        alignmentPicked = true;
                        break;
                    case "Good":
                        editor.main.characterCurrent.Alignment = "Good";
                        alignmentPicked = true;
                        break;
                    case "Evil":
                        editor.main.characterCurrent.Alignment = "Evil";
                        alignmentPicked = true;
                        break;
                    case "Chaotic Evil":
                        editor.main.characterCurrent.Alignment = "Chaotic Evil";
                        alignmentPicked = true;
                        break;
                    default:
                        editor.main.characterCurrent.Alignment = null;
                        alignmentPicked = false;
                        switcher = false;
                        break;
                }
            }
            TextUpdated(switcher);
        }

        private void textboxAge_PreviewDragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
