using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace Presentacion.Utilitarios
{
    public static class ValoresIniciales
    {
        public static IEnumerable<ServiciosTienda.TipoMarcaDto> TipoMarcaLista { get; set; }
        public static IEnumerable<ServiciosTienda.TipoUsuarioDto> TipoUsuarioLista { get; set; }
        public static IEnumerable<ServiciosTienda.TipoTarjetaDto> TipoTarjetaLista { get; set; }
        public static LoginPantalla UsuarioClass { get; set; }
        public static void LlenarListas()
        {
            UsuarioClass = new LoginPantalla();
            ServiciosTienda.ServiciosTiendaClient servicioValores = new ServiciosTienda.ServiciosTiendaClient();
            servicioValores.ObtenerTipoMarcaCompleted += new EventHandler<ServiciosTienda.ObtenerTipoMarcaCompletedEventArgs>(servicioValores_ObtenerTipoMarcaCompleted);
            servicioValores.ObtenerTipoTarjetaCompleted += new EventHandler<ServiciosTienda.ObtenerTipoTarjetaCompletedEventArgs>(servicioValores_ObtenerTipoTarjetaCompleted);
            servicioValores.ObtenerTipoUsuarioCompleted += new EventHandler<ServiciosTienda.ObtenerTipoUsuarioCompletedEventArgs>(servicioValores_ObtenerTipoUsuarioCompleted);

            servicioValores.ObtenerTipoMarcaAsync();
            servicioValores.ObtenerTipoTarjetaAsync();
            servicioValores.ObtenerTipoUsuarioAsync(); 
            TipoMarcaLista = new List<ServiciosTienda.TipoMarcaDto>();
            TipoUsuarioLista = new List<ServiciosTienda.TipoUsuarioDto>();
            TipoTarjetaLista = new List<ServiciosTienda.TipoTarjetaDto>();
        }

        static void servicioValores_ObtenerTipoUsuarioCompleted(object sender, ServiciosTienda.ObtenerTipoUsuarioCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                TipoUsuarioLista = e.Result;
            }
        }

        static void servicioValores_ObtenerTipoTarjetaCompleted(object sender, ServiciosTienda.ObtenerTipoTarjetaCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                TipoTarjetaLista = e.Result;
            }
        }

        static void servicioValores_ObtenerTipoMarcaCompleted(object sender, ServiciosTienda.ObtenerTipoMarcaCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                TipoMarcaLista = e.Result;
            }
        }

    }
    public class LoginPantalla
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string NumeroTarjeta { get; set; }
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
    }
}
