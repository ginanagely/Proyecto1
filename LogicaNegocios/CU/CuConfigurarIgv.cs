using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.CU
{
    public class CuConfigurarIgv
    {
        Datos.CuConfigurarIgv dominio = new Datos.CuConfigurarIgv();
        public string ObtenerIgv()
        {
            var productoListaDto = dominio.ObtenerValorConfigByCodigo("01");
            return productoListaDto;
        }

        public void GuardarCuConfigurarIgv(string valor)
        {
            using (var transaction = new System.Transactions.TransactionScope())
            {
                dominio.ActualizarValorConfigByCodigo("01",valor);
                transaction.Complete();
            }
        }
    }
}
