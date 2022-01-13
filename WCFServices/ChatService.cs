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

        }
        public void SendMessage(int senderID, int receiverID, string message){
        }
        public void SendFriendRequest(int senderID, int receiverID) {

        }
    }
}
