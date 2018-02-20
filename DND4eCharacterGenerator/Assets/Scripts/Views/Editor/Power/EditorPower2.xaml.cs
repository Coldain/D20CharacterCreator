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

namespace DnD4e.Assets.Scripts.Views.Editor.Power
{
    public partial class EditorPower2 : UserControl
    {

        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Powers myPower = new Powers();
        CharacterEditor editor;
        int i;
        int x;
        public EditorPower2(CharacterEditor _editor, List<Powers> _powers, int iPowerList, int xPower)
        {
            editor = _editor;
            i = iPowerList;
            x = xPower;

            List<powerSelections2> choices = new List<powerSelections2>();
            InitializeComponent();
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[14].Pick, editor.main.listDefinitions[14].Description);
            editor.framedetails.Content = details;
            if (editor.main.characterCurrent.Class.Subclass.Abilities == null)
            {
                powerSelections2 powers = new powerSelections2() { Relevance = "Powers" };
                powers.Options = new ObservableCollection<Powers>(_powers);
                choices.Add(powers);
                trvFamilies.ItemsSource = choices;
            }
            else
            {
                List<Powers> otherPowers = new List<Powers>();
                List<Powers> suggestedPowers1 = new List<Powers>();
                List<Powers> suggestedPowers2 = new List<Powers>();
                foreach (Powers tempPower in _powers)
                {
                    if (tempPower.AttackType.ToUpper() == editor.main.characterCurrent.Class.Subclass.Abilities[0].Substring(0, 2).ToUpper())
                        suggestedPowers1.Add(tempPower);
                    else if (editor.main.characterCurrent.Class.Subclass.Abilities.Count() > 1)
                    {
                        if (tempPower.AttackType.ToUpper() == editor.main.characterCurrent.Class.Subclass.Abilities[1].Substring(0, 2).ToUpper())
                            suggestedPowers2.Add(tempPower);
                        if (editor.main.characterCurrent.Class.Subclass.Abilities.Count() > 2)
                        {
                            if (tempPower.AttackType.ToUpper() == editor.main.characterCurrent.Class.Subclass.Abilities[2].Substring(0, 2).ToUpper())
                                suggestedPowers2.Add(tempPower);
                        }
                        else
                            otherPowers.Add(tempPower);
                    }
                    else
                        otherPowers.Add(tempPower);
                }
                powerSelections2 suggested1 = new powerSelections2() { Relevance = "Suggested " + editor.main.characterCurrent.Class.Subclass.Abilities[0] + " " + "Powers" };
                suggested1.Options = new ObservableCollection<Powers>(suggestedPowers1);
                choices.Add(suggested1);
                if (suggestedPowers2.Count < 0)
                {
                    powerSelections2 suggested2 = new powerSelections2() { Relevance = "Suggested " + editor.main.characterCurrent.Class.Subclass.Abilities[1] + " and " + editor.main.characterCurrent.Class.Subclass.Abilities[2] + " " + "Powers" };
                    suggested2.Options = new ObservableCollection<Powers>(suggestedPowers2);
                    choices.Add(suggested2);
                }
                powerSelections2 others = new powerSelections2() { Relevance = "Other Powers" };
                others.Options = new ObservableCollection<Powers>(otherPowers);
                choices.Add(others);
                trvFamilies.ItemsSource = choices;
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
            myPower = null;
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
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[14].Pick, editor.main.listDefinitions[14].Description);
            editor.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            myPower = editor.main.listPowers[rand.Next(0, editor.main.listPowers.Count)];
            SelectionDetailsPower details = new SelectionDetailsPower(myPower, editor.main);
            editor.framedetails.Content = details;
            ChangeSelections(true);
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectionDetailsPower details = new SelectionDetailsPower(myPower, editor.main);
            editor.main.characterCurrent.PowerList[i].Item2[x] = myPower;
            editor.framedetails.Content = details;
            EditorPower1 detailpowers = new EditorPower1(editor);
            editor.frameContainer.Content = detailpowers;

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
            myPower = grid.DataContext as Powers;
            if (myPower != null)
            {
                SelectionDetailsPower details = new SelectionDetailsPower(myPower, editor.main);
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

    public class powerSelections2
    {
        public powerSelections2()
        {
            this.Options = new ObservableCollection<Powers>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Powers> Options { get; set; }
    }
}

