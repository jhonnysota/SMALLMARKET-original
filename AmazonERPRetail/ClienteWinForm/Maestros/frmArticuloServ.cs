using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Maestros.Busqueda;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class frmArticuloServ : FrmMantenimientoBase
    {

        #region Constructores

        public frmArticuloServ()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            
            FormatoGrid(dgvCaracteristicas, false);
            LlenarCombos();
        }

        //Edición
        public frmArticuloServ(ArticuloServE oArticuloTmp)
            : this()
        {
            oArticuloServ = oArticuloTmp; //AgenteMaestros.Proxy.ObtenerArticuloServ(idEmpresa_, idArticulo_);
            Text = "Articulo (" + oArticuloServ.nomArticulo +")";
        }

        //Nuevo
        public frmArticuloServ(Int32 TipoArticuloTmp)
            : this()
        {
            TipoArticulo = TipoArticuloTmp;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        //VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        ArticuloServE oArticuloServ = null;
        List<ArticuloDetalleE> oListaEliminados = null;
        Int32 TipoArticulo = Variables.Cero;
        Int32 Opcion = Variables.Cero;
        String RutaImagen = String.Empty;
        String RutaTemp = string.Empty;
        Image ImagenDefecto;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            List<ParTabla> ListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaTipoArticulo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            //Unidad de Medida
            List<UMedidaE> ListaUMedida = AgenteGeneral.Proxy.ListarUMedida("%");
            ListaUMedida.Add(new UMedidaE() { idUMedida = 0, NomUMedida = Variables.Seleccione });
            ComboHelper.LlenarCombos<UMedidaE>(cboUnidadMedida, (from x in ListaUMedida orderby x.idUMedida select x).ToList(), "idUMedida", "NomUMedida");

            //Unidad de Medida Envase
            List<UMedidaE> ListaUMedidaEnva = AgenteGeneral.Proxy.ListarUMedida("%");
            ListaUMedidaEnva.Add(new UMedidaE() { idUMedida = 0, NomUMedida = Variables.Seleccione });
            ComboHelper.LlenarCombos<UMedidaE>(cboUniMedEnvase, (from x in ListaUMedida orderby x.idUMedida select x).ToList(), "idUMedida", "NomUMedida");
            

            // Detracciones
            List<TasasDetraccionesE> ListarDetracciones = AgenteGeneral.Proxy.ListarDetraccionesCabActivas();
            ListarDetracciones.Add(new TasasDetraccionesE() { idTipoDetraccion = Variables.Cero.ToString(), NombreTemp = "<<Seleccionar Detracción>>" });
            ComboHelper.LlenarCombos<TasasDetraccionesE>(cboTipoDetraccion, (from x in ListarDetracciones orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "NombreTemp");

            ListarDetracciones = null;
            ListaTipoArticulo = null;
        }

        private void Agregar(ArticuloDetalleE oDetalle)
        {
            if (oArticuloServ.ListaArticuloCaracteristica != null)
            {
                Boolean oExiste = false;

                foreach (ArticuloDetalleE item in oArticuloServ.ListaArticuloCaracteristica)
                {
                    if (oDetalle.idCaracteristica == item.idCaracteristica)
                    {
                        oExiste = true;
                        item.idCaracteristica = oDetalle.idCaracteristica;
                        item.Descripcion = oDetalle.Descripcion;
                        item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        item.fechaRegistro = VariablesLocales.FechaHoy;
                    }
                }

                if (!oExiste)
                {
                    oArticuloServ.ListaArticuloCaracteristica.Add(oDetalle);
                }
            }
            else
            {
                oArticuloServ.ListaArticuloCaracteristica = new List<ArticuloDetalleE>
                {
                    oDetalle
                };
            }

            bsArticuloDetalle.DataSource = oArticuloServ.ListaArticuloCaracteristica;
            bsArticuloDetalle.ResetBindings(false);
        }

        private void EditarDetalle()
        {
            try
            {
                if (bsArticuloDetalle.Count > 0)
                {
                    frmArticuloDetalle oFrm = new frmArticuloDetalle(((ArticuloDetalleE)bsArticuloDetalle.Current), Opcion = (Int32)EnumOpcionGrabar.Actualizar);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        Agregar(oFrm.oArticulodet);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void Datos()
        {
            if (oArticuloServ != null)
            {
                Int32 LongiCate = txtCodCategoria.TextLength;

                oArticuloServ.idTipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
                oArticuloServ.codCategoria = txtCodCategoria.Text;

                if (chkCombinar.Checked)
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        Boolean Banderita = (txtCodArticulo.Text.IndexOf(txtCodCategoria.Text) > 0);

                        if (Banderita)
                        {
                            if (txtCodArticulo.Text.Substring(0, LongiCate) == txtCodCategoria.Text)
                            {
                                oArticuloServ.codArticulo = txtCodArticulo.Text;
                            }
                            else
                            {
                                oArticuloServ.codArticulo = txtCodCategoria.Text + txtCodArticulo.Text;
                            }
                        }
                        else
                        {
                            oArticuloServ.codArticulo = txtCodCategoria.Text + txtCodArticulo.Text;
                        }
                    }
                    else
                    {
                        oArticuloServ.codArticulo = txtCodCategoria.Text + txtCodArticulo.Text;
                    }
                }
                else
                {
                    oArticuloServ.codArticulo = txtCodArticulo.Text.Replace(txtCodCategoria.Text, "");
                }
                                
                oArticuloServ.nomArticulo = txtNombre.Text;
                oArticuloServ.nomArticuloLargo = txtNombreLargo.Text;
                oArticuloServ.nomCorto = txtNombreCorto.Text;
                oArticuloServ.codBarra = txtBarras.Text;
                ///
               // oArticuloServ.codArticulo = txtCodArticulo.Text;

                Int32.TryParse(txtModelo.Text, out Int32 idModelo);
                oArticuloServ.codModelo = idModelo;
                Int32.TryParse(txtMarca.Text, out Int32 idMarca);
                oArticuloServ.codMarca = idMarca;
                oArticuloServ.codUniMedAlmacen = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                oArticuloServ.idUniMedEnvase = Convert.ToInt32(cboUniMedEnvase.SelectedValue);

                oArticuloServ.codTipoMedPresentacion = null;
                oArticuloServ.codUniMedPresentacion = null;

                decimal.TryParse(txtFraccion.Text, out decimal Contenido);
                decimal.TryParse(TxtVolumen.Text, out decimal Volumen);
                decimal.TryParse(txtPeso.Text, out decimal Peso);

                oArticuloServ.Contenido = Contenido;
                oArticuloServ.Capacidad = Volumen;
                oArticuloServ.PesoUnitario = Peso;

                oArticuloServ.indLineaVenta = false;
                oArticuloServ.codLineaVenta = string.Empty;
                oArticuloServ.indCodSunat = chkArtSunat.Checked;

                if (oArticuloServ.indCodSunat)
                {
                    oArticuloServ.CodigoSunat = Convert.ToString(cboartSunat.SelectedValue);
                }

                oArticuloServ.Combinar = chkCombinar.Checked;
                oArticuloServ.indDetraccion = chkDetraccion.Checked;

                if (chkDetraccion.Checked)
                {
                    oArticuloServ.tipDetraccion = cboTipoDetraccion.SelectedValue.ToString();
                }
                else
                {
                    oArticuloServ.tipDetraccion = String.Empty;
                }

                oArticuloServ.indReceta = ChkReceta.Checked;

                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oArticuloServ.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }
                else
                {
                    oArticuloServ.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }
            }
        }

        private void BuscarGrupoOpcion(Int32 tipArticulo)
        {
            List<ArticuloEstrucE> oListaEstructura = AgenteMaestros.Proxy.ListarArticuloEstruc(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipArticulo);
            FrmArticuloCatOpcionArbol2 frm = new FrmArticuloCatOpcionArbol2(tipArticulo, Convert.ToInt32((from x in oListaEstructura
                                                                                                        where x.indUltimoNivel == "S"
                                                                                                        select x.numNivel).SingleOrDefault()), String.Empty);
            if (frm.ShowDialog() == DialogResult.OK && frm.ArticuloCat != null)
            {
                txtCodCategoria.Text = frm.ArticuloCat.CodCategoria;
                txtDesCategoria.Text = frm.ArticuloCat.desCategoria2;
                
                if (chkCombinar.Checked)
                {
                    Int32 Codigo = AgenteMaestros.Proxy.CorrelativoArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodCategoria.Text.Trim());
                    Codigo++;

                    if (VariablesLocales.oVenParametros != null)
                    {
                        int CantidadDigitos = VariablesLocales.oVenParametros.digArticulo;
                        txtCodArticulo.Text = Codigo.ToString().PadLeft(CantidadDigitos, '0');
                    }
                    else
                    {
                        txtCodArticulo.Text = String.Format("{0:0000}", Codigo);
                    }

                    txtNombre.Focus();
                }
            }
            else
            {
                txtCodCategoria.Text = String.Empty;
                txtDesCategoria.Text = String.Empty;
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oArticuloServ == null)
            {
                oArticuloServ = new ArticuloServE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                cboTipoArticulo.SelectedValue = Convert.ToInt32(TipoArticulo);

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                chkCombinar.Checked = true;

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboTipoArticulo.SelectedValue = Convert.ToInt32(oArticuloServ.idTipoArticulo);
                txtCodCategoria.Text = oArticuloServ.codCategoria;
                txtDesCategoria.Text = oArticuloServ.desCategoria;

                if (oArticuloServ.codArticulo.IndexOf(oArticuloServ.codCategoria.ToString()) > -1)
                {
                    txtCodArticulo.Text = oArticuloServ.codArticulo.Remove(0, oArticuloServ.codCategoria.Length);
                }
                else
                {
                    txtCodArticulo.Text = oArticuloServ.codArticulo;
                }
             


                txtNombre.Text = oArticuloServ.nomArticulo;
                txtNombreLargo.Text = oArticuloServ.nomArticuloLargo;
                txtNombreCorto.Text = oArticuloServ.nomCorto;
                txtBarras.Text = oArticuloServ.codBarra;
                txtModelo.Text = oArticuloServ.codModelo == 0 ? String.Empty : oArticuloServ.codModelo.ToString();
                txtMarca.Text = oArticuloServ.codMarca == 0 ? String.Empty : oArticuloServ.codMarca.ToString();
                txtDesMarca.Text = oArticuloServ.desMarca;
                txtDesModelo.Text = oArticuloServ.desModelo;

                //Unidad de Medida
                cboUnidadMedida.SelectedValue = Convert.ToInt32(oArticuloServ.codUniMedAlmacen);
                //Unidad de Medida Envase
                cboUniMedEnvase.SelectedValue = Convert.ToInt32(oArticuloServ.idUniMedEnvase);

                txtFraccion.Text = oArticuloServ.Contenido.ToString("N2");
                TxtVolumen.Text = oArticuloServ.Capacidad.ToString("N2");
                txtPeso.Text = oArticuloServ.PesoUnitario.ToString("N6");
                //chkLineaVenta.Checked = oArticuloServ.indLineaVenta;

                //if (oArticuloServ.indLineaVenta)
                //{
                //    cboLinea.SelectedValue = oArticuloServ.codLineaVenta;
                //}

                chkCombinar.Checked = oArticuloServ.Combinar;
                chkDetraccion.Checked = oArticuloServ.indDetraccion;

                if (oArticuloServ.indDetraccion)
                {
                    cboTipoDetraccion.SelectedValue = oArticuloServ.tipDetraccion.ToString();
                }

                chkArtSunat.Checked = oArticuloServ.indCodSunat;

                if (chkArtSunat.Checked)
                {
                    cboartSunat.SelectedValue = oArticuloServ.CodigoSunat;
                }

                ChkReceta.Checked = oArticuloServ.indReceta;
                txtUsuarioRegistro.Text = oArticuloServ.UsuarioRegistro;
                txtFechaRegistro.Text = oArticuloServ.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oArticuloServ.UsuarioModificacion;
                txtFechaModificacion.Text = oArticuloServ.FechaModificacion.ToString();

                bsArticuloDetalle.DataSource = oArticuloServ.ListaArticuloCaracteristica;
                bsArticuloDetalle.ResetBindings(false);

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                Datos();

                if (ValidarGrabacion())
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oArticuloServ = AgenteMaestros.Proxy.GrabarArticuloServ(oArticuloServ, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados != null && oListaEliminados.Count > Variables.Cero)
                            {
                                foreach (ArticuloDetalleE item in oListaEliminados)
                                {
                                    oArticuloServ.ListaArticuloCaracteristica.Add(item);
                                }
                            }

                            oArticuloServ = AgenteMaestros.Proxy.GrabarArticuloServ(oArticuloServ, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    base.Grabar();
                    oArticuloServ = null;
                    oListaEliminados = null;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String resultado = ValidarEntidad<ArticuloServE>(oArticuloServ);

            if (!String.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            return base.ValidarGrabacion();
        }
        
        public override void AgregarDetalle()
        {
            try
            {
                frmArticuloDetalle oFrm = new frmArticuloDetalle();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oArticulodet != null)
                {
                    Agregar(oFrm.oArticulodet);

                    bsArticuloDetalle.DataSource = oArticuloServ.ListaArticuloCaracteristica;
                    bsArticuloDetalle.ResetBindings(false);
                    base.AgregarDetalle();

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410") //Solamente Power seed y AyV Seed
                    {
                        //StringBuilder oSb = new StringBuilder();
                        //String NombreDetalle = String.Empty;

                        //foreach (ArticuloDetalleE item in oArticuloServ.ListaArticuloCaracteristica)
                        //{
                        //    if (oFrm.oArticulodet.DesArticulo.Contains("TIPO"))
                        //    {
                        //        oSb.Append(txtNombre.Text.Trim()).Append(" ").Append(oFrm.oArticulodet.Descripcion.Trim()).Append(" ");
                        //    }
                        //    else
                        //    {
                        //        oSb.Append(txtNombre.Text.Trim()).Append(" ").Append(oFrm.oArticulodet.Descripcion.Trim()).Append(" ");
                        //    }
                        //}

                        //oSb.Append(txtNombreLargo.Text.Trim());
                        //txtNombre.Text = DevolverNombre(oArticuloServ.ListaArticuloCaracteristica);
                    }
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
                if (bsArticuloDetalle.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oListaEliminados == null)
                        {
                            oListaEliminados = new List<ArticuloDetalleE>();
                        }

                        base.QuitarDetalle();
                        //Actualizando el campo para saber que se va a realizar...
                        ((ArticuloDetalleE)bsArticuloDetalle.Current).Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                        //Agregando a la lista de eliminados
                        oListaEliminados.Add((ArticuloDetalleE)bsArticuloDetalle.Current);
                        //Removiendo de la lista principal(temporalmente)...
                        oArticuloServ.ListaArticuloCaracteristica.RemoveAt(bsArticuloDetalle.Position);
                        //Actualizando la lista...
                        bsArticuloDetalle.DataSource = oArticuloServ.ListaArticuloCaracteristica;
                        bsArticuloDetalle.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmArticuloServ_Load(object sender, EventArgs e)
        {
            Grid = false;
            ImagenDefecto = pbImagen.Image;
            chkCombinar.Visible = false;
            Nuevo();

            if (VariablesLocales.oVenParametros != null)
            {
                int CantidadDigitos = VariablesLocales.oVenParametros.digArticulo;
                txtCodArticulo.MaxLength = CantidadDigitos;
            }
        }

        private void btCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarGrupoOpcion(Convert.ToInt32(cboTipoArticulo.SelectedValue));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        //private void chkLineaVenta_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkLineaVenta.Checked)
        //    {
        //        cboLinea.Enabled = true;
        //        List<LineaE> ListaLineaVenta = AgenteVentas.Proxy.ListarLinea(VariablesLocales.SesionLocal.IdEmpresa);
        //        LineaE L = new LineaE() { idLinea = Variables.Cero.ToString(), Descripcion = Variables.Seleccione };
        //        ListaLineaVenta.Add(L);
        //        ComboHelper.RellenarCombos<LineaE>(cboLinea, (from x in ListaLineaVenta orderby x.idLinea select x).ToList(), "idLinea", "Descripcion", false);
        //    }
        //    else
        //    {
        //        cboLinea.Enabled = false;
        //    }
        //}

        private void dgvCaracteristicas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle();
            }
        }

        private void chkCombinar_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkCombinar.Checked)
            //{
            //    txtCodArticulo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            //}
            //else
            //{
            //    txtCodArticulo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            //}
        }

        //private void cboUniMedPres_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<UMedidaE> ListaUMedidaPres = ListaUnidadMedida(Convert.ToInt32(cboUniMedPres.SelectedValue));
        //        ComboHelper.LlenarCombos<UMedidaE>(cboUnidadMedidaP, ListaUMedidaPres, "idUMedida", "NomUMedida");
        //        ListaUMedidaPres = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.MensajeFault(ex.Message);
        //    }
        //}

        private void cboUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboUniMedEnvase_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtPeso_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPeso.Text))
            {
                txtPeso.Text = Convert.ToDecimal(txtPeso.Text).ToString("N6"); 
            }
        }

        private void txtContenido_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFraccion.Text))
            {
                txtFraccion.Text = Global.FormatoDecimal(txtFraccion.Text);
            }
        }

        private void TxtVolumen_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtVolumen.Text))
            {
                TxtVolumen.Text = Global.FormatoDecimal(TxtVolumen.Text);
            }
        }

        private void btVerImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (oArticuloServ.NombreImagen != "")
                {
                    oArticuloServ.RutaImagen = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos";

                    string RutaFisica = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos\";
                    string Archivo = oArticuloServ.NombreImagen + oArticuloServ.Extension;

                    if (!Directory.Exists(RutaFisica))
                    {
                        Directory.CreateDirectory(RutaFisica);
                    }

                    if (!File.Exists(RutaFisica + Archivo))
                    {
                        oArticuloServ = AgenteMaestros.Proxy.ObtenerImagenArticulo(oArticuloServ);
                        File.WriteAllBytes(RutaFisica + Archivo, oArticuloServ.Imagen);
                        pbImagen.Image = Global.ObtenerByteImagen(oArticuloServ.Imagen);
                    }
                    else
                    {
                        pbImagen.Image = Image.FromFile(RutaFisica + Archivo);
                    }

                    RutaTemp = RutaFisica + Archivo;
                    pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    Global.MensajeComunicacion("No Existe Imagen Para Este Articulo");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btObtener_Click(object sender, EventArgs e)
        {
            try
            {
                RutaImagen = CuadrosDialogo.BuscarArchivo("Buscar Imagenes - Articulos", "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png");

                if (!String.IsNullOrEmpty(RutaImagen))
                {
                    pbImagen.Image = Image.FromFile(RutaImagen);
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (oArticuloServ != null)
                    {
                        string nombreGuid = Guid.NewGuid().ToString();
                        oArticuloServ.NombreReal = Path.GetFileNameWithoutExtension(RutaImagen);
                        oArticuloServ.NombreImagen = nombreGuid;
                        oArticuloServ.Extension = Path.GetExtension(RutaImagen);
                        oArticuloServ.RutaImagen = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos";

                        if (pbImagen.Image != null)
                        {
                            oArticuloServ.Imagen = Global.ObtenerImagenBytes(pbImagen.Image);
                        }
                        else
                        {
                            oArticuloServ.Imagen = null;
                        }
                    }
                }
                else
                {
                    RutaImagen = String.Empty;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                //oArticuloServ = AgenteMaestros.Proxy.ObtenerImagenArticulo(oArticuloServ);
                oArticuloServ.RutaFisica = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos\";

                // Borrando Imagen del Servidor
                oArticuloServ.Archivo = oArticuloServ.NombreImagen + oArticuloServ.Extension;
                oArticuloServ.RutaImagen = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\Articulos\";

                if (!String.IsNullOrEmpty(oArticuloServ.Archivo))
                {
                    if (oArticuloServ != null)
                    {
                        oArticuloServ = AgenteMaestros.Proxy.BorrarImagenArticulo(oArticuloServ);
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Este Archivo No Contiene Una Imagen Servidor");
                }

                // Borrando Imagen de la Maquina Local si Existiera
                if (File.Exists(oArticuloServ.RutaFisica + oArticuloServ.Archivo))
                {
                    pbImagen.Image = null;
                    oArticuloServ = AgenteMaestros.Proxy.BorrarImagenArticuloLocal(oArticuloServ);
                    oArticuloServ.Imagen = null;
                    oArticuloServ.Extension = "";
                    oArticuloServ.NombreImagen = "";
                    oArticuloServ.NombreReal = "";
                    oArticuloServ = AgenteMaestros.Proxy.ActualizarArticuloServ(oArticuloServ);
                    Global.MensajeComunicacion("Esta Imagen Se Elimino Correctamente");

                    //pbImagen.Image = null;
                    //String RutaImagenDefecto = @"D:\Visual Net 2015\ERPIndusoftNet\ClienteWinForm\Resources\producto_sin_imagen.jpg";
                    pbImagen.Image = ImagenDefecto;

                }
                else
                {
                    Global.MensajeComunicacion("Este Archivo No Contiene Una Imagen Local");
                }

                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btZoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(RutaTemp))
                {
                    return;
                }

                pbImagen.Image = null;
                pbImagen.Image = Image.FromFile(RutaTemp);
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                pbImagen.Refresh();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btVolteo_Click(object sender, EventArgs e)
        {
            try
            {
                Image bmp = pbImagen.Image;

                if (bmp != null)
                {
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pbImagen.Image = bmp;
                    bmp = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDetraccion.Checked)
            {
                cboTipoDetraccion.Enabled = true;
            }
            else
            {
                cboTipoDetraccion.Enabled = false;
                cboTipoDetraccion.SelectedValue = "0";
            }
        }

        private void btMarca_Click(object sender, EventArgs e)
        {
            frmBuscarMarcas oFrm = new frmBuscarMarcas(4);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Marcas != null)
            {
                txtMarca.Text = Convert.ToString(oFrm.Marcas.idMarca);
                txtDesMarca.Text = oFrm.Marcas.nombre;
                txtModelo.Text = "";
                txtDesModelo.Text = ""; ;
            }
        }

        private void btBuscarModelo_Click(object sender, EventArgs e)
        {
            //Int32 idMarca = 0;

            //if (txtMarca.Text != "")
            //{
            //    idMarca = Convert.ToInt32(txtMarca.Text);
            //}

            //frmBuscarModelo oFrm = new frmBuscarModelo(4, idMarca);

            //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oModelos != null)
            //{
            //    txtModelo.Text = Convert.ToString(oFrm.oModelos.idModelo);
            //    txtDesModelo.Text = oFrm.oModelos.nombre;
            //}
        }

        private void chkArtSunat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboartSunat.Enabled = chkArtSunat.Checked;

                if (chkArtSunat.Checked)
                {
                    List<ArticuloServSunatE> ListaLineaVenta = AgenteMaestros.Proxy.ListarArticuloServSunat(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                    ListaLineaVenta.Add(new ArticuloServSunatE() { CodigoSunat = Variables.Cero.ToString(), Descripcion = Variables.Seleccione });
                    ComboHelper.RellenarCombos<ArticuloServSunatE>(cboartSunat, (from x in ListaLineaVenta orderby x.CodigoSunat select x).ToList(), "CodigoSunat", "Descripcion", false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
        private void btMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter))
            {
                frmBuscarMarcas oFrm = new frmBuscarMarcas(4);
                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Marcas != null)
                {
                    txtMarca.Text = Convert.ToString(oFrm.Marcas.idMarca);
                    txtDesMarca.Text = oFrm.Marcas.nombre;
                    txtModelo.Text = "";
                    txtDesModelo.Text = ""; ;
                }
            }
        }

        #endregion Eventos




    }
}