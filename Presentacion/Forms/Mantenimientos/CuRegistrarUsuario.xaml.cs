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
using Telerik.Windows.Controls;


namespace Presentacion.Forms.Mantenimientos
{
    public partial class CuRegistrarUsuario : UserControl
    {
        public ServiciosTienda.UsuarioDto usuarioPrincipal=new ServiciosTienda.UsuarioDto();
        public ServiciosTienda.ServiciosTiendaClient usuarioClient = new ServiciosTienda.ServiciosTiendaClient();
        private bool flagRegCliente = false;
        public CuRegistrarUsuario()
        {
            InitializeComponent();
            Loaded += (CuRegistrarUsuario_Loaded);
            usuarioClient.GuardarUsuarioCompleted += (usuarioClient_GuardarUsuarioCompleted);
        }
        public CuRegistrarUsuario(bool flagRegistrarCliente)
        {
            InitializeComponent();
            flagRegCliente = flagRegistrarCliente;
            if (flagRegCliente)
            {
                tipoUsuarioComboBox.Visibility = Visibility.Collapsed;
                tipoUsuarioBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                tipoUsuarioComboBox.Visibility = Visibility.Visible;
                tipoUsuarioBlock.Visibility = Visibility.Visible;
            }
            Loaded += (CuRegistrarUsuario_Loaded);
            usuarioClient.GuardarUsuarioCompleted += (usuarioClient_GuardarUsuarioCompleted);
            usuarioClient.GuardarClienteCompleted += (usuarioClient_GuardarClienteCompleted);
        }

        
        void CuRegistrarUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            tipoTarjetaComboBox.ItemsSource = Utilitarios.ValoresIniciales.TipoTarjetaLista;
            tipoUsuarioComboBox.ItemsSource = Utilitarios.ValoresIniciales.TipoUsuarioLista;
        }

        

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            foreach (var control in LayoutRoot.Children)
            {

                TextBox textControl = new TextBox();
                bool respuestaTextBox = false;
                try
                {
                    textControl = (TextBox)control;

                }
                catch (Exception ex)
                {
                    respuestaTextBox = true;
                }
                if (!(respuestaTextBox))
                { textControl.Text = ""; }
                else
                {
                    ComboBox comboControl = new ComboBox();
                    bool respuestaComboBox = false;
                    try
                    {
                        comboControl = (ComboBox)control;

                    }
                    catch (Exception ex)
                    {
                        respuestaComboBox = true;
                    }
                    if (!(respuestaComboBox))
                    { comboControl.SelectedValue = -1; }

                }
            }
            fechaNacimientoTextBox.Value = null;
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = VerificarDatosRequeridos();
            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje);
                return;
            }
                

            usuarioPrincipal.Nombres=nombresTextBox.Text;
            usuarioPrincipal.Apellidos = apellidosTextBox.Text;
            usuarioPrincipal.FechaNacimiento =Convert.ToDateTime(fechaNacimientoTextBox.Value);
            usuarioPrincipal.TelefonoFijo = telefonoFijoTextBox.Text;
            usuarioPrincipal.TelefonoMovil = telefonoMovilTextBox.Text;
            usuarioPrincipal.CorreoElectronico = correoTextBox.Text;
            usuarioPrincipal.Dni = dniTextBox.Text;
            usuarioPrincipal.Distrito = distritoTextBox.Text;
            usuarioPrincipal.Provincia = provinciaTextBox.Text;
            usuarioPrincipal.Departamento = departamentoTextBox.Text;
            usuarioPrincipal.CodigoPostal = codigoPostalTextBox.Text;
            usuarioPrincipal.Pais = paisTextBox.Text;
            usuarioPrincipal.NumeroTarjeta = nroTarjetaTextBox.Text;
            usuarioPrincipal.IdTipoTarjeta = Convert.ToInt32(tipoTarjetaComboBox.SelectedValue);
            usuarioPrincipal.Direccion = direccionTextBox.Text;
            usuarioPrincipal.IdTipoUsuario = Convert.ToInt32(tipoUsuarioComboBox.SelectedValue);
            usuarioPrincipal.NombreUsuario = usuarioTextBox.Text;
            usuarioPrincipal.Clave = claveTextBox.Text;
            //usuarioPrincipal.Clave=
            
            if (flagRegCliente)
            {
                usuarioClient.GuardarClienteAsync(usuarioPrincipal);
            }
            else
            {
                usuarioClient.GuardarUsuarioAsync(usuarioPrincipal);
            }

            
        }

        private string VerificarDatosRequeridos()
        {
            string respuesta = "";
            if(string.IsNullOrEmpty(nombresTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un nombre de usuario \n";
            }
            if (string.IsNullOrEmpty(apellidosTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un apellido de usuario \n";
            }
            if (fechaNacimientoTextBox.Value==null)
            {
                respuesta = respuesta + "Ingrese una fecha de nacimiento \n";
            }
            if (string.IsNullOrEmpty(telefonoFijoTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un telefono fijo \n";
            }
            if (string.IsNullOrEmpty(dniTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un dni \n";
            }
            if (string.IsNullOrEmpty(distritoTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un distrito \n";
            }
            if (string.IsNullOrEmpty(provinciaTextBox.Text))
            {
                respuesta = respuesta + "Ingrese una provincia \n";
            }
            if (string.IsNullOrEmpty(departamentoTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un departamento \n";
            }
            if (string.IsNullOrEmpty(paisTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un pais \n";
            }
            if (string.IsNullOrEmpty(nroTarjetaTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un numero de tarjeta de credito \n";
            }
            if (string.IsNullOrEmpty(direccionTextBox.Text))
            {
                respuesta = respuesta + "Ingrese una dirección \n";
            }

            if(tipoTarjetaComboBox.SelectedItem==null)
            {
                respuesta = respuesta + "Seleccione un tipo de tarjeta \n";
            }
            if(!flagRegCliente)
            {
                if (tipoUsuarioComboBox.SelectedItem == null)
                {
                    respuesta = respuesta + "Seleccione un tipo de usuario \n";
                }
            }
            if(string.IsNullOrEmpty(usuarioTextBox.Text))
            {
                respuesta = respuesta + "Ingrese un nombre de login \n";
            }

            if (string.IsNullOrEmpty(claveTextBox.Text))
            {
                respuesta = respuesta + "Ingrese una clave de usuario \n";
            }

            return respuesta; 
        }
            

        #region validaciones
        private void nombresTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloLetras(e);
        }

        private void apellidosTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloLetras(e);
        }

        private void telefonoFijoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }

        private void telefonoMovilTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }

        private void dniTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }

        private void distritoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloLetras(e);
        }

        private void provinciaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloLetras(e);
        }

        private void departamentoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloLetras(e);
        }

        private void paisTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloLetras(e);
        }

        private void codigoPostalTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void nroTarjetaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilitarios.Validaciones.ValidarSoloNumero(e);
        }
        #endregion
        void usuarioClient_GuardarUsuarioCompleted(object sender, ServiciosTienda.GuardarUsuarioCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Usuario Registrado Correctamente");
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }
        void usuarioClient_GuardarClienteCompleted(object sender, ServiciosTienda.GuardarClienteCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Cliente Registrado Correctamente");
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        



    }
}
