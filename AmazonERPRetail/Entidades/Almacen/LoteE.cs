using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class LoteE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 tipMovimiento { get; set; }

		[DataMember]
		public Int32 idDocumentoAlmacen { get; set; }

        [DataMember]
        public Boolean indfecProceso { get; set; }

        [DataMember]
        public DateTime fecProceso { get; set; }

        [DataMember]
        public Boolean indPersona { get; set; }

        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
		public String Lote { get; set; }

		[DataMember]
		public String LoteProveedor { get; set; }

		[DataMember]
		public Int32? idPaisOrigen { get; set; }

		[DataMember]
		public Int32? idPaisProcedencia { get; set; }

		[DataMember]
		public String Batch { get; set; }

		[DataMember]
		public Decimal? PorcentajeGerminacion { get; set; }

		[DataMember]
		public DateTime? fecPrueba { get; set; }

        [DataMember]
        public Decimal? PesoUnitario { get; set; }

        [DataMember]
        public String nomComercial { get; set; }

        [DataMember]
        public Int32 codColor { get; set; }

        [DataMember]
        public String HibOp { get; set; }

        [DataMember]
        public String Otros { get; set; }

        [DataMember]
        public String CaCm { get; set; }

        [DataMember]
        public String Patron { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public String EntregadoPor { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
		[DataMember]
        public int Opcion { get; set; }

        [DataMember]
        public String ruc { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String LoteAlmacen { get; set; }

        [DataMember]
        public String DesPaisOrigen { get; set; }

        [DataMember]
        public String DesPaisProcedencia { get; set; }

        [DataMember]
        public String DesColor { get; set; }

        [DataMember]
        public String SiglaLoteAlmacen { get; set; }

    }   
}