using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Configuration;
using System.Web.Configuration;

using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using HelperSql;

namespace ClienteWinForm.Seguridad
{
    public partial class frmDataBase : frmResponseBase
    {

        public frmDataBase()
        {
            InitializeComponent();

            #region Obteniendo Datos del AppConfig

            Servicio = ConfigurationManager.AppSettings.Get("ServicioMaestros");
            
            if (!String.IsNullOrEmpty(Servicio))
            {
                txtServicio.Text = Servicio;
            }

            #endregion Obteniendo Datos del AppConfig

            Global.CrearToolTip(btActualizar, "Obtener Instancias");
            Global.CrearToolTip(btActualizarBd, "Obtener B.D.");
            Global.CrearToolTip(btProbar, "Probar la conexión con el servidor");
            Global.CrearToolTip(btServicio, "Guardar el servicio para todos los módulos");
            Global.CrearToolTip(btCadConexion, "Guardar cadena de conexión");
        }

        #region Variables

        String Servidor = String.Empty;
        String BaseDatos = String.Empty;
        String UsuarioSql = String.Empty;
        String ClaveSql = String.Empty;

        String Servicio = String.Empty;
        String CadenaGeneral = String.Empty;
        Boolean Ampliado = false;

        #endregion Variables

        #region Procedimientos de Usuario

