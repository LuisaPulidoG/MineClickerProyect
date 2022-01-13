using MineClicker.CurrentGameServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MineClicker.Helpers {
    public abstract class CurrentGameCallbackHandler : ICurrentGameServiceCallback {
        public abstract void EndGame(string playerWinnerUsername);
        public abstract void StartGameCallback(string gameGUID);

    }
}
