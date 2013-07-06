using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.CU
{
    public class CuVentaCelularLogica:CuRealizarVentaLogica
    {
        Datos.CuVentaCelular dominioCelular = new Datos.CuVentaCelular();
        public string RealizarVentaProductoSegunTextSintaxis(string sintaxis)
        {
            var cadenaRespuesta="";
            //*usuario-login*clave*idProducto*cantidad*contraseña tarjeta,
            try
            {
            
                var datosVenta = sintaxis.Split('*');
                var nombreUsuario = datosVenta[0].Trim();
                var claveUsuario = datosVenta[1].Trim();
                var idProducto = datosVenta[2].Trim();
                var cantidad = datosVenta[3].Trim();
                var claveTarjeta = datosVenta[4].Trim();
                //verificar usuario
                //verificar Producto
                //verificar VerificarTarjeta
            
                var usuarioListaDto = dominioCelular.ObtenerPersonaListaSegunLogin(nombreUsuario,claveUsuario);
                var usuario=usuarioListaDto.FirstOrDefault();
                if(usuario==null)
                {
                    cadenaRespuesta = "ERROR: Usuario ingresado No Valido";

                }
                else
                {
                    var productoListaDto = dominioCelular.ObtenerProductoSegunIdLista(Convert.ToInt32(idProducto));
                    var producto=productoListaDto.FirstOrDefault();
                    if(producto==null)
                    {
                        cadenaRespuesta = "ERROR: Codigo Producto No Valido";
                    }
                    else
                    {

                        var ventaDto = new Transversal.CuRealizarVentaDto();
                        ventaDto.claveUsuario = claveUsuario;
                        
                        ventaDto.Cantidad = Convert.ToInt32(cantidad);
                        ventaDto.IdUsuario = usuario.IdUsuario;
                        ventaDto.IdCliente = usuario.IdUsuario;
                        ventaDto.PrecioUnitario = producto.Precio;
                        var igvLista = ObtenerIgv();
                        var igv = igvLista.FirstOrDefault();
                        ventaDto.IdProducto = Convert.ToInt32(idProducto);
                        ventaDto.Igv = igv;
                        var precioBruto = ventaDto.PrecioUnitario * ventaDto.Cantidad;
                        var precioIgv = precioBruto * ventaDto.Igv;
                        ventaDto.Total = precioBruto + precioIgv;
                        var respuesta = RegistrarVenta(ventaDto);
                        if (respuesta.Contains("ERROR"))
                        {
                            cadenaRespuesta = respuesta;
                        }
                        else
                        {
                            cadenaRespuesta = "OK";
                        }
                    }
                
                }

            }
            catch
            {
                //cadenaRespuesta="ERROR: en sintaxis recibida";
                cadenaRespuesta = "ERROR: en sintaxis ";
                
            }
            

           
            return cadenaRespuesta;
        }
    }
}
