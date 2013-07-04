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
    public partial class CuSolicitarAnulacionBoleta : UserControl
    {
        public CuSolicitarAnulacionBoleta()
        {
            InitializeComponent();
        }

        private void buscarBoletaButton_Click(object sender, RoutedEventArgs e)
        {
            FacturaVirtualChild nuevaFactura = new FacturaVirtualChild(nroBoletaTextBox.Text,"SOLICITAR");
            nuevaFactura.Show();

        }
    }
}
