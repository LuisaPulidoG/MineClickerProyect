using DatosClicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ChatService" en el código y en el archivo de configuración a la vez.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]

    public class ChatService : IChatService {
        private Dictionary<int, IChatServiceCallback> playersConnection = new Dictionary<int, IChatServiceCallback>();

        public void Connect(int playerID) {
            if (playersConnection.ContainsKey(playerID)) {
                playersConnection.Remove(playerID);
            }
            playersConnection.Add(playerID, OperationContext.Current.GetCallbackChannel<IChatServiceCallback>());
        }
        public void SendMessage(int senderID, int receiverID, string message){
            var playerReceiver = playersConnection.Where(x => x.Key == receiverID).FirstOrDefault();
            if (playerReceiver.Value != null) {
                playerReceiver.Value.ReceiveMessage(senderID, message);
            } else {
                throw new FaultException("Your friend is offline");
            }
        }
        public void SendFriendRequest(int senderID, string username) {
            using (MineClickerEntities db = new MineClickerEntities()) {
                var friend = db.Player.Where(x => x.Username == username).FirstOrDefault();
                if(friend == null) {
                    throw new FaultException("User not found");
                }
                if (db.FriendRequest.Where(x => x.PlayerSenderID == senderID && x.PlayerReceiverID == friend.PlayerId).Count() > 0) {
                    throw new FaultException("Request already sent");
                }
                var friendRequest = new FriendRequest {
                    PlayerSenderID = senderID,
                    PlayerReceiverID = friend.PlayerId
                };
                db.FriendRequest.Add(friendRequest);
                db.SaveChanges();
                var playerSender = db.Player.Where(x => x.PlayerId == senderID).FirstOrDefault();
                var playerReceiver = playersConnection.Where(x => x.Key == friend.PlayerId).FirstOrDefault();
                if(playerReceiver.Value != null) {
                    playerReceiver.Value.ReceiveFriendRequest(friendRequest.FriendRequestID, playerSender.Username);
                }
            }

        }
    }
}
