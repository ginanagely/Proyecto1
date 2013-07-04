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

namespace Presentacion
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Utilitarios.ValoresIniciales.LlenarListas();
            MenuUserControl.RegUsuarioLink.Click += new RoutedEventHandler(RegUsuarioLink_Click);
            MenuUserControl.RegClienteLink.Click += new RoutedEventHandler(RegClienteLink_Click);
            MenuUserControl.ConfigurarIgvLink.Click += new RoutedEventHandler(ConfigurarIgvLink_Click);
            MenuUserControl.RegistrarProductoLink.Click += new RoutedEventHandler(RegistrarProductoLink_Click);
            MenuUserControl.ComprarProductoLink.Click += new RoutedEventHandler(ComprarProductoLink_Click);
            MenuUserControl.solicitarAnulacionBoletaLink.Click += new RoutedEventHandler(solicitarAnulacionBoletaLink_Click);
            MenuUserControl.anularBoletaLink.Click += new RoutedEventHandler(anularBoletaLink_Click);
            MenuUserControl.ventasRealizadasLink.Click += new RoutedEventHandler(ventasRealizadasLink_Click);
        }

        void ventasRealizadasLink_Click(object sender, RoutedEventArgs e)
        {
            var formulario = new Forms.Mantenimientos.Reportes();
            ContenidoFrame.Children.Clear();
            ContenidoFrame.Children.Add(formulario);
        }

        void anularBoletaLink_Click(object sender, RoutedEventArgs e)
        {
            var formulario = new Forms.Mantenimientos.MostrarReclamosUserControl();
            ContenidoFrame.Children.Clear();
            ContenidoFrame.Children.Add(formulario);
        }

        void solicitarAnulacionBoletaLink_Click(object sender, RoutedEventArgs e)
        {
             var formulario = new Forms.Mantenimientos.CuSolicitarAnulacionBoleta();
             ContenidoFrame.Children.Clear();
             ContenidoFrame.Children.Add(formulario);
        }

        void ComprarProductoLink_Click(object sender, RoutedEventArgs e)
        {
            var formulario = new Forms.Mantenimientos.CuBuscarProducto();
            ContenidoFrame.Children.Clear();
            ContenidoFrame.Children.Add(formulario);
        }

        void ConfigurarIgvLink_Click(object sender, RoutedEventArgs e)
        {
            var child = new Forms.Mantenimientos.CuConfigurarIgvChild();
            child.Show();
        }

        void RegistrarProductoLink_Click(object sender, RoutedEventArgs e)
        {
            var formulario = new Forms.Mantenimientos.CuRegistrarProducto();
            ContenidoFrame.Children.Clear();
            ContenidoFrame.Children.Add(formulario);
        }

        void RegClienteLink_Click(object sender, RoutedEventArgs e)
        {
            var formulario = new Forms.Mantenimientos.CuRegistrarUsuario(true);
            ContenidoFrame.Children.Clear();
            ContenidoFrame.Children.Add(formulario);
        }

        void RegUsuarioLink_Click(object sender, RoutedEventArgs e)
        {
            var formulario=new Forms.Mantenimientos.CuRegistrarUsuario(false);
            ContenidoFrame.Children.Clear();
            ContenidoFrame.Children.Add(formulario);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.Mantenimientos.CuLoginChild login = new Forms.Mantenimientos.CuLoginChild();
            login.Show();
            login.Closed += (login_Closed);
        }

        void login_Closed(object sender, EventArgs e)
        {
            var childPersonal = (ChildWindow)sender;
            if (childPersonal.DialogResult==true)
            {
                if (Utilitarios.ValoresIniciales.UsuarioClass.TipoUsuario == "ADMINISTRADOR")
                {
                    MenuUserControl.RadPanelBarReportes.Visibility = Visibility.Visible;
                    MenuUserControl.RegUsuarioLink.Visibility = Visibility.Visible;
                    MenuUserControl.RegistrarProductoLink.Visibility = Visibility.Visible;
                    MenuUserControl.ConfigurarIgvLink.Visibility = Visibility.Visible;
                    MenuUserControl.anularBoletaLink.Visibility = Visibility.Visible;
                    MenuUserControl.solicitarAnulacionBoletaLink.Visibility = Visibility.Visible;
                }
                else if (Utilitarios.ValoresIniciales.UsuarioClass.TipoUsuario == "CLIENTE")
                {
                    MenuUserControl.RadPanelBarReportes.Visibility = Visibility.Collapsed;
                    MenuUserControl.RegUsuarioLink.Visibility = Visibility.Collapsed;
                    MenuUserControl.RegistrarProductoLink.Visibility = Visibility.Collapsed;
                    MenuUserControl.ConfigurarIgvLink.Visibility = Visibility.Collapsed;
                    MenuUserControl.anularBoletaLink.Visibility = Visibility.Collapsed;
                    MenuUserControl.solicitarAnulacionBoletaLink.Visibility = Visibility.Visible;
                }
                usuarioTextBlock.Text = "BienVenido Sr(a) " + Utilitarios.ValoresIniciales.UsuarioClass.Nombre + ",Con el rol de " + Utilitarios.ValoresIniciales.UsuarioClass.TipoUsuario;
            }
            
        }
    }
}
