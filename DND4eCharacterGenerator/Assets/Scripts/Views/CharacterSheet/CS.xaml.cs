using DnD4e.CharacterBuilder.Editor.ViewModels;
using System;
using System.Collections.Generic;
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

namespace DnD4e.Assets.Scripts.Views.CharacterSheet
{
    /// <summary>
    /// Interaction logic for CharacterSheet.xaml
    /// </summary>
    public partial class CS : Window
    {
        PrintDialog pd = new PrintDialog();
        MainController main;
        CSMain sheetMain;
        CSFeats sheetFeats;
        CSDetails sheetsDeatils;
        CSBattleMain sheetsBattle0;
        CSBattleX sheetsBattle1;
        int pageTotal;
        int pageCurrent;
        
        public CS(MainController _main, int _pageTotal)
        {
            main = _main;
            pageTotal = _pageTotal;
            sheetMain = new CSMain(main);
            sheetFeats = new CSFeats(main);
            sheetsDeatils = new CSDetails(main);
            sheetsBattle0 = new CSBattleMain(main);
            sheetsBattle1 = new CSBattleX(main);
            InitializeComponent();
            SwitchPages(); 
        }

        private void SwitchPages()
        {
            labelPage.Content = "Sheet " + (pageCurrent + 1) + " " + "out of " + pageTotal;
            switch (pageCurrent % pageTotal)
            {
                case 0:
                    frameContainer.Content = sheetMain;
                    break;
                case 1:
                    frameContainer.Content = sheetFeats;
                    break;
                case 2:
                    frameContainer.Content = sheetsDeatils;
                    break;
                case 3:
                    frameContainer.Content = sheetsBattle0;
                    break;
                case 4:
                    frameContainer.Content = sheetsBattle1;
                    break;
            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (pageCurrent == pageTotal - 1)
                pageCurrent = 0;
            else
                pageCurrent++;
            SwitchPages();
        }

        private void buttonMain_Click(object sender, RoutedEventArgs e)
        {
            pageCurrent = 0;
            SwitchPages();
        }

        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (pageCurrent == 0)
                pageCurrent = pageTotal-1;
            else
                pageCurrent--;
            SwitchPages();
        }

        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            pd.PrintVisual((Visual)frameContainer, "This is the contents of a frame!");
            pd.PageRangeSelection = PageRangeSelection.AllPages;            
            pd.UserPageRangeEnabled = true;
            Nullable<Boolean> print = pd.ShowDialog();
            if (print == true)
            {
                MessageBox.Show("Printing...");
            }
        }

        private void buttonPrintAll_Click(object sender, RoutedEventArgs e)
        {
            pd.PrintVisual((Visual)sheetMain, "This is the contents of a page!");
            pd.PrintVisual((Visual)sheetFeats, "This is the contents of a page!");
            pd.PrintVisual((Visual)sheetsDeatils, "This is the contents of a page!");
            pd.PrintVisual((Visual)sheetsBattle0, "This is the contents of a page!");
            pd.PrintVisual((Visual)sheetsBattle1, "This is the contents of a page!");
            pd.PageRangeSelection = PageRangeSelection.AllPages;
            pd.UserPageRangeEnabled = true;
            Nullable<Boolean> print = pd.ShowDialog();
            if (print == true)
            {
                MessageBox.Show("Printing...");
            }
        }

        private void buttonEditor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

    }
}
