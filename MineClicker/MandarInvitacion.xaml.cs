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

namespace MineClicker
{
    /// <summary>
    /// Lógica de interacción para MandarInvitacion.xaml
    /// </summary>
    public partial class MandarInvitacion : Window
    {
        public MandarInvitacion()
        {
            InitializeComponent();
        }

        private void BotonSalirInvitacion(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal IniciarPantallaPrincipal = new PantallaPrincipal();
            this.Close();
            IniciarPantallaPrincipal.ShowDialog();
        }

        private void BtnSendMailInvitation(object sender, RoutedEventArgs e)
        {

        }
    }
}
