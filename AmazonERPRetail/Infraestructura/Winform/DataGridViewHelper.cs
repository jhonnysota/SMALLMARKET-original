using System;
using System.Windows.Forms;
using System.Drawing;

namespace Infraestructura.Winform
{
    public static class DataGridViewHelper
    {
        public static DataGridViewCellStyle FormatoFecha = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd/MM/yyyy" };
        public static DataGridViewCellStyle FormatoDecimal = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" };

        public enum TipoDatosGrid
        {
            Texto,
            Fecha,
            Numeros,
            NumerosDecimales,
            CheckBox,
            Button,
            ImageColumn
        }

        #region Estilos Grid

        static DataGridViewCellStyle EstiloCeldaGrid1 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            //Original
            BackColor = Color.Gray,//Color.FromArgb(Convert.ToInt32(Convert.ToByte(174)), Convert.ToInt32(Convert.ToByte(170)), Convert.ToInt32(Convert.ToByte(170))),
            //BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(117)), Convert.ToInt32(Convert.ToByte(133)), Convert.ToInt32(Convert.ToByte(150))),
            //BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192))),
            Font = new Font("Tahoma", 9.25f, FontStyle.Bold, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = Color.AliceBlue,//SystemColors.Highlight,
            SelectionForeColor = Color.Blue,//SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        static DataGridViewCellStyle EstiloCeldaGrid2 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = SystemColors.ControlLightLight,
            //Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlText,
            //SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionBackColor = Color.AliceBlue,//Color.FromArgb(Convert.ToInt32(Convert.ToByte(100)), Convert.ToInt32(Convert.ToByte(170)), Convert.ToInt32(Convert.ToByte(255))),
            SelectionForeColor = Color.Blue,//SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.False
        };

        static DataGridViewCellStyle EstiloCeldaGrid3 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 15.25f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.WindowText,
            //SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            //SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(51)), Convert.ToInt32(Convert.ToByte(153)), Convert.ToInt32(Convert.ToByte(255))),
            SelectionBackColor = Color.AliceBlue,//Color.FromArgb(Convert.ToInt32(Convert.ToByte(100)), Convert.ToInt32(Convert.ToByte(170)), Convert.ToInt32(Convert.ToByte(255))),
            SelectionForeColor = Color.Blue,//SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        #endregion

        public static void AplicarTemaGrid(DataGridView grid, Boolean SeleccionMultiple = false, DataGridViewSelectionMode TipoSeleccion = DataGridViewSelectionMode.FullRowSelect)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.BackgroundColor = SystemColors.Window;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersDefaultCellStyle = EstiloCeldaGrid1; //////////////
            grid.ColumnHeadersHeight = 35;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.DefaultCellStyle = EstiloCeldaGrid2; //////////////////
            grid.RowsDefaultCellStyle.Font = new Font("Segoe UI", 7.25f, FontStyle.Regular, GraphicsUnit.Point);
            grid.EnableHeadersVisualStyles = false;
            //grid.GridColor = SystemColors.GradientInactiveCaption;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //grid.RowHeadersDefaultCellStyle = EstiloCeldaGrid3; //////////////////////////
            grid.Font = EstiloCeldaGrid1.Font;
            grid.MultiSelect = SeleccionMultiple;
            grid.SelectionMode = TipoSeleccion;
        }

        public static void setGridRowHeader(DataGridView dgv, Boolean hSize = false)
        {
            dgv.TopLeftHeaderCell.Value = "NO ";
            dgv.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);

            foreach (DataGridViewColumn cCol in dgv.Columns)
            {
                if (cCol.ValueType.ToString() == typeof(DateTime).ToString())
                {
                    cCol.DefaultCellStyle = FormatoFecha;
                }
                else if (cCol.ValueType.ToString() == typeof(decimal).ToString() | cCol.ValueType.ToString() == typeof(double).ToString())
                {
                    cCol.DefaultCellStyle = FormatoDecimal;
                }
            }

            if (hSize)
            {
                dgv.RowHeadersWidth = dgv.RowHeadersWidth + 16;
            }

