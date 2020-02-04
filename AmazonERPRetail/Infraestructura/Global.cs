using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml;
using System.Text;

using Infraestructura.Recursos;

namespace Infraestructura
{
    public class Global
    {

        public static void BloquearControlesInterno(GroupBox groupBox, Boolean bloquear)
        {
            foreach (Control item in groupBox.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).ReadOnly = bloquear;
                }
                else if (item is Button)
                {
                    ((Button)item).Enabled = !bloquear;
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Enabled = !bloquear;
                }
                else if (item is DataGridView)
                {
                    ((DataGridView)item).Enabled = !bloquear;
                }
                else if (item is GroupBox)
                {
                    BloquearControlesInterno((GroupBox)item, !bloquear);
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)item).Enabled = !bloquear;
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Enabled = !bloquear;
                }
            }
        }

        public static void BloquearPanelControlesInterno(Panel panel, Boolean bloquear)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).ReadOnly = bloquear;
                }
                else if (item is Button)
                {
                    ((Button)item).Enabled = !bloquear;
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Enabled = !bloquear;
                }
                else if (item is DataGridView)
                {
                    ((DataGridView)item).Enabled = !bloquear;
                }
                else if (item is GroupBox)
                {
                    BloquearControlesInterno((GroupBox)item, !bloquear);
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Enabled = !bloquear;
                }
            }
        }

        public static void LimpiarControlesGroupBox(GroupBox groupBox)
        {
            foreach (Control item in groupBox.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = -1;
                }
                else if (item is GroupBox)
                {
                    LimpiarControlesGroupBox((GroupBox)item);
                }
            }
        }

        public static void LimpiarControlesPaneles(Panel panel)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
                //else if (item is ComboBox)
                //{
                //    ((ComboBox)item).SelectedIndex = -1;
                //}
                //else if (item is Panel)
                //{
                //    LimpiarControlesInternoPaneles((Panel)item);
                //}
            }
        }

        #region Cuadros - Mensajes

        public static void MensajeAdvertencia(String mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static void MensajeComunicacion(String mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static void MensajeFault(String mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult MensajeConfirmacion(String Mensaje, MessageBoxDefaultButton BotonDefecto = MessageBoxDefaultButton.Button1)
        {
            return MessageBox.Show(Mensaje, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, BotonDefecto);
        }

        public static void MensajeError(String mensaje)
        {
            MessageBox.Show(Mensajes.ErrorInesperado + "\n" + mensaje, "Aviso de Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        #endregion

        public static void EventoEnter(KeyEventArgs e, Button Boton)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Boton.PerformClick();
                    break;
                default:
                    break;
            }
        }

        public static void CalcularAnchoGrilla(Int32 WidthRowHeader, DataGridView Grid)
        {
            Int32 c = 0;
            //Int32 wc = 0;
            foreach (DataGridViewColumn col in Grid.Columns)
            {
                if (col.Visible)
                {
                    //if (col.Width > 200)
                    //{
                    //    wc += col.Width;
                    //}
                    //else {
                    c += 1;
                    //}
                }
            }

            //Int32 Wcolumns = ((Grid.Width - Grid.RowHeadersWidth - wc) / c);
            Int32 Wcolumns = ((Grid.Width - Grid.RowHeadersWidth) / c);

            foreach (DataGridViewColumn item in Grid.Columns)
            {
                //if (item.Width < 200)
                //{
                item.Width = (Wcolumns - WidthRowHeader);
                //}
                //else {
                //    item.Width = (wc - 6);
                //}
            }
        }

        #region Funciones de Cadena

        public static String Derecha(String Parametro, Int32 Caracteres)
        {
            Int32 valor = Parametro.Length - Caracteres;
            String resultado = Parametro.Substring(valor, Caracteres);
            return resultado;
        }

        public static String Izquierda(String Parametro, Int32 Caracteres)
        {
            String resultado = Parametro.Substring(0, Caracteres);
            return resultado;
        }

        public static String Extraer(String Parametro, Int32 Inicio, Int32 Caracteres)
        {
            String resultado = Parametro.Substring(Inicio, Caracteres);
            return resultado;
        }

        public static String Extraer(String Parametro, Int32 Inicio)
        {
            String resultado = Parametro.Substring(Inicio);
            return resultado;
        }

        public static String PrimeraMayuscula(String Valor)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Valor);
        }

        public static String DejarSoloUnEspacio(String Cadena)
        {
            try
            {
                return Regex.Replace(Cadena, @"\s+", " ");
                //return new Regex(@"\s+").Replace(Cadena, " "); //Combinacion de las 2 opciones abajo
                //return new Regex(@"\s*").Replace(str, String.Empty); // Quita completamente los espacios en blanco
                //System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " "); // Quita los espacios en blanco dejando un solo espacio
            }
            catch (Exception)
            {
                return Cadena;
            }
        }

        public static String Reemplazar(String Cadena, int Indice, int Longi, string cadReemplazo)
        {
            StringBuilder sbCad = new StringBuilder();
            sbCad.Append(Cadena.Substring(Indice, Longi));
            sbCad.Append(cadReemplazo);
            sbCad.Append(Cadena.Substring(Indice + Longi));

            return sbCad.ToString();
        }

        public static String ReemplazarFormula(String Cadena, int Indice, int Longi, string cadReemplazo)
        {
            StringBuilder sbCad = new StringBuilder();
            sbCad.Append(Cadena.Substring(0, Indice));
            sbCad.Append(cadReemplazo);
            sbCad.Append(Cadena.Substring(Indice + Longi));

            return sbCad.ToString();
        }

        #endregion

        #region DataTable

        public static DataTable CargarTipoReporteEEFF()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdTipoReporte");
            output.Columns.Add("TipoReporte");

            DataRow dt;

            dt = output.NewRow();
            dt["IdTipoReporte"] = "B";
            dt["TipoReporte"] = "BALANCE";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdTipoReporte"] = "R";
            dt["TipoReporte"] = "RESULTADO";
            output.Rows.Add(dt);

            return output;
        }

        public static DataTable CargarDigitosEEFF()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdDigito");
            output.Columns.Add("Digito");

            DataRow dt;

            dt = output.NewRow();
            dt["IdDigito"] = "1";
            dt["Digito"] = "1 DIGITOS";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdDigito"] = "2";
            dt["Digito"] = "2 DIGITOS";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdDigito"] = "3";
            dt["Digito"] = "3 DIGITOS";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdDigito"] = "4";
            dt["Digito"] = "4 DIGITOS";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdDigito"] = "5";
            dt["Digito"] = "5 DIGITOS";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdDigito"] = "6";
            dt["Digito"] = "6 DIGITOS";
            output.Rows.Add(dt);

            return output;
        }

        public static DataTable CargarTipoItemEEFF()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdTipoItem");
            output.Columns.Add("TipoItem");

            DataRow dt;

            dt = output.NewRow();
            dt["IdTipoItem"] = 1;
            dt["TipoItem"] = "Presentar el valor Normal";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdTipoItem"] = 2;
            dt["TipoItem"] = "Presentar el valor en Negativo";
            output.Rows.Add(dt);

            return output;
        }

        public static DataTable CargarTipoColumnaEEFFItem()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdColumna");
            output.Columns.Add("Columna");

            DataRow dt;

            dt = output.NewRow();
            dt["IdColumna"] = "1";
            dt["Columna"] = "Valor Normal";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdColumna"] = "2";
            dt["Columna"] = "Invertir Signo";
            output.Rows.Add(dt);

            return output;
        }

        public static DataTable CargarTipoTablaEEFFItem()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdTipoTabla");
            output.Columns.Add("TipoTabla");

            DataRow dt;

            dt = output.NewRow();
            dt["IdTipoTabla"] = "DET";
            dt["TipoTabla"] = "DETALLE";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdTipoTabla"] = "TIT";
            dt["TipoTabla"] = "TITULO";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdTipoTabla"] = "TOT";
            dt["TipoTabla"] = "TOTAL";
            output.Rows.Add(dt);


            return output;
        }

        public static DataTable CargarTipoCaracteristicaEEFFItem()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdCaracteristica");
            output.Columns.Add("Caracteristica");

            DataRow dt;

            dt = output.NewRow();
            dt["IdCaracteristica"] = "BOX";
            dt["Caracteristica"] = "BOX";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCaracteristica"] = "CUR";
            dt["Caracteristica"] = "CURSIVA";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCaracteristica"] = "LIN";
            dt["Caracteristica"] = "LINEA";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCaracteristica"] = "NEG";
            dt["Caracteristica"] = "NEGRITA";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCaracteristica"] = "NOR";
            dt["Caracteristica"] = "NORMAL";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCaracteristica"] = "POR";
            dt["Caracteristica"] = "PORCENTAJE";
            output.Rows.Add(dt);


            return output;
        }

        public static DataTable CargarCondicionEEFFItem()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdCondicion");
            output.Columns.Add("Condicion");

            DataRow dt;

            dt = output.NewRow();
            dt["IdCondicion"] = ">";
            dt["Condicion"] = "MAYOR QUE CERO";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCondicion"] = "<";
            dt["Condicion"] = "MENOR QUE CERO";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdCondicion"] = "=";
            dt["Condicion"] = "AMBOS";
            output.Rows.Add(dt);

            return output;
        }

        public static DataTable CargarOperacionEEFFItem()
        {
            DataTable output = new DataTable();
            output.Columns.Add("IdOperacion");
            output.Columns.Add("Operacion");

            DataRow dt;

            dt = output.NewRow();
            dt["IdOperacion"] = "+";
            dt["Operacion"] = "SUMAR";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["IdOperacion"] = "-";
            dt["Operacion"] = "RESTAR";
            output.Rows.Add(dt);


            return output;
        }

        public static DataTable CargarTipoCalculoDepreciacion()
        {
            DataTable output = new DataTable();
            output.Columns.Add("CodId");
            output.Columns.Add("NomTipo");

            DataRow dt;
            dt = output.NewRow();
            dt["CodId"] = 0;
            dt["NomTipo"] = "Contable/Financiero";
            output.Rows.Add(dt);

            dt = output.NewRow();
            dt["CodId"] = 1;
            dt["NomTipo"] = "Tributario";
            output.Rows.Add(dt);

            return output;
        }

        public static DataTable CargarDH()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "Deudor";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "H";
            Fila["Nombre"] = "Acreedor";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarAC()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "Abierto";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Cerrado";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoDscto()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "01";
            Fila["Nombre"] = "Dscto Ley";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "02";
            Fila["Nombre"] = "SPP";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoPlaDscto()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Retencion";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "2";
            Fila["Nombre"] = "Aporte";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarMN()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "Mostrar";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "No mostrar";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarMV()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "M";
            Fila["Nombre"] = "En Muestra";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "V";
            Fila["Nombre"] = "En Venta";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarAI()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "Activo";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "I";
            Fila["Nombre"] = "Inactivo";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarAID()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "Activo";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Inactivo";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarABD()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "Activo";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Baja";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarIE()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "I";
            Fila["Nombre"] = "Ingreso";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "Egreso";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarLTD()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "Liquidacion";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Temporada";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "2";
            Fila["Nombre"] = "Diferida";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTitDet()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "TI";
            Fila["Nombre"] = "TITULO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "DE";
            Fila["Nombre"] = "DETALLE";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarVentaCompra()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "<<SELECCIONE>>";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "COMPRA";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "VENTA";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoReparable()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "NORMAL";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "R";
            Fila["Nombre"] = "REPARABLE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "B";
            Fila["Nombre"] = "BOLETAS";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoFacturacion()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "M";
            Fila["Nombre"] = "MECANIZADA";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "F.E. DIRECTA";
            oDt.Rows.Add(Fila);


            Fila = oDt.NewRow();
            Fila["id"] = "B";
            Fila["Nombre"] = "F.E. BIZLINKS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "F.E. PAPERLESS";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarUbl()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "20";
            Fila["Nombre"] = "UBL 2.0";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "21";
            Fila["Nombre"] = "UBL 2.1";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarEsGuia()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "FACT";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "G";
            Fila["Nombre"] = "GUIA";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "EXPORT";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "SERVICIO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "O";
            Fila["Nombre"] = "OTROS";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoTransporte()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = Variables.Seleccione;
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "M";
            Fila["Nombre"] = "MARITIMO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "AEREO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "T";
            Fila["Nombre"] = "TERRESTRE";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoCalculo()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = Variables.Seleccione;
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "CANTIDAD";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "PESO";
            oDt.Rows.Add(Fila);
            
            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "FOB";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoNivel()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = Variables.Seleccione;
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "DETALLE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "SUB-TOTAL";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarEstadoSerie()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "En Curso";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "Finalizado";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Pendiente";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarEstadoDocumento()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Creado";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "Emitido";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "Facturado";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarEstadoRetencion()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Creado";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "Emitido";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "Anulado";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarMesParaInt()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "01";
            Fila["Nombre"] = "ENERO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "02";
            Fila["Nombre"] = "FEBRERO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "03";
            Fila["Nombre"] = "MARZO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "04";
            Fila["Nombre"] = "ABRIL";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "05";
            Fila["Nombre"] = "MAYO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "06";
            Fila["Nombre"] = "JUNIO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "07";
            Fila["Nombre"] = "JULIO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "08";
            Fila["Nombre"] = "AGOSTO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "09";
            Fila["Nombre"] = "SETIEMBRE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "10";
            Fila["Nombre"] = "OCTUBRE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "11";
            Fila["Nombre"] = "NOVIEMBRE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "12";
            Fila["Nombre"] = "DICIEMBRE";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarContadoCredito()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "Contado";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "Crédito";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarGrupoDocumentos()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "Facturas";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "B";
            Fila["Nombre"] = "Boletas";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Notas de Crédito";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "Notas de Débito";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "G";
            Fila["Nombre"] = "Guias de Remisión";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Pedidos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "T";
            Fila["Nombre"] = "Cotizaciones";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarCiudad()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "01";
            Fila["Nombre"] = "LIMA";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "02";
            Fila["Nombre"] = "ICA";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarPoPer()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "EMPLEADO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "O";
            Fila["Nombre"] = "OBRERO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarGenero()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "M";
            Fila["Nombre"] = "Masculino";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "Femenino";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarGastosExportacion()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "EM";
            Fila["Nombre"] = "Embalaje";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "FL";
            Fila["Nombre"] = "Flete";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "SE";
            Fila["Nombre"] = "Seguro";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "GA";
            Fila["Nombre"] = "Gastos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "OT";
            Fila["Nombre"] = "Otros";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoNumeracion()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = Variables.Seleccione;
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Consecutivo";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "2";
            Fila["Nombre"] = "Por año";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "3";
            Fila["Nombre"] = "Por año  y mes";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarUbicacionGenerica()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "X";
            Fila["Nombre"] = "Ninguna";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "Generica";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "Ubicacion Definida";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Por Posicion Disponible";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarFPCE()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "F";
            Fila["Nombre"] = "Free";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Paid";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Costos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "Existencia";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoSaldo()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "Ambos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Cuadrados";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "Diferencia";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarAfectacionAlmacenNC()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = 0;
            Fila["Nombre"] = "Ninguno";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 1;
            Fila["Nombre"] = "Devolucion";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 2;
            Fila["Nombre"] = "Descuento";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoOpe()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = 1;
            Fila["Nombre"] = "Costo De Venta";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 2;
            Fila["Nombre"] = "Consumo";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoAnticipo()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = 0;
            Fila["Nombre"] = "PENDIENTES";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 1;
            Fila["Nombre"] = "DETALLADO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarMontoCantidad(Boolean Ultimo = false)
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Monto";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "2";
            Fila["Nombre"] = "Cantidad";
            oDt.Rows.Add(Fila);

            if (Ultimo)
            {
                Fila = oDt.NewRow();
                Fila["id"] = "3";
                Fila["Nombre"] = "U.Medida";
                oDt.Rows.Add(Fila);
            }

            return oDt;
        }

        public static DataTable CargarCP()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Cobranzas";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Provision";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarPC()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Pendientes";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "Cerradas";
            oDt.Rows.Add(Fila);


            return oDt;
        }

        public static DataTable CargarPeriodo()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Periodo Actual";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "8";
            Fila["Nombre"] = "Periodo Anterior No Declarado";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "9";
            Fila["Nombre"] = "Periodo Anterior Si Declarado";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoCCosto()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "Administracion";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "2";
            Fila["Nombre"] = "Ventas";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "3";
            Fila["Nombre"] = "Produccion";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoConcepto()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "11";
            Fila["Nombre"] = "<<TODOS>>";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "REFERENCIALES";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "INGRESOS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "2";
            Fila["Nombre"] = "RETENCIONES";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "3";
            Fila["Nombre"] = "OTROS DSCTOS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "4";
            Fila["Nombre"] = "APORTACIONES";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "SISTEMA";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoDato()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "DIAS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "H";
            Fila["Nombre"] = "HORAS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "M";
            Fila["Nombre"] = "MONTO O NINGUNO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarAfectosDias()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "SI";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "NO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoFondo()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "102";
            Fila["Nombre"] = "Fondos Fijos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "168";
            Fila["Nombre"] = "Entregas a Rendir";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarSelectivo()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("NOMBRE");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "PORCENTAJE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "L";
            Fila["Nombre"] = "LITRO";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "NINGUNO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoAuxiliar()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "<<Seleccione>>";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "CL";
            Fila["Nombre"] = "Clientes";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "PR";
            Fila["Nombre"] = "Proveedores";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "BA";
            Fila["Nombre"] = "Bancos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "PE";
            Fila["Nombre"] = "Personal";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "FF";
            Fila["Nombre"] = "Fondos Fijos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "CR";
            Fila["Nombre"] = "Cuentas a Rendir";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarSNID()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "Si";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "No";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarSN(Boolean PrimeraLinea = false)
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            if (PrimeraLinea)
            {
                Fila = oDt.NewRow();
                Fila["id"] = "A";
                Fila["Nombre"] = "<<SEL.>>";
                oDt.Rows.Add(Fila);
            }

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "SI";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "NO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarPL()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "%";
            Fila["Nombre"] = "Porcentaje";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "L";
            Fila["Nombre"] = "Litro";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarMA()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "M";
            Fila["Nombre"] = "Mensual";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "Acumulado";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoPartida()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "GA";
            Fila["Nombre"] = "Gastos - Partidas";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "RE";
            Fila["Nombre"] = "Recursos - Rubros";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarModoCompra()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "I";
            Fila["Nombre"] = "Inicial";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "R";
            Fila["Nombre"] = "Reposicion";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarFormaPag()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "Egreso";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "I";
            Fila["Nombre"] = "Ingreso";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoOrdenCompra()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "1";
            Fila["Nombre"] = "BIENES";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "9";
            Fila["Nombre"] = "SERVICIOS";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoCompra()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "N";
            Fila["Nombre"] = "Nacional";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "S";
            Fila["Nombre"] = "Nacional Serv.Tercero";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "E";
            Fila["Nombre"] = "Importado";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarConceptosReparable()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = 0;
            Fila["Nombre"] = "<<Seleccione>>";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 1;
            Fila["Nombre"] = "Gtos.Personales del Contribuyente";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 2;
            Fila["Nombre"] = "Impuesto a la Renta";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 3;
            Fila["Nombre"] = "Multas, Recargos, Int. Morat. Y Sanc.";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 4;
            Fila["Nombre"] = "Donaciones y Cualq. Actos de Liberalidad";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 5;
            Fila["Nombre"] = "Gtos. Cuyos Doc. No cumplen con RCP";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 6;
            Fila["Nombre"] = "Gtos. De Ejerc. Anteriores";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 7;
            Fila["Nombre"] = "Impto. Rta. Terceros Asumidos x el Contrib.";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 8;
            Fila["Nombre"] = "IGV que Graba el Retiro de Bienes";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 9;
            Fila["Nombre"] = "Otros Diversos";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoCanje()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "CJ";
            Fila["Nombre"] = "CANJE";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "RV";
            Fila["Nombre"] = "RENOVACION";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "CT";
            Fila["Nombre"] = "TERCEROS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "CR";
            Fila["Nombre"] = "REFINANCIAMIENTO";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarEstadoCanje()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "Por Aceptar";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "A";
            Fila["Nombre"] = "Aceptada";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "B";
            Fila["Nombre"] = "Anulada";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoCompraConta()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = 1;
            Fila["Nombre"] = "Compras";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 2;
            Fila["Nombre"] = "Compras No Domiciliados";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarTipoDocLiquidacion()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = 1;
            Fila["Nombre"] = "PROVISION";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 2;
            Fila["Nombre"] = "MOVILIDAD";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = 3;
            Fila["Nombre"] = "OTROS";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        public static DataTable CargarEstados(String ConAnular = "S")
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;

            Fila = oDt.NewRow();
            Fila["id"] = "0";
            Fila["Nombre"] = "TODOS";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "P";
            Fila["Nombre"] = "PENDIENTES";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "C";
            Fila["Nombre"] = "CANCELADOS";
            oDt.Rows.Add(Fila);

            if (ConAnular == "S")
            {
                Fila = oDt.NewRow();
                Fila["id"] = "A";
                Fila["Nombre"] = "ANULADOS";
                oDt.Rows.Add(Fila); 
            }

            return oDt;
        }

        public static DataTable CargarTipoProductosPlanilla()
        {
            DataTable oDt = new DataTable();
            oDt.Columns.Add("id");
            oDt.Columns.Add("Nombre");

            DataRow Fila;
            Fila = oDt.NewRow();
            Fila["id"] = "D";
            Fila["Nombre"] = "Letras en Descuentos";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "L";
            Fila["Nombre"] = "Letras en Cobranzas Libre";
            oDt.Rows.Add(Fila);

            Fila = oDt.NewRow();
            Fila["id"] = "G";
            Fila["Nombre"] = "Letras en Garantia";
            oDt.Rows.Add(Fila);

            return oDt;
        }

        #endregion

        public static void Pasar(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true; //esta linea quita el sonido al presionar enter
            }
        }

        public static void CrearToolTip(Control ctrl, String Mensaje)
        {
            ToolTip ttAyuda = new ToolTip
            {
                IsBalloon = true,
                ToolTipTitle = "Información",
                ToolTipIcon = ToolTipIcon.Info
            };

            ttAyuda.SetToolTip(ctrl, Mensaje);
        }

        public static Boolean EsNumero(String Cadena)
        {
            if (String.IsNullOrEmpty(Cadena))
            {
                return false;
            }

            Int32 i = 0;

            for (; i < Cadena.Length; i++)
            {
                if (!Char.IsDigit(Convert.ToChar(Cadena.Substring(i, 1))))
                {
                    return false;
                }
            }

            return true;
        }

        public static void QuitarReferenciaWebBrowser(WebBrowser oWb)
        {
            oWb.Navigate("about:blank");

            while (oWb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }

        //public static FileInfo CambiarExtensionExcel(FileInfo Archivo)
        //{
        //    try
        //    {
        //        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        //        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(Archivo.FullName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //        String NuevoNombre = Archivo.Name;
        //        NuevoNombre = NuevoNombre.Substring(0, NuevoNombre.Length - 4);
        //        String NuevaRuta = @"C:\ERPIndusoft\ArchivosTemporales";

        //        if (!Directory.Exists(NuevaRuta))
        //        {
        //            Directory.CreateDirectory(NuevaRuta);
        //        }

        //        NuevaRuta = NuevaRuta + @"\" + NuevoNombre + ".xlsx";
                
        //        if (File.Exists(NuevaRuta))
        //        {
        //            File.Delete(NuevaRuta);
        //        }

        //        Archivo = new FileInfo(NuevaRuta);

        //        wb.SaveAs(Archivo.FullName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        wb.Close();
        //        app.Quit();

        //        return Archivo;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public static void AjustarResolucion(Form formulario)
        {
            String ancho = Screen.PrimaryScreen.Bounds.Size.Width.ToString();//Obtengo el ancho de la pantalla
            String alto = Screen.PrimaryScreen.Bounds.Size.Height.ToString();//Obtengo el alto de la pantalla
            String tamano = ancho + "x" + alto;//Concateno para utilizarlo en el switch
            switch (tamano)
            {
                case "800x600":
                    cambiarResolucion(formulario, 110F, 110F);//Hago el ajuste con esta función
                    break;
                case "1024x768":
                    cambiarResolucion(formulario, 96F, 110F);
                    break;
                default:
                    cambiarResolucion(formulario, 96F, 96F);
                    break;
            }
        }

        private static void cambiarResolucion(Form formulario, float ancho, float alto)
        {
            formulario.AutoScaleDimensions = new SizeF(ancho, alto); //Ajusto la resolución
            formulario.PerformAutoScale(); //Escalo el control contenedor y sus elementos secundarios.
        }

        public static String FormatoDecimal(String oText, Int32 numDecimal = 2)
        {
            string Formato = "N" + numDecimal.ToString();
            String Numero = Variables.Cero.ToString(Formato);

            if (!String.IsNullOrEmpty(oText))
            {
                Numero = Convert.ToDecimal(oText).ToString(Formato);
            }

            return Numero;
        }

        #region Para las imagenes
        
        //Obtener la imagen y volcarlo en picturebox
        public static Image ObtenerByteImagen(Byte[] byteArray)
        {
            try
            {
                Image oImagen = null;

                using (MemoryStream oMs = new MemoryStream(byteArray))
                {
                    oImagen = Image.FromStream(oMs);
                    oMs.Flush();
                }

                return oImagen;
            }
            catch (IOException iex)
            {
                throw new Exception(iex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Convertir la imagen en un array de bytes
        public static Byte[] ObtenerImagenBytes(Image Imagen)
        {
            try
            {
                Byte[] oImagenBytes = null;

                using (MemoryStream oMs = new MemoryStream())
                {
                    Imagen.Save(oMs, ImageFormat.Jpeg);
                    oImagenBytes = oMs.ToArray();
                    oMs.Flush();
                }

                return oImagenBytes;
            }
            catch (IOException iex)
            {
                throw new Exception(iex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Obtener la imagen y volcarla a una carpeta temporal...
        public static void EscribirImagenEnFile(Byte[] oImagenByte, String Ruta)
        {
            try
            {
                using (MemoryStream oMs = new MemoryStream(oImagenByte))
                {
                    using (FileStream oFs = new FileStream(Ruta, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        oMs.WriteTo(oFs);
                        oFs.Flush();
                    }

                    oMs.Flush();
                }
            }
            catch (IOException iex)
            {
                throw new Exception(iex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EscribirImagenEnFile(Image img, String RutaImagen)
        {
            try
            {
                Byte[] Contenido = null;

                using (MemoryStream oMs = new MemoryStream())
                {
                    img.Save(oMs, img.RawFormat);
                    Contenido = oMs.GetBuffer();
                    oMs.Flush();
                }

                if (!File.Exists(RutaImagen))
                {
                    File.WriteAllBytes(RutaImagen, Contenido);
                }
            }
            catch (IOException iex)
            {
                throw new Exception(iex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        public static void EliminarTemporal(String Ruta)
        {
            try
            {
                if (File.Exists(Ruta))
                {
                    File.Delete(Ruta);
                }
            }
            catch (IOException ex)
            {
                Int32 prueba = Marshal.GetHRForException(ex);

                if (Marshal.GetHRForException(ex) != -2147024864)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static String LeerXml(String Ruta, String Etiqueta, String KeyName)//, String KeyValue)
        {
            String cadRetorno = String.Empty;
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(Ruta);

            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == Etiqueta)
                {
                    foreach (XmlNode xNode in xElement.ChildNodes)
                    {
                        if (xNode.Attributes != null)
                        {
                            //String prueba = EncryptHelper.Decrypt(xNode.Attributes[0].Value.ToString());
                            if (xNode.Attributes[0].Value.ToString() == KeyName)
                            {
                                cadRetorno = xNode.Attributes[1].Value;
                                break;
                            }
                        }
                    }
                }
            }

            return cadRetorno;
        }

        public static String LeerXml(String Ruta, String Etiqueta)
        {
            String cadRetorno = String.Empty;
            using (XmlReader reader = XmlReader.Create(Ruta))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == Etiqueta)
                        {
                            cadRetorno = reader.ReadString();
                            break;
                        }
                    }
                }
            }

            return cadRetorno;
        }

        public static Boolean RevisarEmail(String Email)
        {
            String Expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(Email, Expresion))
            {
                if (Regex.Replace(Email, Expresion, String.Empty).Length == 0)
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

        public static String EspaciosDerecha(Int32 lenght, Int32 maxChar)
        {
            String espacios = "";
            Int32 spaces = maxChar - lenght;

            for (Int32 x = 0; x < spaces; x++)
            {
                espacios += " ";
            }

            return espacios;
        }

    }
}

