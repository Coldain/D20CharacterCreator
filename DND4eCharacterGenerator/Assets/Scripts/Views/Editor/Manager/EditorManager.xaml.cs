using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor.Manager;
using DnD4e.CharacterBuilder.Editor.View.Class;
using DnD4e.CharacterOOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Manager
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class EditorManager : UserControl
    {
        bool deselect;
        Canvas canvasSelected;
        bool namePicked;
        bool genderPicked;
        bool alignmentPicked;
        bool heightPicked;
        bool weightPicked;
        bool agePicked;
        Grid currentGrid;
        CharacterEditor editor;
        public EditorManager(CharacterEditor _editor)
        {
            editor = _editor;
            InitializeComponent();
            this.DataContext = editor.main.characterCurrent;
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


        private void buttonSaveAs_Click()
        {
            
        }

        private void buttonSave_Click()
        {            
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            //string savePathTXT = folderBrowserDialog.SelectedPath + "\\" + editor.main.characterCurrent.Name + "_" + editor.main.characterCurrent.Player + ".txt";
            string savePathJSON = folderBrowserDialog.SelectedPath + "\\" + editor.main.characterCurrent.Name + "_" + editor.main.characterCurrent.Player + ".json";
            JSONCharacter buffer = editor.main.characterCurrent.SaveCharacter();
            
            //System.IO.FileStream fsTXT = new System.IO.FileStream(savePathTXT, System.IO.FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JSONCharacter));
            //ser.WriteObject(fsTXT, buffer);
            //fsTXT.Close();
            System.IO.FileStream fsJSON = new System.IO.FileStream(savePathJSON, System.IO.FileMode.OpenOrCreate);
            ser.WriteObject(fsJSON, buffer);
            fsJSON.Close();



            //CharacterBuffer buffer = editor.main.characterCurrent.SaveCharacter();
            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CharacterBuffer));
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //js.WriteObject(ms, buffer);
            //ms.Position = 0;
            //System.IO.StreamReader sr = new System.IO.StreamReader(ms);
            //string savePath = @"C:\Users\Coldain\Desktop\DnD\4e\Character Creator\Saved Characters\" + editor.main.characterCurrent.Name + "_" + editor.main.characterCurrent.Player + ".text";
            //using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(savePath))
            //{
            //    outputFile.WriteLine(sr.ReadToEnd());
            //}
            //string savePath2 = @"C:\Users\Coldain\Desktop\DnD\4e\Character Creator\Saved Characters\" + editor.main.characterCurrent.Name + "_" + editor.main.characterCurrent.Player + ".json";
            //using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(savePath2))
            //{
            //    outputFile.WriteLine(sr.ReadToEnd());
            //}
            //sr.Close();
            //ms.Close();
        }

        private void buttonLevelUp_Click()
        {

        }

        private void buttonRetrain_Click()
        {

        }

        private void path_MouseEnter(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            if (tempPath == canvasRetrain)
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
            if (tempPath == canvasRetrain)
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
                case "buttonSaveAs":
                    //deselect = false;
                    //Path path = canvas.Children[2] as Path;
                    //path_MouseLeave(path, null);
                    //canvasClear.Opacity = 0.6;
                    buttonSaveAs_Click();
                    break;
                case "buttonSave":
                    buttonSave_Click();
                    break;
                case "buttonLevelUp":
                    buttonLevelUp_Click();
                    break;
                case "buttonRetrain":
                    buttonRetrain_Click();
                    break;

            }
        }        

        private void textNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var patten = @"[0-9]{4}";
            Regex regex = new Regex(patten);
            e.Handled = !regex.IsMatch(e.Text);
        }          

        private void textboxAge_PreviewDragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
