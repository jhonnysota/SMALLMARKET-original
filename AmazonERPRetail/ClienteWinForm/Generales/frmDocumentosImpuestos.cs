using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
//using Entidades.Asistencia;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Generales
{
    public partial class frmDocumentosImpuestos : frmResponseBase
    {
        #region Constructores

        public frmDocumentosImpuestos()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        public frmDocumentosImpuestos(ImpuestosDocumentosE oTmp)
            :this()
        {
            Detalle = oTmp;
        }

        public frmDocumentosImpuestos(String idDocumento, String Descripcion)
            : this()
        {
            txtDocumento.Text = idDocumento;
            txtDesDocumento.Text = Descripcion;
        }

        #endregion 

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        public ImpuestosE oImpuestos = null;
        public ImpuestosDocumentosE Detalle = null;       

        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (Detalle == null)
            {
                Detalle = new ImpuestosDocumentosE();
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtDocumento.Text = Detalle.idDocumento;
                txtImpuesto.Text = Detalle.idImpuesto.ToString();
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

        } 

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new ImpuestosDocumentosE();            
            }
            else
            {
                txtDocumento.Text = Convert.ToString(Detalle.idDocumento);
                txtDesDocumento.Text = Detalle.desDocumento;
                txtImpuesto.Text = Convert.ToString(Detalle.idImpuesto);
                txtDesImpuesto.Text = Detalle.desImpuesto;
            }

            bsBase.DataSource = Detalle;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            bsBase.EndEdit();

            Detalle.idDocumento = txtDocumento.Text;
            Detalle.idImpuesto = Convert.ToInt32(txtImpuesto.Text);
            Detalle.desImpuesto = txtDesImpuesto.Text;            

            if (!ValidarGrabacion())
            {
                return;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<ImpuestosDocumentosE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);

                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void DocumentosImpuestos_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btBuscarImpuesto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBuscarDocumentosImpuestos oFrm = new FrmBuscarDocumentosImpuestos();
                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oImpuesto != null)
                {
                    txtImpuesto.Text = oFrm.oImpuesto.idImpuesto.ToString();
                    txtDesImpuesto.Text = oFrm.oImpuesto.desImpuesto;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion
    }
}
