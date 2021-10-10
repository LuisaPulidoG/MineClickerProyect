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
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using Chat_WCF;
namespace MineClicker
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Inicio_sesion : Window
    {
        public Inicio_sesion()
        {
            
            InitializeComponent();
            
        }
        private ChannelFactory<IChatService> remoteFactory;
        public IChatService remoteProxy;
        private ChatUser clientUser;
        private bool isConnected = false;
        public string Username { get; set; }
        public string Userpassword { get; set; }

        public char PasswordChar { get; set; }

        private void Cancel_buttom(object sender, RoutedEventArgs e)
        {
            this.Username = String.Empty;
            this.Userpassword = String.Empty;
            this.Close();
        }
        private void Login_buttom(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(nickname.Text))
            {
                this.Username = nickname.Text;
                this.Userpassword = password.Text;

                Chat_window chatwindowcreate = new Chat_window();
                chatwindowcreate.statuslabel.Text = "conected";
                chatwindowcreate.NameUser.Text=Username;

                remoteFactory = new ChannelFactory<IChatService>("ChatConfig");
                remoteProxy = remoteFactory.CreateChannel();
                clientUser = remoteProxy.ClientConnect(Username, Userpassword);

                if (clientUser != null)
                {
                    //usersTimer.Enabled = true;
                    //messagesTimer.Enabled = true;
                    isConnected = true;
                }
                this.Close();
                chatwindowcreate.ShowDialog();

                //
                
            }
            else
            {
                MessageBox.Show("Error campo vacio", "Error validacion",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


    }
}
