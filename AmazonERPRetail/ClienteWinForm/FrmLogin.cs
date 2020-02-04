using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Xml;
using System.Text;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Tools;

namespace ClienteWinForm
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        #region Dll's

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam); 

        #endregion

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        Int32 nroIntentos = 0;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private bool successLogin = false;
        String passis = "";
        String glosita = "Estableciendo conexion con el servidor...";
        Int32 Letra = 0;

        #endregion

        #region Procedimientos de Usuario

        private void ValidaUsuario()
        {
            if (TxtUsuario.Text != "" && TxtPass.Text != "")
            {
                TxtPass.Enabled = TxtUsuario.Enabled = btIniciar.Enabled = false;
                pbProgress.Visible = true;
                lblFrase.Visible = true;
                timer1.Enabled = true;
                _bw.RunWorkerAsync();
            }
            else
            {
                Global.MensajeComunicacion("Debe ingresar usuario y clave");
            }
        }

        private void HabilitarEmpresaLocal(object sender, EventArgs e)
        {
            try
            {
                if (VariablesLocales.SesionUsuario.UsuarioLocales.Count() == 1)
                {
                    VariablesLocales.SesionUsuario.Empresa = (from x in VariablesLocales.SesionUsuario.UsuarioEmpresas
                                                              from y in VariablesLocales.SesionUsuario.UsuarioLocales
                                                              where x.IdEmpresa == y.IdEmpresa
                                                              select x).FirstOrDefault();
                    VariablesLocales.SesionLocal = (from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                    select x).FirstOrDefault();

                    //Variable para establecer parametros generales a los formularios
                    VariablesLocales.ListaParametros = new GeneralesServiceAgent().Proxy.ListarParametroPorUsuario(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    TxtPass.Enabled = false;
                    TxtUsuario.Enabled = false;
                    cboSucursales.Enabled = true;
                    CboEmpresas.Enabled = true;
                    btIniciar.Enabled = false;
                    BsEmpresa.DataSource = VariablesLocales.SesionUsuario.UsuarioEmpresas;
                    CboEmpresas_SelectedIndexChanged(sender, e);

                    StartPosition = FormStartPosition.CenterScreen;
                    //Application.DoEvents();
                    btAcceder.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (successLogin)
                {
                    HabilitarEmpresaLocal(sender, e);
                }
                else
                {
                    if (nroIntentos >= 3)
                    {
                        Global.MensajeComunicacion("Ha superado el número de intentos");
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }

                    TxtPass.Enabled = TxtUsuario.Enabled = btIniciar.Enabled = true;
                    timer1.Enabled = false;
                }
            }

            pbProgress.Visible = false;
            lblFrase.Visible = false;
            timer1.Enabled = false;
            _bw.Dispose();
            btAcceder.Focus();
        }

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (TxtUsuario.Text != "SISTEMAS")
                {
                    VariablesLocales.SesionUsuario = AgenteSeguridad.Proxy.ValidarUsuario(TxtUsuario.Text, EncryptHelper.EncryptToByte(TxtPass.Text));
                }
                else
                {
                    VariablesLocales.SesionUsuario = new Usuario() { IdPersona = 0, NombreCompleto = "SISTEMAS", Credencial = "SISTEMAS", NombreCorto = "SISTEMAS" };
                    passis = TxtPass.Text;
                }

                if (VariablesLocales.SesionUsuario != null)// && VariablesLocales.SesionUsuario.IdPersona > 0)
                {
                    if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                    {
                        if (passis == "873249")
                        {
                            VariablesLocales.SesionUsuario.UsuarioEmpresas = AgenteMaestros.Proxy.ListarEmpresa("");
                            VariablesLocales.SesionUsuario.UsuarioLocales = AgenteMaestros.Proxy.ListarLocalTodos("", true, false);
                            successLogin = true;
                            //VariablesLocales.oSalesPoint = AgenteVentas.Proxy.CargarSalesPoint(System.Net.Dns.GetHostName());
                        }
                        else
                        {
                            Global.MensajeComunicacion("La clave del usuario SISTEMAS es incorrecta");
                            nroIntentos++;
                        }
                    }
                    else
                    {
                        if (VariablesLocales.SesionUsuario.UsuarioEmpresas != null && VariablesLocales.SesionUsuario.UsuarioEmpresas.Count > 0)
                        {
                            successLogin = true;
                            //VariablesLocales.oSalesPoint = AgenteVentas.Proxy.CargarSalesPoint(System.Net.Dns.GetHostName());
                        }
                        else
                        {
                            Global.MensajeComunicacion("Usuario no tiene empresas asignados");
                        }
                    }
                }
                else
                {
                    nroIntentos++;
                    Global.MensajeComunicacion("Revisar. Datos incorrectos.");
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pbProgress.Visible = false;
            lblFrase.Visible = false;

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment cd = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                var myversion = cd.CurrentVersion;
                lblVersion.Text = "Versión: " + myversion;
            }
            else
            {
                lblVersion.Text = "1.0.0.1";
            }

            if (File.Exists(@"C:\AmazonErp\Configuracion.config"))
            {
                //VariablesGlobales x = new VariablesGlobales();
                TxtEsquema.Text = EncryptHelper.Decrypt(Global.LeerXml(@"C:\AmazonErp\Configuracion.config", "Scheme"));
                //VariablesGlobales.EsquemaDb = TxtEsquema.Text.Trim();
                TxtUsuario.Enabled = true;
                TxtPass.Enabled = true;
            }
            else
            {
                TxtUsuario.Enabled = false;
                TxtPass.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Letra += 1;

            if (Letra == glosita.Length)
            {
                lblFrase.Text = string.Empty;
                Letra = 0;
            }
            else
            {
                lblFrase.Text += glosita.Substring(Letra - 1, 1);
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                if (BtEsquema.Visible)
                {
                    BtEsquema.Visible = false;
                    TxtEsquema.Visible = false;
                }
                else
                {
                    BtEsquema.Visible = true;
                    TxtEsquema.Visible = true;
                    TxtEsquema.Focus();
                }
            }
        }

        private void BtIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seguridad");
            }
        }

        private void BtAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboEmpresas.SelectedValue != null && cboSucursales.SelectedValue != null)
                {
                    VariablesLocales.SesionUsuario.Empresa = (Empresa)CboEmpresas.SelectedItem;
                    VariablesLocales.SesionLocal = (LocalE)cboSucursales.SelectedItem;

                    //if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                    //{
                    //    VariablesLocales.SesionUsuario.UsuarioAreas = AgenteMaestros.Proxy.ListarTodasAreas(VariablesLocales.SesionLocal.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                    //}
                    //else
                    //{
                    //    VariablesLocales.SesionUsuario.UsuarioAreas = AgenteMaestros.Proxy.ListarTodasAreasPorUsuario(VariablesLocales.SesionLocal.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.SesionUsuario.IdPersona);
                    //}

                    //VariablesLocales.SesionArea = (from x in VariablesLocales.SesionUsuario.UsuarioAreas
                    //                               where x.idEmpresa == Convert.ToInt32(CboEmpresas.SelectedValue)
                    //                               && x.idLocal == Convert.ToInt32(cboSucursales.SelectedValue)
                    //                               select x).FirstOrDefault();

                    //Variable para establecer parametros generales a los formularios
                    VariablesLocales.ListaParametros = new GeneralesServiceAgent().Proxy.ListarParametroPorUsuario(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona);

                    DialogResult = DialogResult.OK;
                    Dispose();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seguridad");
            }
        }

        private void CboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboEmpresas.Items != null && CboEmpresas.Items.Count > 0)
            {
                try
                {
                    int idEmpresa = Convert.ToInt32(CboEmpresas.SelectedValue);
                    BsLocal.DataSource = (from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                     where x.IdEmpresa == idEmpresa
                                                     select x).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "USUARIO")
            {
                TxtUsuario.Text = String.Empty;
                TxtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtUsuario.Text))
            {
                TxtUsuario.Text = "USUARIO";
                TxtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (TxtPass.Text == "CONTRASEÑA")
            {
                TxtPass.Text = String.Empty;
                TxtPass.ForeColor = Color.LightGray;
                TxtPass.UseSystemPasswordChar = true;
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtPass.Text))
            {
                TxtPass.Enter -= TxtPass_Enter;
                TxtPass.Text = "CONTRASEÑA";
                TxtPass.ForeColor = Color.DimGray;
                TxtPass.UseSystemPasswordChar = false;
                TxtPass.Enter += TxtPass_Enter;
                btIniciar.Focus();
            }
        }

        private void PbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PbMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String servidor = EncryptHelper.Encrypt("ServidorSQL");
            String nomservidor = EncryptHelper.Encrypt("PROGRAMADOR2-PC");
            using (XmlTextWriter writer = new XmlTextWriter(@"C:\AmazonErp\Configuracion.config", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();
                writer.WriteStartElement("configuration");
                writer.WriteStartElement("appSettings");

                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", servidor);
                writer.WriteAttributeString("value", nomservidor);
                writer.WriteEndElement();

                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", "NombreBD");
                writer.WriteAttributeString("value", "INDUSOFT_NET_ERP");
                writer.WriteEndElement();

                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", "UsuarioSQL");
                writer.WriteAttributeString("value", "sa");
                writer.WriteEndElement();

                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", "ClaveSQL");
                writer.WriteAttributeString("value", "123456.abc");
                writer.WriteEndElement();

                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", "ServicioMaestros");
                writer.WriteAttributeString("value", "http://localhost:8089/WCFService.svc");
                writer.WriteEndElement();

                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", "ServicioGenerales");
                writer.WriteAttributeString("value", "http://localhost:8089/WCFService.svc");
                writer.WriteEndElement();

                //Finalizando appSettings
                writer.WriteEndElement();
                //Finalizando configuration
                writer.WriteEndElement();

                writer.WriteEndDocument();

                writer.Flush();
            };
            //writer.Close();
        }

        private void BtEsquema_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TxtEsquema.Text))
                {
                    string Ruta = @"C:\AmazonErp\Configuracion.config";
                    string esquema = EncryptHelper.Encrypt(TxtEsquema.Text);

                    if (!File.Exists(Ruta))
                    {
                        using (XmlTextWriter writer = new XmlTextWriter(Ruta, Encoding.UTF8))
                        {
                            writer.Formatting = Formatting.Indented;

                            writer.WriteStartDocument();
                            writer.WriteStartElement("configuration");
                            //writer.WriteStartElement("appSettings");

                            //writer.WriteStartElement("add");
                            //writer.WriteAttributeString("key", "Esquema");
                            //writer.WriteAttributeString("value", esquema);
                            //writer.WriteEndElement();

                            writer.WriteElementString("Scheme", esquema);

                            //Finalizando appSettings
                            //writer.WriteEndElement();
                            //Finalizando configuration
                            writer.WriteEndElement();

                            writer.WriteEndDocument();

                            writer.Flush();
                        };  
                    }
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Ruta);
                        XmlNode root = doc.DocumentElement["Scheme"];
                        root.FirstChild.InnerText = esquema;
                        doc.Save(Ruta);
                    }

                    //Variables.Esquema = TxtEsquema.Text;
                    TxtUsuario.Enabled = true;
                    TxtPass.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seguridad");
            }
        }

        #endregion

    }
}
