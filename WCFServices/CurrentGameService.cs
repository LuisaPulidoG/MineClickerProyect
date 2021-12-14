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
        public void StartGame(string gameGUID) {
           
        }
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
    }

    
}
