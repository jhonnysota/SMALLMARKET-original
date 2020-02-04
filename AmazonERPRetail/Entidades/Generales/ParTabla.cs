using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class ParTabla
    {

        public ParTabla() 
        {                  
            Descripcion = "";                 
            EquivalenciaSunat = "";             
        }

        #region Entidad

        [DataMember]
        public Int32 IdParTabla { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String NemoTecnico { get; set; }

        [DataMember]
        public Int32 Grupo { get; set; }

        [DataMember]
        public Boolean EsEditable { get; set; }

        [DataMember]
        public String EquivalenciaSunat { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public String ValorCadena { get; set; }

        [DataMember]
        public Int32 ValorEntero { get; set; }

        [DataMember]
        public Boolean FlagCorrelativo { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }
        
        #endregion

        #region Extensiones

		[DataMember]
		public Decimal ValorDecimal { get; set; }

        [DataMember]
        public Boolean CkeckAgregar { get; set; }

        [DataMember]
        public String desTemporal { get; set; }

        [DataMember]
        public String NemoTemp { get; set; }

        #endregion

    }
}
