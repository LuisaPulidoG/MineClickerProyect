using DatosClicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CurrentGameService" en el código y en el archivo de configuración a la vez.
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class CurrentGameService : ICurrentGameService {
        private List<int> waitingQueue = new List<int>();
        private Dictionary<int, ICurrentGameServiceCallback> clients = new Dictionary<int, ICurrentGameServiceCallback>();
        private Dictionary<string, Dictionary<int, ICurrentGameServiceCallback>> currentGames = new Dictionary<string, Dictionary<int, ICurrentGameServiceCallback>>();
        private Dictionary<string, Dictionary<int, List <Models.Block>>> finishedGames = new Dictionary<string, Dictionary<int, List<Models.Block>>>();
        
        public void SetPlayerInWaitingQueue(int playerID) {
            if (waitingQueue.Count == 0) {
                waitingQueue.Add(playerID);
                clients.Add(playerID, OperationContext.Current.GetCallbackChannel<ICurrentGameServiceCallback>());
            } else {
                clients.Add(playerID, OperationContext.Current.GetCallbackChannel<ICurrentGameServiceCallback>());
                int playerID2 = waitingQueue.First();
                waitingQueue.RemoveAt(0);
                string result = CreateGame(playerID, playerID2, 1);
            }
        }
        public string CreateGame(int playerID1, int playerID2, int type) {
            string id = Guid.NewGuid().ToString();
            currentGames.Add(id, new Dictionary<int, ICurrentGameServiceCallback>() {
                { playerID1, clients[playerID1] },
                { playerID2, clients[playerID2] }
            });
            clients[playerID1].StartGameCallback(id);
            clients[playerID2].StartGameCallback(id);
            return id;
        }
        public void SendDestroyedBlocks(List<Models.Block> destroyedBlocks, string guid, int playerID) {
            var game = currentGames.FirstOrDefault(x => x.Key == guid);
            if (finishedGames.ContainsKey(guid)) {
                finishedGames[guid].Add(playerID, destroyedBlocks);
            } else { 
                finishedGames.Add(guid, new Dictionary<int, List<Models.Block>>() {
                    {playerID, destroyedBlocks }
                });
            }
            currentGames[guid][playerID] = OperationContext.Current.GetCallbackChannel<ICurrentGameServiceCallback>();
            if (finishedGames[guid].Count == currentGames[guid].Count) {
                RegisterGame(guid);
            }
        }
        private void RegisterGame(string guid) {
            using (MineClickerEntities db = new MineClickerEntities()) {
                Game newGame = new Game {
                    CreationDate = DateTime.Now
                };
                var gamePlayers = finishedGames[guid];
                var playerWinnerID = 0;
                var highestDestroyedBlocks = 0;
                var currentDestroyedBlocks = 0;
                foreach (var player in gamePlayers) {
                    var playerGaming = new PlayerGame() {
                        Game = newGame,
                        PlayerId = player.Key
                    };
                    List<PlayerGameBlock> playerGameBlocks = new List<PlayerGameBlock>();
                    foreach(var block in player.Value) {
                        var playerGameBlock = playerGameBlocks.FirstOrDefault(x => x.BlockId == block.BlockID);
                        if(playerGameBlock == null) {
                            playerGameBlocks.Add(new PlayerGameBlock {
                                PlayerGame = playerGaming,
                                BlockId = block.BlockID,
                                Destroyed = 1
                            });
                        } else {
                            playerGameBlock.Destroyed++;
                        }
                        currentDestroyedBlocks++;
                    }
                    newGame.PlayerGame.Add(playerGaming);
                    if(currentDestroyedBlocks > highestDestroyedBlocks) {
                        playerWinnerID = player.Key;
                    }
                }
                newGame.PlayerId = playerWinnerID;
                db.Game.Add(newGame);
                db.SaveChanges();
                finishedGames.Remove(guid);
                var playerWinner = db.Player.Find(playerWinnerID);
                foreach(var player in currentGames[guid]) {
                    player.Value.EndGame(playerWinner.Username);
                }
            }
        }
    }

    
}
