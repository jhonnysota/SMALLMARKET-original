using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infraestructura.Recursos;
using System.Data;

namespace Infraestructura.Winform
{
    public static class ComboHelper
    {
        /// <summary>
        /// Metodo que llena el datasource del Combox
        /// </summary>
        /// <typeparam name="T">Tipo de Datos que se usara para el Listado</typeparam>
        /// <param name="combo">ComboBox que llenaremos con los datos</param>
        /// <param name="listaSource">Lista de datos que se llenaran al ComboBox</param>
        /// <param name="valor">ValuesMember</param>
        /// <param name="mostrar">DisplayMember</param>
        /// <param name="añadeSeleccione">Especifica si añade un item al inicio</param>
        public static void RellenarCombos<T>(ComboBox combo, T listaSource, String valor = "IdParTabla", String mostrar = "Nombre", Boolean añadeSeleccione = false)
        {
            combo.DataSource = listaSource;
            combo.DisplayMember = mostrar;
            combo.ValueMember = valor;

            if (añadeSeleccione)
            {
                AnadirSeleccione(combo);
            }
        }

        public static void RellenarCombos<T>(ComboBox combo, List<T> listaSource, String valor = "IdParTabla", String mostrar = "Nombre", Boolean añadeSeleccione = false)
        {
            combo.DisplayMember = mostrar;
            combo.ValueMember = valor;
            combo.DataSource = listaSource;
           

          
            if (añadeSeleccione)
            {
                AnadirSeleccione(combo);								
            }
        }

        public static void LlenarCombos<T>(object cboAlmacen, List<T> list, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public static void RellenarCombos<T>(DataGridViewComboBoxColumn combo, List<T> listaSource, String valor = "IdParTabla", String mostrar = "Nombre", Boolean añadeSeleccione = false)
        {
            combo.DataSource = listaSource;
            combo.DisplayMember = mostrar;
            combo.ValueMember = valor;
        }

        public static void RellenarCombos(ComboBox combo, Dictionary<Int32, String> listaSource)
        {
            //combo.DataSource = listaSource;
            //combo.DisplayMember = mostrar;
            //combo.ValueMember = valor;

            combo.DataSource = new BindingSource(listaSource, null);
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";
        }

        public static void RellenarCombos<T>(DataGridViewComboBoxColumn combo, T listaSource, String valor = "IdParTabla", String mostrar = "Nombre", Boolean añadeSeleccione = false)
        {
            combo.DataSource = listaSource;
            combo.DisplayMember = mostrar;
            combo.ValueMember = valor;            
        }

        public static void AnadirSeleccione(ComboBox paramCombo)
        {
            paramCombo.Items.Insert(0, Mensajes.MSG_GBL_ELIJA_OPCION);
        }

        public static void LlenarCombos<T>(ComboBox comboBox, List<T> listado, String valueMember = "IdParTabla", String displayMember = "Nombre")
        {
            comboBox.DataSource = listado;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        public static void LlenarCombos<T>(DataGridViewComboBoxColumn comboBox, List<T> listado, String valueMember = "IdParTabla", String displayMember = "Nombre")
        {
            comboBox.DataSource = listado;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        public static void LlenarListBox<T>(ListBox cListBox, List<T> Listado, String ValueMember, String DisplayMember)
        {
            cListBox.DataSource = null;
            cListBox.DisplayMember = DisplayMember;
            cListBox.DataSource = Listado;
            cListBox.DisplayMember = DisplayMember;
            cListBox.ValueMember = ValueMember;
        }

        public static DataSet ConvertirDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        public static void AutoCompletar(ComboBox oCombo, KeyPressEventArgs e, Boolean blnLimitToList)
        {
            String BuscarCadena = String.Empty;

            if (e.KeyChar == (char)8)
            {
                if (oCombo.SelectionStart <= 1)
                {
                    oCombo.Text = String.Empty;
                    return;
                }

                if (oCombo.SelectionLength == 0)
                {
                    BuscarCadena = oCombo.Text.Substring(0, oCombo.Text.Length - 1);
                }
                else
                {
                    BuscarCadena = oCombo.Text.Substring(0, oCombo.SelectionStart - 1);
                }
            }
            else
            {
                if (oCombo.SelectionLength == 0)
                {
                    BuscarCadena = oCombo.Text + e.KeyChar;
                }
                else
                {
                    BuscarCadena = oCombo.Text.Substring(0, oCombo.SelectionStart) + e.KeyChar;
                }
            }

            // Buscar la cadena en el ComboBox list.
            Int32 intIdx = -1;
            intIdx = oCombo.FindString(BuscarCadena);

            if (intIdx != -1)
            {
                oCombo.SelectedText = "";
                oCombo.SelectedIndex = intIdx;
                oCombo.SelectionStart = BuscarCadena.Length;
                oCombo.SelectionLength = oCombo.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }
        }

    }
}
