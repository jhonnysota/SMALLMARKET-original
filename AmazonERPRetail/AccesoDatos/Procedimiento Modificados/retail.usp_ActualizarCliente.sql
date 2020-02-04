
if OBJECT_ID('[retail].[usp_ActualizarCliente]') is null    
        drop procedure [retail].[usp_ActualizarCliente]
go

create procedure [retail].[usp_ActualizarCliente]  
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
 @UsuarioModificacion varchar(20)  
as  
begin  
  
    update retail.Cliente  
        SET SiglaComercial = @SiglaComercial,  
   TipoCliente = @TipoCliente,  
   fecInscripcion = @fecInscripcion,  
   fecInicioEmpresa = @fecInicioEmpresa,  
   tipConstitucion = @tipConstitucion, 
   idMoneda=@idMoneda,
   tipRegimen = @tipRegimen,  
   catCliente = @catCliente,  
   indEstado = @indEstado,  
   fecBaja = @fecBaja,  
   indVinculada = @indVinculada,  
   UsuarioModificacion = @UsuarioModificacion,  
   FechaModificacion = getdate()  
    where idPersona = @idPersona  
 and idEmpresa = @idEmpresa  
   
end  