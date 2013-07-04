using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace LogicaNegocios.CU
{
    public class CuRealizarVentaLogica
    {
        Datos.CuRealizarVenta dominio = new Datos.CuRealizarVenta();
        public string ObtenerIgv()
        {
            var productoListaDto = dominio.ObtenerValorConfigByCodigo("01");
            return productoListaDto;
        }
        public string RegistrarVenta(Transversal.CuRealizarVentaDto ventaDto)
        {
            var respuestaEvento = "";
            using (var transaction = new TransactionScope())
            {

                var idProducto = ventaDto.IdProducto;
                var productosComprados = dominio.ObtenerTotalProductosComprados(idProducto);
                var productosVendidos = dominio.ObtenerTotalProductosVendidos(idProducto);
                if (productosComprados - productosVendidos >= ventaDto.Cantidad)
                {
                    
                    var NroBoletaDeVenta = dominio.ObtenerValorConfigByCodigo("02");
                    ventaDto.NumeroDocumento = NroBoletaDeVenta;
                    ventaDto.Operacion = true;
                    var idVenta = dominio.GuardarVenta(ventaDto);
                    ventaDto.IdVenta = idVenta;
                    dominio.GuardarVentaDetalle(ventaDto);
                    dominio.GuardarRegDiario(ventaDto);
                    var numeroVenta = Convert.ToInt32(NroBoletaDeVenta);
                    numeroVenta++;

                    dominio.ActualizarValorConfigByCodigo("02", numeroVenta.ToString());

                    respuestaEvento = ventaDto.NumeroDocumento;
                    
                }
                else
                {
                    respuestaEvento = "ERROR - PRODUCTOS INSUFICIENTES PARA PROCEDER CON LA COMPRA";
                    
                    
                }
                transaction.Complete();
            }
            return respuestaEvento;
        }
    }
}
