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
using System.Windows.Shapes;
using System.ServiceModel;
using MineClicker.Helpers;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class LogIn : Window {

        public LogIn() {

            InitializeComponent();
        }

        public string username { get; set; }
        public string password { get; set; }



        private void BotonCancelar(object sender, RoutedEventArgs e) {
            this.username = String.Empty;
            this.password = String.Empty;
            this.Close();

        }

        private void LogInBtn(object sender, RoutedEventArgs e) {
            if (!String.IsNullOrEmpty(CajatxNombreUsuario.Text) && !String.IsNullOrEmpty(CajaContrasenia.Password)) {
                this.username = CajatxNombreUsuario.Text;
                this.password = CajaContrasenia.Password;
                try {
                    var player = PlayerHelper.LogIn(username, password);
                    Session.Player = player;
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return;
                }

                MainWindow IniciarPantallaPrincipal = new MainWindow();
                IniciarPantallaPrincipal.UserName = CajatxNombreUsuario.Text;
                IniciarPantallaPrincipal.UserPassword = CajaContrasenia.Password;
                this.Close();
                IniciarPantallaPrincipal.ShowDialog();



            } else {
                MessageBox.Show("Error campo vacio", "Error validacion",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BotonRegistrarJugador(object sender, RoutedEventArgs e) {
            PlayerRegister newinicioJuego = new PlayerRegister();
            this.Close();
            newinicioJuego.ShowDialog();

        }
    }
}
