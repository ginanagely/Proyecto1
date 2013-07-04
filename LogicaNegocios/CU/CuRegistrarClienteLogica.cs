using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Transactions;

namespace LogicaNegocios.CU
{
   
    public class CuRegistrarClienteLogica
    {
        Datos.CuRegistrarCliente dominio = new CuRegistrarCliente();
        public int GuardarUsuario(Transversal.UsuarioDto usuarioDto)
        {
            int idUsuario = 0;
            using (var transaction = new TransactionScope())
            {
                idUsuario = dominio.GuardarUsuario(usuarioDto);
                usuarioDto.IdUsuario = idUsuario;
                dominio.GuardarLogin(usuarioDto);
                dominio.GuardarLogin(usuarioDto);
                transaction.Complete();
            }
            return idUsuario;
        }

        public int GuardarCliente(Transversal.UsuarioDto usuarioDto)
        {
            usuarioDto.IdTipoUsuario = (int)TipoUsuarioEnum.Cliente;
            int idUsuario = 0;
            using (var transaction = new TransactionScope())
            {
                
                idUsuario = dominio.GuardarUsuario(usuarioDto);
                usuarioDto.IdUsuario = idUsuario;
                dominio.GuardarLogin(usuarioDto);
                transaction.Complete();
            }

            return idUsuario;
        }

    }
}
