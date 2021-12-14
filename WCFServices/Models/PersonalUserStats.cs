using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices.Models {
    [DataContract]
    public struct PersonalUserStats {
        [DataMember]
        public float Money;
        [DataMember]
        public int DestroyedBlocks;
        [DataMember]
        public Dictionary<string, int> MaterialsDestroyed;
    }
}
