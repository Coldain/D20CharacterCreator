﻿using DnD4e.CharacterBuilder.Editor.ViewModels;
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
    /// Interaction logic for CSDetails.xaml
    /// </summary>
    public partial class CSDetails : Page
    {
        public CSDetails(MainController main)
        {
            InitializeComponent();
            // labelSheet.Content = "Sheet 3 out of " + pageTotal;
        }
    }
}
