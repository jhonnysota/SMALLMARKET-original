using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Tools;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Maestros
{
    public partial class FrmEmpresa : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevos
        public FrmEmpresa()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvEmpresas, true);
            LlenarCombos();
        }

        //Edición
        public FrmEmpresa(Int32 idEmpresa, String _Departamento, String _Provincia)
            : this()
        {
            empresa = AgenteMaestros.Proxy.RecuperarEmpresaPorID(Convert.ToInt32(idEmpresa));
            Departamento = _Departamento;
            Provincia = _Provincia;
        }

        #endregion Constructores

        #region Variables

        public Empresa empresa = null;

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        public String Departamento;
        public String Provincia;
        public String Distrito;
        String Direccion;
        Int16 Opcion = Variables.Cero;

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<UbigeoE> ListaDepartamento = AgenteMaestros.Proxy.ListarDepartamentos();
            ListaDepartamento.Add(new UbigeoE() { Departamento = Variables.SeleccionDepartamento });

            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, ListaDepartamento, "Departamento", "Departamento");
        }

        void EditarDetalle(DataGridViewCellEventArgs e, EmpresaImagenesE current)
        {
            try
            {
                if (bsEmpresaImagenes.Count > 0)
                {
                    String RutaImagen = String.Empty;

                    if (!String.IsNullOrWhiteSpace(txtIdEmpresa.Text) || txtIdEmpresa.Text != "0")
                    {
                        if (current.idImagen == 1) //Firma
                        {
                            RutaImagen = VariablesLocales.ObtenerFirma(Convert.ToInt32(txtIdEmpresa.Text), txtRuc.Text.Trim());
                        }
                        else if (current.idImagen == 2) //Logo
                        {
                            RutaImagen = VariablesLocales.ObtenerLogo(Convert.ToInt32(txtIdEmpresa.Text), txtRazonSocial.Text.Trim());
                        }
                        else //Letra
                        {
                            RutaImagen += VariablesLocales.ObtenerLetra(Convert.ToInt32(txtIdEmpresa.Text), txtRazonSocial.Text.Trim());
                        } 
                    }

                    frmEmpresaImagenes oFrm = new frmEmpresaImagenes(current, RutaImagen);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        empresa.ListaEmpresaImagenes[e.RowIndex] = oFrm.oEmpresaImagen;
                        bsEmpresaImagenes.DataSource = empresa.ListaEmpresaImagenes;
                        bsEmpresaImagenes.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void DatosPorGuardar()
        {
            if (empresa != null)
            {
                empresa.RUC = txtRuc.Text;
                empresa.RazonSocial = Global.DejarSoloUnEspacio(txtRazonSocial.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
                empresa.NombreComercial = Global.DejarSoloUnEspacio(txtNombreComercial.Text.Trim().Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));
                empresa.RepresentanteLegal = txtRepresentante.Text;
                empresa.sNumDocRepresentante = txtNumDocRepre.Text;
                empresa.sTelefonos = txtTelefonos.Text;
                empresa.sFax = txtFax.Text;
                empresa.sWeb = txtWeb.Text;
                empresa.sEmail = txtEmail.Text;
                empresa.sEmailFe = txtEmailFact.Text;
                empresa.sEmailOtros = txtEmailOtros.Text;
                empresa.Fda = string.Empty;
                empresa.AgenteRetenedor = chkRetencion.Checked;
                empresa.PrincipalContribuyente = chkContribuyente.Checked;
                empresa.idUbigeo = cboDistrito.SelectedValue.ToString();
                empresa.DireccionCompleta = txtDireccion.Text;

                if (!String.IsNullOrEmpty(txtUsuarioSol.Text.Trim()))
                {
                    empresa.UsuarioSol = EncryptHelper.EncryptToByte(txtUsuarioSol.Text);
                }
                else
                {
                    empresa.UsuarioSol = null;
                }

                if (!String.IsNullOrEmpty(txtClaveSol.Text.Trim()))
                {
                    empresa.ClaveSol = EncryptHelper.EncryptToByte(txtClaveSol.Text);
                }
                else
                {
                    empresa.ClaveSol = null;
                }

                empresa.indCalzado = chkCalzado.Checked;

                if (Opcion == (Int16)EnumOpcionGrabar.Insertar)
                {
                    empresa.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }
                else
                {
                    empresa.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (empresa == null)
            {
                empresa = new Empresa();
                txtUsuarioReg.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaReg.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaMod.Text = VariablesLocales.FechaHoy.ToString();

                txtRuc.Focus();

                cboDepartamento.SelectedValue = Variables.SeleccionDepartamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                cboProvincia.SelectedValue = Variables.SeleccioneProvincia;
                cboDistrito.SelectedValue = Variables.Cero.ToString();

                Opcion = (Int16)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdEmpresa.Text = empresa.IdEmpresa.ToString();
                txtRuc.Text = empresa.RUC;
                txtRazonSocial.Text = empresa.RazonSocial;
                txtNombreComercial.Text = empresa.NombreComercial;
                txtRepresentante.Text = empresa.RepresentanteLegal;
                txtNumDocRepre.Text = empresa.sNumDocRepresentante;
                txtTelefonos.Text = empresa.sTelefonos;
                txtFax.Text = empresa.sFax;
                txtWeb.Text = empresa.sWeb;
                txtEmail.Text = empresa.sEmail;
                txtEmailFact.Text = empresa.sEmailFe;
                txtEmailOtros.Text = empresa.sEmailOtros;
                chkRetencion.Checked = empresa.AgenteRetenedor;
                chkContribuyente.Checked = empresa.PrincipalContribuyente;
                cboDepartamento.SelectedValue = Departamento;
                cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                cboProvincia.SelectedValue = Provincia;
                cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                cboDistrito.SelectedValue = empresa.idUbigeo;
                txtDireccion.Text = empresa.DireccionCompleta;
                txtUsuarioSol.Text = EncryptHelper.Decrypt(empresa.UsuarioSol);
                txtClaveSol.Text = EncryptHelper.Decrypt(empresa.ClaveSol);
                chkCalzado.Checked = empresa.indCalzado;

                txtUsuarioReg.Text = empresa.UsuarioRegistro;
                txtFechaReg.Text = empresa.FechaRegistro.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaMod.Text = VariablesLocales.FechaHoy.ToString();

                txtRuc.Focus();
                Opcion = (Int16)EnumOpcionGrabar.Actualizar;
            }

            bsEmpresaImagenes.DataSource = empresa.ListaEmpresaImagenes;
            bsEmpresaImagenes.ResetBindings(false);

            if (empresa.ListaEmpresaImagenes.Count > Variables.Cero)
            {
                chkImagen.Checked = true;
            }
            else
            {
                chkImagen.Checked = false;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            bsEmpresaImagenes.EndEdit();
            DatosPorGuardar();

            if (!ValidarGrabacion())
            {
                return;
            }

            try
            {
                if (Opcion == (Int16)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        Empresa temporal = null;
                        temporal = AgenteMaestros.Proxy.RecuperarEmpresaPorRUC(txtRuc.Text.Trim());

                        if (temporal == null)
                        {
                            empresa = AgenteMaestros.Proxy.GrabarEmpresa(empresa, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                        else
                        {
                            Global.MensajeComunicacion("El ruc ingresado ya existe. Intente de nuevo...");
                            txtRuc.Focus();
                        }
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        empresa = AgenteMaestros.Proxy.GrabarEmpresa(empresa, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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

        public override Boolean ValidarGrabacion()
        {
            String resultado = ValidarEntidad<Empresa>(empresa);

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
                frmEmpresaImagenes oFrm = new frmEmpresaImagenes();

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    EmpresaImagenesE oEmpImga = oFrm.oEmpresaImagen;
                    Int32 Item = Variables.ValorUno;

                    if (empresa.ListaEmpresaImagenes.Count > Variables.Cero)
                    {
                        Item = Convert.ToInt32(empresa.ListaEmpresaImagenes.Max(mx => mx.idImagen)) + 1;
                    }

                    oEmpImga.idImagen = Item;
                    empresa.ListaEmpresaImagenes.Add(oEmpImga);
                    bsEmpresaImagenes.DataSource = empresa.ListaEmpresaImagenes;
                    bsEmpresaImagenes.ResetBindings(false);
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
                if (bsEmpresaImagenes.Current != null)
                {
                    if (empresa.ListaEmpresaImagenes != null && empresa.ListaEmpresaImagenes.Count > Variables.Cero)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) != DialogResult.Yes)
                        {
                            return;
                        }

                        //Borrando la imagen de la carpeta
                        String RutaImagen = @"C:\AmazonErp\Logo\";

                        RutaImagen += ((EmpresaImagenesE)bsEmpresaImagenes.Current).Nombre + ((EmpresaImagenesE)bsEmpresaImagenes.Current).Extension;

                        if (File.Exists(RutaImagen))
                        {
                            File.Delete(RutaImagen);
                        }

                        //Eliminando la imagen de la base de datos
                        AgenteMaestros.Proxy.EliminarEmpresaImagenes(((EmpresaImagenesE)bsEmpresaImagenes.Current).idImagen, ((EmpresaImagenesE)bsEmpresaImagenes.Current).idEmpresa.Value);
                        bsEmpresaImagenes.EndEdit();

                        empresa.ListaEmpresaImagenes.RemoveAt(bsEmpresaImagenes.Position);
                        bsEmpresaImagenes.DataSource = empresa.ListaEmpresaImagenes;
                        bsEmpresaImagenes.ResetBindings(false);

                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        ////Para saber si algun dato del BindingSource ha cambiado...
        //private void empresaBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    bFlag = true;
        //}

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            //BloquearOpcion(EnumOpcionMenuBarra.Anular, false);

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                txtClaveSol.Size = new Size(119, 20);
                chkVerDatos.Visible = true;
            }
        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<UbigeoE> ListaProvincias = AgenteMaestros.Proxy.ListarProvincias(cboDepartamento.SelectedValue.ToString());
                ListaProvincias.Add(new UbigeoE() { Provincia = Variables.SeleccioneProvincia });
                ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, ListaProvincias, "Provincia", "Provincia");

                cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<UbigeoE> ListaDistritos = AgenteMaestros.Proxy.ListarDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
                UbigeoE CampoInicial = new UbigeoE() { idUbigeo = Variables.Cero.ToString(), Distrito = Variables.SeleccioneDistrito };
                ListaDistritos.Add(CampoInicial);

                ComboHelper.LlenarCombos<UbigeoE>(cboDistrito, ListaDistritos, "idUbigeo", "Distrito");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btConfigurarCorreo_Click(object sender, EventArgs e)
        {
            frmConfigurarCorreo oFrm = new frmConfigurarCorreo(txtEmailOtros.Text, empresa.ClaveOtros, empresa.PuertoOtros, empresa.ServidorSalienteOtros, empresa.HabilitaSslOtros);

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                txtEmailOtros.Text = oFrm.Correo;
                empresa.ClaveOtros = oFrm.Clave;
                empresa.PuertoOtros = oFrm.Puerto;
                empresa.ServidorSalienteOtros = oFrm.Servidor;
                empresa.HabilitaSslOtros = oFrm.HabilitaSsl;
            }
        }

        private void dgvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((EmpresaImagenesE)bsEmpresaImagenes.Current));
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        private void btQuitar_Click(object sender, EventArgs e)
        {
            QuitarDetalle();
        }

        private void chkImagen_CheckedChanged(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle,true);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);

            if (chkImagen.Checked)
            {
                Size = new Size(987, 412);
            }
            else
            {
                //BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, opcion);
                //BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                Size = new Size(792, 388); //792, 388
            }
        }

        private void btBuscarRuc_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarRuc oFrm = new frmBuscarRuc();
                oFrm.Ruc = txtRuc.Text.ToString();

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    txtRazonSocial.Text = oFrm.RazonSocial;
                    txtNombreComercial.Text = oFrm.NomComercial;
                    txtTelefonos.Text = oFrm.Telefonos;
                    Direccion = Global.DejarSoloUnEspacio(oFrm.Direccion.Trim());
                    List<String> Padrones = new List<String>(oFrm.Padrones);

                    if (Padrones.Count > Variables.Cero)
                    {
                        Boolean Encuentro = false;

                        foreach (String item in Padrones)
                        {
                            Encuentro = item.ToUpper().IndexOf("BUENOS CONTRIBUYENTES") > 0;

                            if (Encuentro)
                            {
                                chkContribuyente.Checked = true;
                            }

                            Encuentro = item.ToUpper().IndexOf("RETENCIÓN DE IGV") > 0;

                            if (Encuentro)
                            {
                                chkRetencion.Checked = true;
                            }
                        }
                    }
                    
                    Direccion = Direccion.Replace(oFrm.Departamento + " - " + oFrm.Provincia + " - " + oFrm.Distrito, "");

                    cboDepartamento.SelectedValue = oFrm.Departamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    cboProvincia.SelectedValue = oFrm.Provincia;
                    cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
                    cboDistrito.Text = oFrm.Distrito;

                    txtDireccion.Text = Direccion.Trim();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkVerDatos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkVerDatos.Checked)
                {
                    txtUsuarioSol.UseSystemPasswordChar = false;
                    txtClaveSol.UseSystemPasswordChar = false;
                    txtUsuarioSol.Font = new Font(txtUsuarioSol.Font, FontStyle.Regular);
                    txtClaveSol.Font = new Font(txtUsuarioSol.Font, FontStyle.Regular);
                }
                else
                {
                    txtUsuarioSol.UseSystemPasswordChar = true;
                    txtClaveSol.UseSystemPasswordChar = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Eventos

    }
}
