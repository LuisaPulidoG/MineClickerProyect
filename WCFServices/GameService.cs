using DatosClicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Models;

namespace WCFServices {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GameService" en el código y en el archivo de configuración a la vez.
    public class GameService : IGameService {

        public List<Models.Block> GetBlocks() {
            using (MineClickerEntities db = new MineClickerEntities()) {
                List<Models.Block> blocks = new List<Models.Block>();
                var blocksBD = db.Block.ToList();
                foreach (var block in blocksBD) {
                    blocks.Add(new Models.Block {
                        Name = block.Name,
                        BlockID = block.BlockId,
                        Value = block.Value,
                        Rarity = block.Rarity,
                        Hardness = block.Hardness
                    });
                }
                return blocks;
            }
        }

    }
}
