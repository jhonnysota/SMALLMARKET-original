using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Almacen.Procesos;
using ClienteWinForm.Contabilidad.Reportes;

using OfficeOpenXml;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarRegistroKardex : FrmMantenimientoBase
    {

        public frmImportarRegistroKardex()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        List<MovimientoAlmacenXLSE> oListaPrincipal = null;
        List<OperacionE> oListaOperaciones = null;
        List<AlmacenE> oListaAlmacenes = null;

        List<ParTabla> oListaTipMovimientos = null;
        List<ParTabla> oListaTipArticulos = null;
        List<AlmacenE> oListaAlmacenesCombo = null;
        List<OperacionE> oListaOperacionesCombo = null;

        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty;
        Int32 errores = 0;
        Int32 resp = 0;
        Int32 MovImportados = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Operaciones
            oListaOperacionesCombo = AgenteAlmacen.Proxy.ListarOperacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.LlenarCombos<OperacionE>(cboOperaciones, oListaOperacionesCombo, "idOperacion", "desTemporal");

            //Almacenes
            oListaAlmacenesCombo = AgenteAlmacen.Proxy.ListarAlmacenPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacenes, oListaAlmacenesCombo, "idAlmacen", "desTemporal");

            //Parámetros generales
            oListaTipMovimientos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPMOVALM");
            oListaTipArticulos = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
        }

        void ImportarTipoExcel(String Tipo, String RutaExcel)
        {
            try
            {
                switch (Tipo)
                {
                    case "Op":
                        ImportarOperaciones(RutaExcel);
                        break;
                    case "Al":
                        ImportarAlmacenes(RutaExcel);
                        break;
                    case "Ka":
                        ImportarMovAlmacen(RutaExcel);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void ImportarOperaciones(String Ruta)
        {
            Int32 InicioLectura = 7;
            Int32 FilaError = 2;
            Int32 Colum = 1;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    OperacionE oRegistro = null;
                    oListaOperaciones = new List<OperacionE>();

                    //Excel
                    using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets["Operaciones"])
                    {
                        //Para el recorrido del excel
                        Int32 totFilas = oHoja.Dimension.Rows;
                        Int32.TryParse(oHoja.Cells[2, 1].Value.ToString(), out Int32 idEmpresaExcel);
                        String Valor = String.Empty;

                        if (idEmpresaExcel == 0)
                        {
                            throw new Exception("Falta colocar en la hoja excel el código de la empresa");
                        }

                        if (idEmpresaExcel != VariablesLocales.SesionUsuario.Empresa.IdEmpresa)
                        {
                            throw new Exception("La empresa asociada a la hoja excel no es la misma en la se encuentra en estos momentos; las empresas deben ser iguales.");
                        }

                        //Recorriendo la hoja excel hasta el total de fila obtenido...
                        for (int f = InicioLectura; f <= totFilas; f++)
                        {
                            if (oHoja.Cells[f, 1].Value != null)
                            {
                                if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                                {
                                    FilaError = f;
                                    
                                    oRegistro = new OperacionE
                                    {
                                        idEmpresa = idEmpresaExcel,
                                        orden = "0",
                                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                                    };

                                    Colum = 1; //Tipo de articulo o almacén
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        ParTabla TipArt = oListaTipArticulos.Find
                                        (
                                            delegate (ParTabla t) { return t.Nombre.ToUpper() == oHoja.Cells[f, Colum].Value.ToString().ToUpper(); }
                                        );

                                        if (TipArt != null)
                                        {
                                            oRegistro.tipAlmacen = Convert.ToInt32(TipArt.IdParTabla);
                                        }
                                        else
                                        {
                                            throw new Exception("No existe el tipo de articulo escogido");
                                        }
                                    }

                                    Colum = 2; //Tipo de movimiento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        ParTabla TipMov = oListaTipMovimientos.Find
                                        (
                                            delegate (ParTabla t) { return t.Nombre.ToUpper() == oHoja.Cells[f, Colum].Value.ToString().ToUpper(); }
                                        );

                                        if (TipMov != null)
                                        {
                                            oRegistro.tipMovimiento = Convert.ToInt32(TipMov.IdParTabla);
                                        }
                                        else
                                        {
                                            throw new Exception("No existe el tipo de movimiento escogido.");
                                        }
                                    }

                                    Colum = 3; //Nombre de la operación
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.desOperacion = oRegistro.desDetalle = oHoja.Cells[f, Colum].Value.ToString();
                                    }

                                    Colum = 4; //Código de Sunat
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        if (!String.IsNullOrWhiteSpace(oHoja.Cells[f, Colum].Value.ToString()))
                                        {
                                            oRegistro.codSunat = oHoja.Cells[f, Colum].Value.ToString(); 
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("Debe colocar el código de sunat."));
                                        }
                                    }

                                    Colum = 5; //Indica valorizar
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indValorizar = true;
                                        }
                                        else
                                        {
                                            oRegistro.indValorizar = false;
                                        }
                                    }

                                    Colum = 6; //Indica servicio
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indServicio = true;
                                        }
                                        else
                                        {
                                            oRegistro.indServicio = false;
                                        }
                                    }

                                    Colum = 7; //Indica automático
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.automatico = true;
                                        }
                                        else
                                        {
                                            oRegistro.automatico = false;
                                        }
                                    }

                                    Colum = 8; //Indica Orden de trabajo
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indOrdentrabajo = true;
                                        }
                                        else
                                        {
                                            oRegistro.indOrdentrabajo = false;
                                        }
                                    }

                                    Colum = 9; //Indica transferencia
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indTransferencia = true;
                                        }
                                        else
                                        {
                                            oRegistro.indTransferencia = false;
                                        }
                                    }

                                    Colum = 10; //Indica consumo
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indConsumo = true;
                                        }
                                        else
                                        {
                                            oRegistro.indConsumo = false;
                                        }
                                    }

                                    Colum = 11; //Indica documento automático
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indDocumentoAutomatico = true;
                                        }
                                        else
                                        {
                                            oRegistro.indDocumentoAutomatico = false;
                                        }
                                    }

                                    Colum = 12; //Indica Proveedor
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indProveedor = true;
                                        }
                                        else
                                        {
                                            oRegistro.indProveedor = false;
                                        }
                                    }

                                    Colum = 13; //Indica cliente
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indCliente = true;
                                        }
                                        else
                                        {
                                            oRegistro.indCliente = false;
                                        }
                                    }

                                    Colum = 14; //Indico estadistico
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indEstadistico = true;
                                        }
                                        else
                                        {
                                            oRegistro.indEstadistico = false;
                                        }
                                    }

                                    Colum = 15; //Indica orden de compra
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indOrdenCompra = true;
                                        }
                                        else
                                        {
                                            oRegistro.indOrdenCompra = false;
                                        }
                                    }

                                    Colum = 16; //Indica conversión
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indConversion = true;
                                        }
                                        else
                                        {
                                            oRegistro.indConversion = false;
                                        }
                                    }

                                    Colum = 17; //Indica devolución
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indDevolucion = true;
                                        }
                                        else
                                        {
                                            oRegistro.indDevolucion = false;
                                        }
                                    }

                                    Colum = 18; //Indica documento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indDocumento = true;
                                        }
                                        else
                                        {
                                            oRegistro.indDocumento = false;
                                        }
                                    }

                                    Colum = 19; //Indica referencia
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.indReferencia = true;
                                        }
                                        else
                                        {
                                            oRegistro.indReferencia = false;
                                        }
                                    }

                                    oListaOperaciones.Add(oRegistro);
                                    //ContadorItem++;
                                }
                            }
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Colum.ToString(), ex.Message));
            }
        }

        void ImportarAlmacenes(String Ruta)
        {
            Int32 InicioLectura = 7;
            Int32 FilaError = 2;
            Int32 Colum = 1;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    AlmacenE oRegistro = null;
                    oListaAlmacenes = new List<AlmacenE>();

                    //Excel
                    using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets["Almacenes"])
                    {
                        //Para el recorrido del excel
                        Int32 totFilas = oHoja.Dimension.Rows;
                        Int32.TryParse(oHoja.Cells[2, 1].Value.ToString(), out Int32 idEmpresaExcel);
                        String Valor = String.Empty;

                        if (idEmpresaExcel == 0)
                        {
                            throw new Exception("Falta colocar en la hoja excel el código de la empresa");
                        }

                        if (idEmpresaExcel != VariablesLocales.SesionUsuario.Empresa.IdEmpresa)
                        {
                            throw new Exception("La empresa asociada a la hoja excel no es la misma en la se encuentra en estos momentos; las empresas deben ser iguales.");
                        }

                        //Recorriendo la hoja excel hasta el total de fila obtenido...
                        for (int f = InicioLectura; f <= totFilas; f++)
                        {
                            if (oHoja.Cells[f, 1].Value != null)
                            {
                                if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                                {
                                    FilaError = f;

                                    oRegistro = new AlmacenE
                                    {
                                        idEmpresa = idEmpresaExcel,
                                        Clase = (Int32?)null,
                                        Direccion = String.Empty,
                                        TipoNumeracion = "1",
                                        desResponsable = String.Empty,
                                        EmailResponsable = String.Empty,
                                        tlfResponsable = String.Empty,
                                        idCCostos = String.Empty,
                                        indEstado = false,
                                        fecBaja = (DateTime?)null,
                                        indUbiGenerica = "X",
                                        idUbicacion = String.Empty,
                                        SiglaLoteAlmacen = String.Empty,
                                        CodEstablecimiento = String.Empty,
                                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                                    };

                                    Colum = 1; //Tipo de articulo o almacén
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        ParTabla TipArt = oListaTipArticulos.Find
                                        (
                                            delegate (ParTabla t) { return t.Nombre.ToUpper() == oHoja.Cells[f, Colum].Value.ToString().ToUpper(); }
                                        );

                                        if (TipArt != null)
                                        {
                                            oRegistro.tipAlmacen = Convert.ToInt32(TipArt.IdParTabla);
                                        }
                                        else
                                        {
                                            throw new Exception("No existe el tipo de articulo escogido");
                                        }
                                    }

                                    Colum = 3; //Descripción del almacén
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.desAlmacen = oHoja.Cells[f, Colum].Value.ToString();

                                        if (!String.IsNullOrWhiteSpace(oRegistro.desAlmacen))
                                        {
                                            List<String> oLista = new List<String>(oRegistro.desAlmacen.Split(' '));
                                            String DesCortita = String.Empty;

                                            foreach (String item in oLista)
                                            {
                                                if (item.Trim().ToUpper() != "DE" && item.Trim().ToUpper() != "Y" && item.Trim().ToUpper() != "LAS" && item.Trim().ToUpper() != "EL")
                                                {
                                                    DesCortita += item.Trim().Substring(0, 3) + "."; 
                                                }
                                            }

                                            oRegistro.desCorta = DesCortita;
                                        }
                                    }

                                    Colum = 4; //Verifica Stock
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.VerificaStock = true;
                                        }
                                        else
                                        {
                                            oRegistro.VerificaStock = false;
                                        }
                                    }

                                    Colum = 5; //Verifica Lote
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        Valor = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 1);

                                        if (Valor.ToUpper() == "V" || Valor.ToUpper() == "T")
                                        {
                                            oRegistro.VerificaLote = true;
                                        }
                                        else
                                        {
                                            oRegistro.VerificaLote = false;
                                        }
                                    }

                                    oListaAlmacenes.Add(oRegistro);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Colum.ToString(), ex.Message));
            }
        }

        void ImportarMovAlmacen(String Ruta)
        {
            Int32 InicioLectura = 8;
            Int32 FilaError = 2;
            Int32 Colum = 1;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    MovimientoAlmacenXLSE oRegistro = null;
                    oListaPrincipal = new List<MovimientoAlmacenXLSE>();

                    //Excel
                    using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets["Kardex"])
                    {
                        //Para el recorrido del excel
                        Int32 totFilas = oHoja.Dimension.Rows;
                        Int32.TryParse(oHoja.Cells[2, 1].Value.ToString(), out Int32 idEmpresaExcel);

                        if (idEmpresaExcel == 0)
                        {
                            throw new Exception("Falta colocar en la hoja excel el código de la empresa");
                        }

                        if (idEmpresaExcel != VariablesLocales.SesionUsuario.Empresa.IdEmpresa)
                        {
                            throw new Exception("La empresa asociada a la hoja excel no es la misma en la se encuentra en estos momentos; las empresas deben ser iguales.");
                        }

                        //Recorriendo la hoja excel hasta el total de fila obtenido...
                        for (int f = InicioLectura; f <= totFilas; f++)
                        {
                            if (oHoja.Cells[f, 1].Value != null)
                            {
                                if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                                {
                                    FilaError = f;

                                    oRegistro = new MovimientoAlmacenXLSE
                                    {
                                        idEmpresa = idEmpresaExcel,
                                        idUsuario = VariablesLocales.SesionUsuario.IdPersona,
                                        Linea = f
                                    };

                                    Colum = 1; //Tipo de movimiento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        ParTabla TipMov = oListaTipMovimientos.Find
                                        (
                                            delegate (ParTabla t) { return t.Nombre.ToUpper() == oHoja.Cells[f, Colum].Value.ToString().ToUpper(); }
                                        );

                                        if (TipMov != null)
                                        {
                                            oRegistro.tipMovimiento = Convert.ToInt32(TipMov.IdParTabla);
                                        }
                                        else
                                        {
                                            throw new Exception("No existe el tipo de movimiento escogido.");
                                        }
                                    }

                                    Colum = 2; //Almacen
                                    if (!chkUsarAlmacen.Checked)
                                    {
                                        if (oHoja.Cells[f, Colum].Value != null)
                                        {
                                            String AlmacenTmp = oHoja.Cells[f, Colum].Value.ToString();
                                            List<String> oLista = new List<String>(AlmacenTmp.Split('-'));

                                            if (oLista.Count > 0)
                                            {
                                                oRegistro.idAlmacen = Convert.ToInt32(oLista[0]);

                                                //Buscando el tipo de almacén en la lista con la que se lleno el combo si en caso el check no este activado
                                                AlmacenE almacen = oListaAlmacenesCombo.Find
                                                (
                                                    delegate (AlmacenE al) { return al.idAlmacen == oRegistro.idAlmacen; }
                                                );

                                                if (almacen != null)
                                                {
                                                    oRegistro.tipAlmacen = Convert.ToInt32(almacen.tipAlmacen);
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("Debe colocar un código de almacén");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        oRegistro.tipAlmacen = Convert.ToInt32(((AlmacenE)cboAlmacenes.SelectedItem).tipAlmacen);
                                        oRegistro.idAlmacen = Convert.ToInt32(cboAlmacenes.SelectedValue);
                                    }

                                    Colum = 3; //Código del articulo
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.codArticulo = oHoja.Cells[f, Colum].Value.ToString();
                                    }

                                    Colum = 4; //Operación
                                    if (!chkUsarOperacion.Checked)
                                    {
                                        if (oHoja.Cells[f, Colum].Value != null)
                                        {
                                            oRegistro.idOperacion = Convert.ToInt32(oHoja.Cells[f, Colum].Value);
                                        } 
                                    }
                                    else
                                    {
                                        oRegistro.idOperacion = Convert.ToInt32(cboOperaciones.SelectedValue);
                                    }

                                    Colum = 6; //Fecha del documento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.fecDocumento = Convert.ToDateTime(oHoja.Cells[f, Colum].Value);
                                        oRegistro.fecProceso = Convert.ToDateTime(oHoja.Cells[f, Colum].Value);
                                    }

                                    Colum = 7; //Tipo de documento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.idDocumento = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 8; //Serie del documento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.serDocumento = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 9; //N° del documento
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.numDocumento = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 10; //Tipo de documento de referencia
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.idDocumentoRef = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 11; //Serie de la referencia
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.SerieDocumentoRef = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 12; //N° de la referencia
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.NumeroDocumentoRef = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 13; //Moneda
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.idMoneda = oHoja.Cells[f, Colum].Value.ToString().Substring(0, 2);
                                    }

                                    Colum = 14; //Cantidad
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.Cantidad = Convert.ToDecimal(oHoja.Cells[f, Colum].Value);
                                    }

                                    Colum = 15; //Costo Unitario
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        if (oRegistro.idMoneda == "01")
                                        {
                                            oRegistro.CostoUnitBase = Convert.ToDecimal(oHoja.Cells[f, Colum].Value); 
                                        }
                                        else
                                        {
                                            oRegistro.CostoUnitRefe = Convert.ToDecimal(oHoja.Cells[f, Colum].Value);
                                        }
                                    }

                                    Colum = 16; //Costo Total
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        if (oRegistro.idMoneda == "01")
                                        {
                                            oRegistro.CostoTotBase = Convert.ToDecimal(oHoja.Cells[f, Colum].Value);
                                        }
                                        else
                                        {
                                            oRegistro.CostoTotRefe = Convert.ToDecimal(oHoja.Cells[f, Colum].Value);
                                        }
                                    }

                                    Colum = 17; //Lote
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.Lote = oHoja.Cells[f, Colum].Value.ToString().ToString();
                                    }

                                    Colum = 18; //Lote proveedor
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.LoteProv = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 19; //Pais de origen
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.PaisOrigen = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }
                                    else
                                    {
                                        oRegistro.PaisOrigen = String.Empty;
                                    }

                                    Colum = 20; //Pais de destino
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.PaisDestino = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }
                                    else
                                    {
                                        oRegistro.PaisDestino = String.Empty;
                                    }

                                    Colum = 21; //Batch
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.batch = oHoja.Cells[f, Colum].Value.ToString().Trim();
                                    }

                                    Colum = 22; //Germinación
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        String Germ = oHoja.Cells[f, Colum].Value.ToString();
                                        List<String> oLista = new List<String>(Germ.Split('%'));

                                        oRegistro.Germinacion = Convert.ToDecimal(oLista[0]);
                                    }

                                    Colum = 23; //Fecha de prueba
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        DateTime.TryParse(oHoja.Cells[f, Colum].Value.ToString(), out DateTime fec);

                                        if (fec.ToString("dd/MM/yyyy") != "01/01/0001")
                                        {
                                            oRegistro.FechaPrueba = Convert.ToDateTime(fec);

                                            if (oRegistro.FechaPrueba < Convert.ToDateTime("01/01/1980"))
                                            {
                                                throw new Exception("La fecha de prueba tiene que ser mayor a 01/01/1980");
                                            }
                                        }
                                        else
                                        {
                                            oRegistro.FechaPrueba = null;
                                        }
                                    }
                                    else
                                    {
                                        oRegistro.FechaPrueba = null;
                                    }

                                    //Buscando el tipo de almacén en la lista con la que se lleno el combo si en caso el check no este activado
                                    OperacionE operacion = oListaOperacionesCombo.Find
                                    (
                                        delegate (OperacionE op) { return op.idOperacion == oRegistro.idOperacion; }
                                    );

                                    if (operacion != null)
                                    {
                                        //Documento que sustenta el movimiento
                                        if (!operacion.indDocumento)
                                        {
                                            oRegistro.idDocumento = String.Empty;
                                            oRegistro.serDocumento = String.Empty;
                                            oRegistro.numDocumento = String.Empty;
                                            oRegistro.fecDocumento = null;
                                        }
                                        //Referencia
                                        if (!operacion.indReferencia)
                                        {
                                            oRegistro.idDocumentoRef = "0";
                                            oRegistro.SerieDocumentoRef = String.Empty;
                                            oRegistro.NumeroDocumentoRef = String.Empty;
                                        }
                                    }

                                    //Añadiendo a la lista principal
                                    oListaPrincipal.Add(oRegistro);
                                }
                            }
                        }

                        FilaError = 0;
                        Colum = 0;
                        //Para saber cuantos registros de han importado
                        MovImportados = oListaPrincipal.Count;
                        //Para saber si es que hay mas de una fecha de proceso
                        var ListaAgrupada1 = oListaPrincipal.GroupBy(x => x.fecProceso).Select(p => p.First()).ToList();

                        if (ListaAgrupada1.Count > 1)
                        {
                            throw new Exception("Debe existir una sola fecha en la Columna F (Fecha)");
                        }

                        //Obteniendo el tipo de cambio
                        TipoCambioE tipoCambio = VariablesLocales.RetornaTipoCambio("02", ListaAgrupada1[0].fecProceso.Date);

                        if (tipoCambio != null)
                        {
                            foreach (MovimientoAlmacenXLSE item in oListaPrincipal)
                            {
                                item.tipCambio = tipoCambio.valVenta;
                            } 
                        }
                        else
                        {
                            throw new Exception("No hay tipo de cambio para la fecha que se encuentra en el Excel");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (FilaError == 0 && Colum == 0)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Colum.ToString(), ex.Message));
                }
            }
        }

        List<MovimientoAlmacenXLSE> ImportarLotes(String Ruta)
        {
            Int32 InicioLectura = 8;
            Int32 FilaError = 2;
            Int32 Colum = 1;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    MovimientoAlmacenXLSE oRegistro = null;
                    List<MovimientoAlmacenXLSE> oListaDevuelta = new List<MovimientoAlmacenXLSE>();

                    //Excel
                    using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets["Kardex"])
                    {
                        //Para el recorrido del excel
                        Int32 totFilas = oHoja.Dimension.Rows;
                        Int32.TryParse(oHoja.Cells[2, 1].Value.ToString(), out Int32 idEmpresaExcel);

                        if (idEmpresaExcel == 0)
                        {
                            throw new Exception("Falta colocar en la hoja excel el código de la empresa");
                        }

                        if (idEmpresaExcel != VariablesLocales.SesionUsuario.Empresa.IdEmpresa)
                        {
                            throw new Exception("La empresa asociada a la hoja excel no es la misma en la se encuentra en estos momentos; las empresas deben ser iguales.");
                        }

                        //Recorriendo la hoja excel hasta el total de fila obtenido...
                        for (int f = InicioLectura; f <= totFilas; f++)
                        {
                            if (oHoja.Cells[f, 1].Value != null)
                            {
                                if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                                {
                                    FilaError = f;

                                    oRegistro = new MovimientoAlmacenXLSE
                                    {
                                        idEmpresa = idEmpresaExcel,
                                        idUsuario = VariablesLocales.SesionUsuario.IdPersona,
                                        Linea = f
                                    };

                                    Colum = 17; //Lote
                                    if (oHoja.Cells[f, Colum].Value != null)
                                    {
                                        oRegistro.Lote = oHoja.Cells[f, Colum].Value.ToString().ToString();
                                    }

                                    //Añadiendo a la lista principal
                                    if (!String.IsNullOrWhiteSpace(oRegistro.Lote))
                                    {
                                        oListaDevuelta.Add(oRegistro);
                                    }
                                }
                            }
                        }
                    }

                    return oListaDevuelta;
                }
            }
            catch (Exception ex)
            {
                if (FilaError == 0 && Colum == 0)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Colum.ToString(), ex.Message));
                }
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Int32 Minimo = 0; //Para saber la linea mínima
            Int32 Maximo = 0; //Para saber la linea máxima
            String MensajeErr = String.Empty;

            try
            {
                if (TipoProceso == "P")
                {
                    #region Procesando la Información

                    errores = 0;
                    Int32 TotalReg = Variables.Cero; //Total registros en la lista Principal
                    Int32 TotalTemp = Variables.Cero; //Total registros para poder ir descontando cuantos van quedandos
                    Int32 cantReg = Variables.Cero; //Para saber cuantos registros se van a ir quitando
                    Int32 Residuo = Variables.Cero; //Para saber si sobra registros en caso el total sea impar

                    //Borrando VENTAS por Empresa y Usuario
                    AgenteAlmacen.Proxy.EliminarMovimientoAlmacenXLS(oListaPrincipal[0].idEmpresa, oListaPrincipal[0].idUsuario);

                    //Empezando el ingreso a VoucherXLS
                    if (oListaPrincipal.Count < 1000)
                    {
                        oListaPrincipal = AgenteAlmacen.Proxy.InsertarMovimientoAlmacenXLS(oListaPrincipal);
                    }
                    else
                    {
                        List<MovimientoAlmacenXLSE> oListaExcel = new List<MovimientoAlmacenXLSE>(oListaPrincipal);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<MovimientoAlmacenXLSE> oListaTemporal = new List<MovimientoAlmacenXLSE>();

                            if (Residuo == oListaExcel.Count)
                            {
                                for (int i = 0; i < Residuo; i++)
                                {
                                    oListaTemporal.Add(oListaExcel[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantReg; i++)
                                {
                                    oListaTemporal.Add(oListaExcel[i]);
                                }
                            }

                            foreach (MovimientoAlmacenXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteAlmacen.Proxy.InsertarMovimientoAlmacenXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                //lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Obteniendo los errores si los hubiere...
                    errores = AgenteAlmacen.Proxy.ProcesarMovimientoAlmacenXLS(oListaPrincipal[0].idEmpresa, 0, oListaPrincipal[0].idUsuario);

                    if (errores > 0)
                    {
                        throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                    }

                    #endregion
                }
                else if (TipoProceso == "E")
                {
                    #region Importando desde Excel

                    if (rbOperaciones.Checked)
                    {
                        ImportarTipoExcel("Op", RutaGeneral);
                    }
                    else if (rbAlmacenes.Checked)
                    {
                        ImportarTipoExcel("Al", RutaGeneral);
                    }
                    else if (rbKardex.Checked)
                    {
                        ImportarTipoExcel("Ka", RutaGeneral);
                    }

                    #endregion
                }
                else if (TipoProceso == "I")
                {
                    #region Operaciones

                    if (rbOperaciones.Checked)
                    {
                        resp = AgenteAlmacen.Proxy.InsertarOperacionesMasiva(oListaOperaciones);
                    }

                    #endregion

                    #region Almacenes

                    if (rbAlmacenes.Checked)
                    {
                        resp = AgenteAlmacen.Proxy.InsertarAlmacenesMasivo(oListaAlmacenes);
                    }

                    #endregion

                    #region Movimientos de Almacen

                    if (rbKardex.Checked)
                    {
                        resp = AgenteAlmacen.Proxy.IntegrarMovimientoAlmacenXLS(oListaPrincipal, VariablesLocales.SesionUsuario.Credencial);
                    }

                    #endregion
                }

                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MensajeErr + ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btExaminar.Enabled = true;
            btActualizar.Enabled = true;
            btCancelar.Enabled = false;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            letra = 0;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                if (errores > 0)
                {
                    bterrores.Enabled = true;
                }

                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (TipoProceso == "P")
                {
                    if (rbKardex.Checked)
                    {
                        btProcesar.Enabled = true;
                        bterrores.Enabled = false;
                        btIntegrar.Enabled = true;

                        Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                    }
                }
                else if (TipoProceso == "E")
                {
                    if (rbOperaciones.Checked)
                    {
                        btProcesar.Enabled = false;
                        bterrores.Enabled = false;
                        btIntegrar.Enabled = oListaOperaciones.Count > 0;

                        if (oListaOperaciones.Count > 0)
                        {
                            Global.MensajeComunicacion(String.Format("Se han importado de la hoja excel {0} registros...", oListaOperaciones.Count));
                        }
                    }
                    else if (rbAlmacenes.Checked)
                    {
                        btProcesar.Enabled = false;
                        bterrores.Enabled = false;
                        btIntegrar.Enabled = oListaAlmacenes.Count > 0;

                        if (oListaAlmacenes.Count > 0)
                        {
                            Global.MensajeComunicacion(String.Format("Se han importado de la hoja excel {0} registros...", oListaAlmacenes.Count));
                        }
                    }
                    else
                    {
                        btIntegrar.Enabled = false;
                        btProcesar.Enabled = oListaPrincipal.Count > 0;

                        if (oListaPrincipal.Count > 0 && MovImportados > 0)
                        {
                            Global.MensajeComunicacion(String.Format("Se han importado de la hoja excel {0} registros...", MovImportados.ToString()));
                        }
                    }
                }
                else
                {
                    if (rbOperaciones.Checked && resp > 0)
                    {
                        LlenarCombos();
                        oListaOperaciones = null;
                        Global.MensajeComunicacion("Se han ingresado correctamente las Operaciones de Almacén...");
                    }

                    if (rbAlmacenes.Checked && resp > 0)
                    {
                        LlenarCombos();
                        oListaAlmacenes = null;
                        Global.MensajeComunicacion("Se han ingresado correctamente los Almacenes...");
                    }

                    if (rbKardex.Checked && resp > 0)
                    {
                        oListaPrincipal = null;
                        Global.MensajeComunicacion("Se han ingresado correctamente los Movientos a almacén...");
                    }

                    btProcesar.Enabled = false;
                    bterrores.Enabled = false;
                    btIntegrar.Enabled = false;
                }
            }
        }

        #endregion

        #region Eventos

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx;*.xls");
            }
            catch (Exception ex)
            {
                btExaminar.Enabled = true;
                TipoProceso = String.Empty;
                lblProcesando.Visible = false;
                timer1.Enabled = false;
                Cursor = Cursors.Arrow;
                Marquee = String.Empty;
                Global.MensajeError(ex.Message);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Tiene que seleccionar el archivo excel");
                    return;
                }

                RutaGeneral = txtRuta.Text.Trim();

                if (File.Exists(RutaGeneral))
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }

                    TipoProceso = "E";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    bterrores.Enabled = false;
                    btIntegrar.Enabled = false;

                    Marquee = "Cargando Hoja Excel...";
                    lblProcesando.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    pbProgress.Visible = true;

                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaGeneral));
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            letra += 1;

            if (letra == Marquee.Length)
            {
                lblProcesando.Text = String.Empty;
                letra = 0;
            }
            else
            {
                lblProcesando.Text += Marquee.Substring(letra - 1, 1);
            }
        }

        private void frmImportarRegistroKardex_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btIntegrar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoProceso = "I";
                btExaminar.Enabled = false;
                btCancelar.Enabled = true;
                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
                Marquee = "Integrando los datos a la BD...";
                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bterrores_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmErrores);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmErrores("MovXLS")
                {
                    MdiParent = MdiParent
                };

                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                }

                TipoProceso = "P";
                btExaminar.Enabled = false;
                btCancelar.Enabled = true;
                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                bterrores.Enabled = false;
                btIntegrar.Enabled = false;

                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                Marquee = "Procesando Información...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkUsarOperacion_CheckedChanged(object sender, EventArgs e)
        {
            cboOperaciones.Enabled = chkUsarOperacion.Checked;
        }

        private void chkUsarAlmacen_CheckedChanged(object sender, EventArgs e)
        {
            cboAlmacenes.Enabled = chkUsarAlmacen.Checked;
        }

        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            oListaOperaciones = null;
            oListaAlmacenes = null;
            oListaPrincipal = null;

            btRevisarLotes.Enabled = rbKardex.Checked;
            btActualizar.Enabled = !rbKardex.Checked;
        }

        private void rbAlmacenes_CheckedChanged(object sender, EventArgs e)
        {
            oListaOperaciones = null;
            oListaAlmacenes = null;
            oListaPrincipal = null;

            btRevisarLotes.Enabled = rbKardex.Checked;
            btActualizar.Enabled = !rbKardex.Checked;
        }

        private void rbKardex_CheckedChanged(object sender, EventArgs e)
        {
            oListaOperaciones = null;
            oListaAlmacenes = null;
            oListaPrincipal = null;

            chkUsarOperacion.Checked = false;
            chkUsarAlmacen.Checked = false;
            chkUsarOperacion.Enabled = rbKardex.Checked;
            chkUsarAlmacen.Enabled = rbKardex.Checked;

            btRevisarLotes.Enabled = rbKardex.Checked;
            btActualizar.Enabled = !rbKardex.Checked;
        }

        private void btRevisarLotes_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Tiene que seleccionar el archivo excel");
                    return;
                }

                List<MovimientoAlmacenXLSE> ListaMovLotes = ImportarLotes(txtRuta.Text.Trim());

                if (ListaMovLotes.Count > 0)
                {
                    List<kardexE> ListaKardex = AgenteAlmacen.Proxy.RevisarLotesKardexXLS(ListaMovLotes);

                    if (ListaKardex.Count > 0)
                    {
                        frmRevisionLotesKardex oFrm = new frmRevisionLotesKardex(ListaKardex);

                        if (oFrm.ShowDialog() == DialogResult.OK)
                        {
                            btActualizar.Enabled = true;
                        }
                    }
                    else
                    {
                        btActualizar.Enabled = true;
                    }
                }
                else
                {
                    btActualizar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
