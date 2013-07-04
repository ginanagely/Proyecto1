using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios
{
    public class UtilClass
    {

    }
    public enum TipoUsuarioEnum
    {
        Administrador=1,
        Cliente=2,
    }

    public enum EstadoVentaEnum
    {
        Realizada = 0,
        Entregada = 1,
        Anulada = 2,
    }
    public enum EstadoReclamoEnum
    {
        Solicitado = 0,
        Aceptado = 1,
    }
}
