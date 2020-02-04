
CREATE procedure [retail].[usp_InsertarCliente]    
 @idPersona int,     
 @idEmpresa int,     
 @SiglaComercial varchar(50),     
 @TipoCliente int,     
 @fecInscripcion smalldatetime = null,     
 @fecInicioEmpresa smalldatetime = null,     
 @tipConstitucion int = null,     
 @tipRegimen int = null,     
 @catCliente int = null,      
 @indEstado bit,    
 @idMoneda char(2),  
 @indVinculada bit,    
 @fecBaja smalldatetime = null,     
 @UsuarioRegistro varchar(20)    
as    
begin    
     
    insert into retail.Cliente    
    (    
        idPersona, idEmpresa, SiglaComercial, idMoneda,TipoCliente, fecInscripcion, fecInicioEmpresa, tipConstitucion, tipRegimen, catCliente,     
  indEstado, fecBaja,indVinculada, UsuarioRegistro, FechaRegistro, UsuarioModificacion, FechaModificacion    
    )    
    values    
    (    
        @idPersona, @idEmpresa, @SiglaComercial,@idMoneda ,@TipoCliente, @fecInscripcion, @fecInicioEmpresa, @tipConstitucion, @tipRegimen, @catCliente,     
  @indEstado, @fecBaja,@indVinculada, @UsuarioRegistro, getdate(), @UsuarioRegistro, getdate()    
    )       
end    