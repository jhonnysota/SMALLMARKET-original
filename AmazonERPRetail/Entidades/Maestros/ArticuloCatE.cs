using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class ArticuloCatE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public String CodCategoria { get; set; }

        [DataMember]
        public String nombre_categoria { get; set; }

        [DataMember]
        public Int32 numNivel { get; set; }

        [DataMember]
        public String CodCategoriaSup { get; set; }

        [DataMember]
        public bool indCuenta { get; set; }

        [DataMember]
        public string numVerPlanCuentas { get; set; }

        [DataMember]
        public string codCuentaAdm { get; set; }

        [DataMember]
        public string codCuentaVta { get; set; }

        [DataMember]
        public string codCuentaPro { get; set; }

        [DataMember]
        public string codCuentaConsumo { get; set; }

        [DataMember]
        public string codCuentaVenta { get; set; }

        [DataMember]
        public string codCuentaVenta12 { get; set; }

        [DataMember]
        public string codCuentaCompra { get; set; }

        [DataMember]
        public string codCuentaPorRecibir { get; set; }

        [DataMember]
        public String indUltimoNivel { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime fechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime fechaModificacion { get; set; }

        [DataMember]
        public Int32? idTipoArticuloAsoc { get; set; }

        [DataMember]
        public String codCategoriaAsoc { get; set; }

        //Extensiones
        [DataMember]
        public String CodCategoriaAnte { get; set; }

        [DataMember]
        public string desCuenta { get; set; }

        [DataMember]
        public string desCuenta2 { get; set; }

        [DataMember]
        public string desCuenta3 { get; set; }

        [DataMember]
        public string desCuenta4 { get; set; }

        [DataMember]
        public string desCuenta5 { get; set; }

        [DataMember]
        public string desCuenta6 { get; set; }

        [DataMember]
        public string desCuenta7 { get; set; }

        [DataMember]
        public string TipoAlmacen { get; set; }

        [DataMember]
        public string desCuenta12 { get; set; }

        //
        [DataMember]
        public string desCategoria1 { get; set; }
        [DataMember]
        public string desCategoria2 { get; set; }


    }
}
