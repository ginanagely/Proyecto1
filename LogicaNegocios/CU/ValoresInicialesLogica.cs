using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;

namespace LogicaNegocios.CU
{
    public class ValoresInicialesLogica
    {
        Datos.ValoresIniciales dominio = new ValoresIniciales();
        public List<Transversal.TipoMarcaDto> ObtenerTipoMarca()
        {
            var tipoMarcaListaDto = dominio.ObtenerTipoMarca();
            return tipoMarcaListaDto;
        }
        public List<Transversal.TipoUsuarioDto> ObtenerTipoUsuario()
        {
            var tipoUsuarioListaDto = dominio.ObtenerTipoUsuario();
            return tipoUsuarioListaDto;
        }
        public List<Transversal.TipoTarjetaDto> ObtenerTipoTarjeta()
        {
            var tipoTarjetaListaDto = dominio.ObtenerTipoTarjeta();
            return tipoTarjetaListaDto;
        }
    }
}
