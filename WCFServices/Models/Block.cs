using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices.Models {
    [DataContract]
    public class Block {
        [DataMember]
        public int BlockID;
        [DataMember]
        public string Name;
        [DataMember]
        public double Value;
        [DataMember]
        public int Rarity;
        [DataMember]
        public int Hardness;

        public Block(DatosClicker.Block block) {
            BlockID = block.BlockId;
            Name = block.Name;
            Value = block.Value;
            Rarity = block.Rarity;
            Hardness = block.Hardness;
        }
        public Block() {
        }

    }
}
