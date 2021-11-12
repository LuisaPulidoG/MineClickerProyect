using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface IChatService
    {
        [OperationContract]
        ChatUser ClientConnect(string userName,string password);

        [OperationContract]
        List<ChatUser> GetAllUsers();
        [OperationContract]
        List<ChatMenssage> GetChatMenssages(ChatUser user);
        [OperationContract]
        void SendNewMessage(ChatMenssage newMessage);
        [OperationContract]
        void RemoverUser(ChatUser user);

        List<ChatUser> GetAllUsercontacts(ChatUser user);

    }
    [DataContract]
    public class ChatUser
    {
        private string userName, ipAddress, hostName, password;
        private List<ChatUser> UserContacts=new List<ChatUser>();

        [DataMember]
        public string UserName { get => userName; set => userName = value; }
        [DataMember]
        public string IpAddress { get => ipAddress; set => ipAddress = value; }
        [DataMember]
        public string HostName { get => hostName; set => hostName = value; }
        [DataMember]
        public string Password { get => password; set => password = value; }
        public List<ChatUser> UserContacts1 { get => UserContacts; set => UserContacts = value; }

        public override string ToString()
        {
            return this.userName;
        }
    }
    public class ChatMenssage
    {
        private ChatUser userChat;
        private string menssage;
        private DateTime date;

        [DataMember]
        public ChatUser UserChat { get => userChat; set => userChat = value; }
        
        [DataMember]
        public string Menssage { get => menssage; set => menssage = value; }

        [DataMember]
        public DateTime Date { get => date; set => date = value; }
    }
}
