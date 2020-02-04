using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;

#region Para Excel

using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using System.Diagnostics;
//using Microsoft.Office.Interop.Excel;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmGenerarAsientoPlanilla : FrmMantenimientoBase
    {

        public frmGenerarAsientoPlanilla()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombo();

            pFormatoGrid(dgvPlantilla, false, 30, 23, false);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        PlantillaAsientoE oPlantilla = null;
        List<PlantillaAsientoDetE> oListaPlantillas = null;

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            //Plantillas
            List<PlantillaAsientoE> oListarPlantillas = AgenteContabilidad.Proxy.ListarPlantillaAsiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            PlantillaAsientoE FilaNueva = new PlantillaAsientoE() { idPlantilla = Variables.Cero, Descripcion = "<<Seleccionar Plantilla>>" };
            oListarPlantillas.Add(FilaNueva);
            ComboHelper.LlenarCombos<PlantillaAsientoE>(cboPlantilla, (from x in oListarPlantillas orderby x.idPlantilla select x).ToList(), "idPlantilla", "Descripcion");
            oListarPlantillas = null;
        }

        void LlenarComboGrid()
        {
            //Documentos
            DataGridViewComboBoxColumn oCombo = dgvPlantilla.Columns["idDocumento"] as DataGridViewComboBoxColumn;

            List<DocumentosE> oListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE oItemDoc = new DocumentosE() { idDocumento = "0", desDocumento = Variables.Seleccione };
            oListaDocumentos.Add(oItemDoc);

            ComboHelper.RellenarCombos<DocumentosE>(oCombo, (from x in oListaDocumentos
                                                             where x.indBaja == false
                                                             orderby x.idDocumento
                                                             select x).ToList(), "idDocumento", "desDocumento");
            oListaDocumentos = null;
        }

        void ImportarExcel(FileInfo oFi_)
        {
            String MensajeFila = String.Empty;
            String MensajeColu = String.Empty;

            try
            {
                //if (oFi_.Extension.ToUpper() == ".XLS")
                //{
                //    oFi_ = Infraestructura.Global.CambiarExtensionExcel(oFi_);
                //}

                //Excel...
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Obteniendo la pestaña
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[Convert.ToInt32(((PlantillaAsientoE)cboPlantilla.SelectedItem).Hoja)];
                    Int32 colIni = Convert.ToInt32(txtColIni.Text);
                    Int32 colFin = Convert.ToInt32(txtColFin.Text);
                    Int32 filIni = Convert.ToInt32(txtFilaIni.Text);
                    Int32 filFin = Convert.ToInt32(txtFilaFin.Text);
                    Int32 Fila = filFin - 1;
                    Int32 totFilas = Convert.ToInt32(txtTotFilas.Text);
                    
                    if (colIni == Variables.Cero)
                    {
                        throw new Exception("La columna inicial no puede ser 0.");
                    }

                    if (colFin == Variables.Cero)
                    {
                        throw new Exception("La columna final no puede ser 0.");
                    }

                    if (filIni == Variables.Cero)
                    {
                        throw new Exception("La fila inicial no puede ser 0.");
                    }

                    if (filFin == Variables.Cero)
                    {
                        throw new Exception("La fila final no puede ser 0.");
                    }

                    String idCCosto = String.Empty;
                    Decimal Monto = Variables.Cero;
                    String codCuenta = String.Empty;
                    //String ctaTemporal = String.Empty;
                    PlanCuentasE oCuenta = null;
                    Boolean indQuitar = false;
                    Int32 divDH = Variables.Cero;
                    oListaPlantillas = new List<PlantillaAsientoDetE>();
                    

                    for (int i = colIni; i <= colFin; i++)
                    {
                        if (oHoja.Cells[2, i].Value != null)
                        {
                            if (oHoja.Cells[2, i].Value.ToString().Trim().ToUpper() == "TOTAL")
                            {
                                divDH = i;
                                break;
                            }
                        }
                    }

                    foreach (PlantillaAsientoDetE itemPlantilla in oPlantilla.ListaPlantillas)
                    {
                        totFilas = Convert.ToInt32(txtTotFilas.Text);

                        for (int f = filIni; f <= Fila; f++)
                        {
                            MensajeFila = "Fila " + f.ToString();

                            for (int c = colIni; c <= colFin; c++)
                            {
                                MensajeColu = "Colum. " + c.ToString();

                                //if (c == 44 && f == 4)
                                //{
                                //    MessageBox.Show("Aqui");
                                //}

                                if (oHoja.Cells[f, c].Value != null)
                                {
                                    if (Convert.ToDecimal(oHoja.Cells[f, c].Value) != Variables.Cero)
                                    {
                                        if (colIni == c)
                                        {
                                            idCCosto = oHoja.Cells[f, c].Value.ToString().Trim();
                                        }
                                        else
                                        {
                                            if (itemPlantilla.QuitarDH)
                                            {
                                                if (oHoja.Cells[f - totFilas, c].Value != null)
                                                {
                                                    if (oHoja.Cells[f - totFilas, c].Value.ToString().Trim().ToUpper() == "TOTAL")
                                                    {
                                                        indQuitar = true;
                                                    }
                                                }
                                            }

                                            if (oHoja.Cells[filFin, c].Value != null)
                                            {
                                                codCuenta = oHoja.Cells[filFin, c].Value.ToString().Trim();

                                                if (codCuenta.Contains(itemPlantilla.codCuenta))
                                                {
                                                    oCuenta = VariablesLocales.ObtenerPlanCuenta(itemPlantilla.codCuenta);

                                                    if (oCuenta == null)
                                                    {
                                                        throw new Exception(String.Format("La cuenta {0} no existe.", codCuenta));
                                                    }

                                                    if (itemPlantilla.Calculo == "CU" && itemPlantilla.indDebeHaber == Variables.Debe)
                                                    {
                                                        Monto = Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());
                                                        break;
                                                    }
                                                    else if (itemPlantilla.Calculo == "CU" && itemPlantilla.indDebeHaber == Variables.Haber)
                                                    {
                                                        if (totFilas > 2)
                                                        {
                                                            Monto = Convert.ToDecimal(oHoja.Cells[f - 2, c].Value.ToString().Trim());
                                                        }
                                                        else
                                                        {
                                                            Monto = Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());
                                                        }

                                                        break;
                                                    }
                                                    else if (itemPlantilla.Calculo == "AH")
                                                    {
                                                        if (!indQuitar)
                                                        {
                                                            Monto += Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());
                                                        }
                                                        else
                                                        {
                                                            Monto -= Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());
                                                        }
                                                    }
                                                    else if (itemPlantilla.Calculo == "AV" && itemPlantilla.indDebeHaber == Variables.Debe)
                                                    {
                                                        if (c < divDH)
                                                        {
                                                            Int32 totCol = c + 3;

                                                            for (int col = c; col <= totCol; col++)
                                                            {
                                                                if (oHoja.Cells[filFin, col].Value != null)
                                                                {
                                                                    if (oHoja.Cells[filFin, col].Value.ToString().Trim() == codCuenta)
                                                                    {
                                                                        Monto += Convert.ToDecimal(oHoja.Cells[f - 2, col].Value.ToString().Trim());
                                                                    }
                                                                }
                                                            }

                                                            break;
                                                        }
                                                    }
                                                    else if (itemPlantilla.Calculo == "AV" && itemPlantilla.indDebeHaber == Variables.Haber)
                                                    {
                                                        if (c > divDH)
                                                        {
                                                            Int32 Residuo = totFilas % 2;
                                                            Int32 Disminuir = Residuo == 0 ? totFilas : totFilas + 1;
                                                            Monto = Convert.ToDecimal(oHoja.Cells[f - 2, c].Value.ToString().Trim());

                                                            if (itemPlantilla.Seguir)
                                                            {
                                                                for (int col = c + 1; col <= colFin - 1; col++)
                                                                {
                                                                    if (oHoja.Cells[filFin, col].Value != null)
                                                                    {
                                                                        if (oHoja.Cells[filFin, col].Value.ToString().Trim() == codCuenta)
                                                                        {
                                                                            if (!itemPlantilla.Saltar)
                                                                            {
                                                                                Monto += Convert.ToDecimal(oHoja.Cells[f - 2, col].Value.ToString().Trim());
                                                                            }
                                                                            else
                                                                            {
                                                                                if (!String.IsNullOrEmpty(itemPlantilla.Refe1))
                                                                                {
                                                                                    if (oHoja.Cells[f - Disminuir, col].Value.ToString().ToUpper().Trim().Contains(itemPlantilla.Refe1))
                                                                                    {
                                                                                        if (Monto != Variables.Cero)
                                                                                        {
                                                                                            CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 0, idCCosto, Monto, oCuenta, String.Empty, String.Empty);
                                                                                            Monto = Variables.Cero;
                                                                                        }

                                                                                        Monto = Convert.ToDecimal(oHoja.Cells[f - 2, col].Value.ToString().Trim()) + Convert.ToDecimal(oHoja.Cells[f - 2, colFin].Value.ToString().Trim());
                                                                                        CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 0, idCCosto, Monto, oCuenta, String.Empty, String.Empty);
                                                                                        Monto = Variables.Cero;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Monto != Variables.Cero)
                                                                                        {
                                                                                            CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 0, idCCosto, Monto, oCuenta, String.Empty, String.Empty);
                                                                                        }

                                                                                        Monto = Convert.ToDecimal(oHoja.Cells[f - 2, col].Value.ToString().Trim());
                                                                                    }
                                                                                }
                                                                                else
                                                                                {

                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (!String.IsNullOrEmpty(itemPlantilla.Refe1))
                                                                {
                                                                    Monto = Variables.Cero;

                                                                    if (oHoja.Cells[f - Disminuir, c].Value.ToString().ToUpper().Trim().Contains(itemPlantilla.Refe1))
                                                                    {
                                                                        Monto = Convert.ToDecimal(oHoja.Cells[f - 2, c].Value.ToString().Trim());
                                                                        break;
                                                                    }

                                                                    continue;
                                                                }
                                                            }

                                                            break;
                                                        }
                                                    }
                                                    else if (itemPlantilla.Calculo == "NO" && itemPlantilla.indDebeHaber == Variables.Haber)
                                                    {
                                                        if (c > divDH)
                                                        {
                                                            if (itemPlantilla.indContraPart)
                                                            {
                                                                if (oHoja.Cells[filFin, c + 1].Value.ToString().Trim() != itemPlantilla.ctaContraPart)
                                                                {
                                                                    Monto = Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());
                                                                    break;
                                                                }

                                                                continue;
                                                            }
                                                            else
                                                            {
                                                                Monto = Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());

                                                                if (itemPlantilla.indDetalle)
                                                                {
                                                                    Monto = Variables.Cero;
                                                                    CargarDetalle(oExcel, itemPlantilla.Hoja.Value, itemPlantilla.Refe1, itemPlantilla.Refe2, itemPlantilla.idEmpresa,
                                                                                    itemPlantilla.idLocal, itemPlantilla.indDebeHaber, 0, idCCosto, oCuenta);

                                                                    break;
                                                                }

                                                                if (itemPlantilla.Seguir)
                                                                {
                                                                    CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 0, idCCosto, Monto, oCuenta, String.Empty, String.Empty);
                                                                    Monto = Variables.Cero;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (itemPlantilla.indContraPart)
                                                        {
                                                            if (oHoja.Cells[filFin, c + 1].Value.ToString().Trim() == itemPlantilla.ctaContraPart)
                                                            {
                                                                Monto = Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());
                                                                break;
                                                            }

                                                            continue;
                                                        }
                                                        else
                                                        {                                                            
                                                            Monto = Convert.ToDecimal(oHoja.Cells[f, c].Value.ToString().Trim());

                                                            if (itemPlantilla.indDetalle)
                                                            {
                                                                Monto = Variables.Cero;
                                                                CargarDetalle(oExcel, itemPlantilla.Hoja.Value, itemPlantilla.Refe1, itemPlantilla.Refe2, itemPlantilla.idEmpresa, 
                                                                                itemPlantilla.idLocal, itemPlantilla.indDebeHaber, 0, idCCosto, oCuenta);
                                                            }

                                                            if (itemPlantilla.Seguir)
                                                            {
                                                                CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 0, idCCosto, Monto, oCuenta, String.Empty, String.Empty);
                                                                Monto = Variables.Cero;

                                                                if (itemPlantilla.indDebeHaber == Variables.Debe)
                                                                {
                                                                    for (int iColum = c + 1; iColum < divDH; iColum++)
                                                                    {
                                                                        if (oHoja.Cells[filFin, iColum].Value != null)
                                                                        {
                                                                            if (oHoja.Cells[filFin, iColum].Value.ToString().Trim() == codCuenta)
                                                                            {
                                                                                Monto = Convert.ToDecimal(oHoja.Cells[f, iColum].Value.ToString().Trim());
                                                                                
                                                                                if (Monto != Variables.Cero)
                                                                                {
                                                                                    CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 0, idCCosto, Monto, oCuenta, String.Empty, String.Empty);
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                    Monto = Variables.Cero;
                                                                }
                                                            }

                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (colIni == c)
                                    {
                                        throw new Exception(String.Format("Falta ingresar el Centro de Costo en la fila {0} columna {1}", f, c));    
                                    }                                    
                                }
                            }

                            if (Monto != Variables.Cero)
                            {
                                CargarLinea(itemPlantilla.idEmpresa, itemPlantilla.idLocal, itemPlantilla.numVerPlanCuentas, itemPlantilla.indDebeHaber, 
                                            itemPlantilla.codColumnaCoven, idCCosto, Convert.ToDecimal(Monto), oCuenta, String.Empty, String.Empty);
                            }                            

                            idCCosto = String.Empty;
                            Monto = Variables.Cero;
                            codCuenta = String.Empty;
                            indQuitar = false;
                            totFilas++;

                            if (itemPlantilla.Calculo == "AV")
                            {
                                break;
                            }
                            else if (itemPlantilla.indDetalle)
                            {
                                break;
                            }
                            else if (itemPlantilla.Calculo == "CU" && itemPlantilla.indDebeHaber == Variables.Haber)
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    CargarDataGridView(oListaPlantillas);
                    //lblItems.Text = "Items " + oListaPlantillas.Count.ToString();
                    oCuenta = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ". Revisar en:\n\r" + MensajeFila + " " + MensajeColu);
            }
        }

        void CargarDataGridView(List<PlantillaAsientoDetE> oListaDetalle)
        {
            dgvPlantilla.DataSource = null;

            if (oListaDetalle.Count > Variables.Cero)
            {
                if (((PlantillaAsientoE)cboPlantilla.SelectedItem).sumCCostos)
                {
                    List<PlantillaAsientoDetE> oListaTemp = oListaDetalle
                        .GroupBy(cc => cc.idCCostos + cc.codCuenta)
                        .Select(x => new PlantillaAsientoDetE
                        {
                            idEmpresa = x.First().idEmpresa,
                            idLocal = x.First().idLocal,
                            numVerPlanCuentas = x.First().numVerPlanCuentas,
                            codCuenta = x.First().codCuenta,
                            desCuenta = x.First().desCuenta,
                            indDebeHaber = x.First().indDebeHaber,
                            codColumnaCoven = x.First().codColumnaCoven,
                            idCCostos = x.First().idCCostos,
                            Monto = x.Sum(m => m.Monto), //Sumando...
                            UsuarioRegistro = x.First().UsuarioRegistro,
                            oPlanCuentas = x.First().oPlanCuentas,
                            nroDocumento = x.First().nroDocumento,
                            RazonSocial = x.First().RazonSocial,
                            idDocumento = x.First().idDocumento,
                            Serie = x.First().Serie,
                            Numero = x.First().Numero
                        }).ToList();

                    if (oListaTemp != null)
                    {
                        oListaDetalle = new List<PlantillaAsientoDetE>(oListaTemp);
                        oListaTemp = null;
                    }
                }

                LlenarComboGrid();
                dgvPlantilla.DataSource = oListaDetalle;
                OtroFormato();
            }
            else
            {
                dgvPlantilla.DataSource = null;
            }
        }

        void CargarLinea(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String indDebeHaber, Int32? codColumnaCoven, String idCCosto, Decimal Monto, 
                        PlanCuentasE oCuenta, String NumeroDoc, String RazonSocial)
        {
            PlantillaAsientoDetE oPlantillaDet = new PlantillaAsientoDetE()
            {
                idEmpresa = idEmpresa,
                idLocal = idLocal,
                numVerPlanCuentas = numVerPlanCuentas,
                codCuenta = oCuenta.codCuenta,
                desCuenta = oCuenta.Descripcion,
                indDebeHaber = indDebeHaber,
                codColumnaCoven = codColumnaCoven == Variables.Cero ? (Nullable<Int32>)null : codColumnaCoven,
                idCCostos = oCuenta.indSolicitaCentroCosto == Variables.SI ? idCCosto : String.Empty,
                Monto = Convert.ToDecimal(Monto),
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                oPlanCuentas = oCuenta,
                nroDocumento = NumeroDoc,
                RazonSocial = RazonSocial,
                idDocumento = String.Empty,
                Serie = String.Empty,
                Numero = String.Empty
            };

            oListaPlantillas.Add(oPlantillaDet);
            oPlantillaDet = null;
        }

        void CargarDetalle(ExcelPackage oExcel, Int32 Hoja, String Refe1, String Refe2, Int32 idEmpresa, Int32 idLocal, String indDebeHaber, Int32 codColumnaCoven, 
                            String idCCosto, PlanCuentasE oPlanCuenta)
        {
            //Obteniendo la pestaña
            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[Hoja];

            //Para el recorrido del excel
            Int32 totFilasExcel = oHoja.Dimension.Rows;

            //Recorriendo la hoja excel hasta el total de fila obtenido...
            for (int f = 1; f <= totFilasExcel; f++)
            {
                if (oHoja.Cells[f, 1].Value != null)
                {
                    //Ubicando la referencia 1 en la pestaña 3
                    if (oHoja.Cells[f, 1].Value.ToString().Trim() == Refe1)
                    {
                        //Agregando una fila mas para el recorrido del detalle
                        Int32 Fila = f + 1;

                        //Recorriendo para ingresar el detalle mientras la columna 1 tenga datos
                        while (oHoja.Cells[Fila, 1].Value != null)
                        {
                            if (oHoja.Cells[Fila, 5].Value.ToString().Trim() == oPlanCuenta.codCuenta)
                            {
                                if (oHoja.Cells[Fila, 3].Value.ToString().Trim() == Refe2)
                                {
                                    CargarLinea(idEmpresa, idLocal, oPlanCuenta.numVerPlanCuentas, indDebeHaber, codColumnaCoven, idCCosto,
                                                    Convert.ToDecimal(oHoja.Cells[Fila, 4].Value.ToString().Trim()),
                                                    oPlanCuenta, oHoja.Cells[Fila, 1].Value.ToString().Trim(),
                                                    oHoja.Cells[Fila, 2].Value.ToString().Trim());
                                }
                            }

                            Fila++;
                        }
                        
                        //Salimos del bucle for para que no siga buscando incidencias...
                        break;
                    }
                }
            }
        }

        void OtroFormato()
        {
            dgvPlantilla.Columns[0].Width = 65; //Cuenta
            dgvPlantilla.Columns[1].Width = 200; //Descripción de la cuenta
            dgvPlantilla.Columns[2].Width = 45; //Indica Debe/Haber
            dgvPlantilla.Columns[3].Width = 60; //C Costos
            dgvPlantilla.Columns[4].Width = 75; //Importe
            dgvPlantilla.Columns[5].Width = 80; //Nro de Documento de identidad
            dgvPlantilla.Columns[6].Width = 250; //Razón Social
            dgvPlantilla.Columns[7].Width = 140; //Tipo de documento
            dgvPlantilla.Columns[8].Width = 50; //Serie
            dgvPlantilla.Columns[9].Width = 65; //Numero de documento
            dgvPlantilla.Columns[10].Width = 55; //Compras y ventas
            dgvPlantilla.Columns[11].Width = 90; //Usuario registro

            foreach (DataGridViewRow Fila in dgvPlantilla.Rows)
            {
                Fila.Cells[7].Value = "0";

                if (((PlantillaAsientoDetE)Fila.DataBoundItem).oPlanCuentas.indSolicitaDcto == Variables.SI)
                {
                    Fila.Cells[7].ReadOnly = false;
                    Fila.Cells[8].ReadOnly = false;
                    Fila.Cells[9].ReadOnly = false;
                    Fila.Cells[7].Style.BackColor = Color.White;
                    Fila.Cells[8].Style.BackColor = Color.White;
                    Fila.Cells[9].Style.BackColor = Color.White;
                }

                if (((PlantillaAsientoDetE)Fila.DataBoundItem).oPlanCuentas.indSolicitaAnexo == Variables.SI)
                {
                    Fila.Cells[5].ReadOnly = false;
                    Fila.Cells[6].ReadOnly = false;
                    Fila.Cells[5].Style.BackColor = Color.White;
                    Fila.Cells[6].Style.BackColor = Color.White;
                }

                if (((PlantillaAsientoDetE)Fila.DataBoundItem).oPlanCuentas.indSolicitaCentroCosto == Variables.SI)
                {
                    Fila.Cells[3].ReadOnly = false;
                    Fila.Cells[3].Style.BackColor = Color.White;
                }
            }
        }

        void pFormatoGrid(DataGridView oDgv, Boolean EscogerVariasFilas = false, Int32 AltoCabecera = 25, Int32 AltoFilas = 20, Boolean MostrarColorAlterno = true, float tamLetraCabecera = 8.25f, float tamLetraDetalle = 8)
        {
            // crear un estilo para las cabeceras del control
            DataGridViewCellStyle styCabecera = new DataGridViewCellStyle();
            styCabecera.BackColor = Color.SlateGray;//Color.FromArgb(72, 102, 153);
            styCabecera.ForeColor = Color.White;
            styCabecera.Alignment = DataGridViewContentAlignment.MiddleCenter;
            styCabecera.Font = new System.Drawing.Font("Tahoma", tamLetraCabecera * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            styCabecera.Padding = new Padding(5);
            oDgv.ColumnHeadersDefaultCellStyle = styCabecera;

            oDgv.RowHeadersWidth = 30;
            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = AltoCabecera;

            DataGridViewCellStyle styCabecera2 = new DataGridViewCellStyle();
            styCabecera2.BackColor = Color.SlateGray; //Color.FromArgb(72, 102, 153);
            styCabecera2.ForeColor = Color.White;
            styCabecera2.SelectionBackColor = Color.Empty;
            styCabecera2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //styCabecera2.Font = new System.Drawing.Font("Tahoma", tamLetraCabecera * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            oDgv.RowHeadersDefaultCellStyle = styCabecera2;
            oDgv.BorderStyle = BorderStyle.None;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightSteelBlue;

            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            
            // creación de estilo para el control DataGridView
            DataGridViewCellStyle styEstilo = new DataGridViewCellStyle();
            styEstilo.BackColor = Color.Silver;
            //styEstilo.ForeColor = Color.DarkViolet;
            styEstilo.Font = new System.Drawing.Font("Tahoma", tamLetraDetalle * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //styEstilo.Alignment = DataGridViewContentAlignment.TopRight;
            //styEstilo.NullValue = "Sin asignar";
            styEstilo.SelectionBackColor = Color.LightSkyBlue;
            styEstilo.SelectionForeColor = Color.White;
            //styEstilo.WrapMode = DataGridViewTriState.True;
            oDgv.DefaultCellStyle = styEstilo;

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = EscogerVariasFilas;
            
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = AltoFilas;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
        }

        String ObtenerFilCol(Int32 Inicio, Int32 Final)
        {
            Int32 Contador = Variables.Cero;

            for (int i = Inicio; i <= Final; i++)
            {
                Contador++;
            }

            return Contador.ToString();
        }

        void LimpiarTodo()
        {
            txtRuta.Text = String.Empty;
            cboPlantilla.SelectedValue = Variables.Cero;
            cboPlantilla_SelectionChangeCommitted(new Object(), new EventArgs());
            cboPlantilla.Enabled = false;
        }

        #endregion Procedimientos de Usuario

        #region Override Datagridview
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //  Si el control DataGridView no tiene el foco...
            if (!dgvPlantilla.Focused && !dgvPlantilla.IsCurrentCellInEditMode)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            ////  Si la tecla presionada es distinta de la tecla Enter
            ////  abandonamos el procedimiento.
            if ((keyData != Keys.Return))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            int iColumnIndex = dgvPlantilla.CurrentCell.ColumnIndex;
            int iRowIndex = dgvPlantilla.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (iColumnIndex == dgvPlantilla.Columns.Count - 1)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                else
                {
                    dgvPlantilla.CurrentCell = dgvPlantilla[iColumnIndex + 1, iRowIndex];
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion Override Datagridview

        #region Eventos

        private void frmGenerarAsientoPlanilla_Load(object sender, EventArgs e)
        {
            Grid = false;
            dtpFecha_ValueChanged(null, null);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void btBuscarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Excel", "Libro de Excel (*.xlsx)|*.xlsx|Libro de Excel 97-2003 (*.xls)|*.xls|Archivos XML|*.xml");

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    cboPlantilla.Enabled = true;
                    dtpFecha.Enabled = true;
                    txtGlosa.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
                else
                {
                    cboPlantilla.Enabled = false;
                    dtpFecha.Enabled = false;
                    txtGlosa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void cboPlantilla_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgvPlantilla.DataSource = null;

                if (Convert.ToInt32(cboPlantilla.SelectedValue) != Variables.Cero)
                {
                    oPlantilla = null;

                    if (((PlantillaAsientoE)cboPlantilla.SelectedItem).indExcel)
                    {
                        txtHoja.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtFilaIni.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtColIni.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtFilaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtColFin.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        btObtenerDatos.Enabled = true;

                        txtHoja.Text = ((PlantillaAsientoE)cboPlantilla.SelectedItem).Hoja.ToString();
                        txtFilaIni.Text = ((PlantillaAsientoE)cboPlantilla.SelectedItem).filInicial.ToString();
                        txtColIni.Text = ((PlantillaAsientoE)cboPlantilla.SelectedItem).colInicial.ToString();
                        txtFilaFin.Text = ((PlantillaAsientoE)cboPlantilla.SelectedItem).filFinal.ToString();
                        txtColFin.Text = ((PlantillaAsientoE)cboPlantilla.SelectedItem).colFinal.ToString();

                        txtTotFilas.Text = ObtenerFilCol(Convert.ToInt32(txtFilaIni.Text), Convert.ToInt32(txtFilaFin.Text));
                        txtTotCol.Text = ObtenerFilCol(Convert.ToInt32(txtColIni.Text), Convert.ToInt32(txtColFin.Text));
                    }

                    txtGlosa.Text = ((PlantillaAsientoE)cboPlantilla.SelectedItem).GlosaGeneral.ToString();
                    oPlantilla = AgenteContabilidad.Proxy.RecuperarPlantillaAsiento(Convert.ToInt32(cboPlantilla.SelectedValue), ((PlantillaAsientoE)cboPlantilla.SelectedItem).idEmpresa.Value);
                }
                else
                {
                    txtHoja.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtFilaIni.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtColIni.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtFilaFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtColFin.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtGlosa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    txtTotFilas.Text = String.Empty;
                    txtTotCol.Text = String.Empty;
                    btObtenerDatos.Enabled = false;

                    oPlantilla = null;
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                if (oListaPlantillas == null && oListaPlantillas.Count == Variables.Cero)
                {
                    Infraestructura.Global.MensajeFault("No hay datos para generar el voucher.");
                    return;
                }

                if (String.IsNullOrEmpty(txtGlosa.Text))
                {
                    Infraestructura.Global.MensajeFault("Debe ingresar una glosa antes de generar el voucher.");
                    return;
                }

                #endregion Validaciones

                if (dgvPlantilla.IsCurrentCellDirty)
                {
                    dgvPlantilla.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                String Mensaje = String.Empty;
                String Glosa = txtGlosa.Text.Trim();
                PlantillaAsientoE oPlantillaGrabar = new PlantillaAsientoE();
                oPlantillaGrabar = oPlantilla;
                oPlantillaGrabar.ListaPlantillas = new List<PlantillaAsientoDetE>(oListaPlantillas);

                oPlantillaGrabar.Fecha = dtpFecha.Value.Date;
                oPlantillaGrabar.Mes = txtMes.Text;
                oPlantillaGrabar.Anio = txtAnio.Text;
                oPlantillaGrabar.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oPlantillaGrabar.GlosaGeneral = Glosa.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");

                Mensaje = AgenteContabilidad.Proxy.GenerarAsientoContable(oPlantillaGrabar);
                oPlantillaGrabar = null;
                LimpiarTodo();

                MessageBox.Show("Se generó el comprobante " + Mensaje);
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void btObtenerDatos_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Infraestructura.Global.MensajeFault("Debe buscar el archivo antes de importar.");
                    btBuscarArchivo.Focus();
                    return;
                }

                if (Convert.ToInt32(cboPlantilla.SelectedValue) == Variables.Cero)
                {
                    Infraestructura.Global.MensajeFault("Debe escoger una plantilla antes de importar.");
                    cboPlantilla.Focus();
                    return;
                }

                #endregion Validaciones

                FileInfo oFi = new FileInfo(txtRuta.Text);

                if (!oFi.Exists)
                {
                    Infraestructura.Global.MensajeFault("Compruebe si existe el archivo.");
                    return;
                }

                if (((PlantillaAsientoE)cboPlantilla.SelectedItem).indExcel)
                {
                    ImportarExcel(oFi);
                }
                else
                {

                }

                btnGenerar.Enabled = true;
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            txtMes.Text = dtpFecha.Value.Date.ToString("MM");
            txtAnio.Text = dtpFecha.Value.Date.ToString("yyyy");
        }

        private void dgvPlantilla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvPlantilla_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvPlantilla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvPlantilla.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPlantilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                //Si se quiere aumentar el 0 adelante
                //while ((RowsNumber.Length < dgvPlantilla.RowCount.ToString().Length))
                //{
                //    RowsNumber = ("0" + RowsNumber);
                //}

                System.Drawing.Font oFont = new System.Drawing.Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvPlantilla.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                {
                    dgvPlantilla.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                }

                Brush ob = SystemBrushes.Window;
                e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y
                                + ((e.RowBounds.Height - size.Height) / 2)));
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void txtColFin_TextChanged(object sender, EventArgs e)
        {
            txtTotCol.Text = ObtenerFilCol(Convert.ToInt32(txtColIni.Text), Convert.ToInt32(txtColFin.Text));
        }

        #endregion Eventos

    }
}
