using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClicker.Helpers {
    public abstract class ChatCallbackHandler : ChatServiceReference.IChatServiceCallback {
        public abstract void ReceiveFriendRequest(int friendRequestID, string senderUsername);
        public abstract void ReceiveMessage(int senderID, string message);
    }
}
