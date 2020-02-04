using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Validation;

using Entidades.Seguridad;
using Entidades.Generales;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm
{
    public partial class FrmMantenimientoBase : Form, IMantenimiento
    {

        public FrmMantenimientoBase()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            //if (VariablesLocales.ListaParametros != null && VariablesLocales.ListaParametros.Count > Variables.Cero)
            //{
            //    oParametros = (from x in VariablesLocales.ListaParametros where x.IdParametro == 2 select x).FirstOrDefault();
                
            //    if (oParametros != null)
	           // {
            //        BackColor = Color.FromName(oParametros.ValorCadena);

            //        //foreach (Control contHijo in control.Controls)
            //        //{
            //        //    //Aqui va la lógica de lo queramos hacer, en mi ejemplo, voy a pintar de color azul el fondo de todos los controles

            //        //    contHijo.BackColor = Color.Blue;
            //        //}
            //        //RecControles(this);
	           // }
            //    else
	           // {
            //        BackColor = Color.LightSteelBlue;
	           // }
            //}
        }

        public void RecControles(Control control)
        {
            //Recorremos con un ciclo for each cada control que hay en la colección Controls
            foreach (Control contHijo in control.Controls)
            {
                //Preguntamos si el control tiene uno o mas controles dentro del mismo con la propiedad 'HasChildren'
                //Si el control tiene 1 o más controles, entonces llamamos al procedimiento de forma recursiva, para que siga recorriendo los demás controles
                if (contHijo.HasChildren) this.RecControles(contHijo);

                if (contHijo is Label)
                {
                    //contHijo.Text. = Color.Blue;  
                    contHijo.BackColor = Color.FromArgb(126, 212, 255);
                    //contHijo.SegundoColor = System.Drawing.Color.LightSteelBlue;
                    //lblPeriodo.PrimerColor = Color.Red;
                }
                
                //Aqui va la lógica de lo queramos hacer, en mi ejemplo, voy a pintar de color azul el fondo de todos los controles
                //contHijo.BackColor = Color.Blue;
            }
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        #region Variables Internas

        bool _nuevo;
        bool _editar;
        bool _grabar;
        bool _anular;
        bool _buscar;
        bool _agregarDetalle;
        bool _quitarDetalle;
        bool _exportar;
        bool _imprimir;
        bool _cancelar;
        bool _cerrar;

        ParametroE oParametros = null;

        #endregion

        #region Propiedades Publicas

        /// <summary>
        /// Numero de veces que puede abrir una determinada Ventana
        /// </summary>
        public Int32 NroSesiones = 1;
        public Int32 idSistemaForm = 0;
        public Boolean Grid = true;
        public Boolean bFlag = false;
        public Boolean Modificacion = false;
        //public Opcion OpcionSeguridad = null;

        #endregion

        #region Procedimientos

        public virtual void CerrarFormulario(string NombreFrm)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                String nombreForm = Application.OpenForms[i].ToString();

                if (nombreForm.Contains(NombreFrm) != false)
                {
                    Application.OpenForms[i].Close();
                }
            }
        }

        public virtual bool ValidarIngresoVentana()
        {
            return true;
        }

        public virtual bool ValidarGrabacion()
        {
            return true;
        }

        public virtual String ValidarEntidad<T>(T entidad) where T : class
        {
            ValidationResults resultado = Validation.Validate(entidad);

            if (!resultado.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("No se puede grabar. Debera validar los atributos siguientes: \n\r");
                foreach (ValidationResult item in resultado)
                {
                    sb.Append(item.Key + " - " + item.Message + "\r\n");
                }
                return sb.ToString();
            }

            return "";
        }

        public void FormatoGrid(DataGridView oDgv, bool PrimerCol, Boolean EscogerVariasFilas = false, Int32 AltoCabecera = 25, Int32 AltoFilas = 20, Boolean MostrarColorAlterno = true, float tamLetraCabecera = 8.25f, float tamLetraDetalle = 8, DataGridViewSelectionMode selectionMode = DataGridViewSelectionMode.FullRowSelect)
        {
            oDgv.SuspendLayout();
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            //if (oParametros != null)
            //{
            //    oDgv.BackgroundColor = Color.FromName(oParametros.ValorCadena);
            //}
            //else
            //{
            //    oDgv.BackgroundColor = Color.LightSteelBlue;
            //}
            oDgv.BackgroundColor = Color.Azure;
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            //oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", tamLetraCabecera * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(126, 212, 255);
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(126, 212, 255);
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            
            if (MostrarColorAlterno)
            {
                oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;    
            }
            
            //oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", tamLetraDetalle * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = selectionMode;
            oDgv.MultiSelect = EscogerVariasFilas;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = AltoCabecera;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = AltoFilas;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
            oDgv.ResumeLayout();
        }

        #region ToolStripMenuBase

        public void BloquearOpcion(EnumOpcionMenuBarra opcionMenuBarra, bool bloqueo)
        {
            FrmMain x = (FrmMain)MdiParent;

            switch (opcionMenuBarra)
            {
                case EnumOpcionMenuBarra.Nuevo:
                    _nuevo = x.tsbNuevo.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Editar:
                    _editar = x.tsbEditar.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Grabar:
                    _grabar = x.tsbGrabar.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Buscar:
                    _buscar = x.tsbBuscar.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Cancelar:
                    _cancelar = x.tsbCancelar.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Anular:
                    _anular = x.tsbAnular.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Cerrar:
                    _cerrar = x.tsbCerrar.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Imprimir:
                    _imprimir = x.tsbImprimir.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.AgregarDetalle:
                    _agregarDetalle = x.tsbAgregarDetalle.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.QuitarDetalle:
                    _quitarDetalle = x.tsbQuitarDetalle.Enabled = bloqueo;
                    break;
                case EnumOpcionMenuBarra.Exportar:
                    _exportar = x.tsbExportar.Enabled = bloqueo;
                    break;
                default:
                    break;
            }
        }

        public virtual void OpcionMenu(EnumOpcionMenuBarra opcionMenuBarra)
        {
            switch (opcionMenuBarra)
            {
                case EnumOpcionMenuBarra.Nuevo:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);

                        BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                        BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);

                        BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                        BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
                    }

                    break;
                case EnumOpcionMenuBarra.Grabar:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    }

                    break;
                case EnumOpcionMenuBarra.Editar:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                        BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                        BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
                    }

                    break;
                case EnumOpcionMenuBarra.Anular:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    }

                    break;
                case EnumOpcionMenuBarra.Cancelar:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    }

                    break;
                case EnumOpcionMenuBarra.AgregarDetalle:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                    BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    }

                    break;
                case EnumOpcionMenuBarra.QuitarDetalle:

                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                    BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);

                    if (Grid)
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                    }
                    else
                    {
                        BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                        BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    }

                    break;
                case EnumOpcionMenuBarra.Cerrar:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion

        #region IMantenimiento

        public virtual void Nuevo()
        {
            bFlag = true;
            OpcionMenu(EnumOpcionMenuBarra.Nuevo);
        }

        public virtual void Editar()
        {
            bFlag = true;
            OpcionMenu(EnumOpcionMenuBarra.Editar);
        }

        public virtual void Grabar()
        {
            bFlag = false;
            Modificacion = false;
            OpcionMenu(EnumOpcionMenuBarra.Grabar);
        }

        public virtual void Cerrar()
        {
            if (!Grid)
            {
                if (bFlag)
                {
                    if (Modificacion)
                    {
                        DialogResult Resp = MessageBox.Show("Hay cambios pendientes\n\r¿ Desea guardarlos ?", "Cerrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        switch (Resp)
                        {
                            case DialogResult.Cancel:
                                break;
                            case DialogResult.No:
                                Dispose();
                                break;
                            case DialogResult.Yes:
                                Grabar();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Dispose();
                    }
                }
                else
                {
                    Dispose();
                }
            }
            else
            {
                Dispose();
            }
        }

        public virtual void Exportar()
        {
            throw new NotImplementedException();
        }

        public virtual void AgregarDetalle()
        {
            bFlag = true;
            Modificacion = true;
            OpcionMenu(EnumOpcionMenuBarra.AgregarDetalle);
        }

        public virtual void QuitarDetalle()
        {
            bFlag = true;
            Modificacion = true;
            OpcionMenu(EnumOpcionMenuBarra.QuitarDetalle);
        }

        public virtual void Imprimir()
        {
            OpcionMenu(EnumOpcionMenuBarra.Imprimir);
        }

        public virtual void Buscar()
        {
            OpcionMenu(EnumOpcionMenuBarra.Buscar);
        }

        public virtual void Anular()
        {
            OpcionMenu(EnumOpcionMenuBarra.Anular);
        }

        public virtual void Cancelar()
        {
            bFlag = false;
            Modificacion = false;
            OpcionMenu(EnumOpcionMenuBarra.Cancelar);
        }

        #endregion

        #region Eventos

        private void FrmMantenimientoBase_Load(object sender, EventArgs e)
        {
            NroSesiones = 1;
            String NombreFormulario = Name;
            FrmMain p = (FrmMain)MdiParent;

            if (p != null)
            {
                p.AgregarMenuItemReciente(Text, NombreFormulario);
            }
        }

        private void FrmMantenimientoBase_Activated(object sender, EventArgs e)
        {
            FrmMain x = (FrmMain)MdiParent;

            if (x != null)
            {
                x.tsbNuevo.Enabled = _nuevo;
                x.tsbGrabar.Enabled = _grabar;
                x.tsbEditar.Enabled = _editar;
                x.tsbAnular.Enabled = _anular;
                x.tsbBuscar.Enabled = _buscar;
                x.tsbAgregarDetalle.Enabled = _agregarDetalle;
                x.tsbQuitarDetalle.Enabled = _quitarDetalle;
                x.tsbExportar.Enabled = _exportar;
                x.tsbImprimir.Enabled = _imprimir;
                x.tsbCancelar.Enabled = _cancelar;
                x.tsbCerrar.Enabled = _cerrar;
            }
        }

        private void FrmMantenimientoBase_Deactivate(object sender, EventArgs e)
        {
            FrmMain x = (FrmMain)MdiParent;

            if (x != null)
            {
                x.tsbNuevo.Enabled = false;
                x.tsbGrabar.Enabled = false;
                x.tsbEditar.Enabled = false;
                x.tsbAnular.Enabled = false;
                x.tsbBuscar.Enabled = false;
                x.tsbAgregarDetalle.Enabled = false;
                x.tsbQuitarDetalle.Enabled = false;
                x.tsbExportar.Enabled = false;
                x.tsbImprimir.Enabled = false;
                x.tsbCancelar.Enabled = false;
                x.tsbCerrar.Enabled = false;
            }
        }        

        private void FrmMantenimientoBase_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                FrmMain x = (FrmMain)MdiParent;

                if (x != null)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Escape: //Cerrar el formulario activo...

                            if (x.tsbCerrar.Enabled)
                            {
                              //////
                              // if (MessageBox.Show(this, "¿Esta seguro que desea salir sin guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                               {
                                    Cerrar();
                               }
                               //////
                               
                            }

                            break;
                        case Keys.F1: //Buscar registros...

                            if (x.tsbBuscar.Enabled)
                            {
                                Buscar();
                            }

                            break;
                        case Keys.F2: //Realizar un registro nuevo...

                            if (x.tsbNuevo.Enabled)
                            {
                                if (!bFlag)
                                {
                                    Nuevo();
                                }
                            }

                            break;
                        case Keys.F3: //Editar un registro...

                            if (x.tsbEditar.Enabled)
                            {
                                if (!bFlag)
                                {
                                    Editar();
                                }
                            }

                            break;
                        case Keys.F5: //Grabar un registro nuevo o algun cambio pendiente...

                            if (x.tsbGrabar.Enabled)
                            {
                                if (bFlag)
                                {
                                    Grabar();
                                }
                            }

                            break;
                        case Keys.F6: //Cancelar el registro pendiente a grabar

                            if (x.tsbCancelar.Enabled)
                            {
                                if (bFlag)
                                {
                                    Cancelar();
                                }
                            }

                            break;
                        case Keys.F7: //Anular o eliminar el registro...

                            if (x.tsbAnular.Enabled)
                            {
                                Anular();
                            }
                            break;
                        case Keys.F8: // Exportar registros...

                            if (x.tsbExportar.Enabled)
                            {
                                Exportar();
                            }

                            break;

                        case Keys.F9: //Imprimir registros...

                            if (x.tsbImprimir.Enabled)
                            {
                                Imprimir();
                            }

                            break;

                        case Keys.Insert: //Agregar o insertar detalle (datagridview)...

                            if (x.tsbAgregarDetalle.Enabled)
                            {
                                if (bFlag)
                                {
                                    AgregarDetalle();
                                }
                            }

                            break;
                        case Keys.Delete: //Quitar o Borrar detalle (datagridview)...

                            if (x.tsbQuitarDetalle.Enabled)
                            {
                                if (bFlag)
                                {
                                    QuitarDetalle();
                                }
                            }

                            break;

                        default:
                            break;
                    } 
                }

                if (e.Control && e.KeyCode == Keys.S) 
                {
                    Opcion opcion = (from f in VariablesLocales.listaOpciones
                                     where f.Ubicacion.Equals(Name, StringComparison.OrdinalIgnoreCase)
                                     select f).FirstOrDefault();

                    if (opcion != null)
                    {
                        //FrmObservacionOpcion frm = new FrmObservacionOpcion();
                        //frm.Titulo = opcion.Nombre;
                        //frm.Mensaje = opcion.Ubicacion;
                        //frm.Obs = opcion.Observacion;
                        //frm.ShowDialog();
                        MessageBox.Show(opcion.nombreGrupo, "Sistema");
                    }
                    else
                    {
                        Global.MensajeFault("No se encontro información de este formulario");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FrmMantenimientoBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMain p = (FrmMain)MdiParent;
            
            if (p != null)
            {
                p.QuitarMenuItemReciente(Text);
            }

            Cerrar();
        }
        
        #endregion        

    }
}
