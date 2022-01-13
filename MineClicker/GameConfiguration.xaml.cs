using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para ConfiguracionJuego.xaml
    /// </summary>
    public partial class GameConfiguration : Window {
        public GameConfiguration() {
            InitializeComponent();
        }

        private void BackBtn(object sender, RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void CambioIdiomaEspaniol_Click(object sender, RoutedEventArgs e) {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-MX");
            GameConfiguration window = new GameConfiguration();
            this.Close();
            window.ShowDialog();
        }

        private void CambioIdiomaJapones_Click(object sender, RoutedEventArgs e) {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja-JP");
            GameConfiguration window = new GameConfiguration();
            this.Close();
            window.ShowDialog();
        }

        private void CambioIdiomaIngles_Click(object sender, RoutedEventArgs e) {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
            GameConfiguration window = new GameConfiguration();
            this.Close();
            window.ShowDialog();
        }
    }
}
