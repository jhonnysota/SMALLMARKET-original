using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class  CondicionE
    {

        public CondicionE()
        {
            ListaDias = new List<CondicionDiasE>();
        }
            
        [DataMember]
		public Int32 idTipCondicion { get; set; }

		[DataMember]
		public Int32 idCondicion { get; set; }

		[DataMember]
		public String desCondicion { get; set; }

		[DataMember]
		public Boolean GeneraLetra { get; set; }

		[DataMember]
		public Boolean Credito { get; set; }

		[DataMember]
		public Boolean SeCobra { get; set; }

		[DataMember]
		public Boolean ManejaUnidad { get; set; }

		[DataMember]
		public Boolean tGratuita { get; set; }

		[DataMember]
		public Boolean ConImpuesto { get; set; }

		[DataMember]
		public Boolean ncDescuentos { get; set; }

		[DataMember]
		public Boolean tFilial { get; set; }

        [DataMember]
        public Boolean indCreditoCobranza { get; set; }

        [DataMember]
        public Boolean indDias { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Detalle
        [DataMember]
        public List<CondicionDiasE> ListaDias { get; set; }
 
        [DataMember]
        public Int32 Opcion { get; set; }      

    }   
}