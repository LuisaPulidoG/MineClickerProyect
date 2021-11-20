using System;
using System.Text.RegularExpressions;

namespace MineClicker.Validadores
{
    public class ValidadorEntrada
    {
        public bool EmailStructureValidator(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CompleteTextbox(string nombre)
        {
            if (nombre.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
