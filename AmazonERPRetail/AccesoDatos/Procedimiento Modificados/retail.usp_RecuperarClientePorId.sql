exec sp_helptext 'retail.usp_RecuperarClientePorId'

-- exec usp_RecuperarClientePorId 907, 1  
create procedure [retail].[usp_RecuperarClientePorId]  
  @idPersona int,  
 @idEmpresa int  
as  
begin  
   
    select cli.idPersona, cli.idEmpresa,cli.idMoneda ,cli.SiglaComercial, cli.TipoCliente, cli.fecInscripcion, cli.fecInicioEmpresa, cli.tipConstitucion, cli.tipRegimen, cli.catCliente,   
   per.idCanalVenta, cli.indEstado, cli.fecBaja, cli.UsuarioRegistro, cli.FechaRegistro, cli.UsuarioModificacion, cli.FechaModificacion, per.RUC, per.RazonSocial, isnull(cli.indVinculada, 0) 'indVinculada',  
   coalesce(per.DireccionCompleta + ' ' + u.Departamento + '-' + u.Provincia + '-' + u.Distrito, per.DireccionCompleta) 'DireccionCompleta'  
    from retail.Cliente cli  
 inner join retail.Persona per  
  on per.IdPersona = cli.IdPersona  
  and cli.IdEmpresa = @idEmpresa  
 left join retail.UbigeoSunat u  
  on u.idUbigeo = per.idUbigeo  
    where cli.idPersona = @idPersona  
 and cli.idEmpresa = @idEmpresa  
end  