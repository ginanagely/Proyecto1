using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Presentacion.Forms.Mantenimientos
{
    public partial class CuConfigurarIgvChild : ChildWindow
    {
        ServiciosTienda.ServiciosTiendaClient servicio = new ServiciosTienda.ServiciosTiendaClient();
        public CuConfigurarIgvChild()
        {
            InitializeComponent();
            Loaded += (CuConfigurarIgvChild_Loaded);
            servicio.ObtenerIgvCompleted += (servicio_ObtenerIgvCompleted);
            servicio.GuardarCuConfigurarIgvCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(servicio_GuardarCuConfigurarIgvCompleted);
        }

        void servicio_GuardarCuConfigurarIgvCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                this.DialogResult = true;
            }
            
        }

        void CuConfigurarIgvChild_Loaded(object sender, RoutedEventArgs e)
        {
            servicio.ObtenerIgvAsync();
        }

        
        void servicio_ObtenerIgvCompleted(object sender, ServiciosTienda.ObtenerIgvCompletedEventArgs e)
        {
            igvTextBox.Text ="IGV ACTUAL : "+ e.Result.ToString();
           
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nuevoIgvTextBox.Text))
            {
                MessageBox.Show("Debe de Ingresar un nuevo valor");
                return;
            }
            servicio.GuardarCuConfigurarIgvAsync(nuevoIgvTextBox.Text);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void nuevoIgvTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }
    }
}

