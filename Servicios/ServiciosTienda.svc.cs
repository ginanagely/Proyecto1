using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LogicaNegocios.CU;


namespace Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiciosTienda" in code, svc and config file together.
    public class ServiciosTienda : IServiciosTienda
    {
        LogicaNegocios.CU.CuRegistrarClienteLogica logica = new CuRegistrarClienteLogica();
        LogicaNegocios.CU.ValoresInicialesLogica logicaValoresIniciales = new ValoresInicialesLogica();
        CuRegistrarProductoLogica logicaRegProducto = new CuRegistrarProductoLogica();
        CuConfigurarIgv logicaConfigIgv = new CuConfigurarIgv();
        CuUsuarioLoginLogica logicaUsuarioLogin = new CuUsuarioLoginLogica();
        CuBuscarProductoLogica logicaBuscarProducto = new CuBuscarProductoLogica();
        CuRealizarVentaLogica logicaRealizarVenta = new CuRealizarVentaLogica();
        CuProcesoReclamoBoletaLogica logicaProcesoReclamo = new CuProcesoReclamoBoletaLogica();
        // logicaRealizarVenta = new CuRealizarVentaLogica();


        public int GuardarUsuario(Transversal.UsuarioDto usuarioDto)
        {
            var idUsuario = logica.GuardarUsuario(usuarioDto);
            return idUsuario;
        }

        public List<Transversal.TipoMarcaDto> ObtenerTipoMarca()
        {
            var tipoMarcaListaDto = logicaValoresIniciales.ObtenerTipoMarca();
            return tipoMarcaListaDto;
        }
        public List<Transversal.TipoUsuarioDto> ObtenerTipoUsuario()
        {
            var tipoUsuarioListaDto = logicaValoresIniciales.ObtenerTipoUsuario();
            return tipoUsuarioListaDto;
        }
        public List<Transversal.TipoTarjetaDto> ObtenerTipoTarjeta()
        {
            var tipoTarjetaListaDto = logicaValoresIniciales.ObtenerTipoTarjeta();
            return tipoTarjetaListaDto;
        }


        public int GuardarCliente(Transversal.UsuarioDto usuarioDto)
        {

            var idUsuario = logica.GuardarCliente(usuarioDto);
            return idUsuario;
        }

        
        public IEnumerable<Transversal.ProductoDto> ObtenerProductoLista()
        {
            var productoListaDto = logicaRegProducto.ObtenerProductoLista();
            return productoListaDto;
        }

        public Transversal.ProductoDto ObtenerProductoListaSegunCodigo(int codigo)
        {
            var productoListaDto = logicaRegProducto.ObtenerProductoListaSegunCodigo(codigo);
            return productoListaDto;
        }
        public void GuardarCuRegistrarProducto(Transversal.CuRegistrarProductoDto cuRegProductoDto)
        {
            logicaRegProducto.GuardarCuRegistrarProducto(cuRegProductoDto);
        }

        public string ObtenerIgv()
        {
            var productoListaDto = logicaConfigIgv.ObtenerIgv();
            return productoListaDto;
        }

        public void GuardarCuConfigurarIgv(string valor)
        {

            logicaConfigIgv.GuardarCuConfigurarIgv(valor);
            
        }
        
        public Transversal.CuUsuarioLoginDto ObtenerUsuarioLogin(string nombreUsuario, string clave)
        {
            var productoListaDto = logicaUsuarioLogin.ObtenerUsuarioLogin(nombreUsuario, clave);
            return productoListaDto;
        }

        public IEnumerable<Transversal.ProductoDto> BuscarProducto()
        {
            var productoListaDto = logicaBuscarProducto.ObtenerProductoLista();
            return productoListaDto;
        }

        public string ObtenerIgvVenta()
        {
            var productoListaDto = logicaRealizarVenta.ObtenerIgv();
            return productoListaDto;
        }

        public string RegistrarVenta(Transversal.CuRealizarVentaDto ventaDto)
        {
            var nroBoleta = logicaRealizarVenta.RegistrarVenta(ventaDto);
            return nroBoleta;
        }

        public Transversal.CuProcesoReclamoBoletaDto ObtenerBoleta(string numeroBoleta)
        {
            var boleta = logicaProcesoReclamo.BuscarBoletaSegunNumero(numeroBoleta);
            return boleta;
        }
        public IEnumerable<Transversal.CuProcesoReclamoBoletaDto> ObtenerReclamos()
        {
            return logicaProcesoReclamo.ObtenerReclamosLista();
        }

        public void RegistrarReclamo(Transversal.CuProcesoReclamoBoletaDto procesoDto)
        {
            logicaProcesoReclamo.SolicitarReclamo(procesoDto);
        }
        public void AtenderReclamo(int idReclamo,string nroDocumento)
        {
            logicaProcesoReclamo.ProcesarReclamo(idReclamo, nroDocumento);
        }

        public IEnumerable<Transversal.ProductoDto> BuscarProductoListaSegunCriterio(int idTipoMarca, string modelo, string nombreProducto)
        {
            return logicaBuscarProducto.ObtenerProductoListaSegunCriterio(idTipoMarca, modelo, nombreProducto);
        }
    }
}
