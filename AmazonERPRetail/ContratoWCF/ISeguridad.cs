using System;
using System.Collections.Generic;
using System.ServiceModel;

using Infraestructura.Enumerados;
using Entidades.Seguridad;
using Entidades.Maestros;

namespace ContratoWCF
{
    [ServiceContract]
    public interface ISeguridad
    {

        #region IAccion Members

        [OperationContract]
        AccionE InsertarAccion(AccionE accion);

        [OperationContract]
        AccionE ActualizarAccion(AccionE accion);

        [OperationContract]
        List<AccionE> ListarAccion(String Filtro);

        [OperationContract]
        Int32 BorrarAccion(Int32 IdAccion);

        [OperationContract]
        AccionE ObtenerAccion(Int32 IdAccion);

        [OperationContract]
        List<AccionE> ListarAccionesCrud();

        #endregion

        #region IOpcion Members

        [OperationContract]
        Opcion InsertarOpcion(Opcion opcion);

        [OperationContract]
        Opcion ActualizarOpcion(Opcion opcion);

        [OperationContract]
        List<Opcion> ListarOpcion(String value);

        [OperationContract]
        List<Opcion> ListarOpcionRol(Int32 idRol);

        [OperationContract]
        Int32 BorrarOpcion(Int32 IdOpcion);

        [OperationContract]
        Opcion RecuperarOpcionPorCodigo(Int32 IdOpcion);

        [OperationContract]
        List<Opcion> RecuperarOpcionTotal();

        //[OperationContract]
        //List<Opcion> RecuperarOpcionPorUsuarioEmpresa(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        List<Opcion> ListarOpcionesParaRol(String Filtro);

        [OperationContract]
        List<Opcion> ListarOpcionesPadre(Int32 idEmpresa, Int32 idUsuario);

        #endregion

        #region IRol Members

        [OperationContract]
        Rol InsertarRol(Rol rol);

        [OperationContract]
        Rol ActualizarRol(Rol rol);

        [OperationContract]
        List<Rol> ListarRol(String cod, Boolean activo, Boolean inactivo);

