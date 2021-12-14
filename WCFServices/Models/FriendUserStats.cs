using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices.Models {
    [DataContract]
    public struct FriendUserStats {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public int TotalWins { get; set; }
    }
}
