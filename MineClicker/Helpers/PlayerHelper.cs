﻿using MineClicker.AccountServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServices.Models;

namespace MineClicker.Helpers {
    public class PlayerHelper {
        private static AccountServiceClient client = new AccountServiceClient();
        public static Player LogIn(string username, string password) {
            return client.LogIn(username, password);
        }
        public static GlobalUserStats[] GetGlobalUserStats() {
            return client.GetGlobalStats();
        }
        public static FriendUserStats[] GetFriendsUserStats() {
            return client.GetFriendsStats(Session.Player.PlayerId);
        }

        public static PersonalUserStats GetPersonalUserStats() {
            return client.GetPersonalStats(Session.Player.PlayerId);
        }
        public static Player[] GetFriends() {
            return client.GetFriends(Session.Player.PlayerId);
        }
        public static void PlayerRegister(Player newPlayer) {
            client.RegisterPlayer(newPlayer);
        }
        public static void AttendFriendRequest(int friendRequestID, bool response) {
            client.AttendFriendRequest(friendRequestID, response);
        }
        public static void SendFriendRequest(string username) {
            client.SendFriendRequest(username, Session.Player.PlayerId);
        }
    }
}
