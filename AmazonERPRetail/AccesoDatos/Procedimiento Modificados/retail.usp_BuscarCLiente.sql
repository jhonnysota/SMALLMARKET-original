exec sp_helptext 'retail.usp_BuscarClientes'

-- exec usp_BuscarClientes 1, '', '', 104001  
create PROCEDURE [retail].[usp_BuscarClientes]  
 @idEmpresa int,  
 @RazonSocial nvarchar(100),  
 @NroDocumento nvarchar(25),  
 @TipoCliente int  
AS  
BEGIN  
        
    SELECT cli.IdEmpresa,   
   cli.IdPersona,   
   cli.indVinculada,
   cli.idMoneda,
   per.RazonSocial,   
   per.RUC 'RUC', ---, per.TipoDocumento, per.NroDocumento  
   coalesce(per.DireccionCompleta + ' ' + u.Departamento + '-' + u.Provincia + '-' + u.Distrito, per.DireccionCompleta) 'DireccionCompleta',  
   cli.indEstado,  
   cli.TipoCliente,  
   per.idCanalVenta,  
   per.AgenteRetenedor,  
    (select Nombre from retail.Paises c  
   where c.idPais = per.idPais) 'DesPaís',  
   (select Departamento from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'DesDep',  
   (select Distrito from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'DesDis',  
     (select Provincia from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'DesPro'  
    from retail.Cliente cli inner join retail.Persona per  
  on per.IdPersona = cli.IdPersona  
  left join retail.UbigeoSunat u  
 on u.idUbigeo = per.idUbigeo  
 where cli.IdEmpresa = @idEmpresa  
 and per.RazonSocial like '%' + @RazonSocial + '%'  
 and (per.NroDocumento like @NroDocumento + '%' or per.RUC like @NroDocumento + '%')  
 and (cli.TipoCliente = @TipoCliente or @TipoCliente = 0)  
 and cli.indEstado = 0  
 order by cli.IdPersona  
   
END  