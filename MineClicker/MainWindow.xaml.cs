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
using System.Media;
using MineClicker.Objetos;
using System.IO;
using MineClicker.Helpers;
using WCFServices.Models;
using MineClicker.ChatServiceReference;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para InicioJuego.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        private Player[] friends; 
        


        public string UserName { get; set; }
        public string UserPassword { get; set; }
        private ChatServiceClient client;
        private int CurrentChatPlayerID;
        public MainWindow() {
            InitializeComponent();
            InstanceContext instance = new InstanceContext(new ChatServiceCallback(this));
            client = new ChatServiceClient(instance);
            client.Connect(Session.Player.PlayerId);
            LoadFriends();
        }
        public void LoadFriends() {
            friends = PlayerHelper.GetFriends();
            FriendsList.Children.Clear();
            foreach (var friend in friends) {
                var friendText = new TextBlock {
                    Text = friend.Username,
                    Foreground = Brushes.White,
                    FontSize = 18,
                    Padding = new Thickness(10),
                    Cursor = Cursors.Hand
                };
                friendText.PreviewMouseLeftButtonDown += (sender, e) => {
                    foreach(TextBlock friendTextBlock in FriendsList.Children) {
                        friendTextBlock.Background = Brushes.Transparent;
                    }
                    CurrentChatPlayerID = friend.PlayerId;
                    OpenCurrentFriendChat();
                    friendText.Background = Brushes.Black;
                };
                FriendsList.Children.Add(friendText);
            }
        }
        public void OpenCurrentFriendChat() {
            MessagesStackPanel.Children.Clear();
            if (! Session.chats.ContainsKey(CurrentChatPlayerID)) {
                return;
            }
            var friendChat = Session.chats[CurrentChatPlayerID];
            var friend = friends.Where(x => x.PlayerId == CurrentChatPlayerID).FirstOrDefault();
            foreach(var chatMessage in friendChat) {
                var usernameMessage = chatMessage.Key == CurrentChatPlayerID ? friend.Username : Session.Player.Username;
                MessagesStackPanel.Children.Add(new TextBlock {
                    Text = usernameMessage + ": " + chatMessage.Value
                });
            }
        }

        private void ChatBtn(object sender, RoutedEventArgs e) {
            AddFriendWindow requestWindow = new AddFriendWindow(client);
            this.Close();
            requestWindow.ShowDialog();
        }

        private void StoreBtn(object sender, RoutedEventArgs e) {
            Store storeWindow = new Store();
            this.Close();
            storeWindow.CajaDeTextoApodo.Text = UserName;
            storeWindow.ShowDialog();
        }

        private void ConfigBtn(object sender, RoutedEventArgs e) {
            GameConfiguration configurationWindow = new GameConfiguration();
            this.Close();

            configurationWindow.ShowDialog();
        }

        private void ChangeRightBtn(object sender, RoutedEventArgs e) {

        }

        private void ChangeLeftBtn(object sender, RoutedEventArgs e) {

        }

        private void StatsBtn(object sender, RoutedEventArgs e) {
            Stats statsWindow = new Stats();
            this.Close();
            statsWindow.ShowDialog();
        }

        private void MultiplayerBtn(object sender, RoutedEventArgs e) {
            WaitingGameWindow waitingGameWindow = new WaitingGameWindow();
            this.Close();
            waitingGameWindow.ShowDialog();
        }

        private void SendInvitationBtn(object sender, RoutedEventArgs e) {
            SendInvitation invitationWindow = new SendInvitation();
            this.Close();
            invitationWindow.ShowDialog();
        }

        private void BotonChatGeneral(object sender, RoutedEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(MessageTextBox.Text)) {
                return;
            }
            try {
                client.SendMessage(Session.Player.PlayerId, CurrentChatPlayerID, MessageTextBox.Text);
                ChatHelper.AddMessage(CurrentChatPlayerID, Session.Player.PlayerId, MessageTextBox.Text);
                OpenCurrentFriendChat();
            } catch (FaultException) {
                MessageBox.Show(Properties.Resources.OfflineFriendMessage);
            }
            MessageTextBox.Text = "";
        }
    }
    public class ChatServiceCallback : ChatCallbackHandler {
        private MainWindow window;
        public ChatServiceCallback(MainWindow window) {
            this.window = window;
        }
        public override void ReceiveFriendRequest(int friendRequestID, string senderUsername) {
            var response = MessageBox.Show(senderUsername + " Quiere ser tu amigo", "FriendRequest", MessageBoxButton.YesNo);
            if(response == MessageBoxResult.Yes) {
                PlayerHelper.AttendFriendRequest(friendRequestID, true);
                window.LoadFriends();
            } else {
                PlayerHelper.AttendFriendRequest(friendRequestID, false);
            }
        }

        public override void ReceiveMessage(int senderID, string message) {
            ChatHelper.AddMessage(senderID, senderID, message);
            window.OpenCurrentFriendChat();
        }
    }
}
