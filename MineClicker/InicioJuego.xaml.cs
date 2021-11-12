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
using Chat_WCF;
using System.Media;
using MineClicker.Objetos;
namespace MineClicker
{
    /// <summary>
    /// Lógica de interacción para InicioJuego.xaml
    /// </summary>
    /// 
    

    /*public class BloquesGame
    {
        private String idbloque;
        private float Dureza;
        private float probabilidad;
        private float valor;
        private BitmapImage imagenbloque = new BitmapImage();
        public BloquesGame(string idbloque,float Dureza, float probabilidad, float valor, string imagenbloque)
        {
            this.idbloque = idbloque;
            this.Dureza = Dureza;
            this.probabilidad = probabilidad;
            this.valor = valor;
            this.imagenbloque.BeginInit();
            this.imagenbloque.UriSource = new Uri(imagenbloque,UriKind.Relative);
            this.imagenbloque.EndInit();

        }

        public BitmapImage GetImagen()
        {
            return this.imagenbloque;
        }
        public float getdureza()
        {
            return this.Dureza;
        }
        public float GetProbabilidad()
        {
            return this.probabilidad;
        }
        public float GetValorbloque()
        {
            return this.valor;
        }
        public void setImagenbloque(string imagenueva)
        {
            imagenbloque.UriSource = new Uri(imagenueva, UriKind.Relative);
        }
    }*/
    public partial class InicioJuego : Window
    {
        SoundPlayer sound = new SoundPlayer(@"E:\Proyectos Visual Studio\repos\MineClickerTecno\MineClicker\Sourse_Imagen\RomperBloquewav.wav");
        int bloqueactual;
        int numerorandom;
        int bloquesDestridos = 0;
        float dineroObtenido = 0;
        List<Bloque> listaBloques = new List<Bloque>();
        private Random random = new Random();
        Bloque bloque1 = new Bloque("bloque1", 1, 2, 1000, "/Sourse_Imagen/Bloque1.png");
        Bloque bloque2 = new Bloque("bloque2", 5, 4, 90, "/Sourse_Imagen/Bloque2.png");
        Bloque bloque3 = new Bloque("bloque3", 10,5, 30, "/Sourse_Imagen/Bloque3.png");
        Bloque bloque4 = new Bloque("bloque4", 6, 7, 19, "/Sourse_Imagen/Bloque4.png");

        private ChannelFactory<IChatService> remoteFactory;
        public IChatService remoteProxy;
        private ChatUser clientUser;
        //private bool isConnected = false;

        public string Username { get; set; }
        public string Userpassword { get; set; }
        public char PasswordChar { get; set; }
        
        public InicioJuego()
        {
            listaBloques.Add(bloque1);
            listaBloques.Add(bloque2);
            listaBloques.Add(bloque3);
            listaBloques.Add(bloque4);
            InitializeComponent();
            numerorandom= random.Next(0, 3);
            bloqueactual = numerorandom;
            ImagenChange.Source = listaBloques[numerorandom].GetImagen();
        }

        private void Button_ClickBlock(object sender, RoutedEventArgs e)
        {

            int clicks = int.Parse(ClicsPorSegundo.Text);
            clicks++;
            ClicsPorSegundo.Text = clicks.ToString();
            

            int[] Chancebloque=new int[4];
            for (int i=0; i < 4; i++){
                Chancebloque[i] = 0;
            }

            if (clicks > listaBloques[bloqueactual].getdureza())
            {
                dineroObtenido = dineroObtenido+listaBloques[bloqueactual].GetValorbloque();
                for(int busqueda = 0; busqueda < listaBloques.Count(); busqueda++)
                {
                    float probabilidad = listaBloques[busqueda].GetProbabilidad();
                    for(int numVeces = 0; numVeces < probabilidad; numVeces++)
                    {
                        bloqueactual= random.Next(0, 10);
                        if (Chancebloque[busqueda] < bloqueactual)
                        {
                            Chancebloque[busqueda] = bloqueactual;
                        }
                    }
                }
                for(int valorMax = 0; valorMax < 4; valorMax++)
                {
                    if (valorMax == 0)
                    {
                        bloqueactual = valorMax;
                    }
                    else if (Chancebloque[valorMax] > Chancebloque[valorMax - 1])
                    {
                        bloqueactual = valorMax;
                    }
                }
                clicks = 0;
                ClicsPorSegundo.Text = clicks.ToString();
                bloquesDestridos++;

                
                ImagenChange.Source = listaBloques[bloqueactual].GetImagen();
                sound.Play();
                
            }
            
            bloquesdestruidos.Text = bloquesDestridos.ToString();
            DineroObtenido.Text = dineroObtenido.ToString();
            
        }

        private void Button_Chat(object sender, RoutedEventArgs e)
        {
            Chat_window chatwindowcreate = new Chat_window();
            chatwindowcreate.statuslabel.Text = "conected";
            chatwindowcreate.NameUser.Text = Username;

           // remoteFactory = new ChannelFactory<IChatService>("ChatConfig");
            //remoteProxy = remoteFactory.CreateChannel();
            //clientUser = remoteProxy.ClientConnect(Username, Userpassword);

            //chatwindowcreate.remoteFactory = this.remoteFactory;
            //chatwindowcreate.remoteProxy = this.remoteProxy;
            //chatwindowcreate.clientuser = this.clientUser;

            if (clientUser != null)
            {
                //usersTimer.Enabled = true;
                //messagesTimer.Enabled = true;
                // isConnected = true;
            }

            this.Close();
            chatwindowcreate.ShowDialog();
        }

        private void BotonTiendaPico(object sender, RoutedEventArgs e)
        {
            TiendaPicos TiendaVentan = new TiendaPicos();
            this.Close();
            TiendaVentan.TextBoxApodo.Text = Username;
            TiendaVentan.ShowDialog();
        }

        private void BotonConfiguracion(object sender, RoutedEventArgs e)
        {
            ConfiguracionJuego configuracionJuego = new ConfiguracionJuego();
            this.Close();

            configuracionJuego.ShowDialog();
        }

        private void BotonCambioDerecha(object sender, RoutedEventArgs e)
        {

        }

        private void BotonCambioIzquierda(object sender, RoutedEventArgs e)
        {

        }
    }
}
