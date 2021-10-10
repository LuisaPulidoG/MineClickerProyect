using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using Chat_WCF;
using System.Collections.Generic;
using System.ServiceModel;
using Chat_WCF;
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
           // actualizartable();
        }
        private ChannelFactory<IChatService> remoteFactory;
        private IChatService remoteProxy;
        private ChatUser clientUser;
        private void Escribir_Chat(object sender, TextChangedEventArgs e)
        {

        }
        /*private void actualizartable()
        //{
            List<ChatUser> listUsers = remoteProxy.GetAllUsers();
            
            foreach(ChatUser item in listUsers)
            {

                ListViewItem item1 = new ListViewItem();
                item1.SetValue(item.ToString);
            }

            
        }*/

        private void Buscar_Box(object sender, TextChangedEventArgs e)
        {

        }

        private void Enviar_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Buscar_buttom(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
