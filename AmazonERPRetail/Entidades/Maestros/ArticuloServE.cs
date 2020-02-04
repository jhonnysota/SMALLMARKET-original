using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class ArticuloServE
    {
        public ArticuloServE()
        {
            ListaArticuloCaracteristica = new List<ArticuloDetalleE>();
        }

        [DataMember]
        public Int32 idEmpresa { get; set; } // Campo 0

        [DataMember]
        public Int32 idArticulo { get; set; } // Campo 1

        [DataMember]
        public Int32 idTipoArticulo { get; set; } // Campo 2

        [DataMember]
        public String codArticulo { get; set; } // Campo 3

        [DataMember]
        public String nomArticulo { get; set; } // Campo 4

        [DataMember]
        public String nomArticuloLargo { get; set; } // Campo 5

        [DataMember]
        public String nomCorto { get; set; } // Campo 6

        [DataMember]
        public String codBarra { get; set; } // Campo 7

        [DataMember]
        public Int32? codUniMedAlmacen { get; set; } // Campo 9

        [DataMember]
        public Int32? idUniMedEnvase { get; set; } // Campo 11

        [DataMember]
        public Int32? codTipoMedPresentacion { get; set; } // Campo 12

        [DataMember]
        public Int32? codUniMedPresentacion { get; set; } // Campo 13

        [DataMember]
        public Decimal Contenido { get; set; } // Campo 14

        [DataMember]
        public Decimal Capacidad { get; set; } // Campo 15

        [DataMember]
        public Decimal PesoUnitario { get; set; } // Campo 16

        [DataMember]
        public String codCategoria { get; set; } // Campo 17

        [DataMember]
        public Boolean indLineaVenta { get; set; } // Campo 18

        [DataMember]
        public String codLineaVenta { get; set; } // Campo 19

        [DataMember]
        public Boolean Combinar { get; set; } // Campo 23

        [DataMember]
        public Boolean indDetraccion { get; set; }

        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Boolean indCodSunat { get; set; }

        [DataMember]
        public String CodigoSunat { get; set; }

        [DataMember]
        public Boolean indReceta { get; set; }

        [DataMember]
        public Boolean flagActivo { get; set; }  // Campo 20

        [DataMember]
        public DateTime? fecCese { get; set; } // Campo 21

        [DataMember]  
		public String UsuarioRegistro { get; set; } // Campo 24

        [DataMember]  
		public DateTime? FechaRegistro { get; set; } // Campo 25

        [DataMember]  
		public String UsuarioModificacion { get; set; } // Campo 26

        [DataMember]  
		public DateTime? FechaModificacion { get; set; } // Campo 27

        [DataMember]
        public String RutaImagen { get; set; }

        [DataMember]
        public String NombreReal { get; set; }

        [DataMember]
        public String NombreImagen { get; set; }

        [DataMember]
        public String Extension { get; set; }

        [DataMember]
        public Byte[] Imagen { get; set; }

        [DataMember]
        public String Archivo { get; set; }

        [DataMember]
        public String RutaFisica { get; set; }

        //Detalle
        [DataMember]
        public List<ArticuloDetalleE> ListaArticuloCaracteristica { get; set; }

        //Extensiones
        //[DataMember]
        //public Boolean FlagAprobacion { get; set; }

        [DataMember]
        public String Nombre_Categoria_Principal { get; set; } //Campo 27

        [DataMember]
        public String desTipoArticulo { get; set; } // Campo 28

        [DataMember]
        public String desCategoria { get; set; } // Campo 29
        [DataMember]
        public String nomUMedida { get; set; } // Campo 31
        [DataMember]
        public String nomUMedidaPres { get; set; } // Campo 32
        [DataMember]
        public String nomUMedidaEnv { get; set; } // Campo 32
        [DataMember]
        public String desLinea { get; set; } // Campo 33
        [DataMember]
        public Int32 Cantidad { get; set; } // Campo 34
        [DataMember]
        public String Lote { get; set; } // Campo 35
        [DataMember]
        public Decimal Stock { get; set; } // Campo 36
        [DataMember]
        public String LoteProveedor { get; set; } // Campo 37
        [DataMember]
        public string numVerPlanCuentas { get; set; } // Campo 38
        [DataMember]
        public string codCuentaAdm { get; set; } // Campo 39
        [DataMember]
        public string codCuentaVta { get; set; } // Campo 40
        [DataMember]
        public string codCuentaPro { get; set; } // Campo 41

        #region Campos de Calzado

        [DataMember]
        public Int32? codColor { get; set; }

        [DataMember]
        public String desColor { get; set; }

        [DataMember]
        public Int32? codMaterial { get; set; }

        [DataMember]
        public String desMaterial { get; set; }

        [DataMember]
        public Int32? codCapellada { get; set; }

        [DataMember]
        public String desCapellada { get; set; }

        [DataMember]
        public Int32? codTaco { get; set; }

        [DataMember]
        public String desTaco { get; set; }

        [DataMember]
        public Int32? codEstilo { get; set; }

        [DataMember]
        public String desEstilo { get; set; }

        [DataMember]
        public Int32? codForro { get; set; }

        [DataMember]
        public String desForro { get; set; }

        [DataMember]
        public Int32? codPlanta { get; set; }

        [DataMember]
        public String desPlanta { get; set; }

        [DataMember]
        public Int32? codEstacion { get; set; }

        [DataMember]
        public String desEstacion { get; set; }

        [DataMember]
        public String Horma { get; set; }

        [DataMember]
        public Decimal MedAncho { get; set; }

        [DataMember]
        public Decimal MedLargo { get; set; }

        [DataMember]
        public Decimal AltPlataforma { get; set; }

        [DataMember]
        public Decimal Compartimiento { get; set; }

        [DataMember]
        public Decimal BolInterno { get; set; }

        [DataMember]
        public Decimal BolExterno { get; set; }

        [DataMember]
        public Boolean indCuero { get; set; }

        [DataMember]
        public Int32? codSerie { get; set; }

        [DataMember]
        public String desSerie { get; set; }

        [DataMember]
        public Int32? codModelo { get; set; }

        [DataMember]
        public String desModelo { get; set; }

        [DataMember]
        public Int32? codMarca { get; set; }

        [DataMember]
        public String desMarca { get; set; }

        [DataMember]
        public String SKU { get; set; }    

        #endregion

        [DataMember]
        public String Nemo { get; set; }
        [DataMember]
        public String Barras { get; set; }
        [DataMember]
        public String DescripcionGeneral { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public Boolean Escoger { get; set; } //Para escoger cual se imprime codigo de barras

        #region Para la lista de precio

        [DataMember]
        public Decimal PrecioBruto { get; set; }
        [DataMember]
        public Decimal PorDscto1 { get; set; }
        [DataMember]
        public Decimal PorDscto2 { get; set; }
        [DataMember]
        public Decimal PorDscto3 { get; set; }
        [DataMember]
        public Decimal MontoDscto1 { get; set; }
        [DataMember]
        public Decimal MontoDscto2 { get; set; }
        [DataMember]
        public Decimal MontoDscto3 { get; set; }
        [DataMember]
        public Decimal PrecioValorVenta { get; set; }
        [DataMember]
        public Boolean flgisc { get; set; }
        [DataMember]
        public String TipoImpSelectivo { get; set; }
        [DataMember]
        public Decimal porisc { get; set; }
        [DataMember]
        public Decimal isc { get; set; }
        [DataMember]
        public Boolean flgigv { get; set; }
        [DataMember]
        public Decimal porigv { get; set; }
        [DataMember]
        public Decimal igv { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal PrecioVentaConte { get; set; }
        [DataMember]
        public Decimal PrecioBrutoConte { get; set; }
        [DataMember]
        public Decimal CostoSoles { get; set; } //Para el uso en las conversiones
        [DataMember]
        public Decimal CostoDolares { get; set; } //Para el uso en las conversiones

        #endregion

        [DataMember]
        public Int32 idAlmacen { get; set; }
        [DataMember]
        public Int32 idListaPrecio { get; set; }
        [DataMember]
        public Boolean conLote { get; set; }
        [DataMember]
        public decimal StockDetalle { get; set; }
        [DataMember]
        public decimal PrecioD { get; set; }
        [DataMember]
        public decimal PorDsctoD { get; set; }
        [DataMember]
        public decimal MontoDsctoD { get; set; }
        [DataMember]
        public decimal PrecioValorVentaD { get; set; }
        [DataMember]
        public bool FlgIgvD { get; set; }
        [DataMember]
        public decimal PorIgvD { get; set; }
        [DataMember]
        public decimal IgvD { get; set; }
        [DataMember]
        public decimal PrecioVentaD { get; set; }
        [DataMember]
        public String nomTipoUMedida { get; set; }
        [DataMember]
        public String nomTipoUMedidaEnv { get; set; }


        //Extencion jhonny sota 
         [DataMember]

        public  int idArticuloComponente { get; set;}


    }
}