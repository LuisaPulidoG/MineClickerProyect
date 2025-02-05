﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MineClicker.AccountServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountServiceReference.IAccountService")]
    public interface IAccountService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/LogIn", ReplyAction="http://tempuri.org/IAccountService/LogInResponse")]
        WCFServices.Models.Player LogIn(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/LogIn", ReplyAction="http://tempuri.org/IAccountService/LogInResponse")]
        System.Threading.Tasks.Task<WCFServices.Models.Player> LogInAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetGlobalStats", ReplyAction="http://tempuri.org/IAccountService/GetGlobalStatsResponse")]
        WCFServices.Models.GlobalUserStats[] GetGlobalStats();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetGlobalStats", ReplyAction="http://tempuri.org/IAccountService/GetGlobalStatsResponse")]
        System.Threading.Tasks.Task<WCFServices.Models.GlobalUserStats[]> GetGlobalStatsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetPersonalStats", ReplyAction="http://tempuri.org/IAccountService/GetPersonalStatsResponse")]
        WCFServices.Models.PersonalUserStats GetPersonalStats(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetPersonalStats", ReplyAction="http://tempuri.org/IAccountService/GetPersonalStatsResponse")]
        System.Threading.Tasks.Task<WCFServices.Models.PersonalUserStats> GetPersonalStatsAsync(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetFriendsStats", ReplyAction="http://tempuri.org/IAccountService/GetFriendsStatsResponse")]
        WCFServices.Models.FriendUserStats[] GetFriendsStats(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetFriendsStats", ReplyAction="http://tempuri.org/IAccountService/GetFriendsStatsResponse")]
        System.Threading.Tasks.Task<WCFServices.Models.FriendUserStats[]> GetFriendsStatsAsync(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetFriends", ReplyAction="http://tempuri.org/IAccountService/GetFriendsResponse")]
        WCFServices.Models.Player[] GetFriends(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/GetFriends", ReplyAction="http://tempuri.org/IAccountService/GetFriendsResponse")]
        System.Threading.Tasks.Task<WCFServices.Models.Player[]> GetFriendsAsync(int playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/RegisterPlayer", ReplyAction="http://tempuri.org/IAccountService/RegisterPlayerResponse")]
        void RegisterPlayer(WCFServices.Models.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/RegisterPlayer", ReplyAction="http://tempuri.org/IAccountService/RegisterPlayerResponse")]
        System.Threading.Tasks.Task RegisterPlayerAsync(WCFServices.Models.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/AttendFriendRequest", ReplyAction="http://tempuri.org/IAccountService/AttendFriendRequestResponse")]
        void AttendFriendRequest(int friendRequestID, bool response);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/AttendFriendRequest", ReplyAction="http://tempuri.org/IAccountService/AttendFriendRequestResponse")]
        System.Threading.Tasks.Task AttendFriendRequestAsync(int friendRequestID, bool response);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/SendFriendRequest", ReplyAction="http://tempuri.org/IAccountService/SendFriendRequestResponse")]
        void SendFriendRequest(string username, int senderID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/SendFriendRequest", ReplyAction="http://tempuri.org/IAccountService/SendFriendRequestResponse")]
        System.Threading.Tasks.Task SendFriendRequestAsync(string username, int senderID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountServiceChannel : MineClicker.AccountServiceReference.IAccountService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountServiceClient : System.ServiceModel.ClientBase<MineClicker.AccountServiceReference.IAccountService>, MineClicker.AccountServiceReference.IAccountService {
        
        public AccountServiceClient() {
        }
        
        public AccountServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCFServices.Models.Player LogIn(string username, string password) {
            return base.Channel.LogIn(username, password);
        }
        
        public System.Threading.Tasks.Task<WCFServices.Models.Player> LogInAsync(string username, string password) {
            return base.Channel.LogInAsync(username, password);
        }
        
        public WCFServices.Models.GlobalUserStats[] GetGlobalStats() {
            return base.Channel.GetGlobalStats();
        }
        
        public System.Threading.Tasks.Task<WCFServices.Models.GlobalUserStats[]> GetGlobalStatsAsync() {
            return base.Channel.GetGlobalStatsAsync();
        }
        
        public WCFServices.Models.PersonalUserStats GetPersonalStats(int playerId) {
            return base.Channel.GetPersonalStats(playerId);
        }
        
        public System.Threading.Tasks.Task<WCFServices.Models.PersonalUserStats> GetPersonalStatsAsync(int playerId) {
            return base.Channel.GetPersonalStatsAsync(playerId);
        }
        
        public WCFServices.Models.FriendUserStats[] GetFriendsStats(int playerId) {
            return base.Channel.GetFriendsStats(playerId);
        }
        
        public System.Threading.Tasks.Task<WCFServices.Models.FriendUserStats[]> GetFriendsStatsAsync(int playerId) {
            return base.Channel.GetFriendsStatsAsync(playerId);
        }
        
        public WCFServices.Models.Player[] GetFriends(int playerId) {
            return base.Channel.GetFriends(playerId);
        }
        
        public System.Threading.Tasks.Task<WCFServices.Models.Player[]> GetFriendsAsync(int playerId) {
            return base.Channel.GetFriendsAsync(playerId);
        }
        
        public void RegisterPlayer(WCFServices.Models.Player player) {
            base.Channel.RegisterPlayer(player);
        }
        
        public System.Threading.Tasks.Task RegisterPlayerAsync(WCFServices.Models.Player player) {
            return base.Channel.RegisterPlayerAsync(player);
        }
        
        public void AttendFriendRequest(int friendRequestID, bool response) {
            base.Channel.AttendFriendRequest(friendRequestID, response);
        }
        
        public System.Threading.Tasks.Task AttendFriendRequestAsync(int friendRequestID, bool response) {
            return base.Channel.AttendFriendRequestAsync(friendRequestID, response);
        }
        
        public void SendFriendRequest(string username, int senderID) {
            base.Channel.SendFriendRequest(username, senderID);
        }
        
        public System.Threading.Tasks.Task SendFriendRequestAsync(string username, int senderID) {
            return base.Channel.SendFriendRequestAsync(username, senderID);
        }
    }
}
