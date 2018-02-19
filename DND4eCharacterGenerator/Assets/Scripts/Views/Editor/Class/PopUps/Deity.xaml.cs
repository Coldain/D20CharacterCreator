using DnD4e.Assets.Scripts.Model;
using DnD4e.CharacterBuilder.Editor.View.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DnD4e.Assets.Scripts.Views.Editor.Class.PopUps
{
    /// <summary>
    /// Interaction logic for Deity.xaml
    /// </summary>
    public partial class Deity : UserControl
    {
        bool deselect = false;
        EditorClass3 priorPage;
        PopUp popUp;
        List<Deities> gods;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Deities myDeity = new Deities();
        CharacterEditor editor;

        public Deity(PopUp _popUp, CharacterEditor _editor, EditorClass3 _priorPage)
        {
            priorPage = _priorPage;
            editor = _editor;
            popUp = _popUp;
            InitializeComponent();
            List<Deities> templist = new List<Deities>();
            foreach (Campaigns campain in editor.main.characterCurrent.CampaignList)
                foreach (Deities deity in editor.main.listDeities)
                {
                    if (campain.Setting == deity.Setting)
                    {
                        templist.Add(deity);
                    }
                }
            gods = templist;
            List<deitySelections> choices = new List<deitySelections>();
            deitySelections first = new deitySelections() { Relevance = "Deities" };
            first.Options = new ObservableCollection<Deities>(gods);
            choices.Add(first);
            trvFamilies.ItemsSource = choices;
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[6].Pick, editor.main.listDefinitions[6].Description);
            popUp.framedetails.Content = details;
        }

        private void buttonDeselect_Click(object sender, RoutedEventArgs e)
        {
            Canvas tempCanvase = sender as Canvas;
            tvi = null;
            myDeity = null;
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
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[6].Pick, editor.main.listDefinitions[6].Description);
            popUp.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            myDeity = gods[rand.Next(0, gods.Count)];
            editor.main.characterCurrent.Deity = myDeity;
            SelectionDetailsDeity details = new SelectionDetailsDeity(myDeity);
            popUp.framedetails.Content = details;
            ChangeSelections(true);
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            editor.main.characterCurrent.Deity = myDeity;
            SelectionDetailsDeity details = new SelectionDetailsDeity(myDeity);
            editor.framedetails.Content = details;
            priorPage.deityPicked = true;
            priorPage.ChangeSelections(true);
            editor.main.characterCurrent.Deity = new Deities(myDeity);
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
            myDeity = grid.DataContext as Deities;
            if (myDeity != null)
            {
                SelectionDetailsDeity details = new SelectionDetailsDeity(myDeity);
                popUp.framedetails.Content = details;
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
            popUp.mouseBusy = false;
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

    public class deitySelections
    {
        public deitySelections()
        {
            this.Options = new ObservableCollection<Deities>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Deities> Options { get; set; }
    }
}
