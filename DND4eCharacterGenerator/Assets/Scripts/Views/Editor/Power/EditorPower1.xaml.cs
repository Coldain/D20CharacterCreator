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
    /// <summary>
    /// Interaction logic for EdiorPower.xaml
    /// </summary>
    public partial class EditorPower1 : UserControl
    {
        int i = 1;
        int x = 0;
        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Powers myPower = new Powers();
        CharacterEditor editor;
        public EditorPower1(CharacterEditor _editor)
        {
            editor = _editor;
            List<powerSelections1> choices = new List<powerSelections1>();
            List<Tuple<string, int>> headers = new List<Tuple<string, int>>();
            List<Powers> items = new List<Powers>();
            foreach (Powers tempPowerL in editor.main.listPowers)
            {
                foreach (string tempPowerC in editor.main.characterCurrent.Class.Subclass.Powers)
                {
                    if (tempPowerC == tempPowerL.Power)
                    {
                        items.Add(tempPowerL);
                        int headerLevel;
                        if (int.TryParse(tempPowerL.OriginType, out headerLevel))
                        {
                            string headerName = "Level " + tempPowerL.OriginType + " : " + tempPowerL.Origin + " - " + tempPowerL.ActionType;
                            Tuple<string, int> header = new Tuple<string, int>(headerName, headerLevel);
                            if (!headers.Contains(header))
                                headers.Add(header);
                            while (i <= editor.main.characterCurrent.Level)
                            {
                                switch (i)
                                {
                                    case 1:
                                        {
                                            x = PowerAdjust(2, x, headerName);
                                            x = PowerAdjust(1, x, headerName);
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 2:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 3:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 5:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 6:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 7:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 9:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 10:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 11:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 12:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 16:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 20:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 22:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    case 26:
                                        {
                                            x = PowerAdjust(1, x, headerName);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                i++;
                            }
                        }

                    }

                }
            }

            InitializeComponent();


            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[15].Pick, editor.main.listDefinitions[15].Description);
            editor.framedetails.Content = details;
            foreach (Tuple<List<string>, List<Powers>> tempPowerLists in editor.main.characterCurrent.PowerList)
            {
                powerSelections1 tempPowers = new powerSelections1() { Relevance = tempPowerLists.Item1[0] };
                tempPowers.Options = new ObservableCollection<Powers>(tempPowerLists.Item2);
                choices.Add(tempPowers);
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
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[7].Pick, editor.main.listDefinitions[7].Description);
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
            //editor.main.characterCurrent.KnownLanguages = new List<Languages>();
            //editor.main.characterCurrent.PowerList = new Powers(myPower);
            //foreach (string lang in myPower.Languages)
            //{
            //    foreach (Languages langs in editor.main.listLanguages)
            //    {
            //        if (langs.Language == lang)
            //            editor.main.characterCurrent.KnownLanguages.Add(langs);
            //    }
            //}
            //if (myPower.Abilities.Count == 3)
            //    switch (myPower.Abilities[0])
            //    {
            //        case "Str":
            //            editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength + 2;
            //            break;
            //        case "Con":
            //            editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution + 2;
            //            break;
            //        case "Dex":
            //            editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity + 2;
            //            break;
            //        case "Int":
            //            editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence + 2;
            //            break;
            //        case "Wis":
            //            editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom + 2;
            //            break;
            //        case "Cha":
            //            editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma + 2;
            //            break;
            //    }
            //else if (myPower.Abilities.Count == 2)
            //{
            //    switch (myPower.Abilities[0])
            //    {
            //        case "Str":
            //            editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength + 2;
            //            break;
            //        case "Con":
            //            editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution + 2;
            //            break;
            //        case "Dex":
            //            editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity + 2;
            //            break;
            //        case "Int":
            //            editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence + 2;
            //            break;
            //        case "Wis":
            //            editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom + 2;
            //            break;
            //        case "Cha":
            //            editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma + 2;
            //            break;
            //    }
            //    switch (myPower.Abilities[1])
            //    {
            //        case "Str":
            //            editor.main.characterCurrent.Strength = editor.main.characterCurrent.Strength + 2;
            //            break;
            //        case "Con":
            //            editor.main.characterCurrent.Constitution = editor.main.characterCurrent.Constitution + 2;
            //            break;
            //        case "Dex":
            //            editor.main.characterCurrent.Dexterity = editor.main.characterCurrent.Dexterity + 2;
            //            break;
            //        case "Int":
            //            editor.main.characterCurrent.Intelligence = editor.main.characterCurrent.Intelligence + 2;
            //            break;
            //        case "Wis":
            //            editor.main.characterCurrent.Wisdom = editor.main.characterCurrent.Wisdom + 2;
            //            break;
            //        case "Cha":
            //            editor.main.characterCurrent.Charisma = editor.main.characterCurrent.Charisma + 2;
            //            break;
            //    }
            //}
            //EditorPower2 power2 = new EditorPower2(editor, this);
            //editor.frameContainer.Content = power2;
            //editor.powerSelected = true;
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
        private int PowerAdjust(int iPowers, int iList, string powerGroup)
        {
            if (iPowers < editor.main.characterCurrent.PowerList[iList].Item2.Count())
            {
                while (iPowers < editor.main.characterCurrent.PowerList[iList].Item2.Count())
                {
                    Powers tempPower = new Powers();
                    editor.main.characterCurrent.PowerList[iList].Item2.Add(tempPower);
                    iPowers++;
                }
            }
            else if (iPowers > editor.main.characterCurrent.PowerList[iList].Item2.Count())
            {
                while (iPowers < editor.main.characterCurrent.PowerList[iList].Item2.Count())
                {
                    Powers tempPower = new Powers();                    
                    editor.main.characterCurrent.PowerList[iList].Item2.RemoveAt(editor.main.characterCurrent.PowerList[iList].Item2.IndexOf(tempPower));
                    iPowers--;
                }
            }
            return iList++;
        }
    }

    public class powerSelections1
    {
        public powerSelections1()
        {
            this.Options = new ObservableCollection<Powers>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Powers> Options { get; set; }
    }
}

