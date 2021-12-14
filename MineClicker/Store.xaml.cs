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
    /// Lógica de interacción para TiendaPicos.xaml
    /// </summary>
    public partial class Store : Window {
        public Store() {
            InitializeComponent();
        }

        private void BackBtn(object sender, RoutedEventArgs e) {
            MainWindow goMainWindow = new MainWindow();
            goMainWindow.UserName = CajaDeTextoApodo.Text;
            this.Close();
            goMainWindow.ShowDialog();
        }
    }
}
