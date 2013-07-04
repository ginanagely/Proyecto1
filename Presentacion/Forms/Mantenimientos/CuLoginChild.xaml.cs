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

namespace Presentacion.Forms.Mantenimientos
{
    public partial class CuLoginChild : ChildWindow
    {
        ServiciosTienda.ServiciosTiendaClient Servicio = new ServiciosTienda.ServiciosTiendaClient();
        public CuLoginChild()
        {
            InitializeComponent();
            Servicio.ObtenerUsuarioLoginCompleted += (Servicio_ObtenerUsuarioLoginCompleted);

        }

        void Servicio_ObtenerUsuarioLoginCompleted(object sender, ServiciosTienda.ObtenerUsuarioLoginCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MessageBox.Show("Usuario Identificado Correctamente");
                Utilitarios.ValoresIniciales.UsuarioClass.IdUsuario = e.Result.IdUsuario;
                Utilitarios.ValoresIniciales.UsuarioClass.Nombre = e.Result.NombreUsuario;
                var tipoUsuario = (from dats 
                                      in Utilitarios.ValoresIniciales.TipoUsuarioLista 
                                  where dats.Codigo == e.Result.IdTipoUsuario 
                                  select dats).FirstOrDefault();
                Utilitarios.ValoresIniciales.UsuarioClass.IdTipoUsuario = e.Result.IdTipoUsuario;
                Utilitarios.ValoresIniciales.UsuarioClass.TipoUsuario = tipoUsuario.DescCodigo;
                Utilitarios.ValoresIniciales.UsuarioClass.NumeroTarjeta = e.Result.NumeroTarjeta;

                this.DialogResult = true;

                
            }
            else
                MessageBox.Show("Usuario y/o clave ingresados incorrectamente");

        }

        
        
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Servicio.ObtenerUsuarioLoginAsync(usuarioTextBox.Text, claveTextBox.Text);
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

