using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices {
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IChatService" en el código y en el archivo de configuración a la vez.
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatService {
        [OperationContract(IsOneWay = true)]
        void Connect(int playerID);
        [OperationContract(IsOneWay = true)]
        void SendMessage(int senderID, int receiverID, string message);
        [OperationContract(IsOneWay = true)]
        void SendFriendRequest(int senderID, string username);
    }

    public interface IChatServiceCallback {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(int senderID, string message);
        [OperationContract(IsOneWay = true)]
        void ReceiveFriendRequest(int friendRequestID, string senderUsername);
    }
}
