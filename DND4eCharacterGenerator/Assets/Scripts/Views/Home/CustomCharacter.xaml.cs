using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.CharacterBuilder.Editor.View.Class;
using DnD4e.CharacterBuilder.Editor.ViewModels;
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

namespace DnD4e.Assets.Scripts.Views.Home
{
    public partial class CustomCharacter : UserControl
    {
        MainController main;
        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        List<Campaigns> myCampaignList = new List<Campaigns>();
        Campaigns myCampaign = new Campaigns();
        public HomePage home;

        public CustomCharacter(MainController _main)
        {
            main = _main;
            InitializeComponent();
            List<Selections> choices = new List<Selections>();
            Selections first = new Selections() { Relevance = "Select Campaign Setting(s)" };
            first.Options = new ObservableCollection<Campaigns>(main.listCampaings);
            choices.Add(first);
            trvFamilies.ItemsSource = choices;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            home.popUp.Hide();
        }

        private void buttonAll_Click(object sender, RoutedEventArgs e)
        {
            myCampaignList = main.listCampaings;
            buttonContinue_Click(null, null);
        }

        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            if (myCampaignList.Count > 0)
            {
                main.characterCurrent.CampaignList = myCampaignList;
                main.fromCustom = true;
                int level = Int16.Parse(comboBoxLevelSelector.SelectedValue.ToString());
                main.characterCurrent.Level = level;
                Experience_Manager exp = new Experience_Manager();
                main.characterCurrent.TotalXP = exp.SetLevel(level);
                CharacterEditor editorWindow = new CharacterEditor(main);
                editorWindow.Show();
                home.Close();
                home.popUp.Close();                
            }            
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

            private void buttonDeselect_Click(object sender, RoutedEventArgs e)
        {
            Canvas tempCanvase = sender as Canvas;
            tvi = null;
            myCampaign = null;
            home.popUp.framedetails.Content = null;
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
            SelectionDetailsRole details = new SelectionDetailsRole(main.listDefinitions[1].Pick, main.listDefinitions[1].Description);
            home.popUp.framedetails.Content = details;
        }

        private void ChangeSelections(bool switcher)
        {
            if (switcher == false)
            {
                canvasSelect.Opacity = 0.6;
            }
            else
            {
                canvasSelect.Opacity = 0.2;
                deselect = true;
            }

            buttonContinue.IsEnabled = switcher;

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
            home.popUp.mouseBusy = true;
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
            myCampaign = grid.DataContext as Campaigns;
            if (grid.Children[8].Visibility == Visibility.Visible)
            {
                grid.Children[6].Visibility = Visibility.Hidden;
                grid.Children[7].Visibility = Visibility.Hidden;
                grid.Children[8].Visibility = Visibility.Hidden;
                if (myCampaignList.Contains(myCampaign))
                    myCampaignList.Remove(myCampaign);
            }
            else
            {
                grid.Children[6].Visibility = Visibility.Visible;
                grid.Children[7].Visibility = Visibility.Visible;
                grid.Children[8].Visibility = Visibility.Visible;
                if (!myCampaignList.Contains(myCampaign))
                    myCampaignList.Add(myCampaign);
            }
            if (myCampaign != null)
            {
                SelectionDetailsRole details = new SelectionDetailsRole(myCampaign.Setting, myCampaign.Tidbits + "\r\n" + "Description" + myCampaign.Description + "\r\n" + "Background" + myCampaign.Background);
                home.popUp.framedetails.Content = details;
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
            home.popUp.mouseBusy = false;
        }

        private void path_MouseEnter(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            tempPath.Opacity = 0;
        }

        private void path_MouseLeave(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            tempPath.Opacity = 0.2;
        }

        private void path_MouseDown(object sender, MouseEventArgs e)
        {
            home.popUp.mouseBusy = true;
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
            home.popUp.mouseBusy = false;
        }

        private void ButtonOption(Canvas canvas)
        {
            switch (canvas.Name)
            {
                case "buttonCancel":
                    buttonCancel_Click(this, null);
                    break;
                case "buttonAll":
                    buttonAll_Click(this, null);
                    break;
                case "buttonContinue":
                    buttonContinue_Click(this, null);
                    break;
                default:
                    break;
            }
        }
    }

    public class Selections
    {
        public Selections()
        {
            this.Options = new ObservableCollection<Campaigns>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Campaigns> Options { get; set; }
    }
}
