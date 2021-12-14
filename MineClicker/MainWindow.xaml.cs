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
using System.ServiceModel;
using System.Media;
using MineClicker.Objetos;
using System.IO;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para InicioJuego.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        SoundPlayer EfBlockSound = new SoundPlayer(Properties.SoundResources.RomperBloquewav as Stream);
        int bloqueactual;
        int numerorandom;
        int bloquesDestridos = 0;
        float dineroObtenido = 0;
        List<Bloque> listaBloques = new List<Bloque>();
        private Random random = new Random();
        Bloque bloque1 = new Bloque("bloque1", 1, 2, 1000, "/Sourse_Imagen/Bloque1.png");
        Bloque bloque2 = new Bloque("bloque2", 5, 4, 90, "/Sourse_Imagen/Bloque2.png");
        Bloque bloque3 = new Bloque("bloque3", 10, 5, 30, "/Sourse_Imagen/Bloque3.png");
        Bloque bloque4 = new Bloque("bloque4", 6, 7, 19, "/Sourse_Imagen/Bloque4.png");

        //private bool isConnected = false;

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        //public char PasswordChar { get; set; }

        public MainWindow() {
            listaBloques.Add(bloque1);
            listaBloques.Add(bloque2);
            listaBloques.Add(bloque3);
            listaBloques.Add(bloque4);
            InitializeComponent();
            numerorandom = random.Next(0, 3);
            bloqueactual = numerorandom;
            ImagenChange.Source = listaBloques[numerorandom].GetImagen();
        }

        private void BreakBlockBtn(object sender, RoutedEventArgs e) {

            int clicks = int.Parse(ClicsPorSegundo.Text);
            clicks++;
            ClicsPorSegundo.Text = clicks.ToString();


            int[] Chancebloque = new int[4];
            for (int i = 0; i < 4; i++) {
                Chancebloque[i] = 0;
            }

            if (clicks > listaBloques[bloqueactual].getdureza()) {
                dineroObtenido = dineroObtenido + listaBloques[bloqueactual].GetValorbloque();
                for (int busqueda = 0; busqueda < listaBloques.Count(); busqueda++) {
                    float probabilidad = listaBloques[busqueda].GetProbabilidad();
                    for (int numVeces = 0; numVeces < probabilidad; numVeces++) {
                        bloqueactual = random.Next(0, 10);
                        if (Chancebloque[busqueda] < bloqueactual) {
                            Chancebloque[busqueda] = bloqueactual;
                        }
                    }
                }
                for (int valorMax = 0; valorMax < 4; valorMax++) {
                    if (valorMax == 0) {
                        bloqueactual = valorMax;
                    } else if (Chancebloque[valorMax] > Chancebloque[valorMax - 1]) {
                        bloqueactual = valorMax;
                    }
                }
                clicks = 0;
                ClicsPorSegundo.Text = clicks.ToString();
                bloquesDestridos++;


                ImagenChange.Source = listaBloques[bloqueactual].GetImagen();
                EfBlockSound.Play();

            }

            bloquesdestruidos.Text = bloquesDestridos.ToString();
            DineroObtenido.Text = dineroObtenido.ToString();

        }

        private void ChatBtn(object sender, RoutedEventArgs e) {
            ChatJugadores chatWindow = new ChatJugadores();
            this.Close();
            chatWindow.ShowDialog();
        }

        private void StoreBtn(object sender, RoutedEventArgs e) {
            Store storeWindow = new Store();
            this.Close();
            storeWindow.CajaDeTextoApodo.Text = UserName;
            storeWindow.ShowDialog();
        }

        private void ConfigBtn(object sender, RoutedEventArgs e) {
            GameConfiguration configurationWindow = new GameConfiguration();
            this.Close();

            configurationWindow.ShowDialog();
        }

        private void ChangeRightBtn(object sender, RoutedEventArgs e) {

        }

        private void ChangeLeftBtn(object sender, RoutedEventArgs e) {

        }

        private void StatsBtn(object sender, RoutedEventArgs e) {
            Stats statsWindow = new Stats();
            this.Close();
            statsWindow.ShowDialog();
        }

        private void MultiplayerBtn(object sender, RoutedEventArgs e) {
            WaitingGameWindow waitingGameWindow = new WaitingGameWindow();
            this.Close();
            waitingGameWindow.ShowDialog();
        }

        private void SendInvitationBtn(object sender, RoutedEventArgs e) {
            SendInvitation invitationWindow = new SendInvitation();
            this.Close();
            invitationWindow.ShowDialog();
        }
    }
}
