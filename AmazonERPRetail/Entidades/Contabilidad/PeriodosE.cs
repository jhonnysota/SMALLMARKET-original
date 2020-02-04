using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class PeriodosE
    {            
        [DataMember]  
		public int idEmpresa { get; set; }

		[DataMember]  
		public string AnioPeriodo { get; set; }

		[DataMember]  
		public string MesPeriodo { get; set; }

		[DataMember]
		public string desPeriodo { get; set; }

		[DataMember]
		public DateTime? fecInicio { get; set; }

		[DataMember]  
		public DateTime? fecFinal { get; set; }

		[DataMember]
        public Boolean indCierre { get; set; }

		[DataMember]
        public Boolean indApertura { get; set; }

		[DataMember]
        public Boolean indReapertura { get; set; }

		[DataMember]
        public Boolean indAjusteDifCambio { get; set; }

		[DataMember]
        public Boolean indAaFinMes { get; set; }

		[DataMember]
        public Boolean indEfectivoAsientos { get; set; }

		[DataMember]
        public Boolean indAjustePorDocFinMes { get; set; }

		[DataMember]
        public Boolean indEfectivoAjusteFinMes { get; set; }  
		
        [DataMember]  
		public string UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime? FechaRegistro { get; set; }  
		
        [DataMember]  
		public string UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Decimal TCCompra { get; set; }

        [DataMember]
        public Decimal TCVenta { get; set; }

        //OTROS CAMPOS

        [DataMember]
        public Int32 Opcion { get; set; } //Para saber si la fila del detalle se inserta o se actualiza

        [DataMember]
        public List<PeriodosE> ListaPeriodos { get; set; }

        //Detalle
        [DataMember]
        public List<CierreAlmacenE> ListaCierreAlmacen { get; set; }

        [DataMember]
        public List<CierreSistemaE> ListaCierreSistema { get; set; }

    }   
}