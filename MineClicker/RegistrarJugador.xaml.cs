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

namespace MineClicker
{
    /// <summary>
    /// Lógica de interacción para Register_window.xaml
    /// </summary>
    public partial class RegistrarJugador : Window
    {
        public RegistrarJugador()
        {

            InitializeComponent();
        }
        private void Accept_Buttom(object sender, RoutedEventArgs e)
        {
            IniciarSesion window = new IniciarSesion();

            window.Show();
            window.Close();
        }
    }
}
