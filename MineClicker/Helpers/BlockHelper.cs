using MineClicker.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WCFServices.Models;

namespace MineClicker.Helpers {
    public class BlockHelper {
        private static GameServiceClient client = new GameServiceClient();
        public static Dictionary<int, Bitmap> BlockImages = new Dictionary<int, Bitmap>() {
            {1, Properties.ImageResources.CoalBlock},
            {2, Properties.ImageResources.IronBlock},
            {7, Properties.ImageResources.AmberBlock},
            {8, Properties.ImageResources.CopperBlock},
            {9, Properties.ImageResources.LeadBlock},
            {10, Properties.ImageResources.SilverBlock},
            {11, Properties.ImageResources.GoldBlock},
            {12, Properties.ImageResources.DiamondBlock},
            {13, Properties.ImageResources.PlatinumBlock},
            {14, Properties.ImageResources.FluoriteBlock}
        };
        public static BitmapImage ConvertToImage(Bitmap src) {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        public static Block[] GetBlocks() {
            return client.GetBlocks();
        }
    }
}
