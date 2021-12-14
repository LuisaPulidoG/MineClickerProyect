using DatosClicker;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Models;

namespace WCFServices {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AccountService" en el código y en el archivo de configuración a la vez.
    public class AccountService : IAccountService {
        public Models.Player LogIn(string username, string password) {
            using (MineClickerEntities db = new MineClickerEntities()) {
                var player = db.Player.FirstOrDefault(x => x.Username == username);
                if (player != null) {
                    if (BCrypt.Net.BCrypt.Verify(password, player.Password)) {
                        return new Models.Player(player);
                    }
                }
                throw new FaultException("Player not found");
            }
        }
        public List<GlobalUserStats> GetGlobalStats() {
            using (MineClickerEntities db = new MineClickerEntities()) {
                var results = (from t in db.Game
                               join p in db.Player on t.PlayerId equals p.PlayerId
                               group t by new { t.PlayerId, p.Username } into g
                               orderby g.Count() descending
                               select new { username = g.Key.Username, totalWins = g.Count() }).ToList();
                var list = new List<GlobalUserStats>();
                foreach (var result in results) {
                    list.Add(new GlobalUserStats {
                        Username = result.username,
                        TotalWins = result.totalWins
                    });
                }
                return list;
            }

        }
        public PersonalUserStats GetPersonalStats(int playerId) {
            using (MineClickerEntities db = new MineClickerEntities()) {
                var materials = (from pgb in db.PlayerGameBlock
                                join pg in db.PlayerGame on pgb.PlayerGameId equals pg.PlayerGameId
                                join b in db.Block on pgb.BlockId equals b.BlockId
                                 group pgb by new { pg.PlayerId, pgb.BlockId, b.Name } into g
                                 select new { blockName = g.Key.Name, totalDestroyed=g.Sum(x => x.Destroyed)}
                    ).ToList();
                var totalMoney = db.PlayerGame.Where(x => x.PlayerId == playerId).GroupBy(g => g.PlayerId).Select(x => new { totalEarnings = x.Sum(i => i.EarnedMoney) }).FirstOrDefault().totalEarnings;
                var stats = new PersonalUserStats {
                    DestroyedBlocks = 0,
                    MaterialsDestroyed = new Dictionary<string, int>(),
                    Money = (float)totalMoney
                };
                foreach(var material in materials) {
                    stats.DestroyedBlocks += material.totalDestroyed;
                    stats.MaterialsDestroyed.Add(material.blockName, material.totalDestroyed);
                }
                return stats;
            }
        }
        public List<FriendUserStats> GetFriendsStats(int playerId) {
            using (MineClickerEntities db = new MineClickerEntities()) {
                var player = db.Player.Where(x => x.PlayerId == playerId).FirstOrDefault();
                var playerFriends = player.Player1.ToList().Aggregate(new List<int>(), (ids, x) => {
                    ids.Add(x.PlayerId);
                    return ids;
                });
                var results = (from t in db.Game
                               where (playerFriends.Contains(t.PlayerId))
                               join p in db.Player on t.PlayerId equals p.PlayerId
                               group t by new { t.PlayerId, p.Username } into g
                               orderby g.Count() descending
                               select new { username = g.Key.Username, totalWins = g.Count() }).ToList();
                var list = new List<FriendUserStats>();
                foreach (var result in results) {
                    list.Add(new FriendUserStats {
                        Username = result.username,
                        TotalWins = result.totalWins
                    });
                }
                return list;
            }

        }
    }

    
}
