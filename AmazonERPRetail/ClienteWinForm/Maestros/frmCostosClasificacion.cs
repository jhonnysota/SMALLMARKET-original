using ClienteWinForm.Maestros.Busqueda;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros
{
    public partial class frmCostosClasificacion : FrmMantenimientoBase
    {
        public frmCostosClasificacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        //Nuevo
        public frmCostosClasificacion( List<CostosEstrucE> oListaEstructuraTemp)
            : this()
        {
            Niveles(oListaEstructuraTemp);
        }

        //Edición
        public frmCostosClasificacion(CostosClasificacionE Clasificacion, List<CostosEstrucE> oListaEstructuraTemp)
            : this()
        {
            oClasificacion = Clasificacion;
            Niveles(oListaEstructuraTemp);
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        CostosClasificacionE oClasificacion = null;
        List<CostosEstrucE> oListaEstructura = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboIndNivel.DataSource = Global.CargarSN();
            cboIndNivel.ValueMember = "id";
            cboIndNivel.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oClasificacion.nombreClasificacion = txtNom.Text.Trim();
            oClasificacion.numNivel = Convert.ToInt32(NumNivel.Value);
            oClasificacion.indUltimoNivel = cboIndNivel.SelectedValue.ToString();
            oClasificacion.CodCategoriaSup = txtCatSuperior.Text.Trim();

            if (String.IsNullOrEmpty(txtCatSuperior.Text.Trim()))
            {
                oClasificacion.CodClasificacion = txtCodCategoria.Text.Trim();
            }
            else
            {
                oClasificacion.CodClasificacion = txtCatSuperior.Text.Trim() + txtCodCategoria.Text.Trim();
            }

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oClasificacion.UsuarioRegistro = txtUsuRegistra.Text;
                oClasificacion.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
                oClasificacion.UsuarioModificacion = txtfechamodifica.Text;
                oClasificacion.FechaModificacion = Convert.ToDateTime(txtfechamodifica.Text);
            }
            else
            {
                oClasificacion.UsuarioModificacion = txtUsuModifica.Text;
            }
        }

        void BuscarGrupoOpcion()
        {
            frmCostosCatOpcionArbol frm = new frmCostosCatOpcionArbol(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(NumNivel.Value));

            if (frm.ShowDialog() == DialogResult.OK && frm.ClasificacionCostosCat != null)
            {
                txtCatSuperior.Text = frm.ClasificacionCostosCat.CodClasificacion.Trim();
            }
            else
            {
                txtCatSuperior.Text = String.Empty;
            }
        }

        void Niveles(List<CostosEstrucE> oLista)
        {
            oListaEstructura = new List<CostosEstrucE>(oLista);
            NumNivel.Minimum = oListaEstructura.Min(c => c.numNivel);
            NumNivel.Maximum = oListaEstructura.Max(c => c.numNivel);
        }

        void LongitudCodigo(Int32 Nivel)
        {
            CostosEstrucE oEstructuraActual = oListaEstructura.Where(n => n.numNivel == Nivel ).Single();
            Int32 Registro = oListaEstructura.FindIndex(n => n.numNivel == Nivel);
            
            if (Nivel == 1)
            {
                txtCodCategoria.MaxLength = Convert.ToInt32(oEstructuraActual.numLongitud);    
            }
            else
            {
                CostosEstrucE oEstructura2 = oListaEstructura.Skip(Registro - 1).Take(1).FirstOrDefault();
                txtCodCategoria.MaxLength = Convert.ToInt32(oEstructuraActual.numLongitud) - Convert.ToInt32(oEstructura2.numLongitud);
                oEstructura2 = null;
            }

            cboIndNivel.SelectedValue = oEstructuraActual.indUltimoNivel;

            if (!String.IsNullOrEmpty(txtCodCategoria.Text.Trim()))
            {
                if (txtCodCategoria.MaxLength < oEstructuraActual.numLongitud)
                {
                    txtCodCategoria.Text = txtCodCategoria.Text.Substring(0, txtCodCategoria.MaxLength);
                }
            }
            else
            {
                txtCodCategoria.Text = String.Empty;
            }

            oEstructuraActual = null;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oClasificacion == null)
            {
                oClasificacion = new CostosClasificacionE();
                oClasificacion.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                //cboTipoArticulo.SelectedValue = TipoArticulo;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtfechamodifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
                NumNivel_ValueChanged(null, null);
            }
            else
            {
            //    cboTipoArticulo.SelectedValue = Convert.ToInt32(oArticuloCat.idTipoArticulo);
                txtCatSuperior.Text = oClasificacion.CodCategoriaSup.Trim();

                if (oClasificacion.numNivel == 1)
                {
                    txtCodCategoria.Text = oClasificacion.CodClasificacion;
                }
                else
                {
                    txtCodCategoria.Text = oClasificacion.CodClasificacion.Replace(txtCatSuperior.Text.Trim(), String.Empty);
                }

                oClasificacion.CodCategoriaAnte = oClasificacion.CodClasificacion; //Para poder actualizar una de las llaves... siempre y cuando no este relacionada.
                txtNom.Text = oClasificacion.nombreClasificacion;
                cboIndNivel.SelectedValue = oClasificacion.indUltimoNivel.ToString();

                NumNivel.Value = Convert.ToInt32(oClasificacion.numNivel);
                NumNivel_ValueChanged(null, null);

                txtUsuRegistra.Text = oClasificacion.UsuarioRegistro;
                txtFechaRegistro.Text = oClasificacion.FechaRegistro.ToString();
                txtUsuModifica.Text = oClasificacion.UsuarioModificacion;
                txtfechamodifica.Text = oClasificacion.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oClasificacion != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oClasificacion = AgenteMaestro.Proxy.GrabarClasifica(oClasificacion, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oClasificacion = AgenteMaestro.Proxy.GrabarClasifica(oClasificacion, EnumOpcionGrabar.Actualizar);
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
            String Respuesta = ValidarEntidad<CostosClasificacionE>(oClasificacion);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (NumNivel.Value > 1)
            {
                if (String.IsNullOrEmpty(txtCatSuperior.Text.Trim()))
                {
                    Global.MensajeComunicacion("Solo el Nivel 1 no puede tener Código Superior.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCostosClasificacion_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumNivel.Value > 1)
                {
                    BuscarGrupoOpcion();
                }
                else
                {
                    Global.MensajeComunicacion("La estructura esta en Nivel 1. No tiene la necesidad que haya un Código Superior.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboIndNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void NumNivel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LongitudCodigo(Convert.ToInt32(NumNivel.Value));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }


        #endregion

    }
}
