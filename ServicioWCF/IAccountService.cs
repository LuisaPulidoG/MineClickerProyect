using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Models;

namespace WCFServices {
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IAccountService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAccountService {
        [OperationContract]
        Player LogIn(string username, string password);
        [OperationContract]
        List<GlobalUserStats> GetGlobalStats();
        [OperationContract]
        PersonalUserStats GetPersonalStats(int playerId);
        [OperationContract]
        List<FriendUserStats> GetFriendsStats(int playerId);
    }
}