            dgv.AutoResizeColumns();
        }

        public static void Columnas(DataGridView oDgv, TipoDatosGrid TipoDato, String nomColumna, String titCabecera, String ToolTipText, Boolean Visible, DataGridViewTriState Resizable,
                                            DataGridViewContentAlignment Alineacion, DataGridViewColumnSortMode Ordenar, Boolean Congelar = false, Bitmap Imagen = null)
        {
            switch (TipoDato)
            {
                case TipoDatosGrid.Texto:

                    #region Texto

                    DataGridViewTextBoxColumn txtDgv = new DataGridViewTextBoxColumn();
                    txtDgv.ValueType = typeof(String);
                    txtDgv.Name = nomColumna;
                    txtDgv.HeaderText = titCabecera;
                    txtDgv.ToolTipText = ToolTipText;
                    txtDgv.DefaultCellStyle.Alignment = Alineacion;
                    txtDgv.Visible = Visible;
                    txtDgv.Frozen = Congelar;
                    txtDgv.SortMode = Ordenar;
                    oDgv.Columns.Add(txtDgv);

                    break;

                #endregion

                case TipoDatosGrid.Fecha:

                    #region Fechas

                    DataGridViewTextBoxColumn txtDgvFecha = new DataGridViewTextBoxColumn();
                    txtDgvFecha.ValueType = typeof(DateTime);
                    txtDgvFecha.Name = nomColumna;
                    txtDgvFecha.HeaderText = titCabecera;
                    txtDgvFecha.ToolTipText = ToolTipText;
                    txtDgvFecha.DefaultCellStyle = FormatoFecha;
                    txtDgvFecha.SortMode = Ordenar;
                    txtDgvFecha.Visible = Visible;
                    txtDgvFecha.Frozen = Congelar;

                    oDgv.Columns.Add(txtDgvFecha);

                    break;

                #endregion

                case TipoDatosGrid.Numeros:

                    #region Numero

                    DataGridViewTextBoxColumn txtDgvNumeros = new DataGridViewTextBoxColumn();
                    txtDgvNumeros.ValueType = typeof(int);
                    txtDgvNumeros.Name = nomColumna;
                    txtDgvNumeros.HeaderText = titCabecera;
                    txtDgvNumeros.ToolTipText = ToolTipText;
                    txtDgvNumeros.DefaultCellStyle.Alignment = Alineacion;
                    txtDgvNumeros.Visible = Visible;
                    txtDgvNumeros.Frozen = Congelar;
                    txtDgvNumeros.SortMode = Ordenar;

                    oDgv.Columns.Add(txtDgvNumeros);

                    break;

                #endregion

                case TipoDatosGrid.NumerosDecimales:

                    #region Decimales

                    DataGridViewTextBoxColumn txtDgvNumerosDec = new DataGridViewTextBoxColumn();
                    txtDgvNumerosDec.ValueType = typeof(int);
                    txtDgvNumerosDec.Name = nomColumna;
                    txtDgvNumerosDec.HeaderText = titCabecera;
                    txtDgvNumerosDec.ToolTipText = ToolTipText;
                    txtDgvNumerosDec.DefaultCellStyle = FormatoDecimal;
                    txtDgvNumerosDec.Visible = Visible;
                    txtDgvNumerosDec.Frozen = Congelar;
                    txtDgvNumerosDec.SortMode = Ordenar;

                    oDgv.Columns.Add(txtDgvNumerosDec);

                    break;

                #endregion

                case TipoDatosGrid.CheckBox:

                    #region CheckBox

                    DataGridViewCheckBoxColumn chkDgv = new DataGridViewCheckBoxColumn();
                    chkDgv.ValueType = typeof(bool);
                    chkDgv.Name = nomColumna;
                    chkDgv.HeaderText = titCabecera;
                    chkDgv.ToolTipText = ToolTipText;
                    chkDgv.Visible = Visible;
                    //dgvChk.Width = width;
                    chkDgv.SortMode = DataGridViewColumnSortMode.Automatic;
                    chkDgv.Resizable = Resizable;
                    chkDgv.DefaultCellStyle.Alignment = Alineacion;
                    chkDgv.Frozen = Congelar;
                    //dgvChk.HeaderCell.Style.Alignment = headerAlignment;
                    //if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    //{
                    //    dgvChk.CellTemplate.Style.BackColor = CellTemplateBackColor;
                    //}
                    //dgvChk.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    oDgv.Columns.Add(chkDgv);
                    break;

                #endregion

                case TipoDatosGrid.Button:

                    #region Botones

                    DataGridViewButtonColumn btDgv = new DataGridViewButtonColumn();
                    btDgv.Name = nomColumna;
                    btDgv.FlatStyle = FlatStyle.Popup;
                    btDgv.DataPropertyName = nomColumna;
                    btDgv.Visible = Visible;
                    btDgv.ToolTipText = ToolTipText;
                    //dgvButtons.Width = width;
                    btDgv.SortMode = DataGridViewColumnSortMode.Automatic;
                    btDgv.Resizable = Resizable;
                    btDgv.DefaultCellStyle.Alignment = Alineacion;
                    btDgv.Frozen = Congelar;

                    //dgvButtons.HeaderCell.Style.Alignment = headerAlignment;
                    //if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    //{
                    //    dgvButtons.CellTemplate.Style.BackColor = CellTemplateBackColor;
                    //}
                    //dgvButtons.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    oDgv.Columns.Add(btDgv);
                    break;

                #endregion

                case TipoDatosGrid.ImageColumn:

                    #region Imagenes

                    DataGridViewImageColumn imgBtDgv = new DataGridViewImageColumn();
                    imgBtDgv.Name = nomColumna;
                    //ImageName = "expand.png";

                    imgBtDgv.Image = Imagen;//new Bitmap(ClienteWinForm.Properties.Resources.Add_Reg);//Image.FromFile(ImageName);
                    // dgvnestedBtn.DataPropertyName = cntrlnames;
                    imgBtDgv.Visible = Visible;
                    //dgvnestedBtn.Width = width;
                    imgBtDgv.SortMode = DataGridViewColumnSortMode.Automatic;
                    imgBtDgv.Resizable = Resizable;
                    imgBtDgv.DefaultCellStyle.Alignment = Alineacion;
                    imgBtDgv.Frozen = Congelar;
                    imgBtDgv.ToolTipText = ToolTipText;
                    //dgvnestedBtn.HeaderCell.Style.Alignment = headerAlignment;
                    oDgv.Columns.Add(imgBtDgv);

                    break;

                    #endregion
            }
        }

        static DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle()
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        static DataGridViewCellStyle amountCellStyle = new DataGridViewCellStyle()
        {
            Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2"
        };

        static DataGridViewCellStyle Estilo1 = new DataGridViewCellStyle()
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.FromArgb(79, 129, 189),
            Font = new Font("Segoe UI", 10.0f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        static DataGridViewCellStyle Estilo2 = new DataGridViewCellStyle()
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = SystemColors.ControlLightLight,
            Font = new Font("Segoe UI", 10.0f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            ForeColor = SystemColors.ControlText,
            SelectionBackColor = Color.FromArgb(155, 187, 89),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        static DataGridViewCellStyle Estilo3 = new DataGridViewCellStyle()
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 10.0f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = Color.FromArgb(155, 187, 89),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        public static void AplicarTema(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.BackgroundColor = SystemColors.Window;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersDefaultCellStyle = Estilo1;
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.DefaultCellStyle = Estilo2;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = SystemColors.GradientInactiveCaption;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = true;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.RowHeadersDefaultCellStyle = Estilo3;
            grid.Font = Estilo1.Font;
        }

        public static void setGridRowHeader(ref DataGridView dgv, bool hSize = false)
        {
            dgv.TopLeftHeaderCell.Value = "NO ";
            // Warning!!! Optional parameters not supported
            dgv.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);

            foreach (DataGridViewColumn cCol in dgv.Columns)
            {
                if (cCol.ValueType.ToString() == typeof(DateTime).ToString())
                {
                    cCol.DefaultCellStyle = dateCellStyle;
                }
                else if (cCol.ValueType.ToString() == typeof(Decimal).ToString() || cCol.ValueType.ToString() == typeof(double).ToString())
                {
                    cCol.DefaultCellStyle = amountCellStyle;
                }
            }

            if (hSize)
            {
                dgv.RowHeadersWidth = (dgv.RowHeadersWidth + 16);
            }

            dgv.AutoResizeColumns();
        }

        public static void rowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // set rowheader count
            DataGridView grid = ((DataGridView)(sender));
            string rowIdx = ((e.RowIndex + 1)).ToString();
            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, (e.RowBounds.Height - grid.Rows[e.RowIndex].DividerHeight));
            e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        public static void rowPostPaint_HeaderCount2(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView grid = ((DataGridView)(sender));
            // Captura el numero de filas del datagridview
            String numFila = (e.RowIndex + 1).ToString();

            Font oFont = new Font("Tahoma", 8.25f * 96f / grid.CreateGraphics().DpiX, FontStyle.Italic, grid.Font.Unit, grid.Font.GdiCharSet, grid.Font.GdiVerticalFont);
            SizeF size = e.Graphics.MeasureString(numFila, oFont);

            if (grid.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
            {
                grid.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
            }

            Brush ob = Brushes.Navy;
            e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)));
        }

    }
}
