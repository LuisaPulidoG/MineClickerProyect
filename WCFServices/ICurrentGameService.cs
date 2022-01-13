using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices {
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "ICurrentGameService" en el código y en el archivo de configuración a la vez.
    [ServiceContract(CallbackContract = typeof(ICurrentGameServiceCallback))]
    public interface ICurrentGameService {
        [OperationContract(IsOneWay = true)]
        void SetPlayerInWaitingQueue(int playerID);
        [OperationContract(IsOneWay = true)]
        void SendDestroyedBlocks(List<Models.Block> destroyedBlocks, string guid, int playerID);
    }
    [ServiceContract]
    public interface ICurrentGameServiceCallback {
        [OperationContract(IsOneWay = true)]
        void StartGameCallback(string gameGUID);
        [OperationContract(IsOneWay = true)]
        void EndGame(string playerWinnerUsername);
    }
}
