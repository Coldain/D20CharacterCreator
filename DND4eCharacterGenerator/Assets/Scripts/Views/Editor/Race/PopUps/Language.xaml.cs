using DnD4e.Assets.Scripts.Model;
using DnD4e.CharacterBuilder.Editor.View.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Race.PopUps
{
    public partial class Language : UserControl
    {
        bool deselect = false;
        EditorRace2 priorPage;
        PopUp popUp;
        List<Languages> myLanguages;
        Languages myLanguage;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        CharacterEditor editor;

        public Language(PopUp _popUp, CharacterEditor _editor, EditorRace2 _priorPage)
        {
            priorPage = _priorPage;
            editor = _editor;
            myLanguages = editor.main.listLanguages;
            popUp = _popUp;
            InitializeComponent();
            List<languageSelections> choices = new List<languageSelections>();
            languageSelections first = new languageSelections() { Relevance = "Languages" };
            first.Options = new ObservableCollection<Languages>();
            foreach (Languages item in editor.main.characterCurrent.KnownLanguages) myLanguages.Remove(item);
            for (int i = 0; i < editor.main.listLanguages.Count; i++)
            {
                if (editor.main.listLanguages[i].Setting == editor.main.characterCurrent.Campaign.Setting && editor.main.listLanguages[i].Language != "Mind")
                    if (editor.main.characterCurrent.Level == 1)
                    {
                        if (editor.main.listLanguages[i].Language != "Abyssal" && editor.main.listLanguages[i].Language != "Supernal")
                        {
                            Languages tempLanguage = new Languages(myLanguages[i]);
                            first.Options.Add(tempLanguage);
                        }
                    }
                    else
                    {
                        Languages tempLanguage = new Languages(myLanguages[i]);
                        first.Options.Add(tempLanguage);
                    }

            }            
            choices.Add(first);
            myLanguages = first.Options.ToList();
            trvFamilies.ItemsSource = choices;
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[8].Name, editor.main.listDefinitions[8].Description);
            popUp.framedetails.Content = details;
        }

        private void buttonDeselect_Click(object sender, RoutedEventArgs e)
        {
            Canvas tempCanvase = sender as Canvas;
            tvi = null;
            myLanguage = null;
            popUp.framedetails.Content = null;
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
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[8].Name, editor.main.listDefinitions[8].Description);
            popUp.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int i = rand.Next(0, myLanguages.Count);
            Languages tempLanguage = new Languages();
            tempLanguage.Language = myLanguages[i].Language;
            tempLanguage.Setting = myLanguages[i].Setting;
            tempLanguage.Description = myLanguages[i].Description;
            SelectionDetailsRole details = new SelectionDetailsRole(tempLanguage.Language, tempLanguage.Description, tempLanguage.Image);
            popUp.framedetails.Content = details;
            ChangeSelections(true);
            myLanguage = tempLanguage;
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            editor.main.characterCurrent.KnownLanguages.Add(myLanguage);
            SelectionDetailsRole details = new SelectionDetailsRole(myLanguage.Language, myLanguage.Description, myLanguage.Image);
            editor.framedetails.Content = details;
            priorPage.languagePicked = true;
            priorPage.ChangeSelections(true);
            popUp.Close();
        }

        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            trvFamilies.Tag = e.OriginalSource;
            tvi = (trvFamilies.Tag as TreeViewItem);
            if (tvi != null)
                tvi.IsSelected = false;
            if (tvi2 != null)
                tvi2.IsSelected = false;
        }

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
            popUp.mouseBusy = true;
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
            myLanguage = grid.DataContext as Languages;
            if (myLanguage != null)
            {
                SelectionDetailsRole details = new SelectionDetailsRole(myLanguage.Language, myLanguage.Description, myLanguage.Image);
                popUp.framedetails.Content = details;
                ChangeSelections(true);
            }
        }


        private void treeViewItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                canvasSelected = sender as Canvas;
                Grid grid = (Grid)canvasSelected.Parent;
                TranslateTransform translation = new TranslateTransform(0, 0);
                grid.RenderTransform = translation;
                Mouse.Capture(null);
                popUp.mouseBusy = false;
            }
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
            popUp.mouseBusy = true;
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
            popUp.mouseBusy = false;
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
    public class languageSelections
    {
        public languageSelections()
        {
            this.Options = new ObservableCollection<Languages>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Languages> Options { get; set; }
    }
}
