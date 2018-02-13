using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.CharacterSheet;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.Assets.Scripts.Views.Misc;
using DnD4e.CharacterBuilder.Editor.View.Class;
using DnD4e.CharacterBuilder.Editor.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using DnD4e.Assets.Scripts.Controller.Data;
using RestSharp;

namespace DnD4e.Assets.Scripts.Views.Home
{
    public partial class HomePage : Window
    {
        public PopUp popUp = new PopUp();
        public MainController main = new MainController();
        bool mouseBusy;

        public HomePage()
        {
            InitializeComponent();
        }

        public void buttonCustom_Click(object sender, RoutedEventArgs e)
        {
            CustomCharacter customPopUp = new CustomCharacter(main);
            popUp.Owner = this;
            popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;            
            customPopUp.home = this;
            popUp.frameContainer.Content = customPopUp;
            SelectionDetailsRole details = new SelectionDetailsRole(main.listDefinitions[1].Pick, main.listDefinitions[1].Description);
            popUp.framedetails.Content = details;
            popUp.ShowDialog();
        }

        public void buttonSimple_Click(object sender, RoutedEventArgs e)
        {
            string endPoint = @"http://localhost:5984/_all_dbs";
            var client = new RestClient(endPoint);
            MyDB myDB = new MyDB();

            //MessageBox.Show("Comming...");
        }
        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadCharacter loadPopUp = new LoadCharacter(main);
            popUp.Owner = this;
            popUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            loadPopUp.home = this;
            popUp.frameContainer.Content = loadPopUp;
            //SelectionDetailsRole details = new SelectionDetailsRole(main.listDefinitions[1].Pick, main.listDefinitions[1].Description);
            //popUp.framedetails.Content = details;
            popUp.ShowDialog();
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
            mouseBusy = true;
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
            mouseBusy = false;
        }

        private void ButtonOption(Canvas canvas)
        {
            switch (canvas.Name)
            {
                case "buttonSimple":
                    buttonSimple_Click(this, null);
                    break;
                case "buttonCustom":
                    buttonCustom_Click(this, null);
                    break;
                case "buttonLoad":
                    buttonLoad_Click(this, null);
                    break;
                case "button1":
                    button1_Click(this, null);
                    break;
                case "button2":
                    button2_Click(this, null);
                    break;
                case "button3":
                    button3_Click(this, null);
                    break;
                case "button4":
                    button4_Click(this, null);
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && !mouseBusy && e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }



        public void button1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Comming...");
            PowerCard power = new PowerCard(main, main.listPowers[0]);
            popUp.frameContainer.Content = power;
            popUp.ShowDialog();
        }

        public void button2_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Comming...");
            PowerCard power = new PowerCard(main, main.listPowers[1]);
            popUp.frameContainer.Content = power;
            popUp.ShowDialog();
        }

        public void button3_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Comming...");
            PowerCard power = new PowerCard(main, main.listPowers[2]);
            popUp.frameContainer.Content = power;
            popUp.ShowDialog();
        }
        public void button4_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Comming...");
            PowerCard power = new PowerCard(main, main.listPowers[3]);
            popUp.frameContainer.Content = power;
            popUp.ShowDialog();
        }
    }
}
