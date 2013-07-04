using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.CU
{
    public class CuProcesoReclamoBoletaLogica
    {
        Datos.CuProcesoReclamoBoleta dominio = new Datos.CuProcesoReclamoBoleta();
        public Transversal.CuProcesoReclamoBoletaDto BuscarBoletaSegunNumero(string numeroDocumento)
        {
            var ventaLista = dominio.ObtenerVentaSegunNumeroDocumentoLista(numeroDocumento);

            var venta = ventaLista.FirstOrDefault();
            var ventaDetLista = dominio.ObtenerVentaDetalleIdVenta(venta.IdVenta);
            var ventaDet = ventaDetLista.FirstOrDefault();
            venta.IdProducto = ventaDet.IdProducto;
            setearEstadoVenta(venta);
            setearDatosReclamo(venta);
            
            return venta;
        }
        private void setearEstadoVenta(Transversal.CuProcesoReclamoBoletaDto ventaDto)
        {
            if (ventaDto.estadoVenta == (int)EstadoVentaEnum.Realizada)
            {
                ventaDto.descEstadoVenta = "VENTA REALIZADA";
            }
            else if (ventaDto.estadoVenta == (int)EstadoVentaEnum.Entregada)
            {
                ventaDto.descEstadoVenta = "VENTA ENTREGADA";
            }
            else if (ventaDto.estadoVenta == (int)EstadoVentaEnum.Anulada)
            {
                ventaDto.descEstadoVenta = "VENTA ANULADA";
            }
        }

        private void setearEstadoReclamo(Transversal.CuProcesoReclamoBoletaDto ventaDto)
        {
            if (ventaDto.estadoReclamo == (int)EstadoReclamoEnum.Solicitado)
            {
                ventaDto.descEstadoReclamo = "SOLICITUD PENDIENTE";
            }
            else if (ventaDto.estadoReclamo == (int)EstadoReclamoEnum.Aceptado)
            {
                ventaDto.descEstadoReclamo = "SOLICITUD PROCEDENTE";
            }
            
        }

        private void setearDatosReclamo(Transversal.CuProcesoReclamoBoletaDto ventaDto)
        {
            var producto = dominio.ObtenerProductoSegunId(ventaDto.IdProducto);
            if (producto != null)
            {
                ventaDto.NombreProducto = producto.NOMBRE;
            }
            var usuario = dominio.ObtenerUsuarioSegunId(ventaDto.IdUsuario);
            if (usuario != null)
            {
                ventaDto.NombreUsuario = usuario.NOMBRES + ", " + usuario.APELLIDOS;
            }
            var ventaDetLista = dominio.ObtenerVentaDetalleIdVenta(ventaDto.IdVenta);
            var ventaDet = ventaDetLista.FirstOrDefault();
            if (ventaDet != null)
            {
                ventaDto.Cantidad = ventaDet.Cantidad;
                ventaDto.PrecioTotal = ventaDet.PrecioTotal;

            }
        }

        public IEnumerable<Transversal.CuProcesoReclamoBoletaDto> ObtenerReclamosLista()
        {
            var reclamoLista = dominio.ObtenerReclamoLista();
            foreach (var reclamo in reclamoLista)
            {
               var ventaLista = dominio.ObtenerVentaListaSegunId(reclamo.IdVenta);
               var venta = ventaLista.FirstOrDefault();
               if (venta != null)
               {
                   var ventaDetLista = dominio.ObtenerVentaDetalleIdVenta(venta.IdVenta);
                   var ventaDet = ventaDetLista.FirstOrDefault();
                   reclamo.IdProducto = ventaDet.IdProducto;
                   reclamo.IdUsuario = venta.IdUsuario;
                   reclamo.NroBoleta = venta.NroBoleta;
                   reclamo.estadoVenta = venta.estadoVenta;

                   setearEstadoVenta(reclamo);
                   setearDatosReclamo(reclamo);
                   setearEstadoReclamo(reclamo);
               }
            }
            return reclamoLista;
        }
        public void SolicitarReclamo(Transversal.CuProcesoReclamoBoletaDto reclamoDto)
        {
            
            reclamoDto.estadoReclamo = (int)EstadoReclamoEnum.Solicitado;
            dominio.RegistrarReclamo(reclamoDto);
        }
        public void ProcesarReclamo(int idReclamo,string nroDocumento)
        {
            dominio.ActualizarEstadoRegistroDiarioSegunNroDocumento(0, nroDocumento);
            dominio.ActualizarEstadoVentaSegunNroDocumento((int)EstadoVentaEnum.Anulada,nroDocumento);
            dominio.ActualizarEstadoReclamo((int)EstadoReclamoEnum.Aceptado, idReclamo);
        }
    }
}
