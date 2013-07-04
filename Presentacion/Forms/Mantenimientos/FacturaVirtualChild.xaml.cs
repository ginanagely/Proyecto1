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
    public partial class FacturaVirtualChild : ChildWindow
    {
        ServiciosTienda.ServiciosTiendaClient servicio = new ServiciosTienda.ServiciosTiendaClient();
        string _accion;
        string _numeroBoleta;
        public FacturaVirtualChild(string numeroBoleta,string accion)
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(FacturaVirtualChild_Loaded);
            servicio.ObtenerBoletaCompleted += (servicio_ObtenerBoletaCompleted);
            servicio.RegistrarReclamoCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(servicio_RegistrarReclamoCompleted);
            servicio.AtenderReclamoCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(servicio_AtenderReclamoCompleted);
            _accion = accion;
            _numeroBoleta = numeroBoleta;
        }
        public FacturaVirtualChild(ServiciosTienda.CuProcesoReclamoBoletaDto reclamo)
        {
            InitializeComponent();
            servicio.AtenderReclamoCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(servicio_AtenderReclamoCompleted);
            _accion = "ANULAR";
            _numeroBoleta = reclamo.NroBoleta;
            asuntoGrid.Visibility = Visibility.Visible;
            asuntoTextBox.IsEnabled = false;
            solicitarButton.Visibility = Visibility.Collapsed;
            anularButton.Visibility = Visibility.Visible;

            if (reclamo != null)
            {
                if (!string.IsNullOrEmpty(reclamo.NombreProducto))
                {
                    nombreClienteTextBox.Text = reclamo.NombreProducto;
                }

                fechaTextBox.Text = reclamo.Fecha.ToShortDateString();
                estadoBoletaTextBox.Text = reclamo.descEstadoVenta;
                numeroBoletaTextBox.Text = reclamo.NroBoleta;
                asuntoTextBox.Text = reclamo.Asunto;

                var boletaLista = new List<ServiciosTienda.CuProcesoReclamoBoletaDto>();
                var reclamoDetalle = reclamo;

                boletaLista.Add(reclamoDetalle);
                boletaDetDataGrid.ItemsSource = boletaLista;
            }
            
        }


        void servicio_AtenderReclamoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Reclamo Atendido Correctamente");
            }
        }

        void servicio_RegistrarReclamoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Reclamo Realizado Correctamente");
            }
        }

        void servicio_ObtenerBoletaCompleted(object sender, ServiciosTienda.ObtenerBoletaCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (!string.IsNullOrEmpty(e.Result.NombreProducto))
                {
                    nombreClienteTextBox.Text = e.Result.NombreProducto;
                }
                
                fechaTextBox.Text = e.Result.Fecha.ToShortDateString();
                estadoBoletaTextBox.Text = e.Result.descEstadoVenta;
                numeroBoletaTextBox.Text = e.Result.NroBoleta;

                var boletaLista = new List<ServiciosTienda.CuProcesoReclamoBoletaDto>();
                var reclamoDetalle = e.Result;

                boletaLista.Add(reclamoDetalle);
                boletaDetDataGrid.ItemsSource = boletaLista;
            }
            else
            {
                MessageBox.Show("Boleta no encontrada");
                this.Close();
            }
        }

        void FacturaVirtualChild_Loaded(object sender, RoutedEventArgs e)
        {
            if (_accion == "SOLICITAR")
            {
                asuntoGrid.Visibility = Visibility.Visible;
                asuntoTextBox.IsEnabled = true;
                solicitarButton.Visibility = Visibility.Visible;
                anularButton.Visibility = Visibility.Collapsed;
            }
            
            else if (_accion == "CONSULTAR")
            {
                asuntoGrid.Visibility = Visibility.Collapsed;
                asuntoTextBox.IsEnabled = false;
                solicitarButton.Visibility = Visibility.Collapsed;
                anularButton.Visibility = Visibility.Collapsed;
            }
            servicio.ObtenerBoletaAsync(_numeroBoleta);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void anularButton_Click(object sender, RoutedEventArgs e)
        {
            var cuReclamoSeleccionado = (ServiciosTienda.CuProcesoReclamoBoletaDto)boletaDetDataGrid.SelectedItem;
            if (cuReclamoSeleccionado != null)
            {
                servicio.AtenderReclamoAsync(cuReclamoSeleccionado.IdReclamo, cuReclamoSeleccionado.NroBoleta);
            }
            else
            {
                MessageBox.Show("Seleccione algun elemento del detalle de la venta");
            }
        }

        private void solicitarButton_Click(object sender, RoutedEventArgs e)
        {
            var cuReclamoSeleccionado = (ServiciosTienda.CuProcesoReclamoBoletaDto)boletaDetDataGrid.SelectedItem;
            if (cuReclamoSeleccionado != null)
            {
                cuReclamoSeleccionado.Asunto = asuntoTextBox.Text;
                servicio.RegistrarReclamoAsync(cuReclamoSeleccionado);

            }
            else
            {
                MessageBox.Show("Seleccione algun elemento del detalle de la venta");
            }
        }
    }
}

