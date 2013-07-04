using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace LogicaNegocios.CU
{
    public class CuRegistrarProductoLogica
    {
        Datos.CuRegistrarProducto dominio = new Datos.CuRegistrarProducto();
        public IEnumerable<Transversal.ProductoDto> ObtenerProductoLista()
        {
            var productoListaDto = dominio.ObtenerProductoLista();
            return productoListaDto;
        }

        public Transversal.ProductoDto ObtenerProductoListaSegunCodigo(int codigo)
        {
            var productoListaDto = dominio.ObtenerProductoListaSegunCodigo(codigo);
            return productoListaDto.FirstOrDefault();
        }

        public void GuardarCuRegistrarProducto(Transversal.CuRegistrarProductoDto cuRegProductoDto)
        {
            using (var transaction = new TransactionScope())
            {
                cuRegProductoDto.Fecha = DateTime.Now;
                cuRegProductoDto.Operacion = false;
                cuRegProductoDto.EstadoRegistro = true;

                if (cuRegProductoDto.IdProducto == 0)
                {
                    var idProducto = dominio.GuardarProducto(cuRegProductoDto);
                    cuRegProductoDto.IdProducto = idProducto;

                }
                
                dominio.GuardarRegistroDiario(cuRegProductoDto);
                transaction.Complete();
            }
        }

    }
}
