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
using Presentacion.ServiciosTienda;
using Telerik.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Presentacion.Forms.Mantenimientos
{
    public partial class CuBuscarProducto : UserControl
    {
        ServiciosTienda.ServiciosTiendaClient Servicio = new ServiciosTienda.ServiciosTiendaClient();
        public CuBuscarProducto()
        {
            InitializeComponent();


            var tipoMarcaLista=new List<TipoMarcaDto>();
            tipoMarcaLista.Add(new TipoMarcaDto{Codigo = 0,DescCodigo = "TODO"});
            tipoMarcaLista.AddRange(Utilitarios.ValoresIniciales.TipoMarcaLista);
            tipoMarcaCombo.ItemsSource = tipoMarcaLista;
            tipoMarcaCombo.SelectedValue = 0;
            Servicio.BuscarProductoCompleted += (Servicio_BuscarProductoCompleted);
            Servicio.BuscarProductoListaSegunCriterioCompleted += (Servicio_BuscarProductoListaSegunCriterioCompleted);
            
        }

        void Servicio_BuscarProductoListaSegunCriterioCompleted(object sender, BuscarProductoListaSegunCriterioCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                productosRadTitleView.ItemsSource = new Productos(e.Result);
            }
        }

        void Servicio_BuscarProductoCompleted(object sender, ServiciosTienda.BuscarProductoCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                productosRadTitleView.ItemsSource = new Productos(e.Result);
            }
        }
        
        private BitmapImage MostrarImagen(string imagen)
        {
            var stringUri = "http://localhost:39835/Data/";
            return new BitmapImage(new Uri(stringUri + imagen, UriKind.Absolute));

        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Servicio.BuscarProductoListaSegunCriterioAsync((int)tipoMarcaCombo.SelectedValue,modeloTextBox.Text,nombreTextBox.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Utilitarios.ValoresIniciales.UsuarioClass.IdUsuario == 0)
            {
                MessageBox.Show("PARA REALIZAR UNA COMPRA DEBE DE USTED ESTAR REGISTRADO COMO CLIENTE");
                return;
            }
            var productoTitle = (Producto)productosRadTitleView.MaximizedItem;
            var productoDto = new ServiciosTienda.ProductoDto 
                                    { 
                                        Archivo=productoTitle.SmallImagen,Especificaciones=productoTitle.Description,
                                        IdProducto=productoTitle.IdProducto,IdTipoMarca=productoTitle.IdTipoMarca,
                                        Modelo=productoTitle.Modelo
                                        ,Nombre=productoTitle.Nombre,Precio=productoTitle.Precio,
                                    };
            var ventaChild = new RealizarVentaChild(productoDto);
            ventaChild.Show();


        }

        
    }

    public class Productos : List<Producto>
    {
        public Productos(System.Collections.ObjectModel.ObservableCollection<ServiciosTienda.ProductoDto> coleccionDeProductos)
        {
            foreach(var productoDto in coleccionDeProductos)
            {
                Producto productoVista = new Producto(productoDto.Nombre, productoDto.Archivo);
                productoVista.Precio = (productoDto.Precio);
                
                productoVista.Cantidad = productoDto.Cantidad.ToString();
                productoVista.Modelo = productoDto.Modelo;
                productoVista.IdProducto = productoDto.IdProducto;
                productoVista.IdTipoMarca = productoDto.IdTipoMarca;
                productoVista.Marca = productoDto.NombreTipoMarca;
                //productoVista.Currency = "euro";
                //productoVista.OfficialLanguage = "German";
                productoVista.Description = productoDto.Especificaciones;
                this.Add(productoVista);
            }
            

            
        }
    }


    public class Producto
    {
        public Producto(string nombre,string nombreArchivo)
        {
            this.Nombre = nombre;
            this.SmallImagen = string.Format("http://localhost:39835/Data/{0}", nombreArchivo);
            this.LargeImagen = string.Format("http://localhost:39835/Data/{0}", nombreArchivo);
        }

        public int IdProducto { get; set; }
        public int IdTipoMarca { get; set; }
        public string SmallImagen { get; set; }
        public string LargeImagen { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }//PoliticalSystem { get; set; }
        public string Marca { get; set; }//CapitalCity { get; set; }
        public string Cantidad { get; set; }//TotalArea { get; set; }
        public string Modelo { get; set; } //public string Population { get; set; }
        //public string Currency { get; set; }
        //public string OfficialLanguage { get; set; }
        public string Description { get; set; }
    }
}
