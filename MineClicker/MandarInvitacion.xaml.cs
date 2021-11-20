using MineClicker.EmailSender;
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
using MineClicker.Validadores;

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
            EmailSenderSMTP emailSender = new EmailSenderSMTP();
            ValidadorEntrada tbValidator = new ValidadorEntrada();

            string nombre = this.CajaNombre.Text;
            string correo = this.CajaEmail.Text;

            if (tbValidator.EmailStructureValidator(correo))
            {
                if (tbValidator.CompleteTextbox(nombre))
                {
                    emailSender.SendEmail(nombre, correo);
                    MessageBox.Show("La invitación se ha enviado correctamente\n Puedes revisar la bandeja de entrada si no encuentras el correo", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("El campo del nombre no puede estar vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.CajaEmail.BorderBrush = Brushes.Black;
                    this.CajaNombre.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                MessageBox.Show("El campo del correo electrónico es inválido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.CajaEmail.BorderBrush = Brushes.Red;
                this.CajaNombre.BorderBrush = Brushes.Black;
            }

        }
    }
}
