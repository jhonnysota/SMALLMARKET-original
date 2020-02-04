using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Ventas.Facturacion;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad;
using ClienteWinForm.Contabilidad.CtasPorPagar;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoNotaCreditoUf : FrmMantenimientoBase
    {

        public frmListadoNotaCreditoUf()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvListado, true, false, 28, 23, false);
            AnchoColumnas();
            oListaNumControlDet = CargarDocumentos();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<EmisionDocumentoE> oListaDocumentos = null;
        List<NumControlDetE> oListaNumControlDet = null;
        Boolean Ordenar = false;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvListado.Columns[0].Width = 26; //Estado
            dgvListado.Columns[1].Width = 26; //Enviado a Sunat
            dgvListado.Columns[2].Width = 26; //Anulado en Sunat
            dgvListado.Columns[3].Width = 25; //TD
            dgvListado.Columns[4].Width = 40; //Serie
            dgvListado.Columns[5].Width = 60; //NUmero
            dgvListado.Columns[6].Width = 70; //fecEmision
            dgvListado.Columns[7].Width = 90; //Ruc
            dgvListado.Columns[8].Width = 300; //Razon Social
            dgvListado.Columns[9].Width = 30; //Moneda
            dgvListado.Columns[10].Width = 70; //Subtotal
            dgvListado.Columns[11].Width = 70; //IGV
            dgvListado.Columns[12].Width = 70; //Total
            dgvListado.Columns[13].Width = 150; //Afecto IGV
            dgvListado.Columns[14].Width = 37; //TD referencia
            dgvListado.Columns[15].Width = 60; //Serie referencia
            dgvListado.Columns[16].Width = 72; //Numero referecia
            dgvListado.Columns[17].Width = 50; //Tipo de cambio
            dgvListado.Columns[18].Width = 25; //Es guia

            dgvListado.Columns[19].Width = 90; //Usuario Registro
            dgvListado.Columns[20].Width = 120; //Fecha Registro
            dgvListado.Columns[21].Width = 90; //Usuario Modificacion
            dgvListado.Columns[22].Width = 120; //Fecha Modificacion

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
            {
                dgvListado.Columns[13].Visible = false;
            }
        }

        void EnviarSunat()
        {
            if (((EmisionDocumentoE)bsEmisionNC.Current).indEstado == EnumEstadoDocumentos.E.ToString())
            {
                //EmisionDocumentoE oEmision = AgenteVentas.Proxy.RecuperarDocumentoCompleto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
                //                                                            ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento, ((EmisionDocumentoE)bsEmisionNC.Current).numSerie,
                //                                                            ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento);
                //OperacionesSunat Archivo = new OperacionesSunat();
                //List<String> oLista = new List<String>();
                //oLista = Archivo.GenerarFile(oEmision);

                //if (oLista.Count > Variables.Cero)
                //{
                //    if (oLista[0] == Variables.Cero.ToString())
                //    {
                //        oEmision.EnviadoSunat = true;
                //        oEmision.fecEnvioSunat = VariablesLocales.FechaHoy.Date;
                //        oEmision.EstadoRegistro = Convert.ToInt32(oLista[0]);
                //        oEmision.MensajeRegistro = RevisarEstados(Convert.ToInt32(oLista[0])) + String.Empty + oLista[1].ToString();
                //        oEmision.idRegistro = Convert.ToInt32(oLista[2]);
                //        oEmision.EstadoSunat = (Nullable<Int32>)null;
                //        oEmision.MensajeSunat = String.Empty;

                //        AgenteVentas.Proxy.ActualizarDocumentosSunat(oEmision);

                //        Global.MensajeComunicacion("Se ha enviado con éxito el documento al Servidor de Facturación Electrónica.");

                //        ((EmisionDocumentoE)bsEmisionNC.Current).EnviadoSunat = true;
                //        bsEmisionNC.ResetBindings(false);
                //    }
                //    else
                //    {
                //        String Ruta = @"C:\AmazonErp\Facturas Electronicas\Errores.txt";
                //        //Si existe lo borramos para volverlo a crear...
                //        if (File.Exists(Ruta))
                //        {
                //            File.Delete(Ruta);
                //        }

                //        //Creamos el archivo de errores...
                //        using (StreamWriter sw = new StreamWriter(Ruta))
                //        {
                //            sw.WriteLine(oLista[1]);
                //        }

                //        throw new Exception(oLista[1]);
                //    }
                //}
            }
            else
            {
                throw new Exception("Es obligatorio que el comprobante se encuentre Emitido");
            }
        }

        String RevisarEstados(Int32 Estado)
        {
            String MensajeDevuelto = String.Empty;

            switch (Estado)
            {
                case 0:
                    MensajeDevuelto = "Respuesta Solicitada.\n\r";

                    break;
                case -1:
                    MensajeDevuelto = "Error, archivo Xml inválido.\n\r";

                    break;
                case -2:
                    MensajeDevuelto = "Error, el archivo debe contener solo 1 documento.\n\r";

                    break;
                case -3:
                    MensajeDevuelto = "Error, falta información del emisor.\n\r";

                    break;
                case -4:
                    MensajeDevuelto = "Error, Emisor no registrado.\n\r";

                    break;
                case -5:
                    MensajeDevuelto = "Error al recuperar el Certificado de la Empresa.\n\r";

                    break;
                case -6:
                    MensajeDevuelto = "Error al Foliar el documento.\n\rNo se pudo asignar un correlativo al documento.";

                    break;
                case -8:
                    MensajeDevuelto = "Error al firmar el documento.\n\r";

                    break;
                case -9:
                    MensajeDevuelto = "Error al firmar el envío.\n\r";

                    break;
                case -10:
                    MensajeDevuelto = "Error al enviar documento.\n\r";

                    break;
                case -11:
                    MensajeDevuelto = "Error de conexión DB.\n\r";

                    break;
                case -12:
                    MensajeDevuelto = "Error, documento no encontrado.\n\r.";

                    break;
                case -14:
                    MensajeDevuelto = "Error al validar usuario.\n\r";

                    break;
                case -19:
                    MensajeDevuelto = "Error de Schema.\n\r";

                    break;
                case -98:
                    MensajeDevuelto = "Mensaje de Error.\n\r";

                    break;
                case -99:
                    MensajeDevuelto = "Error, opción de retorno inválida.\n\r";

                    break;
                default:
                    break;
            }

            return MensajeDevuelto;
        }

        List<NumControlDetE> CargarDocumentos()
        {
            List<NumControlDetE> ListaDoc = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                     where x.Grupo == EnumGrupoDocumentos.C.ToString()
                                                                     select x).ToList();//AgenteVentas.Proxy.ListarNumControlDetPorGrupo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, EnumGrupoDocumentos.C.ToString());
            return ListaDoc;
        }

        void DevolverMotivoAnulacion(String Titulo, out String Motivo, out String Tipo)
        {
            Motivo = String.Empty;
            Tipo = String.Empty;

            frmTextoLargo oFrm = new frmTextoLargo(Titulo);

            if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
            {
                Motivo = oFrm.Texto;
                Tipo = oFrm.Tipo;
            }
        }

        Boolean RevisarDocumentosBaja(List<EmisionDocumentoE> oListaTemporal)
        {
            /* Campo EstadoRegistro:
             * BIZLINKS
                L: Pendiente de respuesta
                E: Error de Bizlinks
                P: Procesado: (Para facturas y sus notas asociadas el documento ya ha sido aceptado por SUNAT.
                                Para Boletas y sus notas asociadas indica que fueron procesadas correctamente y 
                                se encuentran listas para ser declaradas a través de un resumen de comprobantes)
                R: Rechazado (El documento ha sido rechazado por SUNAT)
             
             * PARA INDUSOFT:
                L = 1 --Pendiente de respuesta
				E = 2 --Error de Bizlinks
				P = 3 --Procesado
				R = 4 --Rechazado
             
             * Campo EstadoBaja
                N o null: nuevo (está siendo agregado y no será leído por el componente)
                A: Agregado (la data está completa y lista para ser leída)
                L: Leído (el componente de integración ha leído el registro y está siendo procesado)
                E: Error (se encontró un error en la validación local)
            */
            DateTime FechaEmisionAnte = Convert.ToDateTime(oListaTemporal[0].fecEmision);

            foreach (EmisionDocumentoE item in oListaTemporal)
            {
                if (item.indEstado == "B") //Estado en Indusoft
                {
                    if (item.EstadoRegistro == 3) //Estado de Procesado en Bislink
                    {
                        if (item.EstadoBaja == "P") //Estado de Baja en Bislink(Procesado)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} ya esta dado de baja.", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else
                        {
                            if (FechaEmisionAnte == Convert.ToDateTime(item.fecEmision))
                            {
                                FechaEmisionAnte = Convert.ToDateTime(item.fecEmision);
                            }
                            else
                            {
                                Global.MensajeFault(String.Format("Todos los documentos tienen que tener la misma fecha de emisión.", item.numSerie, item.numDocumento));
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (item.EstadoRegistro == 4)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} ha sido rechazado y ya no puede ser anulado.", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else if (item.EstadoRegistro == 2)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} tiene problemas en Bislink. Revisar", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else if (item.EstadoRegistro == 1)
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} ya ha sido enviado y esta pendiente de respuesta.", item.numSerie, item.numDocumento));
                            return false;
                        }
                        else
                        {
                            Global.MensajeFault(String.Format("El documento {0}-{1} no ha sido enviado a Sunat.", item.numSerie, item.numDocumento));
                            return false;
                        }
                    }
                }
                else
                {
                    Global.MensajeFault(String.Format("El documento {0}-{1} tiene que estar anulado en el sistema.", item.numSerie, item.numDocumento));
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreditoUf);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                if (oListaNumControlDet.Count == Variables.Cero)
                {
                    Global.MensajeFault("No se ha configurado ningún item para la Nota de Crédito en Control de Documentos.");
                    return;
                }

                oFrm = new frmNotaCreditoUf(oListaNumControlDet)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsEmisionNC.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreditoUf);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionNC.Current;

                    if (current != null)
                    {
                        oFrm = new frmNotaCreditoUf(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, oListaNumControlDet)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsEmisionNC.List.Count > 0)
                {
                    if (((EmisionDocumentoE)bsEmisionNC.Current).indEstado != EnumEstadoDocumentos.B.ToString())
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                        {
                            AgenteVentas.Proxy.CambiarEstadoDocumento(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionNC.Current).idLocal, 
                                                                    ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento, ((EmisionDocumentoE)bsEmisionNC.Current).numSerie, 
                                                                    ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento, EnumEstadoDocumentos.B.ToString(), 
                                                                    VariablesLocales.SesionUsuario.Credencial);
                            Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                            Buscar();
                        }
                    }
                    else
                    {
                        string idDocumentoActual = ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento;
                        string SerieActual = ((EmisionDocumentoE)bsEmisionNC.Current).numSerie;
                        string NumeroActual = ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento;

                        NumControlDetE ControlDetalle = oListaNumControlDet.Find
                        (
                            delegate (NumControlDetE ncd)
                            {
                                return ncd.idDocumento == idDocumentoActual
                                && ncd.Serie == SerieActual;
                            }
                        );

                        if (ControlDetalle != null)
                        {
                            if (idDocumentoActual == ControlDetalle.idDocumento && SerieActual == ControlDetalle.Serie && NumeroActual == ControlDetalle.numCorrelativo)
                            {
                                if (Global.MensajeConfirmacion("Desea eliminar el registro ?") == DialogResult.Yes)
                                {
                                    Int32 resp = AgenteVentas.Proxy.EliminarEmisDocuCompleto(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa, 
                                                                                            ((EmisionDocumentoE)bsEmisionNC.Current).idLocal, idDocumentoActual, SerieActual, NumeroActual);

                                    if (resp > Variables.Cero)
                                    {
                                        Global.MensajeComunicacion("El documento se eliminó correctamente");

                                        oListaDocumentos.Remove((EmisionDocumentoE)bsEmisionNC.Current);
                                        bsEmisionNC.DataSource = oListaDocumentos;
                                        bsEmisionNC.ResetBindings(false);

                                        VariablesLocales.ListaDetalleNumControl = AgenteVentas.Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                                        oListaNumControlDet = CargarDocumentos();
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                Global.MensajeFault("El documento no es el último generado. Tiene que empezar desde último, según correlativo.");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                string fecIni;
                string fecFin;
                String Serie;
                Int32 idCliente;
                List<EmisionDocumentoE> ListaTemp = null;

                if (rbTodas.Checked)
                {
                    fecIni = "19000101";
                    fecFin = "29991231";
                }
                else
                {
                    fecIni = dtpInicio.Value.ToString("yyyyMMdd");
                    fecFin = dtpFinal.Value.ToString("yyyyMMdd");
                }

                if (rbTodasSeries.Checked)
                {
                    Serie = "%";
                }
                else
                {
                    Serie = cboSeries.SelectedValue.ToString();
                }

                if (rbTodosCLientes.Checked)
                {
                    idCliente = Variables.Cero;
                }
                else
                {
                    idCliente = !String.IsNullOrEmpty(txtIdAuxiliar.Text) ? Convert.ToInt32(txtIdAuxiliar.Text) : Variables.Cero;
                }

                oListaDocumentos = new List<EmisionDocumentoE>();
                var oListTemp = oListaNumControlDet.GroupBy(x => x.idDocumento).Select(p => p.First()).ToList();

                foreach (NumControlDetE item in oListTemp)
                {
                    ListaTemp = AgenteVentas.Proxy.ListarDocumentosVentas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, item.idDocumento, idCliente, Serie, fecIni, fecFin);
                    oListaDocumentos.AddRange(ListaTemp);
                }

                bsEmisionNC.DataSource = oListaDocumentos;
                bsEmisionNC.ResetBindings(false);
                dgvListado.Focus();

                LblRegistros.Text = "Registros " + bsEmisionNC.Count.ToString();
                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsEmisionNC.Count > 0)
                {
                    EmisionDocumentoE current = (EmisionDocumentoE)bsEmisionNC.Current;

                    if (current.indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede imprimir porque se encuentra anulado.");
                        return;
                    }

                    Form oFrm = null;

                    String Letra = current.numSerie.Substring(0, 1);

                    if ((Letra == "F" || Letra == "B") && VariablesLocales.oVenParametros.indFacElec)
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDocumentoElectronicoPDF);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmDocumentoElectronicoPDF(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento, "NC");
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreditoGenesis);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmNotaCreditoGenesis(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179" )
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreditoInter);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmNotaCreditoInter(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214")
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreditoFito);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmNotaCreditoFito(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }
                    else
                    {
                        oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioNotaCredito);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmPrevioNotaCredito(current.idEmpresa, current.idLocal, current.idDocumento, current.numSerie, current.numDocumento);
                    }

                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrmImpresion_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarIngresoVentana()
        {
            if (VariablesLocales.TipoCambioDelDia == null)
            {
                Global.MensajeComunicacion("No se ha ingresado el Tipo de Cambio del dia.");
                return false;
            }

            return base.ValidarIngresoVentana();
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmNotaCreditoUf oFrm = sender as frmNotaCreditoUf;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();

            }
        }

        private void oFrmImpresion_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
            {
                frmNotaCreditoGenesis oFrm = sender as frmNotaCreditoGenesis;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    ((EmisionDocumentoE)bsEmisionNC.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                    bsEmisionNC.ResetBindings(false);
                } 
            }
            else if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179" || VariablesLocales.SesionUsuario.Empresa.RUC == "20535703214") //INTERMETALS y FFS
            {
                frmNotaCreditoInter oFrm = sender as frmNotaCreditoInter;

                if (oFrm.DialogResult == DialogResult.OK)
                {
                    ((EmisionDocumentoE)bsEmisionNC.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                    bsEmisionNC.ResetBindings(false);
                }
            }

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }

        #endregion

        #region Eventos

        private void frmListadoNotaCreditoUf_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            Grid = true;

            Global.CrearToolTip(btCliente, "Buscar Clientes...");
            Global.CrearToolTip(btEmitir, "Emitir Documento (Presionar F11)");
            Global.CrearToolTip(btRevisarEstados, "Revisar Estado de Sunat (Presionar F12)");

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

            if (VariablesLocales.oVenParametros.TipoFacturacion == "B") //Fundo San Miguel
            {
                tsmiPdf.Visible = true;
            }

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                        VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
            {
                btInsertaCtaCte.Visible = true;
            }
        }

        private void rbDesde_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = rbDesde.Checked;
            dtpFinal.Enabled = rbDesde.Checked;
        }

        private void rbTodasSeries_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodasSeries.Checked)
            {
                cboSeries.DataSource = null;
                cboSeries.Enabled = false;
            }
            else
            {
                cboSeries.Enabled = true;
                List<NumControlDetE> ListaDetalle = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                             where x.idControl == 4
                                                                             select x).ToList();
                ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");
                cboSeries.Focus();
                ListaDetalle = null;
            }
        }

        private void rbTodosCLientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosCLientes.Checked)
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btCliente.Enabled = false;
            }
            else
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btCliente.Enabled = true;
                txtRuc.Focus();
            }
        }

        private void dtpInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtIdAuxiliar_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAuxiliar.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El ID del Auxiliar ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtIdAuxiliar.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            dgvListado.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Si se encuentra anulado
            if ((String)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorEmitido;
                }
            }

            if ((String)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.B.ToString())
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }

            //Si se ha enviado a Sunat
            if ((String)dgvListado.Rows[e.RowIndex].Cells["indEstado"].Value == EnumEstadoDocumentos.E.ToString() && (Boolean)dgvListado.Rows[e.RowIndex].Cells["EnviadoSunat"].Value)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorSunat;
                }
            }
        }

        private void btEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsEmisionNC.Count > Variables.Cero)
                {
                    if (((EmisionDocumentoE)bsEmisionNC.Current).indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        Global.MensajeComunicacion("Este documento no se puede emitir porque se encuentra anulado.");
                        return;
                    }

                    if (((EmisionDocumentoE)bsEmisionNC.Current).indEstado == EnumEstadoDocumentos.C.ToString())
                    {
                        AgenteVentas.Proxy.CambiarEstadoDocumento(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionNC.Current).idLocal,
                                    ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento, ((EmisionDocumentoE)bsEmisionNC.Current).numSerie, ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento,
                                    EnumEstadoDocumentos.E.ToString(), VariablesLocales.SesionUsuario.Credencial);

                        ((EmisionDocumentoE)bsEmisionNC.Current).indEstado = EnumEstadoDocumentos.E.ToString();
                        bsEmisionNC.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(VariablesLocales.SesionUsuario.Empresa.sEmailFe))
                {
                    Global.MensajeFault("Defina Correo Electronica de la Empresa Emisora.");
                    return;
                }

                if (!Global.RevisarEmail(VariablesLocales.SesionUsuario.Empresa.sEmailFe))
                {
                    Global.MensajeFault("Correo electrónico de la Empresa Emisora no válido.");
                    return;
                }

                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                {
                    EnviarSunat();
                }
                else if (VariablesLocales.oVenParametros.TipoFacturacion == "B")  //Fundo San Miguel
                {
                    int TipoError = 0;

                    Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(((EmisionDocumentoE)bsEmisionNC.Current).idPersona));

                    if (oPersona != null)
                    {
                        List<String> Correos = Correos = new List<String>(oPersona.Correo.Split(';'));

                        foreach (String item in Correos)
                        {
                            if (String.IsNullOrEmpty(item.Trim()))
                            {
                                Global.MensajeFault("El cliente no tiene correo electrónico.");
                                TipoError = 1;
                            }

                            if (!Global.RevisarEmail(item.Trim()) && TipoError == 0)
                            {
                                Global.MensajeFault("Correo electrónico no válido.");
                                TipoError = 2;
                            }
                        }
                    }

                    if (String.IsNullOrEmpty(((EmisionDocumentoE)bsEmisionNC.Current).idDocumentoRef.Trim()) && String.IsNullOrEmpty(((EmisionDocumentoE)bsEmisionNC.Current).serDocumentoRef.Trim()))
                    {
                        Global.MensajeFault("La Nota de Crédito no tiene referencia revisar por favor.");
                        return;
                    }

                    if (((EmisionDocumentoE)bsEmisionNC.Current).EnviadoSunat)
                    {
                        Global.MensajeComunicacion("El documento ya ha sido enviado a Sunat.");
                        return;
                    }


                    if (TipoError == 1 || TipoError == 2)
                    {
                        if (Global.MensajeConfirmacion("Se enviara al correo de la Empresa Emisora S/N") == DialogResult.No)
                        {
                            return;
                        }
                    }


                    String numLetras = NumeroLetras.enLetras(((EmisionDocumentoE)bsEmisionNC.Current).totTotal.ToString());
                    Int32 Resp = AgenteVentas.Proxy.InsertarFacturaElectronica(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).idLocal,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).numSerie,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento,
                                                                                numLetras,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).EsGuia,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).idPersona.Value);

                    if (Resp > Variables.Cero)
                    {
                        Global.MensajeComunicacion("Se a enviado la factura correctamente");
                        btEmitir.PerformClick();
                        Buscar();
                    }
                }
                else //Otras
                {
                    Global.MensajeFault("No tiene autorización para la Facturación Electrónica.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiVer_Click(object sender, EventArgs e)
        {
            EmisionDocumentoE oDocumento = (EmisionDocumentoE)bsEmisionNC.Current;
            frmRevisarEstadosSunat oFrm = new frmRevisarEstadosSunat(oDocumento);
            oFrm.ShowDialog();
        }

        private void tsmiDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
                {
                    List<EmisionDocumentoE> oListaBaja = new List<EmisionDocumentoE>();

                    if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                    {
                        //if (Global.MensajeConfirmacion("Desea dar de baja a los documentos seleccionados") == DialogResult.Yes)
                        //{
                        //    frmTextoLargo oFrm = new frmTextoLargo("Motivo de Baja");

                        //    if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
                        //    {
                        //        foreach (DataGridViewRow Fila in dgvListado.Rows)
                        //        {
                        //            if (Fila.Selected)
                        //            {
                        //                if (Fila.Cells[0].Value.ToString() == "E")
                        //                {
                        //                    ((EmisionDocumentoE)Fila.DataBoundItem).MotivoAnulacion = oFrm.Texto;
                        //                    ((EmisionDocumentoE)Fila.DataBoundItem).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        //                    oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                        //                }
                        //                else if (Fila.Cells[0].Value.ToString() == "C")
                        //                {
                        //                    Global.MensajeFault(String.Format("El documento {0}-{1} debe estar emitido antes de dar baja en SUNAT. No se tomara en cuenta.", Fila.Cells[4].Value, Fila.Cells[5].Value));
                        //                }
                        //                else
                        //                {
                        //                    if ((Boolean)Fila.Cells[2].Value && Fila.Cells[0].Value.ToString() == "B")
                        //                    {
                        //                        Global.MensajeFault(String.Format("El documento {0}-{1} ya se encuentra anulado y dado de baja en SUNAT. No se tomara en cuenta.", Fila.Cells[4].Value, Fila.Cells[5].Value));
                        //                    }

                        //                    if (Fila.Cells[0].Value.ToString() == "B" && !(Boolean)Fila.Cells[2].Value)
                        //                    {
                        //                        if (Global.MensajeConfirmacion(String.Format("El documento {0}-{1} se encuentra anulado, pero no ha sido dado de baja en SUNAT. Desea mandarlo ?", Fila.Cells[4].Value, Fila.Cells[5].Value)) == DialogResult.Yes)
                        //                        {
                        //                            ((EmisionDocumentoE)Fila.DataBoundItem).MotivoAnulacion = oFrm.Texto;
                        //                            ((EmisionDocumentoE)Fila.DataBoundItem).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        //                            oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                        //                        }
                        //                    }
                        //                }
                        //            }
                        //        }

                        //        if (oListaBaja.Count > Variables.Cero)
                        //        {
                        //            OperacionesSunat ArchivoBaja = new OperacionesSunat();
                        //            ArchivoBaja.GenerarArchivoBaja(oListaBaja);
                        //            Int32 regActualizados = AgenteVentas.Proxy.DarBajaDocumentosVentasSunat(oListaBaja);

                        //            if (regActualizados > Variables.Cero)
                        //            {
                        //                Global.MensajeComunicacion(String.Format("Se dieron de baja {0} documentos.", regActualizados.ToString()));
                        //                Buscar();
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Global.MensajeFault("Tiene que colocar un motivo de anulación para dar de baja...");
                        //    }
                        //}
                    }
                    else if (VariablesLocales.oVenParametros.TipoFacturacion == "B")  //Fundo San Miguel
                    {
                        foreach (DataGridViewRow Fila in dgvListado.Rows)
                        {
                            if (Fila.Selected)
                            {
                                oListaBaja.Add((EmisionDocumentoE)Fila.DataBoundItem);
                            }
                        }

                        if (oListaBaja.Count == Variables.Cero)
                        {
                            Global.MensajeComunicacion("No existe ningún registro seleccionado.");
                            return;
                        }

                        if (Global.MensajeConfirmacion("Desea dar de baja a los documentos seleccionados") == DialogResult.Yes)
                        {
                            if (RevisarDocumentosBaja(oListaBaja))
                            {
                                String MotivoAnulacion = String.Empty;
                                String Tipo = "U";

                                foreach (EmisionDocumentoE item in oListaBaja)
                                {
                                    if (Tipo == "U")
                                    {
                                        DevolverMotivoAnulacion("Motivo de Baja", out MotivoAnulacion, out Tipo);
                                        item.MotivoAnulacion = MotivoAnulacion;
                                    }
                                    else
                                    {
                                        item.MotivoAnulacion = MotivoAnulacion;
                                    }

                                    item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                }

                                Int32 regActualizados = AgenteVentas.Proxy.DarBajaDocumentosVentasSunat(oListaBaja, VariablesLocales.SesionUsuario.Empresa.RUC, "CB");

                                if (regActualizados > Variables.Cero)
                                {
                                    Global.MensajeComunicacion(String.Format("Se dieron de baja {0} documentos.", regActualizados.ToString()));
                                    Buscar();
                                }
                            }
                        }
                    }
                    else //Otras
                    {
                        Global.MensajeFault("No tiene autorización para la Facturación Electrónica.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btRevisarEstados_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaDocumentos != null)
                {
                    if (oListaDocumentos.Count > Variables.Cero)
                    {
                        List<EmisionDocumentoE> oListaDocumentosSunat = new List<EmisionDocumentoE>();

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
                        {
                            //OperacionesSunat ConsultaEstados = new OperacionesSunat();
                            //String Folio = String.Empty;
                            //String Serie = String.Empty;
                            //Int16 Tipo = Variables.Cero;

                            //foreach (EmisionDocumentoE item in bsEmisionNC.List)
                            //{
                            //    if (item.EnviadoSunat && item.EstadoSunat < 1)
                            //    {
                            //        if (item.idDocumentoRef.Substring(0, 1) == "F")
                            //        {
                            //            Folio = "F" + Global.Derecha(item.numSerie.Trim(), 3) + "-" + Convert.ToInt32(item.numDocumento).ToString();
                            //            Tipo = 7;
                            //        }
                            //        else if (item.idDocumentoRef.Substring(0, 1) == "B")
                            //        {
                            //            Folio = "B" + Global.Derecha(item.numSerie.Trim(), 3) + "-" + Convert.ToInt32(item.numDocumento).ToString();
                            //            Tipo = 7;
                            //        }

                            //        List<String> oListaRespuesta = ConsultaEstados.ConsultarEstados(item.numRuc, Tipo, Folio);

                            //        if (oListaRespuesta.Count > Variables.Cero)
                            //        {
                            //            //item.fecAnuladoSunat = (Nullable<DateTime>)null;
                            //            item.EstadoSunat = Convert.ToInt32(oListaRespuesta[0]);
                            //            item.MensajeSunat = oListaRespuesta[1].ToString();
                            //            item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                            //            oListaDocumentosSunat.Add(item);

                            //            ((EmisionDocumentoE)bsEmisionNC.Current).EstadoSunat = item.EstadoSunat;
                            //            ((EmisionDocumentoE)bsEmisionNC.Current).MensajeSunat = item.MensajeSunat;
                            //            ((EmisionDocumentoE)bsEmisionNC.Current).UsuarioModificacion = item.UsuarioModificacion;
                            //        }
                            //    }
                            //}

                            //if (oListaDocumentosSunat.Count > Variables.Cero)
                            //{
                            //    Int32 resp = AgenteVentas.Proxy.ActualizarEstadoSunat(oListaDocumentosSunat);

                            //    if (resp > Variables.Cero)
                            //    {
                            //        Global.MensajeComunicacion("Termino la revisión de los estados.");
                            //    }
                            //}
                            //else
                            //{
                            //    Global.MensajeComunicacion("No hay datos para revisar...");
                            //}
                        }
                        else
                        {
                            foreach (EmisionDocumentoE item in bsEmisionNC.List)
                            {
                                if (item.EnviadoSunat && item.EstadoRegistro < 3)
                                {
                                    oListaDocumentosSunat.Add(item);
                                }
                            }

                            if (oListaDocumentosSunat.Count > Variables.Cero)
                            {
                                Int32 resp = AgenteVentas.Proxy.RecuperarEstadoSunat(oListaDocumentosSunat);

                                if (resp > Variables.Cero)
                                {
                                    Global.MensajeComunicacion("Terminó la revisión de los estados.");
                                }
                            }
                            else
                            {
                                Global.MensajeComunicacion("No hay datos para revisar...");
                            }
                        }

                        oListaDocumentosSunat = null;
                    }

                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btRevisarEstados_MouseDown(object sender, MouseEventArgs e)
        {
            btRevisarEstados.BackgroundImage = ClienteWinForm.Properties.Resources.RevisarGris;
        }

        private void btRevisarEstados_MouseUp(object sender, MouseEventArgs e)
        {
            btRevisarEstados.BackgroundImage = ClienteWinForm.Properties.Resources.RevisarNegro;
        } 

        private void frmListadoNotaCreditoUf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                btEmitir.PerformClick();
            }

            if (e.KeyCode == Keys.F12)
            {
                btRevisarEstados.PerformClick();
            }
        }

        private void dgvListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaDocumentos != null && oListaDocumentos.Count > Variables.Cero)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.ColumnIndex == dgvListado.Columns["numSerie"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numSerie ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numSerie descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["numDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["fecEmision"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.fecEmision ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.fecEmision descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["numRuc"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numRuc ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.numRuc descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["totsubTotal"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totsubTotal ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totsubTotal descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["totIgv"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totIgv ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totIgv descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvListado.Columns["totTotal"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totTotal ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDocumentos = (from x in oListaDocumentos orderby x.totTotal descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsEmisionNC.DataSource = oListaDocumentos;
            }
        }

        private void tsmiPdf_Click(object sender, EventArgs e)
        {
            try
            {
                String UrlFactura = AgenteVentas.Proxy.FacturaElectronicaUrlPdf("6",
                                                                                VariablesLocales.SesionUsuario.Empresa.RUC,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).numSerie,
                                                                                ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento);

                if (!String.IsNullOrEmpty(UrlFactura))
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPrevioDocElectronico);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmPrevioDocElectronico(UrlFactura);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }        

        private void btInsertaCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                CtaCteE oCtaCteDoc = AgenteTesoreria.Proxy.ObtenerMaeCtaCtePorDocumento(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa,
                                                                                        ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento,
                                                                                        ((EmisionDocumentoE)bsEmisionNC.Current).numSerie,
                                                                                        ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento);

                if (oCtaCteDoc == null)
                {
                    Int32 resp = AgenteVentas.Proxy.IngresarDocCtaCte(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionNC.Current).idLocal,
                                                                    ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento, ((EmisionDocumentoE)bsEmisionNC.Current).numSerie,
                                                                    ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento, VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Global.MensajeFault("Documento ingresado a la Cta.Cte. correctamente.");
                    }
                }
                else
                {
                    Global.MensajeFault("El documento ya se encuentra en la Cta.Cte.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oListaDocumentos.Count != 0)
            {
                EmisionDocumentoE EmisionDoc = AgenteVentas.Proxy.RecuperarDocumentoCompleto(((EmisionDocumentoE)bsEmisionNC.Current).idEmpresa, ((EmisionDocumentoE)bsEmisionNC.Current).idLocal,
                                                    ((EmisionDocumentoE)bsEmisionNC.Current).idDocumento, ((EmisionDocumentoE)bsEmisionNC.Current).numSerie,
                                                    ((EmisionDocumentoE)bsEmisionNC.Current).numDocumento);
                frmEditarVendedor oFrm = new frmEditarVendedor(EmisionDoc, "Vendedor");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.EmiDoc != null)
                {
                    oFrm.EmiDoc = AgenteVentas.Proxy.ActualizarEmisionDocumentoVendedor(oFrm.EmiDoc);
                }
            }
        }

        #endregion

    }
}
