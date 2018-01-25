using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.Assets.Scripts.Views.Editor.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DnD4e.CharacterBuilder.Editor.View.Class
{
    public partial class EditorClass2 : UserControl
    {
        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Classes myclass = new Classes();
        CharacterEditor editor;
        List<Classes> firstlist;
        List<Classes> secondlist;
        List<Classes> thirdlist;
        List<Classes> fourthlist;
        List<Classes> fifthlist;
        public List<TreeViewItem> Headers;
        TreeViewItem item;
        bool expand;


        public EditorClass2(List<Classes> _firstlist, List<Classes> _secondlist, List<Classes> _thirdlist, List<Classes> _fourthlist, CharacterEditor _editor)
        {
            editor = _editor;
            firstlist = _firstlist;
            secondlist = _secondlist;
            thirdlist = _thirdlist;
            fourthlist = _fourthlist;
            InitializeComponent();
            List<Selections> choices = new List<Selections>();
            Selections first = new Selections() { Relevance = firstlist[0].PrimaryRoles };
            first.Options = new ObservableCollection<Classes>(firstlist);
            choices.Add(first);
            Selections second = new Selections() { Relevance = secondlist[0].PrimaryRoles };
            second.Options = new ObservableCollection<Classes>(secondlist);
            choices.Add(second);
            Selections third = new Selections() { Relevance = thirdlist[0].PrimaryRoles };
            third.Options = new ObservableCollection<Classes>(thirdlist);
            choices.Add(third);
            Selections fourth = new Selections() { Relevance = fourthlist[0].PrimaryRoles };
            fourth.Options = new ObservableCollection<Classes>(fourthlist);
            choices.Add(fourth);
            List<Classes> otherClasses = new List<Classes>() { _editor.main.listclassMain[_editor.main.listclassMain.Count - 1] };
            fifthlist = otherClasses;
            Selections misc = new Selections() { Relevance = "Other" };
            misc.Options = new ObservableCollection<Classes>(otherClasses);
            choices.Add(misc);
            trvFamilies.ItemsSource = choices;
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[3].Pick, editor.main.listDefinitions[3].Description);
            editor.framedetails.Content = details;
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

        private void Header_Selected(object sender, RoutedEventArgs e)
        {
            StackPanel tempStack = sender as StackPanel;
            Selections tempSelection = tempStack.DataContext as Selections;
            foreach (Roles tempRole in editor.main.listRoles)
            {
                if (tempRole.Role == tempSelection.Options[0].PrimaryRoles)
                {
                    SelectionDetailsRole details = new SelectionDetailsRole(tempRole.Pick, tempRole.Description);
                    editor.framedetails.Content = details;
                }
            }
            if (tvi != null)
                tvi.IsSelected = false;
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
            myclass = null;
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
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[3].Pick, editor.main.listDefinitions[3].Description);
            editor.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int r = rand.Next(0, editor.main.listclassMain.Count);
            myclass = editor.main.listclassMain[r];

            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += worker_DoWork;            
            //if (Headers == null)
            //    Setup();
            ////expand = false;
            ////foreach (TreeViewItem tvitem in Headers)
            ////{
            ////    item = tvitem;
            ////    worker.RunWorkerAsync();
            ////}
            //int max = firstlist.Count + secondlist.Count + thirdlist.Count + fourthlist.Count + fifthlist.Count;
            //Random rand = new Random();
            //int r = rand.Next(0, max);
            //expand = true;
            //if (r < firstlist.Count)
            //{
            //    item = Headers[0];
            //    worker.RunWorkerAsync();
            //    int i = r;
            //    RandomChoice(Headers[0], i);                
            //}
            //else if (r >= firstlist.Count && r < firstlist.Count + secondlist.Count)
            //{
            //    item = Headers[1];
            //    worker.RunWorkerAsync();
            //    int i = r - firstlist.Count;
            //    RandomChoice(Headers[1], i);
            //}
            //else if (r >= firstlist.Count + secondlist.Count && r < firstlist.Count + secondlist.Count + thirdlist.Count)
            //{
            //    item = Headers[2];
            //    worker.RunWorkerAsync();
            //    int i = r - firstlist.Count - secondlist.Count;
            //    RandomChoice(Headers[2], i);
            //}
            //else if (r >= firstlist.Count + secondlist.Count + thirdlist.Count && r < firstlist.Count + secondlist.Count + thirdlist.Count + fourthlist.Count)
            //{
            //    item = Headers[3];
            //    worker.RunWorkerAsync();
            //    int i = r - firstlist.Count - secondlist.Count - thirdlist.Count;
            //    RandomChoice(Headers[3], i);
            //}
            //else
            //{
            //    item = Headers[4];
            //    worker.RunWorkerAsync();
            //    int i = r - firstlist.Count - secondlist.Count - thirdlist.Count - fourthlist.Count;
            //    RandomChoice(Headers[4], i);
            //}

            SelectionDetailsClass details = new SelectionDetailsClass(myclass);
            editor.framedetails.Content = details;
            ChangeSelections(true);
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            editor.main.characterCurrent.Class = new Classes(myclass);
            EditorClass3 edit3 = new EditorClass3(editor, this);
            editor.frameContainer.Content = edit3;
            editor.classSelected = true;
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
            if (canvasSelected != null && canvasSelected != tempCanvas)
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
        }


        private void treeViewItem_MouseUp(object sender, MouseEventArgs e)
        {
            canvasSelected = sender as Canvas;
            Grid grid = (Grid)canvasSelected.Parent;
            TranslateTransform translation = new TranslateTransform(0, 0);
            grid.RenderTransform = translation;
            myclass = grid.DataContext as Classes;
            if (myclass != null)
            {
                SelectionDetailsClass details = new SelectionDetailsClass(myclass);
                editor.framedetails.Content = details;
                ChangeSelections(true);
            }
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

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            item.IsExpanded = expand;
            Thread.Sleep(10);
        }

        public void Setup()
        {
            Headers = new List<TreeViewItem>();
            var test0 = VisualTreeHelper.GetChild(trvFamilies, 0); // border
            var test1 = VisualTreeHelper.GetChild(test0, 0); // scrollviewer
            var test2 = VisualTreeHelper.GetChild(test1, 0); // Grid
            var test3 = VisualTreeHelper.GetChild(test2, 1); // ScrollContentPresenter
            var test4 = VisualTreeHelper.GetChild(test3, 0); // ItemPresenter
            var test5 = VisualTreeHelper.GetChild(test4, 0); // StackPanel
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(test5); i++)
            {
                TreeViewItem tvi = (TreeViewItem)VisualTreeHelper.GetChild(test5, i);
                Headers.Add(tvi);
                //tvi.IsExpanded = true;                
            }
            
        }

        public void RandomChoice(TreeViewItem header, int i)
        {
            var test0 = VisualTreeHelper.GetChild(header, 0); // Grid          
            var test1 = VisualTreeHelper.GetChild(test0, 1); // Border
            var test2 = VisualTreeHelper.GetChild(test1, 0); // ContentPresenter
            var test3 = VisualTreeHelper.GetChild(test2, 0); // StackPanel
            var test4 = VisualTreeHelper.GetChild(test3, 0); // ItemPresenter
            var test5 = VisualTreeHelper.GetChild(test4, 0); // StackPanel
            var test6 = VisualTreeHelper.GetChild(test5, i); // TreeViewItem
            var test7 = VisualTreeHelper.GetChild(test6, 0); // Grid
            var test8 = VisualTreeHelper.GetChild(test7, 1); // Border
            var test9 = VisualTreeHelper.GetChild(test8, 0); // ContentPresenter
            var test10 = VisualTreeHelper.GetChild(test9, 0); // Grid
            Canvas canvas = (Canvas)VisualTreeHelper.GetChild(test10, 5); // Canvas
            treeViewItem_MouseDown(canvas, null);
            treeViewItem_MouseUp(canvas, null);
        }
    }

    public class Selections
    {
        public Selections()
        {
            this.Options = new ObservableCollection<Classes>();
        }
        public string Relevance { get; set; }
        public ObservableCollection<Classes> Options { get; set; }
    }
}

