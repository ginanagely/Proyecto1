using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transversal;

namespace LogicaNegocios.CU
{
    public class CuBuscarProductoLogica
    {
        Datos.CuBuscarProducto dominio = new Datos.CuBuscarProducto();
        public IEnumerable<Transversal.ProductoDto> ObtenerProductoLista()
        {
            var productoListaDto = dominio.ObtenerProductoLista();
            return productoListaDto;
        }
        public IEnumerable<Transversal.ProductoDto> ObtenerProductoListaSegunCriterio(int idTipoMarca,string modelo,string  nombreProducto)
        {
            var productoListaDto=new List<ProductoDto>();
            if(idTipoMarca==0)
            {
                productoListaDto = dominio.ObtenerProductoListaSegunCriterio(modelo, nombreProducto);    
            }
            else
            {
                productoListaDto = dominio.ObtenerProductoListaSegunCriterio(idTipoMarca, modelo, nombreProducto);    
            }
            foreach (var productoDto in productoListaDto)
            {
                var productosComprados = dominio.ObtenerTotalProductosComprados(productoDto.IdProducto);
                var productosVendidos = dominio.ObtenerTotalProductosVendidos(productoDto.IdProducto);
                productoDto.Cantidad = productosComprados - productosVendidos;
                productoDto.NombreTipoMarca = dominio.ObtenerNombreTipoMarcaSegunId(productoDto.IdTipoMarca);
            }
            return productoListaDto;
        }
    }
}
