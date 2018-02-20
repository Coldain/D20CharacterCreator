using DnD4e.Assets.Scripts.Model;
using DnD4e.CharacterBuilder.Editor.View.Class;
using DnD4e.Assets.Scripts.Views.Editor;
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
        int indexPower;
        int indexTuple;
        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Powers myPower = new Powers();
        CharacterEditor editor;
        List<powerSelections1> choices;
        List<Powers> items = new List<Powers>();
        public EditorPower1(CharacterEditor _editor)
        {
            editor = _editor;
            choices = new List<powerSelections1>();
            List<Tuple<string, int>> headers = new List<Tuple<string, int>>();                     
            foreach (Powers tempPowerL in editor.main.listPowers)
            {
                string temporaryUntilPowersAreDividedBetweenSubclasses;
                if (editor.main.characterCurrent.Class.Class == editor.main.characterCurrent.Class.Subclass.SubClass)
                    temporaryUntilPowersAreDividedBetweenSubclasses = editor.main.characterCurrent.Class.Class;
                else
                {
                    temporaryUntilPowersAreDividedBetweenSubclasses = editor.main.characterCurrent.Class.Class.Split('(')[0];
                    temporaryUntilPowersAreDividedBetweenSubclasses = temporaryUntilPowersAreDividedBetweenSubclasses.Substring(0, temporaryUntilPowersAreDividedBetweenSubclasses.Length - 1);
                }
                if (temporaryUntilPowersAreDividedBetweenSubclasses == tempPowerL.Origin)
                {
                    items.Add(tempPowerL);
                    int headerLevel;
                    if (int.TryParse(tempPowerL.OriginType, out headerLevel))
                    {
                        string headerName = "Level " + tempPowerL.OriginType + ": " + tempPowerL.Origin + " - " + tempPowerL.PowerUsage;
                        Tuple<string, int> header = new Tuple<string, int>(headerName, headerLevel);
                        if (!headers.Contains(header))
                            headers.Add(header);
                        while (i <= editor.main.characterCurrent.Level)
                        {
                            switch (i)
                            {
                                case 1:
                                    {
                                        x = PowerAdjust(2, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - At-Will Attack Powers");
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Encounter Attack Powers");
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Daily Attack Powers");
                                        break;
                                    }
                                case 2:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utility Power");
                                        break;
                                    }
                                case 3:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Encounter Attack Power");
                                        break;
                                    }
                                case 5:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Daily Attack Power");
                                        break;
                                    }
                                case 6:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utilty Power");
                                        break;
                                    }
                                case 7:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Encounter Attack Power");
                                        break;
                                    }
                                case 9:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Daily Attack Power");
                                        break;
                                    }
                                case 10:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utility Power");
                                        break;
                                    }
                                case 11:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Encounter Attack Power");
                                        break;
                                    }
                                case 12:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utility Power");
                                        break;
                                    }
                                case 16:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utility Power");
                                        break;
                                    }
                                case 20:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Daily Attack Power");
                                        break;
                                    }
                                case 22:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utility Power");
                                        break;
                                    }
                                case 26:
                                    {
                                        x = PowerAdjust(1, x, "Level " + i + ": " + editor.main.characterCurrent.Class.Subclass.SubClass + " - Utility Power");
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
            this.DataContext = editor.main.characterCurrent.PowerList;
            InitializeComponent();


            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[14].Pick, editor.main.listDefinitions[14].Description);
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
            ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(temptvi);
            tvi2 = temptvi;
            tvi2.IsSelected = false;
            tvi2.FocusVisualStyle = null;
            if (tvi != null)
                tvi.IsSelected = false;
            Powers tempPower = temptvi.DataContext as Powers;
            powerSelections1 tempSelections = parent.DataContext as powerSelections1;
            List<string> tempStringlist = new List<string>();
            tempStringlist.Add(tempSelections.Relevance);
            List<Powers> tempPowerList = new List<Powers>();
            foreach (Powers tempfreakingPower in tempSelections.Options)
            {
                tempPowerList.Add(tempfreakingPower);
            }
            Tuple<List<string>, List<Powers>> tempTuple = new Tuple<List<string>, List<Powers>>(tempStringlist, tempPowerList);
            for (i = 0; i < editor.main.characterCurrent.PowerList.Count(); i++)
            {
                if (editor.main.characterCurrent.PowerList[i].Item1[0] == tempStringlist[0])
                    indexTuple = i;
            }        
            indexPower = editor.main.characterCurrent.PowerList[indexTuple].Item2.IndexOf(tempPower);
            if (tempPower.Power == "Choose a Power")
            {
                EditorPower2 power2 = new EditorPower2(editor, items, indexTuple, indexPower);
                SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[14].Pick, editor.main.listDefinitions[14].Description);                
                editor.frameContainer.Content = power2;
                editor.framedetails.Content = details;
                //choices.Clear();
                //foreach (var item in editor.main.characterCurrent.PowerList)
                //{
                //    powerSelections1 temporarySelections = new powerSelections1();
                //    temporarySelections.Relevance = item.Item1[0];
                //    foreach (var item2 in item.Item2)
                //        temporarySelections.Options.Add(item2);
                //    choices.Add(temporarySelections);
                //    trvFamilies.ItemsSource = choices;
                //}
                //tvi2.DataContext = editor.main.characterCurrent.PowerList[indexTuple].Item2[indexPower];
            }
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
            Powers newPower = new Powers();
            if (myPower != null)
            editor.main.characterCurrent.PowerList[indexTuple].Item2[indexPower] = myPower;
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[14].Pick, editor.main.listDefinitions[14].Description);
            editor.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {            
            
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
            if (myPower != null && myPower.Power != "Choose a Power")
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
            if (editor.main.characterCurrent.PowerList.Count() < iList + 1)
            {
                List<string> tempStringList = new List<string>();
                List<Powers> tempPowersList = new List<Powers>();
                Powers tempPower = new Powers();
                tempPowersList.Add(tempPower);
                tempStringList.Add(powerGroup);
                Tuple<List<string>, List<Powers>> tempTuple = new Tuple<List<string>, List<Powers>>(tempStringList, tempPowersList);
                editor.main.characterCurrent.PowerList.Add(tempTuple);
            }
            if (iPowers > editor.main.characterCurrent.PowerList[iList].Item2.Count())
            {
                while (iPowers > editor.main.characterCurrent.PowerList[iList].Item2.Count())
                {
                    Powers tempPower = new Powers();
                    editor.main.characterCurrent.PowerList[iList].Item2.Add(tempPower);
                    iPowers--;
                }
            }
            else if (iPowers < editor.main.characterCurrent.PowerList[iList].Item2.Count())
            {
                while (iPowers > editor.main.characterCurrent.PowerList[iList].Item2.Count())
                {
                    Powers tempPower = new Powers();
                    editor.main.characterCurrent.PowerList[iList].Item2.RemoveAt(editor.main.characterCurrent.PowerList[iList].Item2.IndexOf(tempPower));
                    iPowers++;
                }
            }
            iList++;
            return iList;
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

