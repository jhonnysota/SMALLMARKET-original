using ClienteWinForm.Maestros;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas.Comisiones
{
    public partial class frmComisionesConfiguracion : FrmMantenimientoBase
    {

        #region Constructores

        public frmComisionesConfiguracion()
        {
            InitializeComponent();
            LlenarCombos();
            FormatoGrid(dgvListadoCategoria, false);
            FormatoGrid(dgvListadoVendedor, false);
            FormatoGrid(dgvListadoLineas, false);
            FormatoGrid(dgvListadoSubjetivo, false);
            FormatoGrid(dgvListadoTarifario, false);
        }

        public frmComisionesConfiguracion(ComisionesConfiguracionE oEntidad_)
            : this()
        {
            oEntidad = oEntidad_;
        } 

        #endregion

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }

        public ComisionesConfiguracionE oEntidad;

        int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
        String RutaPdf = String.Empty;
        int idCategoriaSeleccionada = 0;

        List<ComisionesConfiguracionE> oListaCategoria = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaLineaGeneral = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaLinea = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaTarifarioGeneral = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaTarifario = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaCriterio = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaVendedor = new List<ComisionesConfiguracionE>();

        private void frmComisionesConfiguracion_Load(object sender, EventArgs e)
        {
            Grid = false;

            //BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);            
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            base.Nuevo();

            if (oEntidad.idComision != 0)
            {
                cboPeriodo.SelectedValue = oEntidad.idPeriodo;
                txtNombreZona.Text = oEntidad.NombreZona;

                oListaCategoria = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "categoria");
                oListaLineaGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "linea");
                oListaTarifarioGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "tarifario");
                oListaCriterio = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "criterio");
                oListaVendedor = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "vendedor");

                bsCategorias.DataSource = oListaCategoria;
                bsCategorias.ResetBindings(false);

                if (oListaCategoria != null && oListaCategoria.Count > 0)
                    idCategoriaSeleccionada = oListaCategoria[0].idCategoria;
                else
                    idCategoriaSeleccionada = 0;

                oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                bsLineas.DataSource = oListaLinea;
                bsLineas.ResetBindings(false);

                oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                bsTarifario.DataSource = oListaTarifario;
                bsTarifario.ResetBindings(false);

                bsCriterios.DataSource = oListaCriterio;
                bsCriterios.ResetBindings(false);

                bsVendedor.DataSource = oListaVendedor;
                bsVendedor.ResetBindings(false);
            }
            else
            {
                oEntidad.Estado = "Activo";

                oEntidad.UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial;
                oEntidad.FechaRegistra = VariablesLocales.FechaHoy;
                oEntidad.UsuarioModifica = VariablesLocales.SesionUsuario.Credencial;
                oEntidad.FechaModifica = VariablesLocales.FechaHoy;
            }

            txtNombreZona.Focus();
        }

        // ===================================================================================
        // GRABAR
        // ===================================================================================
        public override void Grabar()
        {
            try
            {
                // Validando si Trabajador ya esta en otra zona del mismo periodo



                // VALIDAMOS DATA
                if (txtNombreZona.Text.Trim().Length == 0)
                {
                    Global.MensajeAdvertencia("Debe de ingresar el Nombre de Zona");
                    txtNombreZona.Focus();
                }
                else
                {

                    oEntidad.NombreZona = txtNombreZona.Text;
                    oEntidad.idPeriodo = Convert.ToInt32(cboPeriodo.SelectedValue);

                    oEntidad.oListaCategoria = oListaCategoria;

                    oEntidad.oListaLinea = oListaLineaGeneral;
                    oEntidad.oListaTarifario = oListaTarifarioGeneral;

                    oEntidad.oListaCriterio = oListaCriterio;
                    oEntidad.oListaVendedor = oListaVendedor;

                    // Guardar SQL
                    AgenteVentas.Proxy.GuardarComisiones(oEntidad);

                    //MENSAJE
                    if (oEntidad.idComision==0)
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    else
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
                //bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                //bsListaVouchers.ResetBindings(false);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsCategorias.Count > 0 || bsCriterios.Count > 0 || bsLineas.Count > 0 || bsTarifario.Count > 0 || bsVendedor.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionComisionesconfiguracion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmImpresionComisionesconfiguracion(oEntidad, oListaVendedor, oListaCriterio, oListaTarifario, oListaLinea, oListaCategoria);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.Show();

                    base.Imprimir();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void LlenarCombos()
        {
            //////Periodo/////////
            List<PeriodoComisionE> ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<PeriodoComisionE>(cboPeriodo, (from x in ListaComision orderby x.Anio descending, x.Mes descending select x).ToList(), "idPeriodo", "Nombre", false);
        }
        

        void Response(String TipoReporte,String Modo,ComisionesConfiguracionE oEntidad,List<ComisionesConfiguracionE> oListaValida)
        {
            try
            {
                //FORMULARIO
                frmComisionesConfiguracionResponse oFrm =
                    new frmComisionesConfiguracionResponse(TipoReporte,Modo, oEntidad, oListaValida);

                // CIERRE FORMULARIO
                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    if (TipoReporte == "vendedor")
                    {
                        if (oListaVendedor == null)
                            oListaVendedor = new List<ComisionesConfiguracionE>();

                        
                        oListaVendedor.Add(oFrm.oEntidad);
                        

                        bsVendedor.DataSource = oListaVendedor;
                        bsVendedor.ResetBindings(false);
                    }
                    if (TipoReporte == "categoria")
                    {
                        if (oListaCategoria == null)
                            oListaCategoria = new List<ComisionesConfiguracionE>();

                        idCategoriaSeleccionada = oEntidad.idCategoria;

                        oListaCategoria.Add(oFrm.oEntidad);

                        List<CategoriaVendedorLineaE> oLista = AgenteVentas.Proxy.ListarCategoriaVendedorLinea(oEntidad.idEmpresa, idCategoriaSeleccionada);

                        foreach(CategoriaVendedorLineaE item in oLista)
                        {
                            oListaLineaGeneral.Add(new ComisionesConfiguracionE() {
                                                            idEmpresa=idEmpresa, 
                                                            idLinea = Convert.ToInt32(item.idLinea), 
                                                            desLinea = item.desLinea, 
                                                            idCategoria = idCategoriaSeleccionada,
                                                            UsuarioRegistra = VariablesLocales.SesionUsuario.Credencial,
                                                            FechaRegistra = VariablesLocales.FechaHoy,
                                                            FechaModifica = VariablesLocales.FechaHoy,
                                                            UsuarioModifica = VariablesLocales.SesionUsuario.Credencial
                            });
                        }

                        oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                        bsLineas.DataSource = oListaLinea;
                        bsLineas.ResetBindings(false);

                        oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                        bsTarifario.DataSource = oListaTarifario;
                        bsTarifario.ResetBindings(false);

                        bsCategorias.DataSource = oListaCategoria;
                        bsCategorias.ResetBindings(false);
                    }
                    if (TipoReporte == "linea")
                    {
                        if (oListaLineaGeneral == null)
                            oListaLineaGeneral = new List<ComisionesConfiguracionE>();

                        oFrm.oEntidad.idCategoria = idCategoriaSeleccionada ;

                        Boolean oNoExiste = true;
                        for (int i = 0; i < oListaLineaGeneral.Count; i++)
                        {
                            if (oListaLineaGeneral[i].idCategoria == oFrm.oEntidad.idCategoria && oListaLineaGeneral[i].idLinea == oFrm.oEntidad.idLinea)
                            {
                                oListaLineaGeneral[i].Meta = oFrm.oEntidad.Meta;
                                oListaLineaGeneral[i].Pago = oFrm.oEntidad.Pago;
                                oNoExiste = false;
                            }
                        }

                        if(oNoExiste)
                            oListaLineaGeneral.Add(oFrm.oEntidad);

                        oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                        bsLineas.DataSource = oListaLinea;
                        bsLineas.ResetBindings(false);
                    }
                    if (TipoReporte == "tarifario")
                    {
                        if (oListaTarifario == null)
                            oListaTarifario = new List<ComisionesConfiguracionE>();

                        oFrm.oEntidad.idCategoria = idCategoriaSeleccionada;

                        Boolean oNoExiste = true;
                        for (int i = 0; i < oListaTarifario.Count; i++)
                        {
                            if (oListaTarifario[i].RangoIni == oFrm.oEntidad.RangoIni && oListaTarifario[i].RangoFin == oFrm.oEntidad.RangoFin)
                            {
                                oListaLineaGeneral[i].Factor = oFrm.oEntidad.Factor;
                                oListaLineaGeneral[i].Comision = oFrm.oEntidad.Comision;
                                oNoExiste = false;
                            }
                        }

                        if (oNoExiste)
                            oListaTarifarioGeneral.Add(oFrm.oEntidad);

                        oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                        bsTarifario.DataSource = oListaTarifario;
                        bsTarifario.ResetBindings(false);
                    }
                    if (TipoReporte == "criterio")
                    {
                        if (oListaCriterio == null)
                            oListaCriterio = new List<ComisionesConfiguracionE>();

                        Boolean oNoExiste = true;
                        for (int i = 0; i < oListaCriterio.Count; i++)
                        {
                            if (oListaCriterio[i].idParTabla == oFrm.oEntidad.idParTabla)
                            {
                                oListaCriterio[i].Comision = oFrm.oEntidad.Comision;
                                oNoExiste = false;
                            }
                        }

                        if (oNoExiste)
                            oListaCriterio.Add(oFrm.oEntidad);

                        bsCriterios.DataSource = oListaCriterio;
                        bsCriterios.ResetBindings(false);
                    }
                }

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }


        private void dgvListadoVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Response("vendedor","actualizar", (ComisionesConfiguracionE)bsVendedor.Current, oListaVendedor);
        }

        private void dgvListadoCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Response("categoria", "actualizar", (ComisionesConfiguracionE)bsCategorias.Current, oListaCategoria);
        }

        private void dgvListadoSubjetivo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Response("criterio", "actualizar", (ComisionesConfiguracionE)bsCriterios.Current, oListaCriterio);
        }

        private void dgvListadoTarifario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Response("tarifario", "actualizar", (ComisionesConfiguracionE)bsTarifario.Current, oListaTarifario);
        }

        private void dgvListadoLineas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Response("linea", "actualizar", (ComisionesConfiguracionE)bsLineas.Current, oListaLinea);
        }



        private void btnAgregarVendedor_Click(object sender, EventArgs e)
        {
            Response("vendedor", "nuevo", new ComisionesConfiguracionE() { idEmpresa = idEmpresa, idVendedor = 0, idComisionVendedor = 0 }, oListaVendedor);
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response("categoria", "nuevo", new ComisionesConfiguracionE() { idEmpresa = idEmpresa, idCategoria = 0, idComisionCategoria = 0 }, oListaCategoria);
        }

        private void btnAgregarCriterio_Click(object sender, EventArgs e)
        {
            Response("criterio", "nuevo", new ComisionesConfiguracionE() { idEmpresa = idEmpresa, idParTabla = 0, idComisionCriterio = 0 }, oListaCriterio);
        }

        private void btnAgregarLineas_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada != 0)
            {
                Response("linea", "nuevo", new ComisionesConfiguracionE() { idEmpresa = idEmpresa, idLinea = 0, idComisionLinea = 0, idCategoria = idCategoriaSeleccionada }, oListaLinea);
            }
            else
            {
                Global.MensajeFault("Debe de seleccionar una Categoria");
            }
        }

        private void btnAgregarTarifario_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada != 0)
            {
                Response("tarifario", "nuevo", new ComisionesConfiguracionE() { idEmpresa = idEmpresa, idComisionTarifario = 0 }, oListaTarifario);
            }
            else
            {
                Global.MensajeFault("Debe de seleccionar una Categoria");
            }
            
        }

        
        private void dgvListadoVendedor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex ==1)
            {
                dgvListadoVendedor.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.LightYellow;
            }
        }

        private void dgvListadoCategoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgvListadoCategoria.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.LightYellow;
            }
        }

        private void dgvListadoSubjetivo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgvListadoSubjetivo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.LightYellow;
            }
            if (e.ColumnIndex == 2)
            {
                dgvListadoSubjetivo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }
        }

        private void dgvListadoLineas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                dgvListadoLineas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.LightYellow;
            }
            if (e.ColumnIndex == 2 )
            {
                dgvListadoLineas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }
        }

        private void dgvListadoTarifario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                dgvListadoTarifario.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }
        }

        private void dgvListadoCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            ComisionesConfiguracionE oItemSeleccionado = (ComisionesConfiguracionE)bsCategorias.Current;

            idCategoriaSeleccionada = oItemSeleccionado.idCategoria;

            oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

            bsLineas.DataSource = oListaLinea;
            bsLineas.ResetBindings(false);

            oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

            bsTarifario.DataSource = oListaTarifario;
            bsTarifario.ResetBindings(false);
        }

        private void btnQuitarVendedor_Click(object sender, EventArgs e)
        {   
            try
            {
                if (bsVendedor.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {

                        oListaVendedor.RemoveAt(bsVendedor.Position);

                        bsVendedor.DataSource = oListaVendedor;
                        bsVendedor.ResetBindings(false);

                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCriterios.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oListaCriterio.RemoveAt(bsCriterios.Position);
                        bsCriterios.DataSource = oListaCriterio;
                        bsCriterios.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsLineas.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oListaLineaGeneral.Remove((ComisionesConfiguracionE)bsLineas.Current);
                        oListaLinea.RemoveAt(bsLineas.Position);

                        bsLineas.DataSource = oListaLinea;
                        bsLineas.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnQuitarTarifario_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsTarifario.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oListaTarifarioGeneral.Remove((ComisionesConfiguracionE)bsTarifario.Current);
                        oListaTarifario.RemoveAt(bsTarifario.Position);

                        bsTarifario.DataSource = oListaTarifario;
                        bsTarifario.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnQuitarCategoria_Click(object sender, EventArgs e)
        {

        }

        private void enviarCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //oEntidad, oListaVendedor, oListaCriterio, oListaTarifario, oListaLinea, oListaCategoria

                if (oEntidad != null)
                {
                    CrearPdf(oEntidad);

                    frmEnvioCorreos oFrm = new frmEnvioCorreos(oEntidad, RutaPdf);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }


        void CrearPdf(ComisionesConfiguracionE oEntidade)
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            String NombreReporte = "Orden Compra " + oEntidad.NombreZona;
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            docPdf.AddAuthor("D&J Software");
            docPdf.AddCreator("D&J Software");
            docPdf.AddTitle("Comisiones Configuracion");
            docPdf.AddSubject("Listas");
            oListaLineaGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "linea");
            oListaTarifarioGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "tarifario");
            

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                String TituloGeneral = " Comisiones Configuracion Con Nombre del Vendedor: " + oEntidad.desPersona;
                String SubTitulo = String.Empty;
                PdfPCell cell = null;

                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    BaseColor ColorFondo = new BaseColor(178, 178, 178); //Gris Claro
                    iTextSharp.text.Font FuenteEstandar = FontFactory.GetFont("Arial", 6.25f);
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    docPdf.Open();

                    DateTime FechaActual = VariablesLocales.FechaHoy.Date;
                    int size = 8;

                    PdfPTable tabletit = new PdfPTable(3);

                    tabletit.WidthPercentage = 100;
                    tabletit.SetWidths(new float[] { 0.3f, 0.4f, 0.3f });
                    tabletit.HorizontalAlignment = Element.ALIGN_CENTER;


                    cell = CellPdf(" ", size, false, "", "");
                    tabletit.AddCell(cell);
                    cell = CellPdf("CALCULO DE COMISIONES", 15, false, "", "bold");
                    tabletit.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    tabletit.AddCell(cell);
                    tabletit.CompleteRow();

                    foreach (ComisionesConfiguracionE item in oListaVendedor)
                    {

                        cell = CellPdf(item.desPersona, 12, false, "", "bold");
                        tabletit.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tabletit.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        tabletit.AddCell(cell);
                        tabletit.CompleteRow();
                    }
                    docPdf.Add(tabletit);


                    PdfPTable table = new PdfPTable(5);

                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 0.2f, 0.3f, 0.3f, 0.3f, 0.5f });
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    int idCategoriaSeleccionada = 0;
                    int idCategoriaSeleccionada1 = 0;
                    decimal meta = 0;
                    decimal resultado = 0;
                    decimal cumplimiento = 0;
                    decimal comision = 0;
                    // ===========================================




                    foreach (ComisionesConfiguracionE item2 in oListaCategoria)
                    {


                        cell = CellPdf(" Categoria: ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(item2.idCategoria.ToString() + "    " + item2.desCategoria, size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" Linea", size, true, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" Meta en 9L", size, true, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" Resultado", size, true, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" Cumplimiento", size, true, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" Comision Asociada Segun Acuerdo", size, true, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        idCategoriaSeleccionada = item2.idCategoria;
                        oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();
                        oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();
                        foreach (ComisionesConfiguracionE item in oListaLinea)
                        {


                            cell = CellPdf(item.desLinea, size, false, "c", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.Meta.ToString("N2"), size, false, "r", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.Resultado.ToString("N2"), size, false, "r", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.Porcentaje.ToString("N2"), size, false, "r", "");
                            table.AddCell(cell);
                            cell = CellPdf(item.Pago.ToString("N2"), size, false, "r", "");
                            table.AddCell(cell);
                            table.CompleteRow();

                            comision += item.Pago;
                            meta += item.Meta;
                            resultado += item.Resultado;
                            cumplimiento += item.Porcentaje;

                        }
                        idCategoriaSeleccionada1++;

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf("_______________", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf("_______________", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf("_____________________", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf("______________________________", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf("Total", size, false, "c", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(meta.ToString(), size, false, "r", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(resultado.ToString(), size, false, "r", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(cumplimiento.ToString() + "%", size, false, "r", "bold");
                        table.AddCell(cell);
                        cell = CellPdf(comision.ToString(), size, false, "r", "bold");
                        table.AddCell(cell);
                        table.CompleteRow();
                        idCategoriaSeleccionada1++;
                    }


                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    table.CompleteRow();

                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    cell = CellPdf("Elementos Subjetivos ", size, true, "c", "");
                    table.AddCell(cell);
                    cell = CellPdf(" ", size, false, "", "");
                    table.AddCell(cell);
                    table.CompleteRow();

                    foreach (ComisionesConfiguracionE item in oListaCriterio)
                    {

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.desParTabla, size, true, "c", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.Comision.ToString("N2"), size, false, "r", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        comision += item.Comision;

                    }


                    foreach (ComisionesConfiguracionE item in oListaVendedor)
                    {
                        cell = CellPdf(" ", size, false, "c", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "c", "");
                        table.AddCell(cell);
                        cell = CellPdf("Total comision", size, true, "c", "");
                        table.AddCell(cell);
                        cell = CellPdf(item.desPersona, size, true, "c", "");
                        table.AddCell(cell);
                        cell = CellPdf(comision.ToString("N2"), size, false, "r", "bold");
                        table.AddCell(cell);
                        table.CompleteRow();
                    }


                    docPdf.Add(table);
                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        PdfPCell CellPdf(string titulo, int size, Boolean border, string align, string bold)
        {
            if (!border)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { Border = 0, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }

    }
}