        void ListarBD(String Servidor, String Usuario, String Clave, Boolean Autenticacion)
        {
            try
            {
                BaseDatos oBd = new BaseDatos();
                List<BaseDatos> oListaBd = (from x in UtilSQL.ListarBD(Servidor, Usuario, Clave, Autenticacion)
                                            where x.EsSistemas == false
                                            select x).ToList();

                cboDataBase.Items.Clear();
                cboDataBase.Items.Add("<<Seleccione Base de Datos>>");

                foreach (BaseDatos item in oListaBd)
                {
                    cboDataBase.Items.Add(item.Nombre);
                }

                if (cboDataBase.Items.Count == 2)
                {
                    cboDataBase.SelectedIndex = 1;
                }
                else
                {
                    cboDataBase.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void ListarInstancias()
        {
            try
            {
                cboInstancias.Items.Clear();
                cboInstancias.Enabled = true;
                txtServidor.Enabled = true;
                String Instancia = "<< Seleccione Servidor SQL >>";
                cboInstancias.Items.Add(Instancia);

                foreach (String item in UtilSQL.ListaServidores())
                {
                    cboInstancias.Items.Add(item.ToString());
                }

                if (cboInstancias.Items.Count > 0)
                {
                    cboInstancias.SelectedItem = Servidor;

                    if (cboInstancias.SelectedItem == null)
                    {
                        cboInstancias.SelectedIndex = 0;
                    }

                    if (cboInstancias.SelectedIndex == -1)
                    {
                        cboInstancias.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Boolean ValidarParametros()
        {
            if (String.IsNullOrEmpty(txtServidor.Text.Trim()))
            {
                Global.MensajeFault("Debe ingresar un Servidor.");
                return false;
            }

            if (rbSql.Checked)
            {
                if (String.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar un Usuario.");
                    return false;
                }

                if (String.IsNullOrEmpty(txtClave.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar una Clave.");
                    return false;
                } 
            }

            return true;
        }

        void LlenarDatos(String Cadena)
        {
            if (!String.IsNullOrWhiteSpace(Cadena))
            {
                if (Cadena.Length > 10)
                {
                    List<String> vs = new List<String>(Cadena.Split('='));

                    if (vs.Count > 0)
                    {
                        Servidor = vs[1].ToString().Replace(";Initial Catalog", "");
                        UsuarioSql = vs[3].ToString().Replace(";Password", "");
                        ClaveSql = vs[4].ToString();
                        BaseDatos = vs[2].ToString().Replace(";User ID", "");
                    }
                }
            }
        }

        void ConfigurarNuevaConexion(String server, String database, String userid, String password)
        {
            System.Configuration.Configuration Config1 = WebConfigurationManager.OpenWebConfiguration("/");
            ConnectionStringsSection conSetting = (ConnectionStringsSection)Config1.GetSection("connectionStrings");
            ConnectionStringSettings StringSettings = new ConnectionStringSettings("CnnSql", "Data Source=" + server + ";Initial Catalog=" + database + ";User ID=" + userid + ";Password=" + password);// + ";");
            conSetting.ConnectionStrings.Remove(StringSettings);
            conSetting.ConnectionStrings.Add(StringSettings);
            Config1.Save(ConfigurationSaveMode.Modified);
        }

        void ObtenerBD()
        {
            if (ValidarParametros())
            {
                if (rbWindows.Checked)
                {
                    ListarBD(txtServidor.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim(), true);
                }
                else
                {
                    ListarBD(txtServidor.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim(), false);
                }
            }
        }

        void CrearCadenaConexion()
        {
            String cad = "Data Source=" + txtServidor.Text.Trim() + ";Initial Catalog=" + cboDataBase.SelectedItem.ToString() + ";User ID=" + txtUsuario.Text.Trim() + ";Password=";
            txtConexion.Text = cad.Trim();
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                //if (VerificarValores())
                //{
                //    ActualizarAppConfig.UpdateAppSettings("ServidorSQL", txtServidor.Text);
                //    ActualizarAppConfig.UpdateAppSettings("NombreBD", cboDataBase.Text);
                //    ActualizarAppConfig.UpdateAppSettings("UsuarioSQL", txtUsuario.Text);
                //    ActualizarAppConfig.UpdateAppSettings("ClaveSQL", txtClave.Text);

                //    base.Aceptar();
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Override

        protected override Boolean ProcessKeyPreview(ref Message m)
        {
            const Int32 WM_KEYDOWN = 0x100;
            const Int32 WM_CHAR = 0x102;
            const Int32 WM_SYSCHAR = 0x106;
            const Int32 WM_SYSKEYDOWN = 0x104;
            const Int32 WM_IME_CHAR = 0x286;
            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                KeyEventArgs e = new KeyEventArgs(((Keys)((Int32)((long)m.WParam))) | ModifierKeys);
                if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                {
                    frmDataBase_KeyDown(this, e);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

        #endregion

        #region Eventos

        private void frmDataBase_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Configuration.Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            //    ConnectionStringSettings connString;

            //    if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            //    {
            //        connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CnnSql"];

            //        if (connString != null)
            //        {
            //            txtConexion.Text = CadenaGeneral = connString.ConnectionString;
            //            LlenarDatos(CadenaGeneral);

            //            if (!String.IsNullOrWhiteSpace(ClaveSql))
            //            {
            //                txtConexion.Text = CadenaGeneral.Replace(ClaveSql, "");
            //            }
            //        }
            //        else
            //        {
            //            txtConexion.Text = "No hay cádena de conexión";
            //            CadenaGeneral = String.Empty;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void txtClave_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (ValidarParametros())
            //    {
            //        if (rbWindows.Checked)
            //        {
            //            ListarBD(txtServidor.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim(), true);
            //        }
            //        else
            //        {
            //            ListarBD(txtServidor.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim(), false);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void cboInstancias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboInstancias.SelectedIndex > 0)
            {
                txtServidor.Text = cboInstancias.Text;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                btProbar.Enabled = true;
                btAceptar.Enabled = true;
                cboDataBase.Enabled = true;
                btServicio.Enabled = true;
                btCadConexion.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                btProbar.Enabled = false;
                btAceptar.Enabled = false;
                cboDataBase.Enabled = false;
                btServicio.Enabled = false;
                btCadConexion.Enabled = false;
            }
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            //Limpiando el combo de BD...
            cboDataBase.Items.Clear();

            //Revisando si hay autenticacion de windows...
            if (rbWindows.Checked)
            {
                try
                {
                    txtUsuario.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtClave.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    cboDataBase.Enabled = true;
                    //txtClave_Validating(new Object(), new CancelEventArgs());
                }
                catch (Exception ex)
                {
                    Global.MensajeFault(ex.Message);
                }
            }
            else
            {
                txtUsuario.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                txtClave.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                cboDataBase.Enabled = false;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            CrearCadenaConexion();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                txtServidor.TextChanged -= txtServidor_TextChanged;
                txtUsuario.TextChanged -= txtUsuario_TextChanged;
                txtClave.TextChanged -= txtClave_TextChanged;

                txtServidor.Text = Servidor;
                txtUsuario.Text = UsuarioSql;
                txtClave.Text = ClaveSql;
                ListarInstancias();
                
                ObtenerBD();

                if (cboDataBase.Items.Count > 0)
                {
                    if (!String.IsNullOrWhiteSpace(BaseDatos))
                    {
                        cboDataBase.SelectedItem = BaseDatos; 
                    }
                }

                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                btProbar.Enabled = true;
                btAceptar.Enabled = true;
                cboDataBase.Enabled = true;
                btServicio.Enabled = true;
                btCadConexion.Enabled = true;

                txtServidor.TextChanged += txtServidor_TextChanged;
                txtUsuario.TextChanged += txtUsuario_TextChanged;
                txtClave.TextChanged += txtClave_TextChanged;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btActualizarBd_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerBD();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btProbar_Click(object sender, EventArgs e)
        {
            UtilSQL.TextConexion(txtServidor.Text.Trim(), txtUsuario.Text.Trim(), txtClave.Text.Trim());
            Database oDb = UtilSQL.TextConexion(txtServidor.Text, txtUsuario.Text, txtClave.Text).Databases[cboDataBase.Text];

            if (oDb != null)
            {
                MessageBox.Show("Conexión con éxitosa... !!", "Base de Datos");
            }
            else
            {
                MessageBox.Show("Datos incorrectos para la conexión. Revisar por favor...", "Base de Datos");
            }

            oDb = null;
        } 

        private void frmDataBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                if (this.Width == 324)
                {
                    this.Width = 623;
                }
                else
                {
                    this.Width = 324;
                }
            }
        }

        private void btServicio_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> ListaServicios = new List<String>()
                {
                    "ServicioMaestros",
                    "ServicioGenerales",
                    "ServicioVentas",
                    "ServicioContabilidad",
                    "ServicioSeguridad",
                    "ServicioActivoFijo",
                    "ServicioProduccion",
                    "ServicioAlmacen",
                    "ServicioCtasPorPagar",
                    "ServicioCtasPorCobrar",
                    "ServicioTesoreria",
                    "ServicioMantenimiento",
                    "ServicioAsistencia",
                    "ServicioRRHH"
                };

                foreach (String item in ListaServicios)
                {
                    ActualizarAppConfig.UpdateAppSettings(item.ToString(), txtServicio.Text);
                }

                Global.MensajeComunicacion("Servicios Guardados.");
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var configurationFileInfo = new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            //var vdm = new VirtualDirectoryMapping(configurationFileInfo.DirectoryName, true, configurationFileInfo.Name);
            //var wcfm = new WebConfigurationFileMap();
            //wcfm.VirtualDirectories.Add("/", vdm);
            //System.Configuration.Configuration config = WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");

            //ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            //if (section != null)
            //{
            //    //... modify the section...
            //    //section.ConnectionStrings.
            //    config.Save();
            //}
        }

        private void btCadConexion_Click(object sender, EventArgs e)
        {
            try
            {
                String Serv = txtServidor.Text.Trim();
                String Bd = cboDataBase.SelectedItem.ToString();
                String Usu = txtUsuario.Text.Trim();
                String Pass = txtClave.Text.Trim();

                if (String.IsNullOrWhiteSpace(Serv))
                {
                    Global.MensajeAdvertencia("Debe ingresar un servidor.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(Bd))
                {
                    Global.MensajeAdvertencia("Debe escoger una BD.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(Usu))
                {
                    Global.MensajeAdvertencia("Debe ingresar un Usuario.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(Pass))
                {
                    Global.MensajeAdvertencia("Debe ingresar una Clave.");
                    return;
                }

                ConfigurarNuevaConexion(txtServidor.Text.Trim(), Bd, Usu, Pass);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtServidor_TextChanged(object sender, EventArgs e)
        {
            CrearCadenaConexion();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            CrearCadenaConexion();
        }

        private void btBaseDato_Click(object sender, EventArgs e)
        {
            if (!Ampliado)
            {
                this.Height = 555;
                Ampliado = true;
            }
            else
            {
                this.Height = 145;
                Ampliado = false;
            }

            try
            {
                if (Ampliado)
                {
                    System.Configuration.Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                    ConnectionStringSettings connString;

                    if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
                    {
                        connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CnnSql"];

                        if (connString != null)
                        {
                            txtConexion.Text = CadenaGeneral = connString.ConnectionString;
                            LlenarDatos(CadenaGeneral);

                            if (!String.IsNullOrWhiteSpace(ClaveSql))
                            {
                                txtConexion.Text = CadenaGeneral.Replace(ClaveSql, "");
                            }
                        }
                        else
                        {
                            txtConexion.Text = "No hay cádena de conexión";
                            CadenaGeneral = String.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
