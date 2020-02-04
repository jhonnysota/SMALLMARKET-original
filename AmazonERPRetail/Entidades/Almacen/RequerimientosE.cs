using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class RequerimientosE
    {
            
        public RequerimientosE()
        {
            ListaRequerimientosItems = new List<RequerimientosItemE>();
        }

        [DataMember]
		public Int32 idRequerimiento { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public Int32? tipArticulo { get; set; }

		[DataMember]
		public String numRequeri { get; set; }

		[DataMember]
		public DateTime fecRequeri { get; set; }

		[DataMember]
		public Int32? idAlmacen { get; set; }

		[DataMember]
		public Int32 idPuntoReq { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String Glosa { get; set; }

		[DataMember]
		public Boolean indIngAlmacen { get; set; }

		[DataMember]
		public String DocumentoRef { get; set; }

		[DataMember]
		public String indEstado { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public List<RequerimientosItemE> ListaRequerimientosItems { get; set; }

        [DataMember]
        public String numRequeri2 { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

    }   
}