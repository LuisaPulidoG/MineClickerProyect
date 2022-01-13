using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CurrentGameService" en el código y en el archivo de configuración a la vez.
    public class CurrentGameService : ICurrentGameService {
        public void StartGame(string gameGUID) {
           
        }

    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CurrentGameServiceClient : DuplexClientBase<CurrentGameService>, ICurrentGameService {
        public CurrentGameServiceClient(InstanceContext callbackContext) : base(callbackContext) { }

        public void StartGame(string gameGUID) {
            base.Channel.StartGame(gameGUID);
        }
    }
}
