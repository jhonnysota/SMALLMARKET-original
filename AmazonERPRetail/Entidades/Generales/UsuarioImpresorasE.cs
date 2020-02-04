using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public partial class UsuarioImpresorasE
    {

        public UsuarioImpresorasE()
        {
            ListaCodBarras = new List<UsuarioImpresorasDetE>();
        }

        [DataMember]
		public Int32 idImpresora { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public Boolean PorDefecto { get; set; }

        [DataMember]
        public Boolean EsMatricial { get; set; }

        [DataMember]
        public Boolean ParaTicket { get; set; }
        
        [DataMember]
        public Boolean ParaBarras { get; set; }

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
        public List<UsuarioImpresorasDetE> ListaCodBarras { get; set; }

        [DataMember]
        public List<UsuarioImpresorasDetE> ListaBarrasEliminados { get; set; }

        [DataMember]
        public Int32 Correlativo { get; set; }

        [DataMember]
        public String NombreImpresora { get; set; }

        [DataMember]
        public Decimal AnchoEtiqueta { get; set; }

        [DataMember]
        public Decimal AltoEtiqueta { get; set; }

        [DataMember]
        public Int32 cantEtiqueta { get; set; }

        [DataMember]
        public Int32 Gap { get; set; }

    }   
}