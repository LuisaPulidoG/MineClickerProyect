using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using Chat_WCF;
using System.Collections.Generic;


namespace MineClicker
{
    /// <summary>
    /// Lógica de interacción para Chat_window.xaml
    /// </summary>
    public partial class Chat_window : Window
    {
        public Chat_window()
        {

            InitializeComponent();
            actualizartableContacts();
        }
        public IChatService remoteProxy;
        public ChannelFactory<IChatService> remoteFactory;
        public ChatUser clientuser;

        private void Escribir_Chat(object sender, TextChangedEventArgs e)
        {

        }
        private void actualizartableContacts()
        {
                List<ChatUser> userContects = new List<ChatUser>();
                if (userContects.Count > 0)
                {
                    ListContactsView.Items.Add("");
                }
                else
                {
                    ListContactsView.Items.Add("Carlos");
                }
        }



        private void Enviar_Button(object sender, RoutedEventArgs e)
        {

            TextBoxMensaje.Text = "";
            TextBoxListaMensajes.Text= TextBoxMensaje.Text;
            TextBoxListaMensajes.Text = "\n";

        }

        private void Buscar_buttom(object sender, RoutedEventArgs e)
        {

        }

        private void Chat_Global(object sender, RoutedEventArgs e)
        {

        }

        private void RegresarJuego_Click(object sender, RoutedEventArgs e)
        {

            InicioJuego newinicioJuego = new InicioJuego();
            newinicioJuego.Username = NameUser.Text;
            this.Close();
            newinicioJuego.ShowDialog();
        }
    }
}
