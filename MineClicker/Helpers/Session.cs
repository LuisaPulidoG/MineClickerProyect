using MineClicker.AccountServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServices.Models;

namespace MineClicker.Helpers {
    public class Session {
        public static Player Player { get; set; }
        public static Dictionary<int, Dictionary<int, string>> chats = new Dictionary<int, Dictionary<int,string>>();
    }
}
