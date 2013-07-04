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
    public partial class RealizarVentaChild : ChildWindow
    {
        public RealizarVentaChild()
        {
            InitializeComponent();
        }
        decimal igv = 0;
        int idProducto = 0;
        ServiciosTienda.ServiciosTiendaClient Servicio = new ServiciosTienda.ServiciosTiendaClient();
        public RealizarVentaChild(ServiciosTienda.ProductoDto producto)
        {
            InitializeComponent();

            NombreUsuarioTextBox.Text = Utilitarios.ValoresIniciales.UsuarioClass.Nombre;
            nombResumenProdTextBox.Text = producto.Nombre;
            precioProdTextBox.Text = producto.Precio.ToString();
            numeroTarjetaTextBox.Text = Utilitarios.ValoresIniciales.UsuarioClass.NumeroTarjeta;
            idProducto = producto.IdProducto;
            Servicio.ObtenerIgvVentaAsync();
            Servicio.ObtenerIgvVentaCompleted += (Servicio_ObtenerIgvVentaCompleted);
            Servicio.RegistrarVentaCompleted += (Servicio_RegistrarVentaCompleted);
        }

        void Servicio_RegistrarVentaCompleted(object sender, ServiciosTienda.RegistrarVentaCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if(e.Result.Contains("ERROR"))
                {

                }
                else
                {

                }

                MessageBox.Show("VENTA REALIZADA CON EXITO");
                FacturaVirtualChild nuevaFactura = new FacturaVirtualChild(e.Result,"CONSULTAR");
                nuevaFactura.Show();
            }
        }

        void Servicio_ObtenerIgvVentaCompleted(object sender, ServiciosTienda.ObtenerIgvVentaCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                igv = Convert.ToDecimal(e.Result);
            }
            
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            
            //Paso Uno Validación
            if (string.IsNullOrEmpty(NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("Nombre usuario en blanco");
                return;
            }
            if (string.IsNullOrEmpty(claveUsuarioTextBox.Text))
            {
                MessageBox.Show("Clave usuario en blanco");
                return;
            }
            if (string.IsNullOrEmpty(NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("Cantidad de productos en blanco");
                return;
            }


            //Paso 2 Validacion
            if (string.IsNullOrEmpty(claveTarjetaTextBox.Text))
            {
                MessageBox.Show("Clave de tarjeta en blanco");
                return;
            }

            var ventaDto = new ServiciosTienda.CuRealizarVentaDto();

            ventaDto.IdProducto = idProducto;
            ventaDto.IdCliente = Utilitarios.ValoresIniciales.UsuarioClass.IdUsuario;
            ventaDto.IdUsuario = Utilitarios.ValoresIniciales.UsuarioClass.IdUsuario;
            ventaDto.Cantidad = Convert.ToInt32(cantidadProductoTextBox.Text);
            ventaDto.PrecioUnitario = Convert.ToDecimal(precioProdTextBox.Text);
            ventaDto.Igv = igv;
            ventaDto.Total = Convert.ToDecimal(totalProdTextBox.Text);
            ventaDto.claveTarjeta=claveTarjetaTextBox.Text;
            ventaDto.claveUsuario=claveUsuarioTextBox.Text;


            Servicio.RegistrarVentaAsync(ventaDto);
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void siguienteP1Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("Nombre usuario en blanco");
                return;
            }
            if (string.IsNullOrEmpty(claveUsuarioTextBox.Text))
            {
                MessageBox.Show("Clave usuario en blanco");
                return;
            }
            if (string.IsNullOrEmpty(NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("Cantidad de productos en blanco");
                return;
            }

           

            paso2Item.IsSelected = true;
        }
        

        private void anteriorP2Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(claveTarjetaTextBox.Text))
            {
                MessageBox.Show("Clave de tarjeta en blanco");
                return;
            }
            paso1TabItem.IsSelected = true;
        }

        private void siguienteP2Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(claveTarjetaTextBox.Text))
            {
                MessageBox.Show("Clave de tarjeta en blanco");
                return;
            }
            paso3Item.IsSelected = true;
        }

        private void cantidadProductoTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var precioTotal = Convert.ToDecimal(precioProdTextBox.Text) * Convert.ToDecimal(cantidadProductoTextBox.Text);
                cantidadProdTextBox.Text = cantidadProductoTextBox.Text;
                var igvTotal = precioTotal * igv;
                totalProdTextBox.Text = (precioTotal + igvTotal).ToString();
            }
            catch (Exception errorComun)
            {

            }
            
        }

        private void cantidadProductoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }
    }
}

