using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using InputKey;

using ClienteWinForm.Busquedas;
using Entidades.Ventas;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenConversion : FrmMantenimientoBase
    {

        #region Constructores

        public frmOrdenConversion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvConversiondet, false);
            FormatoGrid(dgvSalidas, false);
            FormatoGrid(dgvGastos, false);
        }

        //Nuevo
        public frmOrdenConversion(Int32 idconcepto_)
            : this()
        {
            idconcepto = idconcepto_;
        }

        //Edición
        public frmOrdenConversion(OrdenConversionE oOrdenConv, Int32 idconcepto_)
            : this()
        {
            oOrdenConver = AgenteAlmacen.Proxy.ObtenerOrdenConversionCompleta(oOrdenConv.idEmpresa, oOrdenConv.idOrdenConversion);
            idconcepto = idconcepto_;

            Text = "Orden Conversión (" + oOrdenConver.Numero.Trim() + ")";
        }

        #endregion

        #region Variables

        OrdenConversionE oOrdenConver = null;
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        Int32 OpcionGrabar;
        Int32 idconcepto;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            if (rb0.Checked)
            {
                oOrdenConver.idConcepto = 0;
            }
            
            if (rb1.Checked)
            {
                oOrdenConver.idConcepto = 1;
            }

            if (rbTransformacion.Checked)
            {
                oOrdenConver.idConcepto = 2;
            }
          
            oOrdenConver.FechaOperacion = dtpFechaOpe.Value.Date;
            oOrdenConver.Fecha = dtpFecha.Value.Date;
            oOrdenConver.Numero = txtNumero.Text;
            oOrdenConver.Observacion = txtObservaciones.Text;
            oOrdenConver.indGenerada = chkSalida.Checked;
            oOrdenConver.TotalPeso = Convert.ToDecimal(txtTotal.Text);
            oOrdenConver.idMoneda = "01"; //cboMonedas.SelectedValue.ToString();

            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                oOrdenConver.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
	        {
                oOrdenConver.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }

            if (rbTransformacion.Checked == false)
            {
                oOrdenConver.idDocumento = null;
                oOrdenConver.numSerie = null;
                oOrdenConver.numDocumento = null;
                oOrdenConver.idOrdenCompra = 0;
            }
            else
            {
                oOrdenConver.idDocumento = txtDoc.Text;
                oOrdenConver.numSerie = txtSerie.Text;
                oOrdenConver.numDocumento = txtNumdoc.Text;
                oOrdenConver.idOrdenCompra = Convert.ToInt64(txtOC.Text);
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, OrdenConversionDetalleE oOrdenConv)
        {
            try
            {
                if (bsOrdenConversionDet.Count > 0)
                {
                    frmOrdenConversionDetalle oFrm = new frmOrdenConversionDetalle(oOrdenConv);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        OrdenConversionDetalleE oDetalle = oFrm.oDetalleConversion;
                        //Decimal PesoUnitCab = Convert.ToDecimal(txtPesoUnitario.Text);
                        //Decimal CostoUnitCab = Convert.ToDecimal(txtCostoUni.Text);

                        oDetalle.CostoUnitario = 0; //(oDetalle.Equivalente / PesoUnitCab) * CostoUnitCab;
                        oDetalle.TotalCosto = 0; // oDetalle.Equivalente * oDetalle.CostoUnitario;

                        oOrdenConver.ListaConverDetalle[e.RowIndex] = oDetalle;
                        bsOrdenConversionDet.DataSource = oOrdenConver.ListaConverDetalle;
                        bsOrdenConversionDet.ResetBindings(false);

                        SumarTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void EditarDetalle2(DataGridViewCellEventArgs e, OrdenConversionSalidaE oOrdenConvSal)
        {
            try
            {
                if (bsOrdenConversionSalida.Count > 0)
                {
                    frmOrdenConversionSalida oFrm = new frmOrdenConversionSalida(dtpFecha.Value, oOrdenConvSal);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        OrdenConversionSalidaE oDetalle = oFrm.oDetalleConvSalida;

                        oOrdenConver.ListaConverSalida[e.RowIndex] = oDetalle;
                        bsOrdenConversionSalida.DataSource = oOrdenConver.ListaConverSalida;
                        bsOrdenConversionSalida.ResetBindings(false);
                        SumarSalida();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void EditarDetalleGasto(DataGridViewCellEventArgs e, OrdenConversionGastosE oOrdenConvGas)
        {
            try
            {
                if (bsConversionGastos.Count > 0)
                {
                    frmOrdenConversionGastos oFrm = new frmOrdenConversionGastos(Colecciones.CopiarEntidad<OrdenConversionGastosE>(oOrdenConvGas));

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        OrdenConversionGastosE oDetalle = oFrm.oGastoConversion;

                        oOrdenConver.ListaGastos[e.RowIndex] = oDetalle;
                        bsConversionGastos.DataSource = oOrdenConver.ListaGastos;
                        bsConversionGastos.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void SumarSalida()
        {
            Decimal TotalSalida = 0;

            if (oOrdenConver.ListaConverSalida != null && oOrdenConver.ListaConverSalida.Count > 0)
            {
                TotalSalida = (from x in oOrdenConver.ListaConverSalida select x.TotalPeso).Sum();
            }

            txtTotal.Text = TotalSalida.ToString("N3");
        }

        void SumarTotal()
        {
           if (oOrdenConver.ListaConverDetalle != null && oOrdenConver.ListaConverDetalle.Count > 0)
            {
                Decimal PesoTotalDet = (from x in oOrdenConver.ListaConverDetalle select x.TotalPeso).Sum();
                Decimal CostoTotalDet = (from x in oOrdenConver.ListaConverDetalle select x.TotalCosto).Sum();
                Decimal TotalCab = Convert.ToDecimal(txtTotal.Text);
                Decimal CostoCab = Convert.ToDecimal(txtCostoTot.Text);
                Decimal Diferencia = 0;
                Decimal DiferenciaCosto = 0;

                txtTOTALES.Text = PesoTotalDet.ToString("N3");
                txtCostoTotalDet.Text = CostoTotalDet.ToString("N2");

                Diferencia = TotalCab - PesoTotalDet;
                txtDiferenciaPeso.Text = Diferencia.ToString("N3");

                DiferenciaCosto = CostoCab - CostoTotalDet;
                txtDiferenciaCosto.Text = DiferenciaCosto.ToString("N2");

            }
            else
            {
                txtTOTALES.Text = "0.000";
                txtCostoTotalDet.Text = "0.00";
            }
        }

        void SumarGastos()
        {
            if (oOrdenConver != null)
            {

                if (oOrdenConver.ListaGastos != null && oOrdenConver.ListaGastos.Count > 0)
                {
                    Decimal MontoSoles = (from x in oOrdenConver.ListaGastos select x.Monto).Sum();
                    Decimal MontoDolares = (from x in oOrdenConver.ListaGastos select x.MontoDolares).Sum();

                    txtTotalGastoS.Text = MontoSoles.ToString("N2");
                    txtTotalGastoD.Text = MontoDolares.ToString("N2");
                }
                else
                {
                    txtTotalGastoS.Text = "0.00";
                    txtTotalGastoD.Text = "0.00";
                }
            }
            else
            {
                txtTotalGastoS.Text = "0.00";
                txtTotalGastoD.Text = "0.00";
            }

        }

        void EditarLote(DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsOrdenConversionDet != null)
                {
                    OrdenConversionDetalleE oMovimientoSelec = (OrdenConversionDetalleE)bsOrdenConversionDet.Current;
                    frmEntradaAlmacenesLote oFrm = new frmEntradaAlmacenesLote(oMovimientoSelec.idEmpresa, oMovimientoSelec.Lote, oMovimientoSelec.idAlmacen);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oOrdenConver == null)
            {
                oOrdenConver = new OrdenConversionE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                //Producción
                if (idconcepto == 0)
                {
                    rb0.Checked = true;
                }
                //Cambio de código
                if (idconcepto == 1)
                {
                    rb1.Checked = true;
                }
                //Transformación
                if (idconcepto == 2)
                {
                    rbTransformacion.Checked = true;
                }

                txtNumero.Tag = 0;
                txtNumero.Text = "0";//oOrdenConver.Numero;
                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                //Producción
                if (idconcepto == 0)
                {
                    rb0.Checked = true;
                }
                //Cambio de código
                if (idconcepto == 1)
                {
                    rb1.Checked = true;
                }
                //Transformación
                if (idconcepto == 2)
                {
                    rbTransformacion.Checked = true;
                }

                txtNumero.Tag = oOrdenConver.idOrdenConversion;
                txtNumero.Text = oOrdenConver.Numero;
                dtpFechaOpe.Value = Convert.ToDateTime(oOrdenConver.FechaOperacion);
                dtpFecha.Value = Convert.ToDateTime(oOrdenConver.Fecha);
                chkSalida.Checked = Convert.ToBoolean(oOrdenConver.indGenerada);
                txtTotal.Text = oOrdenConver.TotalPeso.ToString("N3");
                txtCostoTot.Text = oOrdenConver.TotalCosto.ToString("N2");
                txtObservaciones.Text = oOrdenConver.Observacion;
                txtUsuarioRegistro.Text = oOrdenConver.UsuarioRegistro;
                txtFechaRegistro.Text = oOrdenConver.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oOrdenConver.UsuarioModificacion;
                txtFechaModificacion.Text = oOrdenConver.FechaModificacion.ToString();

                if (rbTransformacion.Checked == true)
                {
                    txtDoc.Text = oOrdenConver.idDocumento;
                    txtSerie.Text = oOrdenConver.numSerie;
                    txtNumdoc.Text = oOrdenConver.numDocumento;
                    txtOC.Text = Convert.ToString(oOrdenConver.idOrdenCompra);
                }

                if (chkSalida.Checked)
                {
                    pnlPrincipales.Enabled = false;
                    btnSalida.Enabled = false;
                    btEliminarSalida.Enabled = true;
                    btSalida.Enabled = false;
                    btnElim.Enabled = false;
                }

                OpcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;

                if (oOrdenConver.ListaConverDetalle != null && oOrdenConver.ListaConverDetalle.Count > 0)
                {
                    btnIngreso.Enabled = true;

                    var ListaTemp = oOrdenConver.ListaConverDetalle.GroupBy(x => x.indGenerada).Select(p => p.First()).ToList();

                    if (ListaTemp.ToList().Count > 1)
                    {
                        btnIngreso.Enabled = true;
                        btEliminarIngreso.Enabled = false;
                    }
                    else if (ListaTemp.ToList().Count == 1)
                    {
                        if (ListaTemp.ToList()[0].indGenerada)
                        {
                            btnIngreso.Enabled = false;
                            btEliminarIngreso.Enabled = true;
                        }
                    }
                }
            }

            bsOrdenConversionDet.DataSource = oOrdenConver.ListaConverDetalle;
            bsOrdenConversionDet.ResetBindings(false);

            bsOrdenConversionSalida.DataSource = oOrdenConver.ListaConverSalida;
            bsOrdenConversionSalida.ResetBindings(false);

            bsConversionGastos.DataSource = oOrdenConver.ListaGastos;
            bsConversionGastos.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oOrdenConver != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oOrdenConver = AgenteAlmacen.Proxy.GrabarConversion(oOrdenConver, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oOrdenConver = AgenteAlmacen.Proxy.GrabarConversion(oOrdenConver, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<OrdenConversionE>(oOrdenConver);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (chkSalida.Checked)
            {
                if (txtTOTALES.Text != txtTotal.Text)
                {
                    Global.MensajeComunicacion("Las Cantidades Totales deben ser Iguales... ");
                    return false;
                } 
            }

            List<OrdenConversionDetalleE> ListaConversionDetalle = new List<OrdenConversionDetalleE>(oOrdenConver.ListaConverDetalle);

            foreach (OrdenConversionDetalleE item in ListaConversionDetalle)
            {
               if (item.Lote.Trim() == "")
                {
                   Global.MensajeComunicacion("Debe Indicar el Lote .... ");
                   return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                // Verificar si ya se hizo el Ingreso
                List<OrdenConversionDetalleE> ListaConversionDetalle = new List<OrdenConversionDetalleE>(oOrdenConver.ListaConverDetalle);
                bool IngresoGenerado = false;

                foreach (OrdenConversionDetalleE item in ListaConversionDetalle)
                 {
                    if (item.indGenerada)
                    {
                        IngresoGenerado = true;
                    }
                 }

                if (!IngresoGenerado)
                {
                    frmOrdenConversionDetalle oFrm = new frmOrdenConversionDetalle(dtpFecha.Value.Date);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        OrdenConversionDetalleE oDetalle = oFrm.oDetalleConversion;
                        //Decimal PesoUnitCab = Convert.ToDecimal(txtPesoUnitario.Text);
                        //Decimal CostoUnitCab = Convert.ToDecimal(txtCostoUni.Text);

                        oDetalle.CostoUnitario = 0;  //(oDetalle.Equivalente / PesoUnitCab) * CostoUnitCab;
                        oDetalle.TotalCosto = 0; // oDetalle.Equivalente * oDetalle.CostoUnitario;

                        oOrdenConver.ListaConverDetalle.Add(oDetalle);

                        bsOrdenConversionDet.DataSource = oOrdenConver.ListaConverDetalle;
                        bsOrdenConversionDet.ResetBindings(false);

                        SumarTotal();
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Ya se genero el Ingreso Para Agregar debe Eliminar el Ingreso.... ");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                // Verificar si ya se hizo el Ingreso
                List<OrdenConversionDetalleE> ListaConversionDetalle = new List<OrdenConversionDetalleE>(oOrdenConver.ListaConverDetalle);
                bool IngresoGenarado = false;

                foreach (OrdenConversionDetalleE item in ListaConversionDetalle)
                {
                    if (item.indGenerada)
                    {
                        IngresoGenarado = true;
                    }
                }

                if (!IngresoGenarado)
                {
                    if (bsOrdenConversionDet.Current != null)
                    {
                        if (oOrdenConver.ListaConverDetalle != null && oOrdenConver.ListaConverDetalle.Count > Variables.Cero)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                return;

                            AgenteAlmacen.Proxy.EliminarOrdenConversionDetalle(((OrdenConversionDetalleE)bsOrdenConversionDet.Current).idEmpresa, ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).idOrdenConversion, ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).item);
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);

                            bsOrdenConversionDet.EndEdit();

                            oOrdenConver.ListaConverDetalle.RemoveAt(bsOrdenConversionDet.Position);
                            bsOrdenConversionDet.DataSource = oOrdenConver.ListaConverDetalle;
                            bsOrdenConversionDet.ResetBindings(false);

                            SumarTotal();
                            base.QuitarDetalle();
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Ya se genero el Ingreso Para Eliminar el item debe eliminar el Ingreso.... ");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void dgvConversiondet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (dgvConversiondet.Columns[e.ColumnIndex].Name == "Equivalente")
                {
                    InputDialog ventana = new InputDialog();

                    String numLote = InputDialog.mostrar("Introduzca el N° de Lote Correcto?", "Cambio de Lote", 0);

                    if (!String.IsNullOrEmpty(numLote.Trim()))
                    {
                        OrdenConversionDetalleE Item = new OrdenConversionDetalleE()
                        {
                            idEmpresa = ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).idEmpresa,
                            idOrdenConversion = ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).idOrdenConversion,
                            item = ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).item,
                            Lote = numLote,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial
                        };

                        AgenteAlmacen.Proxy.ActualizarLoteOrdenConversion(Item);

                        Global.MensajeComunicacion("Se actualizó el Lote");
                        ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).Lote = numLote;
                        bsOrdenConversionDet.ResetBindings(false);
                    }
                }
                else
                {
                    if (dgvConversiondet.Columns[e.ColumnIndex].Name == "Lote")
                    {
                        if ((Boolean)dgvConversiondet.Rows[e.RowIndex].Cells["indGenerada"].Value == true)
                        {
                            EditarLote(e);
                        }
                        else
                        {
                            EditarDetalle(e, ((OrdenConversionDetalleE)bsOrdenConversionDet.Current));
                        }
                    }
                    else
                    {
                        EditarDetalle(e, ((OrdenConversionDetalleE)bsOrdenConversionDet.Current));
                    }
                }
            }
        }

        private void frmOrdenConversion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            SumarTotal();

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                dgvSalidas.Columns[0].Visible = true;
            }
            if (rbTransformacion.Checked == true)
            {
                btInsertarGuia.Visible = true;
                lblDoc.Visible = true;
                lblNumDoc.Visible = true;
                lblOC.Visible = true;
                lblSerie.Visible = true;
                txtDoc.Visible = true;
                txtSerie.Visible = true;
                txtNumdoc.Visible = true;
                txtOC.Visible = true;
                btOrdenCompra.Visible = true;
                pnlPrincipales.Size = new Size(404,287);
                panel1.Location = new Point(409,217);
                pnlAuditoria.Location = new Point(782,217);
                btSalida.Location = new Point(409,181);
                btnElim.Location = new Point(521,181);
                btInsertarGuia.Location = new Point(82,178);
                panel7.Location = new Point(3,297);
                panel3.Location = new Point(748,297);
                panel4.Location = new Point(3,532);
                this.Size = new Size(1351,696);
            }
            else
            {
                btInsertarGuia.Visible = false;
                lblDoc.Visible = false;
                lblNumDoc.Visible = false;
                lblOC.Visible = false;
                lblSerie.Visible = false;
                txtDoc.Visible = false;
                txtSerie.Visible = false;
                txtNumdoc.Visible = false;
                txtOC.Visible = false;
                btOrdenCompra.Visible = false;
                pnlPrincipales.Size = new Size(404,185);
                btSalida.Location = new Point(88,194);
                btnElim.Location = new Point(272,194);
                btInsertarGuia.Location = new Point(82,258);
                panel1.Location = new Point(409,180);
                pnlAuditoria.Location = new Point(783,180);
                panel7.Location = new Point(3,260);
                panel3.Location = new Point(747,260);
                panel4.Location = new Point(3,495);
                this.Size = new Size(1351,657);
            }

        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpcionGrabar != (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (chkSalida.Checked)
                    {
                        Global.MensajeComunicacion("Ya fue Generada la Salida por Conversión...!!! ");
                    }
                    else
                    {
                        if (oOrdenConver.ListaConverSalida.Count > 0)
                        {
                            if (Global.MensajeConfirmacion("Generar Salida para Conversion...") == DialogResult.Yes)
                            {
                                oOrdenConver = AgenteAlmacen.Proxy.GeneraSalidaAlmacenPorConversion(oOrdenConver, VariablesLocales.SesionUsuario.Credencial);
                                chkSalida.Checked = oOrdenConver.indGenerada;
                                Global.MensajeComunicacion("Se hizo la Salida al almacén correctamente.");
                                btnSalida.Enabled = false;
                                btEliminarSalida.Enabled = true;
                            } 
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion(" Primero debe Grabar Antes de Generar la Salida !!! ");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (OrdenConversionDetalleE item in oOrdenConver.ListaConverDetalle)
                {
                    if (item.Opcion != 0)
                    {
                        Global.MensajeComunicacion("La Orden de Conversión debe estar grabada completamente.");
                        return;
                    }

                    if (item.indGenerada)
                    {
                        Global.MensajeComunicacion("La Orden de Conversión ya ha sido ingresada al almacén.");
                        return;
                    }
                }

                if (Global.MensajeConfirmacion("Generar el Ingreso por Conversion....") == DialogResult.Yes)
                {
                    oOrdenConver = AgenteAlmacen.Proxy.GeneraIngresoAlmacenPorConversion(oOrdenConver, VariablesLocales.SesionUsuario.Credencial);
                    chkSalida.Checked = oOrdenConver.indGenerada;

                    Global.MensajeComunicacion("Se hizo el ingreso al almacén correctamente.");
                    bsOrdenConversionDet.DataSource = oOrdenConver.ListaConverDetalle;
                    bsOrdenConversionDet.ResetBindings(false);

                    btnIngreso.Enabled = false;
                    btEliminarIngreso.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btEliminarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkSalida.Checked)
                {
                    Global.MensajeComunicacion("No se puede eliminar ningúna salida.");
                }
                else
                {
                    if (Global.MensajeConfirmacion("Desea eliminar la Salida del Almacen.") == DialogResult.Yes)
                    {
                        OrdenConversionE oOrden = AgenteAlmacen.Proxy.AnularSalAlmacenPorConversion(oOrdenConver, VariablesLocales.SesionUsuario.Credencial);
                        
                        if (oOrden != null)
                        {
                            chkSalida.Checked = false;
                            btEliminarSalida.Enabled = false;
                            btnSalida.Enabled = true;

                            Global.MensajeComunicacion("Movimientos de Salida Eliminados.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsOrdenConversionDet_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsOrdenConversionDet.Current != null)
                {
                    txtIdDocIngAlmacen.Text = ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).idDocumentoAlmacen.ToString();
                    txtIdMovIngreso.Text = ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).tipMovimiento.ToString();
                    txtDesMovIngreso.Text = ((OrdenConversionDetalleE)bsOrdenConversionDet.Current).nomTipoMov;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (OrdenConversionDetalleE item in oOrdenConver.ListaConverDetalle)
                {
                    if (!item.indGenerada)
                    {
                        Global.MensajeComunicacion("No se puede anular ningún movimiento.");
                        return;
                    }
                }

                if (Global.MensajeConfirmacion("Desea eliminar los Ingresos del Almacen.") == DialogResult.Yes)
                {
                    oOrdenConver = AgenteAlmacen.Proxy.AnularIngAlmacenPorConversion(oOrdenConver, VariablesLocales.SesionUsuario.Credencial);
                    bsOrdenConversionDet.DataSource = oOrdenConver.ListaConverDetalle;
                    bsOrdenConversionDet.ResetBindings(false);

                    Global.MensajeComunicacion("Se anularon los Ingresos de Almacén");
                    btnIngreso.Enabled = true;
                    btEliminarIngreso.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvSalidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle2(e, ((OrdenConversionSalidaE)bsOrdenConversionSalida.Current));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrdenConversionSalida oFrm = new frmOrdenConversionSalida(dtpFecha.Value);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    OrdenConversionSalidaE oMoviItem = oFrm.oDetalleConvSalida;
                    oOrdenConver.ListaConverSalida.Add(oMoviItem);
                    bsOrdenConversionSalida.DataSource = oOrdenConver.ListaConverSalida;
                    bsOrdenConversionSalida.ResetBindings(false);
                    SumarSalida();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnElim_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsOrdenConversionSalida.Current != null)
                {
                    if (oOrdenConver.ListaConverSalida != null && oOrdenConver.ListaConverSalida.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                        {
                            return;
                        }

                        AgenteAlmacen.Proxy.EliminarOrdenConversionSalida(((OrdenConversionSalidaE)bsOrdenConversionSalida.Current).idEmpresa, ((OrdenConversionSalidaE)bsOrdenConversionSalida.Current).idOrdenConversion, ((OrdenConversionSalidaE)bsOrdenConversionSalida.Current).item);
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);

                        bsOrdenConversionSalida.EndEdit();

                        oOrdenConver.ListaConverSalida.RemoveAt(bsOrdenConversionSalida.Position);
                        bsOrdenConversionSalida.DataSource = oOrdenConver.ListaConverSalida;
                        bsOrdenConversionSalida.ResetBindings(false);
                        SumarSalida();

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btAgregarGasto_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrdenConversionGastos oFrm = new frmOrdenConversionGastos();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oGastoConversion != null)
                {
                    OrdenConversionGastosE oGastos = oFrm.oGastoConversion;
                    oOrdenConver.ListaGastos.Add(oGastos);
                    bsConversionGastos.DataSource = oOrdenConver.ListaGastos;
                    bsConversionGastos.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btQuitarGasto_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsConversionGastos.Count > 0)
                {
                    OrdenConversionGastosE current = (OrdenConversionGastosE)bsConversionGastos.Current;

                    if (current != null)
                    {
                        if (current.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oOrdenConver.ListaGastos.Remove(current);
                        }
                        else
                        {
                            if (oOrdenConver.ListaGastosEliminados == null)
                            {
                                oOrdenConver.ListaGastosEliminados = new List<OrdenConversionGastosE>();
                            }

                            oOrdenConver.ListaGastosEliminados.Add(current);
                            oOrdenConver.ListaGastos.Remove(current);
                        }

                        bsConversionGastos.DataSource = oOrdenConver.ListaGastos;
                        bsConversionGastos.ResetBindings(false);
                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btObtenerGastos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtNumero.Tag) > 0)
                {
                    List<OrdenConversionGastosE> oListaGastos = AgenteAlmacen.Proxy.ListarGastosConversion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(txtNumero.Tag));

                    if (oListaGastos.Count > 0)
                    {
                        if (oOrdenConver.ListaGastos.Count > 0)
                        {
                            oOrdenConver.ListaGastosEliminados = new List<OrdenConversionGastosE>(oOrdenConver.ListaGastos);

                            foreach (OrdenConversionGastosE item in oListaGastos)
                            {
                                item.DistribuirItem = false;
                                item.ItemADistribuir = String.Empty;
                                item.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                                item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                item.FechaRegistro = VariablesLocales.FechaHoy;
                                item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                item.FechaModificacion = VariablesLocales.FechaHoy;
                            }

                            oOrdenConver.ListaGastos = new List<OrdenConversionGastosE>(oListaGastos);
                            bsConversionGastos.DataSource = oOrdenConver.ListaGastos;
                            bsConversionGastos.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvGastos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalleGasto(e, ((OrdenConversionGastosE)bsConversionGastos.Current));
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsConversionGastos_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                SumarGastos();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbTransformacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransformacion.Checked == true)
            {
                btInsertarGuia.Visible = true;
                lblDoc.Visible = true;
                lblNumDoc.Visible = true;
                lblOC.Visible = true;
                lblSerie.Visible = true;
                txtDoc.Visible = true;
                txtSerie.Visible = true;
                txtNumdoc.Visible = true;
                txtOC.Visible = true;
                btOrdenCompra.Visible = true;
                pnlPrincipales.Size = new Size(404, 287);
                panel1.Location = new Point(409, 217);
                pnlAuditoria.Location = new Point(782, 217);
                btSalida.Location = new Point(409, 181);
                btnElim.Location = new Point(521, 181);
                btInsertarGuia.Location = new Point(82, 178);
                panel7.Location = new Point(3, 297);
                panel3.Location = new Point(748, 297);
                panel4.Location = new Point(3, 532);
                panel5.Location = new Point(747, 532);
                this.Size = new Size(1351, 696);
            }
            else
            {
                btInsertarGuia.Visible = false;
                lblDoc.Visible = false;
                lblNumDoc.Visible = false;
                lblOC.Visible = false;
                lblSerie.Visible = false;
                txtDoc.Visible = false;
                txtSerie.Visible = false;
                txtNumdoc.Visible = false;
                txtOC.Visible = false;
                btOrdenCompra.Visible = false;
                pnlPrincipales.Size = new Size(404, 185);
                btSalida.Location = new Point(88, 194);
                btnElim.Location = new Point(272, 194);
                btInsertarGuia.Location = new Point(82, 258);
                panel1.Location = new Point(409, 180);
                pnlAuditoria.Location = new Point(783, 180);
                panel7.Location = new Point(3, 260);
                panel3.Location = new Point(747, 260);
                panel4.Location = new Point(3, 495);
                panel5.Location = new Point(747,495);
                this.Size = new Size(1351, 657);
            }
        }

        private void btInsertarGuia_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarGuia oFrm = new frmBuscarGuia();

                if (VariablesLocales.SesionUsuario.Empresa.RUC != "20452630886") // si es diferente a fundo san miguel
                {
                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaDocumentos != null)
                    {
                        foreach (EmisionDocumentoE itemCab in oFrm.oListaDocumentos)
                        {
                            txtDoc.Text = oOrdenConver.idDocumento = itemCab.idDocumento;
                            txtSerie.Text = oOrdenConver.numSerie = itemCab.numSerie;
                            txtNumdoc.Text = oOrdenConver.numDocumento = itemCab.numDocumento;
                        }                       
                    }
                }                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarOrdenCompra oFrm = new frmBuscarOrdenCompra("F");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOC != null)
                {
                    OrdenCompraE oOrden = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(oFrm.oOC.idEmpresa, Convert.ToInt32(oFrm.oOC.idOrdenCompra));
                    oOrdenConver.idOrdenCompra = Convert.ToInt64(oOrden.numOrdenCompra);
                    txtOC.Text = Convert.ToString(oOrdenConver.idOrdenCompra);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
                          
        #endregion

    }
}
