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
namespace MineClicker
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class IniciarSesion : Window
    {

        public IniciarSesion()
        {

            InitializeComponent();
        
            
        }

        public string NombreUsuario { get; set; }
        public string ContraseniaUsuario { get; set; }



        private void BotonCancelar(object sender, RoutedEventArgs e)
        {
            this.NombreUsuario = String.Empty;
            this.ContraseniaUsuario = String.Empty;
            this.Close();
              
        }
  
        private void BotonIngresar(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CajatxNombreUsuario.Text) && !String.IsNullOrEmpty(CajaContrasenia.Password))
            {
                this.NombreUsuario = CajatxNombreUsuario.Text;
                this.ContraseniaUsuario = CajaContrasenia.Password;
                PantallaPrincipal IniciarPantallaPrincipal = new PantallaPrincipal();
                IniciarPantallaPrincipal.NombreUsuario = CajatxNombreUsuario.Text;
                IniciarPantallaPrincipal.ContraseniaUsuario = CajaContrasenia.Password;
                this.Close();
                IniciarPantallaPrincipal.ShowDialog();
                

                
            }
            else
            {
                MessageBox.Show("Error campo vacio", "Error validacion",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


    }
}
