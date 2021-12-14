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

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para MandarInvitacion.xaml
    /// </summary>
    public partial class SendInvitation : Window {
        public SendInvitation() {
            InitializeComponent();
        }

        private void BackBtn(object sender, RoutedEventArgs e) {
            MainWindow goMainWindow = new MainWindow();
            this.Close();
            goMainWindow.ShowDialog();
        }

        private void SendMailInvitationBtn(object sender, RoutedEventArgs e) {
            EmailSenderSMTP emailSender = new EmailSenderSMTP();
            ValidadorEntrada tbValidator = new ValidadorEntrada();

            string name = this.NameBox.Text;
            string email = this.EmailBox.Text;

            if (tbValidator.EmailStructureValidator(email)) {
                if (tbValidator.CompleteTextbox(name)) {
                    emailSender.SendEmail(name, email);
                    MessageBox.Show("La invitación se ha enviado correctamente\n Puedes revisar la bandeja de spam si no encuentras el correo", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                } else {
                    MessageBox.Show("El campo del nombre no puede estar vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.EmailBox.BorderBrush = Brushes.Black;
                    this.NameBox.BorderBrush = Brushes.Red;
                }
            } else {
                MessageBox.Show("El campo del correo electrónico es inválido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.EmailBox.BorderBrush = Brushes.Red;
                this.NameBox.BorderBrush = Brushes.Black;
            }

        }
    }
}
