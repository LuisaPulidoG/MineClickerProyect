using MineClicker.ChatServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClicker.Helpers {
    public class ChatHelper {
        public static void AddMessage(int playerID, int senderID, string message) {

            if (! Session.chats.ContainsKey(playerID)) {
                Session.chats.Add(playerID, new Dictionary<int, string>());
            }
            Session.chats[playerID].Add(senderID, message);
            
        }
    }
}
