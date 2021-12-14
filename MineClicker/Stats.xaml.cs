using MineClicker.AccountServiceReference;
using MineClicker.Helpers;
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
using System.Windows.Shapes;
using WCFServices.Models;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para EstadisticasJugador.xaml
    /// </summary>
    public partial class Stats : Window {
        public ObservableCollection<GlobalUserStats> GlobalUserStatsList {
            get; set;
        } = new ObservableCollection<GlobalUserStats>();
        public ObservableCollection<FriendUserStats> FriendsUserStatsList {
            get; set;
        } = new ObservableCollection<FriendUserStats>();
        public Stats() {
            InitializeComponent();
            DataContext = this;
            LoadGlobalUserStats();
            LoadPersonalUserStats();
            LoadFriendUserStats();
        }
        public void LoadGlobalUserStats() {
            var result = PlayerHelper.GetGlobalUserStats();
            foreach(var r in result) {
                GlobalUserStatsList.Add(r);
            }
        }
        public void LoadFriendUserStats() {
            var result = PlayerHelper.GetFriendsUserStats();
            foreach (var r in result) {
                FriendsUserStatsList.Add(r);
            }
        }
        public void LoadPersonalUserStats() {
            var result = PlayerHelper.GetPersonalUserStats();
            StatsPanel.Children.Add(new TextBlock {
                Text = "Total Money: " + result.Money
            });
            StatsPanel.Children.Add(new TextBlock {
                Text = "Destroyed blocks: " + result.DestroyedBlocks
            }); ;
            foreach (var material in result.MaterialsDestroyed) {
                StatsPanel.Children.Add(new TextBlock {
                    Text = material.Key + ": " + material.Value
                }); 
            }
        }

        private void BackBtn(object sender, RoutedEventArgs e) {
            MainWindow goMainWindow = new MainWindow();
            this.Close();
            goMainWindow.ShowDialog();

        }
    }
}
