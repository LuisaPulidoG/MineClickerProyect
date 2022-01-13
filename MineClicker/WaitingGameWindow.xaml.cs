using MineClicker.CurrentGameServiceReference;
using MineClicker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WCFServices;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para WaitingGameWindow.xaml
    /// </summary>
    public partial class WaitingGameWindow : Window {
        private CurrentGameServiceClient client;

        public WaitingGameWindow() {
            InitializeComponent();
            InstanceContext instance = new InstanceContext(new CurrentGameCallback(this));
            client = new CurrentGameServiceClient(instance);
            client.SetPlayerInWaitingQueue(Session.Player.PlayerId);
        }

    }
    public class CurrentGameCallback : CurrentGameCallbackHandler {
        private WaitingGameWindow waitingGame;
        public CurrentGameCallback(WaitingGameWindow waitingGame) {
            this.waitingGame = waitingGame;
        }

        public override void EndGame(string playerWinnerUsername) {
            throw new NotImplementedException();
        }

        public override void StartGameCallback(string gameGUID) {
            Multiplayer multiplayerGameWindow = new Multiplayer(gameGUID);
            waitingGame.Close();
            multiplayerGameWindow.ShowDialog();
        }

    }
}
