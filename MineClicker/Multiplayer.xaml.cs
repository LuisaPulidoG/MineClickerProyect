using MineClicker.CurrentGameServiceReference;
using MineClicker.Helpers;
using MineClicker.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window {
        private List<WCFServices.Models.Block> blocks = new List<WCFServices.Models.Block>();
        private List<WCFServices.Models.Block> destroyedBlocks = new List<WCFServices.Models.Block>();
        private WCFServices.Models.Block selectedBlock;
        private int countClicks = 0;
        private double money = 0;
        private int remainingTime = 30;
        private CurrentGameServiceClient client;
        private string guid;

        public Multiplayer(string guid) {
            InitializeComponent();
            InstanceContext instance = new InstanceContext(new CurrentGameMultiplayerCallback(this));
            client = new CurrentGameServiceClient(instance);
            this.guid = guid;
            //client. (Session.Player.PlayerId);
            blocks = BlockHelper.GetBlocks().ToList();
            SetBlock();
            TimerHandler();

        }
        private void SetBlock() {
            Dictionary<int, int> probabilities = new Dictionary<int, int>();
            Random random = new Random();
            for(int i = 0; i<100; i++) {
                var chance = random.Next(1,11);
                if (probabilities.ContainsKey(chance)) {
                    probabilities[chance]++;
                } else {
                    probabilities.Add(chance, 1);
                } 
            }
            int selectedRarity = probabilities.Aggregate((max, current) => {
                if (current.Value > max.Value) {
                    return current;
                }
                return max;
            }).Key;
             selectedBlock = blocks.FirstOrDefault(x => x.Rarity == selectedRarity);
            var blockImage = BlockHelper.BlockImages.FirstOrDefault(x => x.Key == selectedBlock.BlockID).Value;
            BlockImage.Source = BlockHelper.ConvertToImage(blockImage);
        }
        private void BreakBlockBtn(object sender, RoutedEventArgs e) {
            countClicks++;
            if (countClicks >= selectedBlock.Hardness) {
                countClicks = 0;
                destroyedBlocks.Add(selectedBlock);
                money = money + selectedBlock.Value;
                EarnedMoney.Text = money.ToString();
                SetBlock();
                DestroyedBlocks.Text = destroyedBlocks.Count().ToString();
            }
            Clicks.Text = countClicks.ToString();
        }
        private void TimerHandler() {
            Task.Run(() => {
                while (remainingTime > 0) {
                    remainingTime--;
                    Application.Current.Dispatcher.Invoke(delegate {
                        Timer.Text = remainingTime.ToString();
                    });
                    Thread.Sleep(1000);
                }
                client.SendDestroyedBlocks(destroyedBlocks.ToArray(),guid,Session.Player.PlayerId);
            });
        }

         
    }
    public class CurrentGameMultiplayerCallback : CurrentGameCallbackHandler {
        private Multiplayer multiplayerWindow;
        public CurrentGameMultiplayerCallback(Multiplayer multiplayerWindow) {
            this.multiplayerWindow = multiplayerWindow;
        }

        public override void EndGame(string playerWinnerUsername) {
            Application.Current.Dispatcher.Invoke(delegate {
                ShowWinnerWindow winnerWindow = new ShowWinnerWindow(playerWinnerUsername);
                multiplayerWindow.Close();
                winnerWindow.ShowDialog();
            });
            
        }

        public override void StartGameCallback(string gameGUID) { 
            throw new NotImplementedException();
        }

    }
}
