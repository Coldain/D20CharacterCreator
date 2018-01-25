using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.CharacterBuilder.Editor.View.Class;
using DnD4e.CharacterBuilder.Editor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Class
{
    public partial class EditorClass1 : UserControl
    {
        bool deselect = false;
        Path pathSelected;
        int option = 0;
        Roles role;
        CharacterEditor editor;

        public EditorClass1(CharacterEditor _editor)
        {
            editor = _editor;
            InitializeComponent();
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[2].Pick, editor.main.listDefinitions[2].Description);
            editor.framedetails.Content = details;
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


        private void Item_MouseEnter(object sender, MouseEventArgs e)
        {
            Path path = sender as Path;
            if (pathSelected != path)
                path.Opacity = 0;
        }

        private void Item_MouseLeave(object sender, MouseEventArgs e)
        {
            Path path = sender as Path;

            if (pathSelected != path)
                path.Opacity = 0.8;
            else
            {
                Item_MouseUp(pathSelected, null);
            }
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            editor.mouseBusy = true;
            Path tempPath = sender as Path;
            if (pathSelected != null && pathSelected != tempPath)
                buttonDeselect_Click(tempPath, null);
            pathSelected = tempPath;
            pathSelected.Fill = Brushes.Transparent;
            pathSelected.Opacity = 100;
            Canvas parent = (Canvas)pathSelected.Parent;
            Canvas grandParent = (Canvas)parent.Parent;
            Path path = (Path)parent.Children[1];
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF4CC513");
            path.Stroke = brush;
            TranslateTransform translation = new TranslateTransform(3, 3);
            grandParent.RenderTransform = translation;
            Mouse.Capture(pathSelected);            
        }


        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            pathSelected = sender as Path;
            Canvas parent = (Canvas)pathSelected.Parent;
            Canvas grandParent = (Canvas)parent.Parent;
            TranslateTransform translation = new TranslateTransform(0, 0);
            grandParent.RenderTransform = translation;
            Mouse.Capture(null);
            switch (pathSelected.Name)
            {
                case "pathController":
                    buttonSelectController_Click(this, null);
                    break;
                case "pathLeader":
                    buttonSelectLeader_Click(this, null);
                    break;
                case "pathDefender":
                    buttonSelectDefender_Click(this, null);
                    break;
                case "pathStriker":
                    buttonSelectStriker_Click(this, null);
                    break;
                case "pathAll":
                    buttonSelectAll_Click(this, null);
                    break;
            }
            editor.mouseBusy = false;
        }

        private void buttonSelectStriker_Click(object sender, RoutedEventArgs e)
        {
            option = 1;
            role = editor.main.listRoles[1];
            Selection();
        }

        private void buttonSelectDefender_Click(object sender, RoutedEventArgs e)
        {
            option = 2;
            role = editor.main.listRoles[2];
            Selection();
        }

        private void buttonSelectLeader_Click(object sender, RoutedEventArgs e)
        {
            option = 3;
            role = editor.main.listRoles[0];
            Selection();
        }

        private void buttonSelectController_Click(object sender, RoutedEventArgs e)
        {
            option = 4;
            role = editor.main.listRoles[3];
            Selection();
        }

        private void buttonSelectAll_Click(object sender, MouseButtonEventArgs e)
        {
            option = 0;
            role = editor.main.listRoles[4];
            Selection();
        }

        private void Selection()
        {
            ChangeSelections(true);
            SelectionDetailsRole details = new SelectionDetailsRole(role.Pick, role.Description);
            editor.framedetails.Content = details;
        }


        private void buttonDeselect_Click(object sender, RoutedEventArgs e)
        {
            Path tempPath = sender as Path;
            option = 0;
            editor.framedetails.Content = null;
            role = editor.main.listRoles[4];            
            ChangeSelections(false);

            if (pathSelected != null)
            {
                Canvas parent = (Canvas)pathSelected.Parent;
                Path path = (Path)parent.Children[1];
                var converter = new BrushConverter();
                path.Stroke = Brushes.Transparent;
                var brush = (Brush)converter.ConvertFromString("#FFCBC5A4");
                pathSelected.Fill = brush;
                pathSelected.Opacity = 0.8;
            }
            if (pathSelected != tempPath)
            {
                Item_MouseUp(pathSelected, null);
            }
            pathSelected = null;
            SelectionDetailsRole details = new SelectionDetailsRole(editor.main.listDefinitions[2].Pick, editor.main.listDefinitions[2].Description);
            editor.framedetails.Content = details;
        }

        private void buttonChooseForMe_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            switch (rand.Next(0, 5))
            {
                case 0:
                    Item_MouseDown(pathController, null);                    
                    Item_MouseUp(pathController, null);
                    break;
                case 1:
                    Item_MouseDown(pathLeader, null);
                    Item_MouseUp(pathLeader, null);
                    break;
                case 2:
                    Item_MouseDown(pathDefender, null);
                    Item_MouseUp(pathDefender, null);
                    break;
                case 3:
                    Item_MouseDown(pathStriker, null);
                    Item_MouseUp(pathStriker, null);
                    break;
                case 4:
                    Item_MouseDown(pathAll, null);
                    Item_MouseUp(pathAll, null);
                    break;
            }
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            List<Classes> leaderClasses = new List<Classes>();
            List<Classes> defenderClasses = new List<Classes>();
            List<Classes> controllerClasses = new List<Classes>();
            List<Classes> strikerClasses = new List<Classes>();


            for (int i = 0; i < editor.main.listclassMain.Count; i++)
            {
                switch (editor.main.listclassMain[i].PrimaryRoles)
                {
                    case "Leader":
                        leaderClasses.Add(editor.main.listclassMain[i]);
                        break;
                    case "Striker":
                        strikerClasses.Add(editor.main.listclassMain[i]);
                        break;
                    case "Defender":
                        defenderClasses.Add(editor.main.listclassMain[i]);
                        break;
                    case "Controller":
                        controllerClasses.Add(editor.main.listclassMain[i]);
                        break;
                }
            }
            EditorClass2 selectClass;
            switch (option)
            {
                case 1:
                    selectClass = new EditorClass2(strikerClasses, controllerClasses, defenderClasses, leaderClasses, editor);
                    editor.frameContainer.Content = selectClass;
                    break;
                case 2:
                    selectClass = new EditorClass2(defenderClasses, leaderClasses, strikerClasses, controllerClasses, editor);
                    editor.frameContainer.Content = selectClass;
                    break;
                case 3:
                    selectClass = new EditorClass2(leaderClasses, defenderClasses, controllerClasses, strikerClasses, editor);
                    editor.frameContainer.Content = selectClass;
                    break;
                default:
                    selectClass = new EditorClass2(controllerClasses, strikerClasses, leaderClasses, defenderClasses, editor);
                    editor.frameContainer.Content = selectClass;
                    break;
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
                    buttonDeselect_Click(path, null);
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
}