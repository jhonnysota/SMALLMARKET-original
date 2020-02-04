using System;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Extensores;

namespace ClienteWinForm.Ventas
{
    public partial class FrmPuntoVentasReimpresion : Form
    {

        #region Constructores

        public FrmPuntoVentasReimpresion()
        {
            InitializeComponent();
            Formato(DgvDetalle);
            Global.CrearToolTip(BtBuscar, "Presionar Tecla F1");
            Global.CrearToolTip(BtGuardar, "Presionar Tecla F5");
        }

        public FrmPuntoVentasReimpresion(string tipo_)
            : this()
        {
            Tipo = tipo_;
            Text = "Anulación de Documentos de Ventas";
            BtGuardar.Text = "Anular";
            BtGuardar.Image = Properties.Resources.Eliminar_Linea;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public EmisionDocumentoE DocumentoVenta = null;
        private readonly string Tipo = "I"; //I=Documentos para volver a imprimir A=Anulacion de documentos

        #endregion

        #region Procedimientos de Usuario

        private void Formato(DataGridView oDgv)
        {
            oDgv.SuspendLayout();
            //Barra de titulos
            oDgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.Black,
                WrapMode = DataGridViewTriState.True
            };

            //La primera columna
            oDgv.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F),
                ForeColor = Color.Black
            };

            //Sin Bordes
            oDgv.BorderStyle = BorderStyle.None;
            //Color de fondo
            oDgv.BackgroundColor = Color.Azure;
            //Deshabilitando el ajuste de columnas de la cabecera y la primera columna
            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //Alto de la la fila de titutlos
            oDgv.ColumnHeadersHeight = 30;
            //Ancho de la primera columna
            oDgv.RowHeadersWidth = 20;
            //Deshabilitando el ajuste de columnas y filas en el detalle
            oDgv.AllowUserToResizeColumns = false;
            oDgv.AllowUserToResizeRows = false;
            //Color de lineas y tipo de bordes
            oDgv.GridColor = Color.Black;
            
            //Tipo de bordes en la cabecera
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //Seleccion multuiple
            oDgv.MultiSelect = false;
            //Quitando los bordes en el detalle
            oDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //Tipo de selección de las celdas
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tipo de letra del detalle
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //Alternando colores en las filas
            //oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            //oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //Color al seleccionar
            oDgv.DefaultCellStyle.SelectionForeColor = Color.White;
            oDgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 28;
            lineas.MinimumHeight = 10;

            //Formato por columnas
            oDgv.Columns["RazonSocial"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            oDgv.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            oDgv.Refresh();

            oDgv.ResumeLayout();
        }

        private void Buscar()
        {
            string RazonSocial = "%" + TxtRazonSocial.Text.Trim() + "%";

            BsDetalle.DataSource = AgenteVentas.Proxy.RecuperarEmisionDocumento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, DtpFecIni.Value.ToString("yyyyMMdd"), DtpFecFin.Value.ToString("yyyyMMdd"),  RazonSocial);
            BsDetalle.ResetBindings(false);

            if (BsDetalle.List.Count > 0)
            {
                DgvDetalle.Focus();
            }
        }

        private void Aceptar()
        {
            if (BsDetalle.Current is EmisionDocumentoE current)
            {
                //Cabecera
                DocumentoVenta = Colecciones.CopiarEntidad<EmisionDocumentoE>(current);

                if (Tipo == "I")
                {
                    //Detalle
                    DocumentoVenta.ListaItemsDocumento = AgenteVentas.Proxy.ObtenerEmisionDocumentoDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    //Lista de Pagos
                    DocumentoVenta.ListaCancelaciones = AgenteVentas.Proxy.ObtenerEmisionDocumentoCancelacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    string Mensaje = string.Format("Se va Anular el Documento {0}-{1} con N° de Pedido {2}", current.numSerie, current.numDocumento, current.CodPedido);
                    MessageBoxButtons botones = MessageBoxButtons.YesNo;
                    MessageBoxIcon Icono = MessageBoxIcon.Question;
                    DialogResult result = MessageBox.Show(Mensaje, "Aviso", botones, Icono, MessageBoxDefaultButton.Button2);
                    bool resp = false;

                    if (result == DialogResult.Yes)
                    {
                        //Detalle
                        DocumentoVenta.ListaItemsDetallado = AgenteVentas.Proxy.ObtenerEmisionDocumentoDetallado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, current.idDocumento, current.numSerie, current.numDocumento);
                        resp = AgenteVentas.Proxy.AnularTicket(DocumentoVenta, "N", VariablesLocales.SesionUsuario.Credencial);
                    }

                    if (resp)
                    {
                        BsDetalle.RemoveCurrent();
                        BsDetalle.ResetBindings(false);
                        Global.MensajeComunicacion("Documento anulado.");
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void FrmPuntoVentasReimpresion_Load(object sender, EventArgs e)
        {
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                DgvDetalle.Columns["nroDocAsociado"].Visible = true;
            }
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TxtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Global.EventoEnter(e, BtBuscar);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void FrmPuntoVentasReimpresion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Dispose();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    Aceptar();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DtpFecIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void DtpFecFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TxtRazonSocial.Focus();
                e.Handled = true; //esta linea quita el sonido al presionar enter
            }
        }

        #endregion

    }
}
