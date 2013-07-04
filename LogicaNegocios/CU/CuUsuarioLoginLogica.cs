using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.CU
{
    public class CuUsuarioLoginLogica
    {
        Datos.CuUsuarioLogin dominio = new Datos.CuUsuarioLogin();
        public Transversal.CuUsuarioLoginDto ObtenerUsuarioLogin(string nombreUsuario,string clave)
        {
            var productoListaDto = dominio.ObtenerPersonaListaSegunLogin(nombreUsuario,clave);
            return productoListaDto.FirstOrDefault();
        }
    }
}
