using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.CharacterBuilder.Editor.View.Class;
using DnD4e.CharacterBuilder.Editor.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Json;
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
    /// <summary>
    /// Interaction logic for LoadCharacter.xaml
    /// </summary>
    public partial class LoadCharacter : UserControl
    {
        MainController main;
        bool deselect = false;
        Canvas canvasSelected;
        TreeViewItem tvi;
        TreeViewItem tvi2;
        Campaigns myCampaign = new Campaigns();
        public HomePage home;

        public LoadCharacter(MainController _main)
        {
            main = _main;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            home.popUp.Hide();
        }

        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            System.IO.FileStream fs = new System.IO.FileStream(main.characterPath, System.IO.FileMode.Open);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JSONConverter));
            JSONConverter j = (JSONConverter)ser.ReadObject(fs);
            fs.Close();
            main.characterCurrent = new CharacterOOP.Character(j);
            CharacterEditor editorWindow = new CharacterEditor(main);
            editorWindow.Show();
            home.Close();
            home.popUp.Close();
            //string savePath = @"C:\Users\Coldain\Desktop\DnD\4e\Character Creator\Saved Characters\Nadarr_.text";
            //System.IO.StreamReader sr = System.IO.File.OpenText(savePath);


            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(JSONConverter));
            //JSONConverter JConvert = js.ReadObject(sr);
            //sr.Close();
            //JsonSerializer.DeserializeFromString<JSONConverter>(JConvert);

            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(JSONConverter));
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //ms.Position = 0;
            //System.IO.StreamReader sr = new System.IO.StreamReader(ms);
            //string savePath = @"C:\Users\Coldain\Desktop\DnD\4e\Character Creator\Saved Characters\Nadarr_.text";
            //using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(savePath))
            //{
            //    JSONConverter JConvert = (JSONConverter)js.ReadObject(ms);
            //    main.characterCurrent = new CharacterOOP.Character(JConvert);
            //}        
            //sr.Close();
            //ms.Close();
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

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            main.characterPath = openFileDialog.FileName;
            main.characterPath = main.characterPath.Replace(@"\\", @"\");
            List<string> tempList = main.characterPath.Split('\\').ToList();
            CharacterName.Text = tempList[tempList.Count()-1];
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
            if (myCampaign != null)
            {
                SelectionDetailsRole details = new SelectionDetailsRole(myCampaign.Setting, myCampaign.Shortdescription);
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
                case "buttonSelect":
                    buttonSelect_Click(this, null);
                    break;
                case "buttonContinue":
                    buttonContinue_Click(this, null);
                    break;
            }
        }
    }

}
