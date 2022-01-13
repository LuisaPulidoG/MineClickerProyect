using MineClicker.Helpers;
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

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para Register_window.xaml
    /// </summary>
    public partial class PlayerRegister : Window {
        public PlayerRegister() {

            InitializeComponent();
        }
        private void AcceptButton(object sender, RoutedEventArgs e) {
            try {
                WCFServices.Models.Player newPlayer = new WCFServices.Models.Player {
                    Username = Username.Text,
                    Name = Name.Text,
                    Email = Email.Text,
                    Password = Password.Text
                };
                PlayerHelper.PlayerRegister(newPlayer);
                MessageBox.Show(Properties.Resources.RegisterMessage);
                LogIn window = new LogIn();

                window.Show();
                Close();
            } catch (Exception) {
                MessageBox.Show(Properties.Resources.RegisterFailMessage);
            }
        }
        private void CancelButton(object sender, RoutedEventArgs e) {
            LogIn goLogIn = new LogIn();
            this.Close();
            goLogIn.ShowDialog();

        }
    }
}
