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

namespace MineClicker.Objetos
{
    public class Pico
    {
        private String idPico;
        private float Dureza;
        private float probabilidad;
        private float valor;
        private BitmapImage imagenbloque = new BitmapImage();
        public Pico(string idbloque, float Dureza, float probabilidad, float valor, string imagenbloque)
        {
            this.idPico = idbloque;
            this.Dureza = Dureza;
            this.probabilidad = probabilidad;
            this.valor = valor;
            this.imagenbloque.BeginInit();
            this.imagenbloque.UriSource = new Uri(imagenbloque, UriKind.Relative);
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
    }
}
