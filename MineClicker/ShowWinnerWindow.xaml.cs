﻿using MineClicker.CurrentGameServiceReference;
using MineClicker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WCFServices;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para WaitingGameWindow.xaml
    /// </summary>
    public partial class ShowWinnerWindow : Window {

        public ShowWinnerWindow(string  winnerUsername) {
            InitializeComponent();
            WinnerName.Content= winnerUsername;
        }

    }
   
}
