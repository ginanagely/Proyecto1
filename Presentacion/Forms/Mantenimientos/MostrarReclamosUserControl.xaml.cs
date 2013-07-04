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
    public partial class MostrarReclamosUserControl : UserControl
    {
        ServiciosTienda.ServiciosTiendaClient Servicio = new ServiciosTienda.ServiciosTiendaClient();
        public MostrarReclamosUserControl()
        {
            InitializeComponent();
            Loaded += (MostrarReclamosUserControl_Loaded);
        }

        void MostrarReclamosUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Servicio.ObtenerReclamosAsync();
            Servicio.ObtenerReclamosCompleted += new EventHandler<ServiciosTienda.ObtenerReclamosCompletedEventArgs>(Servicio_ObtenerReclamosCompleted);
        }

        void Servicio_ObtenerReclamosCompleted(object sender, ServiciosTienda.ObtenerReclamosCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                reclamosDataGrid.ItemsSource = e.Result;
            }
        }

        private void SeleccionarButton_Click(object sender, RoutedEventArgs e)
        {
            var reclamoDto = (ServiciosTienda.CuProcesoReclamoBoletaDto)reclamosDataGrid.SelectedItem;
            if (reclamoDto != null)
            {
                FacturaVirtualChild ventana = new FacturaVirtualChild(reclamoDto);
                ventana.Show();
            }
            
        }
    }
}
