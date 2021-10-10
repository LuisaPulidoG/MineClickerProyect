using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_WCF
{
    public class ChatEngine
    {
        private List<ChatUser> connectedUsers = new List<ChatUser>();

        private Dictionary<string, List<ChatMenssage>> incomingMessenge = new Dictionary<string, List<ChatMenssage>>();

   
        public List<ChatUser> ConnectedUsers { get => connectedUsers; set => connectedUsers = value; }

        public ChatUser AddNewChatUser(ChatUser newUser)
        {
            var exists =
                from ChatUser existe in this.ConnectedUsers
                where existe.UserName == newUser.UserName
                select existe;

            if (exists.Count() == 0)
            {
                this.ConnectedUsers.Add(newUser);
                incomingMessenge.Add(newUser.UserName, new List<ChatMenssage>()
                    {
                        new ChatMenssage() { UserChat = newUser, Date = DateTime.Now,Menssage = "Bienvenicdo al WPF chat" }
                    });

                Console.WriteLine("\nNew user connected:" + newUser.UserName);
                return newUser;
            }
            else
            {
                return null;
            }


        }

        public void AddNewMessage(ChatMenssage newMessage)
        {
            Console.Write(newMessage.UserChat.UserName + " Say :" + newMessage.Menssage + " at " + newMessage.Date);

            foreach (var user in this.ConnectedUsers)
            {
                if (!newMessage.UserChat.UserName.Equals(user.UserName))
                {
                    incomingMessenge[user.UserName].Add(newMessage);
                }
            }
        }

        public List<ChatMenssage> GetNewMessages(ChatUser user)
        {
            List<ChatMenssage> myNewMessage = incomingMessenge[user.UserName];
            incomingMessenge[user.UserName] = new List<ChatMenssage>();

            if (myNewMessage.Count > 0)
                return myNewMessage;
            else
                return null;

        }

        public void RemoveUser(ChatUser user)
        {
            this.connectedUsers.RemoveAll(useraux => useraux.UserName == user.UserName);

        }
    }
}
