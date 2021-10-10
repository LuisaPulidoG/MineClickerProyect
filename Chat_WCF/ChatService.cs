using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private ChatEngine mainEngine = new ChatEngine();
        public ChatUser ClientConnect(string userName, string password)
        {
            return mainEngine.AddNewChatUser(new ChatUser() { UserName = userName, Password = password });
        }

        public List<ChatUser> GetAllUsers()
        {
            return mainEngine.ConnectedUsers;
            
        }

        public List<ChatMenssage> GetChatMenssages(ChatUser user)
        {
            return mainEngine.GetNewMessages(user);
        }

        public void RemoverUser(ChatUser user)
        {
            mainEngine.RemoveUser(user);
        }

        public void SendNewMessage(ChatMenssage newMessage)
        {
            mainEngine.AddNewMessage(newMessage);
        }
    }

}
