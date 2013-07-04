using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiciosTienda" in both code and config file together.
    [ServiceContract]
    public interface IServiciosTienda
    {
        [OperationContract]
        int GuardarUsuario(Transversal.UsuarioDto usuarioDto);

        [OperationContract]
        List<Transversal.TipoMarcaDto> ObtenerTipoMarca();

        [OperationContract]
        List<Transversal.TipoUsuarioDto> ObtenerTipoUsuario();

        [OperationContract]
        List<Transversal.TipoTarjetaDto> ObtenerTipoTarjeta();

        [OperationContract]
        int GuardarCliente(Transversal.UsuarioDto usuarioDto);

        [OperationContract]
        IEnumerable<Transversal.ProductoDto> ObtenerProductoLista();

        [OperationContract]
        Transversal.ProductoDto ObtenerProductoListaSegunCodigo(int codigo);

        [OperationContract]
        void GuardarCuRegistrarProducto(Transversal.CuRegistrarProductoDto cuRegProductoDto);

        [OperationContract]
        string ObtenerIgv();

        [OperationContract]
        void GuardarCuConfigurarIgv(string valor);

        [OperationContract]
        Transversal.CuUsuarioLoginDto ObtenerUsuarioLogin(string nombreUsuario, string clave);

        [OperationContract]
        IEnumerable<Transversal.ProductoDto> BuscarProducto();

        [OperationContract]
        string ObtenerIgvVenta();

        [OperationContract]
        string RegistrarVenta(Transversal.CuRealizarVentaDto ventaDto);

        [OperationContract]
        Transversal.CuProcesoReclamoBoletaDto ObtenerBoleta(string numeroBoleta);

        [OperationContract]
        IEnumerable<Transversal.CuProcesoReclamoBoletaDto> ObtenerReclamos();

        [OperationContract]
        void RegistrarReclamo(Transversal.CuProcesoReclamoBoletaDto procesoDto);

        [OperationContract]
        void AtenderReclamo(int idReclamo,string nroDocumento);

        [OperationContract]
        IEnumerable<Transversal.ProductoDto> BuscarProductoListaSegunCriterio(int idTipoMarca, string modelo,
                                                                               string nombreProducto);
    }
}
