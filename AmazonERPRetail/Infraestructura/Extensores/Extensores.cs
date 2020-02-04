using System;
//using PresentationControls;
using System.Windows.Forms;

using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace Infraestructura.Extensores
{
    public static class Extensores
    {

        //public static string[] RecuperarValoresFiltro(this CheckBoxComboBox combobox)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string[] totales = combobox.Text.Split(',');
        //    List<string> listaCadenas = new List<string>();
            
        //    foreach (string item in totales)
        //    {
        //        if (item.Split('-')[0].Trim().Length > 0)
        //        {
        //            listaCadenas.Add(item.Split('-')[0].Trim());
        //        }
        //    }

        //    return listaCadenas.ToArray();
        //}

        /// <summary>
        /// Permite cambiar el fondo de un cuadro de texto
        /// </summary>
        /// <param name="Control">Cuadro a cambiar</param>
        /// <param name="enumTipo">Bloquear o desbloquear</param>
        public static void CambiaColorFondo(this Control Control, EnumTipoEdicionCuadros enumTipo, String Limpiar = "N")
        {
            switch (enumTipo)
            {
                case EnumTipoEdicionCuadros.Bloquear:
                    Control.Enabled = false;
                    Control.BackColor = Valores.ColorInabilitado;

                    if (Limpiar == Variables.SI)
                    {
                        if (Control is TextBox)
                        {
                            Control.Text = String.Empty;
                        }
                    }
                    else if (Limpiar == Variables.NO)
                    {

                    }
                    else if (Limpiar == "0")
                    {
                        if (Control is TextBox)
                        {
                            Control.Text = "0.00";
                        }
                    }

                    break;
                case EnumTipoEdicionCuadros.Desbloquear:
                    Control.Enabled = true;
                    Control.BackColor = Valores.ColorHabilitado;
                    break;
                case EnumTipoEdicionCuadros.Descuadrado:
                    Control.BackColor = Valores.ColorDescuadrado;
                    break;
                case EnumTipoEdicionCuadros.Positivo:
                    Control.BackColor = Valores.ColorInabilitado;
                    break;
                default:
                    break;
            }
        }

        public static void SeleccinarTodo(this TextBox Control)
        {
            if (!String.IsNullOrEmpty(Control.Text.Trim()))
            {
                if (Control.Text.Trim() == "0" || Control.Text.Trim() == "0.00" || Control.Text.Trim() == "0.000" || Control.Text.Trim() == "0.0000" || Control.Text.Trim() == "0.00000")
                {
                    Control.SelectAll(); 
                }
            }
        }

    }
}
