using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class PeriodosAlmE
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
		public string fecInicio { get; set; }

		[DataMember]  
		public string fecFinal { get; set; }

		[DataMember]
        public Boolean indCierre { get; set; }

		[DataMember]
        public Boolean indApertura { get; set; }

		[DataMember]
        public Boolean indReapertura { get; set; }

        [DataMember]
        public Decimal TCCompra { get; set; }

        [DataMember]
        public Decimal TCVenta { get; set; }
        [DataMember]  
		public string UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime FechaRegistro { get; set; }  
		
        [DataMember]  
		public string UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime FechaModificacion { get; set; }

        //OTROS CAMPOS
        [DataMember]
        public Int32 Opcion { get; set; } //Para saber si la fila del detalle se inserta o se actualiza
		
    }   
}