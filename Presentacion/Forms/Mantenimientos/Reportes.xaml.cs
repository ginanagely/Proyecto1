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
using Telerik.ReportViewer.Silverlight;

namespace Presentacion.Forms.Mantenimientos
{
    public partial class Reportes : UserControl
    {
        private ReportViewer _visualizarReporte;
        private string _tituloReporte;
        private string _nombreReporte;
        public Reportes()
        {
            InitializeComponent();
            _visualizarReporte = new ReportViewer();
            Loaded += new RoutedEventHandler(Reportes_Loaded);
        }

        void Reportes_Loaded(object sender, RoutedEventArgs e)
        {
            //  this.DialogResult = true;


            _nombreReporte = "Reportes.ReporteTienda.ReporteVentasRealizadasSegunFecha,Reportes";
            _tituloReporte = "Reporte Ventas";
            _visualizarReporte.HorizontalAlignment = HorizontalAlignment.Stretch;
            _visualizarReporte.VerticalAlignment = VerticalAlignment.Stretch;
            try
            {
                LayoutRoot.Children.Clear();
                LayoutRoot.Children.Add(_visualizarReporte);
            }
            catch
            {
                LayoutRoot.Children.Add(_visualizarReporte);
            }

            _visualizarReporte.ZoomPercent = 89;
            LayoutRoot.HorizontalAlignment = HorizontalAlignment.Stretch;
            LayoutRoot.VerticalAlignment = VerticalAlignment.Stretch;
            _visualizarReporte.Report = _nombreReporte;

            _visualizarReporte.ReportServiceUri = new Uri("http://localhost:39835/ServicioReportes.svc");
            _visualizarReporte.RenderBegin += VisualizarReporteRenderBegin;
        }
        void VisualizarReporteRenderBegin(object sender, RenderBeginEventArgs args)
        {

            
            _visualizarReporte.RenderBegin -= VisualizarReporteRenderBegin;
        }
    }
}
