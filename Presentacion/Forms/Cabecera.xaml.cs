using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Presentacion.Forms
{
    public partial class Cabecera : UserControl
    {
        List<Image> listaImagenes = new List<Image>();
        
        System.Windows.Threading.DispatcherTimer time;
        int contadorImg=0;
        public Cabecera()
        {
            InitializeComponent();

            time = new System.Windows.Threading.DispatcherTimer();
            time.Interval = new TimeSpan(0, 0, 0, 7, 0);
            time.Tick += new EventHandler(time_Tick);
            time.Start();
            var a= new Image();
            a.Stretch = Stretch.Fill;
            a.Source=new BitmapImage(new Uri(string.Format("http://localhost:39835/Imagenes/1.jpg"), UriKind.Absolute));
            listaImagenes.Add(a);
            a = new Image();

            a.Stretch = Stretch.Fill;
            a.Source = new BitmapImage(new Uri(string.Format("http://localhost:39835/Imagenes/2.jpg"), UriKind.Absolute));
            listaImagenes.Add(a);
            a = new Image();
            a.Stretch = Stretch.Fill;
            a.Source = new BitmapImage(new Uri(string.Format("http://localhost:39835/Imagenes/3.jpg"), UriKind.Absolute));
            listaImagenes.Add(a);
            a = new Image();
            a.Stretch = Stretch.Fill;
            a.Source = new BitmapImage(new Uri(string.Format("http://localhost:39835/Imagenes/4.jpg"), UriKind.Absolute));
            listaImagenes.Add(a);
            //a.Source=new BitmapImage(new Uri(string.Format("Imagenes/1.jpg"), UriKind.Relative));
            titulo.Transition = new Telerik.Windows.Controls.TransitionEffects.MotionBlurredZoomTransition();
            titulo.Content = listaImagenes[contadorImg];
            //titulo.Content = new BitmapImage(new Uri(string.Format("/Imagenes/1.jpg"), UriKind.Relative));
        }

        void time_Tick(object sender, EventArgs e)
        {
            if (contadorImg == 4)
            {
                contadorImg = 0;
            }
            titulo.Content = listaImagenes[contadorImg];
            time.Start();
            contadorImg++;
            //throw new NotImplementedException();
        }

    }
}
