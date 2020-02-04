using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Contabilidad;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmPlantillaCxp : FrmMantenimientoBase
    {
        #region Constructor

        public frmPlantillaCxp()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombo();
        }

        public frmPlantillaCxp(Int32 idEmpresa_, Int32 idPlantilla_)
            :this()
        {
            oPlantillaCxp = AgenteCtasPorPagar.Proxy.RecuperarPlantilla_ConceptoPorId(idEmpresa_, idPlantilla_);
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        Plantilla_ConceptoE oPlantillaCxp = null;

        List<Plantilla_Concepto_itemE> FilesEliminados = new List<Plantilla_Concepto_itemE>();

        public Int32 Opcion;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvPlantillaDet.Columns[0].Width = 40;  // item
            dgvPlantillaDet.Columns[1].Width = 40;  // Version de Plan de Cuenta
            dgvPlantillaDet.Columns[2].Width = 70; // Codigo de la Cuenta
            dgvPlantillaDet.Columns[3].Width = 150; // Descripcion de la Cuenta
            dgvPlantillaDet.Columns[4].Width = 45;  // Ind.Debe Haber       
            dgvPlantillaDet.Columns[5].Width = 60;  // Columna de compra - venta
            dgvPlantillaDet.Columns[6].Width = 150;  // Descripcion de la Columna  
        }

        void BloquearPaneles(Boolean Flag)
        {
            panel2.Enabled = Flag;
        }

        void LlenarCombo()
        {

            //Libros
            List<ComprobantesE> ListaTipoComprobante = AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComprobantesE p = new ComprobantesE();
            p.idComprobante = Variables.Cero.ToString();
            p.Descripcion = Variables.Todos;
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "Descripcion", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            MonedasE CampoInicial = new MonedasE();
            CampoInicial.idMoneda = Variables.Cero.ToString();
            CampoInicial.desMoneda = Variables.Seleccione;
            ListaMoneda.Add(CampoInicial);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             where (x.idMoneda == Variables.Soles) ||
                                                                   (x.idMoneda == Variables.Dolares) ||
                                                                   (x.idMoneda == Variables.Cero.ToString())
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);

        }

        void pDetalle()
        {
            if (oPlantillaCxp != null)
            {
                oPlantillaCxp.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPlantillaCxp.Opcion = (int)EnumOpcionGrabar.Actualizar;
                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                cboLibro.SelectedValue = oPlantillaCxp.idComprobante.ToString();
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oPlantillaCxp.numFile.ToString();
            }
            else
            {
                oPlantillaCxp = new Plantilla_ConceptoE();
                oPlantillaCxp.idEmpresa = VariablesLocales.SesionLocal.IdEmpresa;
                oPlantillaCxp.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPlantillaCxp.fechaRegistro = VariablesLocales.FechaHoy;
                oPlantillaCxp.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oPlantillaCxp.fechaModificacion = VariablesLocales.FechaHoy;
                oPlantillaCxp.idPlantilla = Variables.Cero;
                oPlantillaCxp.idComprobante = Variables.Cero.ToString();
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                oPlantillaCxp.numFile = Variables.Cero.ToString();
                oPlantillaCxp.Opcion = (int)EnumOpcionGrabar.Insertar;
                Opcion = (Int32)EnumOpcionGrabar.Insertar;

            }

            //idIItemTextBox.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //cantidadTextBox.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //idArticuloTextBox.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //desArticuloTextBox.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //idCCostosTextBox.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //desCCostoTextBox.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //txtPedido.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);


            bsplantillacxp.DataSource = oPlantillaCxp;      
            bsplantillacxp.ResetBindings(false);
            bsplantillacxpitem.DataSource = oPlantillaCxp.ListaPlantillaItem;
            bsplantillacxpitem.ResetBindings(false);

            
            base.Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true); 

        }

        void DatosPorGrabar()
        {

        }

        #endregion

        #region Procedimientos Heredados

        #region Procedimientos Detalles

        public override void AgregarDetalle()
        {
            //List<Plantilla_Concepto_itemE> ListTemp = new List<Plantilla_Concepto_itemE>(oPlantillaCxp.ListaPlantillaItem);
            Plantilla_Concepto_itemE oItem = new Plantilla_Concepto_itemE();
           
            frmPlantillaItem oFrm = new frmPlantillaItem();
            oFrm.Text = "Agregar Nuevo Detalle";

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
            {
                if (oPlantillaCxp.ListaPlantillaItem == null)
                    oPlantillaCxp.ListaPlantillaItem = new List<Plantilla_Concepto_itemE>();

                oFrm.Detalle.Opcion = (int)EnumOpcionGrabar.Insertar;
                oPlantillaCxp.ListaPlantillaItem.Add(oFrm.Detalle);
                bsplantillacxpitem.DataSource = oPlantillaCxp.ListaPlantillaItem;
                bsplantillacxpitem.ResetBindings(false);
                bsplantillacxpitem.MoveLast();
                base.AgregarDetalle();
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsplantillacxpitem.Current != null)
                {
                    if (oPlantillaCxp.ListaPlantillaItem != null && oPlantillaCxp.ListaPlantillaItem.Count > Variables.Cero)
                    {
                           if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                                return;

                            bsplantillacxp.EndEdit();
                            bsplantillacxpitem.EndEdit();

                            Plantilla_Concepto_itemE tmp = (Plantilla_Concepto_itemE)bsplantillacxpitem.Current;
                            tmp.Opcion = (Int32)EnumOpcionGrabar.Eliminar;

                            FilesEliminados.Add(tmp);
                            oPlantillaCxp.ListaPlantillaItem.RemoveAt(bsplantillacxpitem.Position);
                            bsplantillacxpitem.DataSource = oPlantillaCxp.ListaPlantillaItem;
                            bsplantillacxpitem.ResetBindings(false);
                            Modificacion = true;
                        
                    }
                }
                //base.QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion


        #region Procedimientos Heredados Grabacion

        public override bool ValidarGrabacion()
        {
  
            String respuesta = ValidarEntidad<Plantilla_ConceptoE>(oPlantillaCxp);

            if (!String.IsNullOrEmpty(respuesta))
            {
                Global.MensajeComunicacion(respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Grabar()
        {
            try
            {
                if (dgvPlantillaDet.IsCurrentCellDirty)
                {
                    dgvPlantillaDet.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                bsplantillacxp.EndEdit();
                bsplantillacxpitem.EndEdit();


                if (oPlantillaCxp != null)
                {
                    DatosPorGrabar();

                    if (!ValidarGrabacion()) { return; }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) != DialogResult.Yes) { return; }

                        oPlantillaCxp = AgenteCtasPorPagar.Proxy.GrabarPlantilla(oPlantillaCxp, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) != DialogResult.Yes) { return; }

                        oPlantillaCxp = AgenteCtasPorPagar.Proxy.GrabarPlantilla(oPlantillaCxp, EnumOpcionGrabar.Actualizar);

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                bsplantillacxp.DataSource = oPlantillaCxp;
                bsplantillacxp.ResetBindings(false);

                bsplantillacxpitem.DataSource = oPlantillaCxp.ListaPlantillaItem;
                bsplantillacxpitem.ResetBindings(false);

            
                Opcion = Variables.Cero;
                BloquearPaneles(false);
             
                //base.Grabar();
                //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #endregion


        private void frmPlantillaCxp_Load(object sender, EventArgs e)
        {
            LlenarCombo();
            AnchoColumnas();
            pDetalle();

        }

        private void dgvPlantillaDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvPlantillaDet.Rows.Count > Variables.Cero)
                {
                    Plantilla_Concepto_itemE Detalle = new Plantilla_Concepto_itemE();
                    Detalle = (Plantilla_Concepto_itemE)oPlantillaCxp.ListaPlantillaItem[e.RowIndex];

                    frmPlantillaItem oFrm = new frmPlantillaItem(Detalle);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Detalle != null)
                    {
                        oPlantillaCxp.ListaPlantillaItem[e.RowIndex] = oFrm.Detalle;

                        bsplantillacxpitem.DataSource = oPlantillaCxp.ListaPlantillaItem;
                        bsplantillacxpitem.ResetBindings(false);
                    }
                }
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                    ComprobantesFileE File = new ComprobantesFileE();
                    File.numFile = Variables.Cero.ToString();
                    File.Descripcion = Variables.Todos;
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "Descripcion", false);
                    //cboFile.SelectedValue = Variables.ValorCero.ToString();

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    //Limpiar(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 



    }
}