        [OperationContract]
        List<Rol> ListarRolUsuario(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        Int32 AnularRolPorCodigo(Int32 IdRol);

        [OperationContract]
        Rol RecuperarRolPorCodigo(Int32 IdRol);

        [OperationContract]
        Rol CambiarEstadoRol(Int32 IdRol, Boolean estado);

        [OperationContract]
        List<Rol> RecuperarRolOpcion(String cod, bool activo, bool inactivo);

        #endregion

        #region IUsuarioPreferencias Members

        [OperationContract]
        UsuarioPreferenciasE InsertarUsuarioPreferencias(UsuarioPreferenciasE usuariopreferencias);

        [OperationContract]
        UsuarioPreferenciasE ActualizarUsuarioPreferencias(UsuarioPreferenciasE usuariopreferencias);

        [OperationContract]
        Int32 EliminarUsuarioPreferencias(Int32 idEmpresa, Int32 idPreferencias);

        [OperationContract]
        List<UsuarioPreferenciasE> ListarUsuarioPreferencias(Int32 idEmpresa, String NombreFormulario);

        [OperationContract]
        UsuarioPreferenciasE ObtenerUsuarioPreferencias(Int32 idEmpresa, Int32 idPreferencias);

        #endregion

        #region IRolOpcion Members

        [OperationContract]
        String InsertarRolOpcion(List<Rol> RolesOpciones, Int32 idEmpresa);

        [OperationContract]
        RolOpcion ActualizarRolOpcion(RolOpcion rolopcion);

        [OperationContract]
        List<RolOpcion> ListarRolOpcion(Int32 IdRol);

        [OperationContract]
        Int32 AnularRolOpcionPorCodigo(Int32 IdRol);

        [OperationContract]
        RolOpcion RecuperarRolOpcionPorCodigo(Int32 IdRol, Int32 IdOpcion, Int32 IdEmpresa);

        [OperationContract]
        string GrabarRolOpcion(Rol oRolOpcion);

        #endregion

        #region IUsuarioAccion Members JOSE SALAZAR

        [OperationContract]
        String GrabarUsuarioAccion(List<UsuarioAccionE> ListaUsuariosAcciones, EnumOpcionGrabar Opcion);

        [OperationContract]
        String InsertarUsuarioAccion(Usuario usuario, Int32 idEmpresa);

        [OperationContract]
        List<UsuarioAccionE> ListarUsuarioAccion(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        Int32 BorrarUsuarioAccion(Int32 idPersona, Int32 idEmpresa, Int32 idOpcion);

        [OperationContract]
        List<UsuarioAccionE> ObtenerUsuarioAccion(Int32 idPersona, Int32 idEmpresa, Int32 idOpcion);
        
        #endregion

        #region IUsuario Members

        [OperationContract]
        Usuario GrabarUsuario(Usuario oUsuario, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        Usuario InsertarUsuario(Usuario usuario);

        [OperationContract]
        Usuario ActualizarUsuario(Usuario usuario);

        [OperationContract]
        List<Usuario> ListarUsuario(String filtro, Boolean activo, Boolean inactivo);

        [OperationContract]
        List<Usuario> ListarUsuarioTodos(String filtro, Int32? tipoPersona, Boolean activo, Boolean inactivo);

        [OperationContract]
        Int32 AnularUsuarioPorCodigo(Int32 IdPersona);

        [OperationContract]
        Usuario RecuperarUsuarioPorCodigo(Int32 IdPersona, Int32 idEmpresa, String BuscarOtros = "N");

        [OperationContract]
        Usuario CambiarEstadoUsuario(Int32 IdPersona, Boolean estado);

        [OperationContract]
        Usuario ValidarUsuario(String Credencial, Byte[] Clave);

        [OperationContract]
        Usuario ValidarUsuarioEmpresa(Usuario u, Int32 IdEmpresa, Int32 IdLocal);

        [OperationContract]
        List<Opcion> RecuperaOpcionesUsuarioEmpresa(Int32 IdPersona, Int32 idEmpresa);

        [OperationContract]
        Boolean ModificarClave(String Credencial, Byte[] Clave, Boolean reset);

        [OperationContract]
        Usuario RecuperarUsuarioAcccion(String Credencial, Byte[] Clave, Int32 IdEmpresa, Int32 IdAccion);

        [OperationContract]
        List<Usuario> ListarUsuarioPorEmpresa(Int32 IdEmpresa, Int32 IdLocal, String filtro, String activo);

        [OperationContract]
        List<Usuario> ListarUsuarioPorEmpresayArea(Int32 IdEmpresa, Int32 IdLocal, String filtro, String activo);

        [OperationContract]
        List<Usuario> ListarUsuarioEmpresa(Int32 IdEmpresa, String filtro, String activo);

        [OperationContract]
        Byte[] ObtenerClaveUsuario(Int32 idPersona);

        [OperationContract]
        List<Usuario> ListarUsuariosActivos();

        #endregion

        #region IUsuarioRol Members
        [OperationContract]
        String InsertarUsuarioRol(List<Usuario> usuariorol, Int32 idEmpresa);
        [OperationContract]
        UsuarioRol ActualizarUsuarioRol(UsuarioRol usuariorol);
        [OperationContract]
        List<UsuarioRol> ListarUsuarioRol();
        [OperationContract]
        Int32 AnularUsuarioRolPorCodigo(Int32 IdEmpresa, Int32 IdPersona);
        [OperationContract]
        UsuarioRol RecuperarUsuarioRolPorCodigo(Int32 IdPersona, Int32 IdRol, Int32 IdEmpresa);
        #endregion

        #region IUsuarioEmpresaLocal Members

        [OperationContract]
        Usuario InsertarUsuarioEmpresaLocal(Usuario usuario);

        [OperationContract]
        List<UsuarioEmpresaLocal> ListarUsuarioEmpresaLocalPorUsuario(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        List<Usuario> ListarUsuariosLocalEmpresa(List<Empresa> ListaEmpresas);

        [OperationContract]
        List<UsuarioEmpresaLocal> RecuperarUsuarioEmpresaLocalPorEmpresa(Int32 idEmpresa); //JOSE SALAZAR

        #endregion

        #region IPerfil
        //PARA LISTAR
        [OperationContract]
        List<Perfil> ListarPerfil(String parametro);

        //PARA REGISTRAR
        [OperationContract]
        Perfil InsertarPerfil(Perfil perfil);

        //PARA ACTUALIZAR
        [OperationContract]
        Perfil ActualizarPerfil(Perfil perfil);

        //PARA ELIMINAR
        [OperationContract]
        Int32 EliminarPerfil(Int32 IdPerfil);
        #endregion

        #region IUsuarioEmpresaLocalPerfil Members
        [OperationContract]
        List<UsuarioEmpresaLocalPerfil> ListaUsuarioEmpresaLocalPerfilPorUsuario(Int32 idPersona, Int32 idEmpresa, Int32 idLocal);
        [OperationContract]
        Usuario GrabarUsuarioEmpresaLocalPerfil(Usuario vUsuario);
        [OperationContract]
        UsuarioEmpresaLocalPerfil RecuperarUsuarioEmpresaLocalPerfil(Int32 idEmpresa, Int32 idLocal, Int32 idPerfil);
        [OperationContract]
        Persona GrabarPersonaEmpresaLocalPerfil(Persona vPersona);

        [OperationContract]
        List<UsuarioEmpresaLocalPerfil> ListarUsuarioEmpresaLocalPerfil(Int32 IdEmpresa, Int32 IdLocal);

        [OperationContract]
        List<UsuarioEmpresaLocalPerfil> Listar_UsuarioEmpresaLocalPerfil(Int32 IdEmpresa, Int32 IdLocal, Int32 IdPerfil, String Parametro, Boolean ValidaPerfil, Boolean Estado);
        #endregion

        #region IUsuarioCCostos Members JOSE SALAZAR Quispe

        [OperationContract]
        UsuarioCCostosE InsertarUsuarioCCostos(UsuarioCCostosE usuarioccostos);

        [OperationContract]
        UsuarioCCostosE ActualizarUsuarioCCostos(UsuarioCCostosE usuarioccostos);

        [OperationContract]
        Int32 EliminarUsuarioCCostos(Int32 idPersona);

        [OperationContract]
        List<UsuarioCCostosE> ListarUsuarioCCostos(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        UsuarioCCostosE ObtenerUsuarioCCostos(Int32 idPersona, Int32 idCCostos);

        #endregion     

        #region IClonacionTablas JOSE SALAZAR

        [OperationContract]
        ClonacionTablasE InsertarClonacionTablas(ClonacionTablasE clonaciontablas);

        [OperationContract]
        ClonacionTablasE ActualizarClonacionTablas(ClonacionTablasE clonaciontablas);

        [OperationContract]
        Int32 EliminarClonacionTablas(Int32 idTabla);

        [OperationContract]
        List<ClonacionTablasE> ListarClonacionTablas();

        [OperationContract]
        ClonacionTablasE ObtenerClonacionTablas(Int32 idTabla);

        [OperationContract]
        Int32 GrabarVarios(List<ClonacionTablasE> oListaTablas);

        [OperationContract]
        List<ClonacionTablasE> ListarTablasPorSistema(Int32 idSistema);

        [OperationContract]
        List<ClonacionTablasE> ListarTablasTransferidas(Int32 idEmpresaTrans, Boolean Transferido);

        [OperationContract]
        Int32 ClonarTablas(List<ClonacionTablasE> oListaTablasPorTransferir);

        [OperationContract]
        Int32 EliminarTablasTransferidas(Int32 idEmpresaTrans, String Tabla);


        #endregion

        #region IUsuarioPlanilla Members JOSE SALAZAR

        [OperationContract]
        UsuarioPlanillaE InsertarUsuarioPlanilla(UsuarioPlanillaE usuarioplanilla);

        [OperationContract]
        UsuarioPlanillaE ActualizarUsuarioPlanilla(UsuarioPlanillaE usuarioplanilla);

        [OperationContract]
        int EliminarUsuarioPlanilla(Int32 idPersona, String idPlanillas, Int32 idEmpresa);

        [OperationContract]
        List<UsuarioPlanillaE> ListarUsuarioPlanilla(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        UsuarioPlanillaE ObtenerUsuarioPlanilla(Int32 idPersona, String idPlanillas, Int32 idEmpresa);

        #endregion 

        #region IAsignarTipoCobranza Members JOSE SALAZAR

        [OperationContract]
        AsignarTipoCobranzaE InsertarAsignarTipoCobranza(AsignarTipoCobranzaE asignartipocobranza);

        [OperationContract]
        AsignarTipoCobranzaE ActualizarAsignarTipoCobranza(AsignarTipoCobranzaE asignartipocobranza);

        [OperationContract]
        int EliminarAsignarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, Int32 idTipoPlanilla);

        [OperationContract]
        AsignarTipoCobranzaE ObtenerAsignarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, Int32 idTipoPlanilla);

        [OperationContract]
        List<Usuario> ListarTipoCobranzaPorUsuario();

        [OperationContract]
        List<AsignarTipoCobranzaE> ListarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario);

        #endregion

        #region IUsuarioSeries Members JOSE SALAZAR

        [OperationContract]
        UsuarioSeriesE InsertarUsuarioSeries(UsuarioSeriesE usuarioseries);

        [OperationContract]
        UsuarioSeriesE ActualizarUsuarioSeries(UsuarioSeriesE usuarioseries);

        [OperationContract]
        int EliminarUsuarioSeries(Int32 idEmpresa, Int32 idUsuario);

        [OperationContract]
        List<UsuarioSeriesE> ListarUsuarioSeries(Int32 idEmpresa, Int32 idUsuario);

        [OperationContract]
        UsuarioSeriesE ObtenerUsuarioSeries(Int32 idEmpresa, Int32 idUsuario, String idDocumento, String numSerie);

        [OperationContract]
        List<UsuarioSeriesE> ListarUsuarioSeriesPtoVta(Int32 idEmpresa, Int32 idUsuario);

        #endregion

        #region IUsuarioPuntoReque Members JOSE SALAZAR

        [OperationContract]
        UsuarioPuntoRequeE InsertarUsuarioPuntoReque(UsuarioPuntoRequeE usuariopuntoreque);

        [OperationContract]
        UsuarioPuntoRequeE ActualizarUsuarioPuntoReque(UsuarioPuntoRequeE usuariopuntoreque);

        [OperationContract]
        int EliminarUsuarioPuntoReque(Int32 idUsuario);

        [OperationContract]
        List<UsuarioPuntoRequeE> ListarUsuarioPuntoReque(Int32 idUsuario);

        [OperationContract]
        UsuarioPuntoRequeE ObtenerUsuarioPuntoReque(Int32 idUsuario, Int32 idPuntoReq);

        #endregion

        #region IUsuarioAreas Members JOSE SALAZAR

        [OperationContract]
        Usuario GrabarUsuarioArea(Usuario oUsuario);

        [OperationContract]
        UsuarioAreasE InsertarUsuarioAreas(UsuarioAreasE usuarioareas);

        [OperationContract]
        UsuarioAreasE ActualizarUsuarioAreas(UsuarioAreasE usuarioareas);

        [OperationContract]
        int EliminarUsuarioAreas(Int32 idPersona);

        [OperationContract]
        List<UsuarioAreasE> ListarUsuarioAreas();

        [OperationContract]
        UsuarioAreasE ObtenerUsuarioAreas(Int32 idPersona);

        #endregion

        #region IUsuarioAlmacen Members JOSE SALAZAR

        [OperationContract]
        UsuarioAlmacenE InsertarUsuarioAlmacen(UsuarioAlmacenE usuarioalmacen);

        [OperationContract]
        UsuarioAlmacenE ActualizarUsuarioAlmacen(UsuarioAlmacenE usuarioalmacen);

        [OperationContract]
        int EliminarUsuarioAlmacen(Int32 idPersona, Int32 idAlmacen, Int32 idEmpresa);

        [OperationContract]
        List<UsuarioAlmacenE> ListarUsuarioAlmacen(Int32 idPersona, Int32 idEmpresa);

        [OperationContract]
        UsuarioAlmacenE ObtenerUsuarioAlmacen(Int32 idPersona, Int32 idAlmacen, Int32 idEmpresa);

        #endregion 

        #region IUsuarioFondoFijo Members JOSE SALAZAR

        [OperationContract]
        UsuarioFondoFijoE InsertarUsuarioFondoFijo(UsuarioFondoFijoE fondofijo);

        [OperationContract]
        UsuarioFondoFijoE ActualizarUsuarioFondoFijo(UsuarioFondoFijoE fondofijo);

        [OperationContract]
        int EliminarUsuarioFondoFijo(Int32 idEmpresa, Int32 idPersona, Int32 TipoFondo);

        [OperationContract]
        List<UsuarioFondoFijoE> ListarUsuarioFondoFijo(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        List<Usuario> ListarFondosFijosPorUsuario();

        #endregion

    }
}
