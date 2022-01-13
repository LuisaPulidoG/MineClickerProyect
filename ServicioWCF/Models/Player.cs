using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices.Models {
    [DataContract]

    public class Player {
        [DataMember]
        public int PlayerId { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public float Money { get; set; }
        [DataMember]
        public string Name { get; set; }

        public Player(DatosClicker.Player player) {
            PlayerId = player.PlayerId;
            Username = player.Username;
            Password = player.Password;
            Email = player.Email;
            Money = (float) player.Money;
            Name = player.Name;
        }
    }

}
