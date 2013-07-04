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
using System.IO;

namespace Presentacion.Forms.Mantenimientos
{
    public partial class CuRegistrarProducto : UserControl
    {
        public ServiciosTienda.ServiciosTiendaClient productoClient = new ServiciosTienda.ServiciosTiendaClient();
        public CuRegistrarProducto()
        {
            InitializeComponent();

            
            productoClient.ObtenerProductoListaCompleted += (productoClient_ObtenerProductoListaCompleted);
            productoClient.ObtenerProductoListaSegunCodigoCompleted += (productoClient_ObtenerProductoListaSegunCodigoCompleted);
            productoClient.GuardarCuRegistrarProductoCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(productoClient_GuardarCuRegistrarProductoCompleted);
            tipoMarcaComboBox.ItemsSource = Utilitarios.ValoresIniciales.TipoMarcaLista;
            Loaded += (CuRegistrarProducto_Loaded);
        }

        void productoClient_GuardarCuRegistrarProductoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (!string.IsNullOrEmpty(imagenTextBox.Text))
                {
                    guardarImagen();
                }
                
                MessageBox.Show("Producto Registrado Correctamente");
            }
        }

        void productoClient_ObtenerProductoListaSegunCodigoCompleted(object sender, ServiciosTienda.ObtenerProductoListaSegunCodigoCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                SetPaginaCuRegProd(e.Result);
                manejarControlesProductoDet(false);
            }
            else
            {
                codigoTextBox.Text = "";
                manejarControlesProductoDet(true);
            }
            
        }

        void CuRegistrarProducto_Loaded(object sender, RoutedEventArgs e)
        {
            manejarControlesProductoDet(false);
            productoClient.ObtenerProductoListaAsync();
            registrarButton.IsEnabled = false;
        }

        void productoClient_ObtenerProductoListaCompleted(object sender, ServiciosTienda.ObtenerProductoListaCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                nombreAutoComplete.ItemsSource = e.Result;
            }
            
        }
        private void manejarControlesProductoDet(bool flag)
        {
            if (flag)
            {
                especificacionesTextBlock.Visibility = Visibility.Visible;
                especificacionTextBox.Visibility = Visibility.Visible;
                imagenTextBlock.Visibility = Visibility.Visible;
                imagenTextBox.Visibility = Visibility.Visible;
                imagenButton.Visibility = Visibility.Visible;
            }
            else
            {
                especificacionesTextBlock.Visibility = Visibility.Collapsed;
                especificacionTextBox.Visibility = Visibility.Collapsed;
                imagenTextBlock.Visibility = Visibility.Collapsed;
                imagenTextBox.Visibility = Visibility.Collapsed;
                imagenButton.Visibility = Visibility.Collapsed;
            }


        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            tipoMarcaComboBox.SelectedIndex = -1;
            precioTextBox.Text = "";
            modeloTextBox.Text = "";
            imagenTextBox.Text = "";
            especificacionTextBox.Text = "";

            if (nombreAutoComplete.SelectedItem != null)
            {
                var productoSeleccionado = (ServiciosTienda.ProductoDto)nombreAutoComplete.SelectedItem;
                SetPaginaCuRegProd(productoSeleccionado);
                manejarControlesProductoDet(false);
            }
            else if (!string.IsNullOrEmpty(codigoTextBox.Text))
            {

                productoClient.ObtenerProductoListaSegunCodigoAsync(Convert.ToInt32(codigoTextBox.Text));
            }
            else
            {
                codigoTextBox.Text = "";
                manejarControlesProductoDet(true);
            }
            codigoTextBox.IsEnabled = false;
            registrarButton.IsEnabled = true;
        }

        private void SetPaginaCuRegProd(ServiciosTienda.ProductoDto productoDto)
        {
            codigoTextBox.Text = productoDto.IdProducto.ToString();
            nombreAutoComplete.Text = productoDto.Nombre;
            tipoMarcaComboBox.SelectedValue = productoDto.IdTipoMarca;
            modeloTextBox.Text = productoDto.Modelo;
            precioTextBox.Text = productoDto.Precio.ToString();
            especificacionTextBox.Text = productoDto.Especificaciones;
            imagenTextBox.Text = productoDto.Archivo;
           

        }

        private void registrarButton_Click(object sender, RoutedEventArgs e)
        {
    
            if(string.IsNullOrEmpty(cantidadTextBox.Text))
            {
                MessageBox.Show("Ingrese la cantidad de productos que quiera ingresar");
                return;
            }
            if (string.IsNullOrEmpty(nroDocumentoTextBox.Text))
            {
                MessageBox.Show("Ingrese un numero documento de compra");
                return;
            }
            if (tipoMarcaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una marca para el producto");
                return;
            }
            if (string.IsNullOrEmpty(modeloTextBox.Text))
            {
                MessageBox.Show("Escriba un modelo del producto");
                return;
            }
            if (string.IsNullOrEmpty(precioTextBox.Text) || precioTextBox.Text=="0")
            {
                MessageBox.Show("Ingrese un precio del producto");
                return;
            }


            ServiciosTienda.CuRegistrarProductoDto regProductoDto = new ServiciosTienda.CuRegistrarProductoDto();
            if (!string.IsNullOrEmpty(codigoTextBox.Text))
            {
                regProductoDto.IdProducto = Convert.ToInt32(codigoTextBox.Text);
                
            }
            regProductoDto.Nombre = nombreAutoComplete.Text;
            regProductoDto.IdTipoMarca = (int)tipoMarcaComboBox.SelectedValue;
            regProductoDto.Modelo = modeloTextBox.Text;
            regProductoDto.Precio = Convert.ToDecimal(precioTextBox.Text);
            regProductoDto.Especificaciones = especificacionTextBox.Text;
            regProductoDto.Archivo = imagenTextBox.Text;
            regProductoDto.Cantidad = Convert.ToInt32(cantidadTextBox.Text);
            regProductoDto.IdUsuario = Utilitarios.ValoresIniciales.UsuarioClass.IdUsuario;
            regProductoDto.NumeroDocumento = nroDocumentoTextBox.Text;

            productoClient.GuardarCuRegistrarProductoAsync(regProductoDto);
            codigoTextBox.IsEnabled = true;
            registrarButton.IsEnabled = false;
        }
        Stream archivo;
        byte[] bytes;
        string fileName;
        private void imagenButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();

            //Abre la caja de diálogo
            if (ofd.ShowDialog().Value)
            {
                fileName = ofd.File.Name;
                imagenTextBox.Text = fileName;
                archivo = ofd.File.OpenRead();
                bytes = new byte[archivo.Length];
                archivo.Read(bytes, 0, bytes.Length);


                
            }
 
        }

        private void guardarImagen()
        {
            WebClient client = new WebClient();
            client.WriteStreamClosed += (s, a) =>
            {
                if (a.Error == null)
                {
                    //El archivo fue subido correctamente
                }
            };

            client.OpenWriteCompleted += (s, a) =>
            {
                if (a.Error == null)
                {
                    //El Stream ha sido abierto correctamente
                    //Escribe la secuencia de bytes en el Stream abierto

                    Stream stream = a.Result;
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                    stream.Close();
                }
            };

            //Abre un Stream de escritura
            client.OpenWriteAsync(new Uri(string.Format("/Upload.aspx?n={0}", fileName),
                UriKind.RelativeOrAbsolute));
        }

        private void codigoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }

        private void precioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }

        private void cantidadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }


        
    }
}
