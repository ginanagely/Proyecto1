using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Presentacion.Utilitarios
{
    public static class  Validaciones
    {
        public static void ValidarSoloNumero(KeyEventArgs e)
        {
            var regex = new Regex("[0-9]");

            if (e.Key == Key.Tab || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
            else if (regex.IsMatch(e.Key.ToString()) || e.Key == Key.Decimal)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static void ValidarSoloLetras(KeyEventArgs e)
        {
            var regex = new Regex("[0-9]");

            if (e.Key == Key.Tab || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
            else if (!regex.IsMatch(e.Key.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static void ValidarNumeroConLetras(KeyEventArgs e)
        {
            var regex = new Regex("[a-zA-Z0-9]");

            if (e.Key == Key.Tab || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
            else if (regex.IsMatch(e.Key.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
    
        