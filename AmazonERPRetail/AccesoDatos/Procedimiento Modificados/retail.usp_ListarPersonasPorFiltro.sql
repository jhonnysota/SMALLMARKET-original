  -- exec retail.usp_ListarPersonasPorFiltro 4, 'RU', '20'  
alter procedure [retail].[usp_ListarPersonasPorFiltro]  
 @idEmpresa int,  
 @Tipo char(2),  
 @Filtro nvarchar(50)  
as  
  
if @Tipo = 'RU' --Por RUC  
 begin  
  select per.IdPersona,   
    per.RazonSocial,   
    per.RUC, 
	cli.idMoneda,
    coalesce(per.DireccionCompleta + ' ' + u.Departamento + '-' + u.Provincia + '-' + u.Distrito, per.DireccionCompleta) 'DireccionCompleta',  
    Cli = isnull((select (case when c.idPersona is not null then 1 else 0 end) from retail.Cliente c  
       where c.idEmpresa = @idEmpresa  
       and c.idPersona = per.IdPersona), 0),  
    Pro = isnull((select (case when p.idPersona is not null then 1 else 0 end) from retail.Proveedor p  
       where p.idEmpresa = @idEmpresa  
       and p.idPersona = per.IdPersona), 0),  
    Tra = isnull((select (case when t.idPersona is not null then 1 else 0 end) from retail.Trabajador t  
       where t.idEmpresa = @idEmpresa  
       and t.idPersona = per.IdPersona), 0),  
    Ban = isnull((select (case when b.idPersona is not null then 1 else 0 end) from retail.Bancos b  
       where b.idEmpresa = @idEmpresa  
       and b.idPersona = per.IdPersona), 0),  
    idCanalVenta = isnull(per.idCanalVenta, 0),  
    (select p.Nemotecnico from retail.ParTabla p  
    where p.IdParTabla = per.TipoPersona) 'NemoTipPer',  
    per.PrincipalContribuyente,   
    per.AgenteRetenedor,  
    (select Nombre from retail.Paises c  
    where c.idPais = per.idPais) 'desPais',  
    (select Departamento from retail.UbigeoSunat c  
    where c.idUbigeo = per.idUbigeo) 'desDep',  
    (select Distrito from retail.UbigeoSunat c  
    where c.idUbigeo = per.idUbigeo) 'desDis',  
    (select Provincia from retail.UbigeoSunat c  
    where c.idUbigeo = per.idUbigeo) 'desPro'  
  from retail.Persona per  
  left join retail.UbigeoSunat u  
   on u.idUbigeo = per.idUbigeo  

      inner join retail.Cliente cli
   on cli.idPersona= per.IdPersona

  where per.RUC like @Filtro + '%'  
 end  
else if @Tipo = 'RA' -- Por Razón Social  
 begin  
  select per.IdPersona,   
    per.RazonSocial,   
    per.RUC, 
	cli.idMoneda,
    coalesce(per.DireccionCompleta + ' ' + u.Departamento + '-' + u.Provincia + '-' + u.Distrito, per.DireccionCompleta) 'DireccionCompleta',  
    Cli = isnull((select (case when c.idPersona is not null then 1 else 0 end) from retail.Cliente c  
       where c.idEmpresa = @idEmpresa  
       and c.idPersona = per.IdPersona), 0),  
    Pro = isnull((select (case when p.idPersona is not null then 1 else 0 end) from retail.Proveedor p  
       where p.idEmpresa = @idEmpresa  
       and p.idPersona = per.IdPersona), 0),  
    Tra = isnull((select (case when t.idPersona is not null then 1 else 0 end) from retail.Trabajador t  
       where t.idEmpresa = @idEmpresa  
       and t.idPersona = per.IdPersona), 0),  
    Ban = isnull((select (case when b.idPersona is not null then 1 else 0 end) from retail.Bancos b  
       where b.idEmpresa = @idEmpresa  
       and b.idPersona = per.IdPersona), 0),  
    idCanalVenta = isnull(per.idCanalVenta, 0),  
    (select p.Nemotecnico from retail.ParTabla p  
    where p.IdParTabla = per.TipoPersona) 'NemoTipPer',  
    per.PrincipalContribuyente,   
    per.AgenteRetenedor,  
    (select Nombre from retail.Paises c  
   where c.idPais = per.idPais) 'desPais',  
   (select Departamento from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'desDep',  
   (select Distrito from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'desDis',  
   (select Provincia from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'desPro'  
  from retail.Persona per  
  left join retail.UbigeoSunat u  
   on u.idUbigeo = per.idUbigeo  
   inner join retail.Cliente cli
   on cli.idPersona= per.IdPersona
  where per.RazonSocial like '%' + @Filtro + '%'  
 end  
else  
 begin -- Por id Persona  
  select per.IdPersona,   
    per.RazonSocial,   
    per.RUC,  
	cli.idMoneda,
    coalesce(per.DireccionCompleta + ' ' + u.Departamento + '-' + u.Provincia + '-' + u.Distrito, per.DireccionCompleta) 'DireccionCompleta',  
    Cli = isnull((select (case when c.idPersona is not null then 1 else 0 end) from retail.Cliente c  
       where c.idEmpresa = @idEmpresa  
       and c.idPersona = per.IdPersona), 0),  
    Pro = isnull((select (case when p.idPersona is not null then 1 else 0 end) from retail.Proveedor p  
       where p.idEmpresa = @idEmpresa  
       and p.idPersona = per.IdPersona), 0),  
    Tra = isnull((select (case when t.idPersona is not null then 1 else 0 end) from retail.Trabajador t  
       where t.idEmpresa = @idEmpresa  
       and t.idPersona = per.IdPersona), 0),  
    Ban = isnull((select (case when b.idPersona is not null then 1 else 0 end) from retail.Bancos b  
       where b.idEmpresa = @idEmpresa  
       and b.idPersona = per.IdPersona), 0),  
    idCanalVenta = isnull(per.idCanalVenta, 0),  
    (select p.Nemotecnico from retail.ParTabla p  
    where p.IdParTabla = per.TipoPersona) 'NemoTipPer',  
    per.PrincipalContribuyente,   
    per.AgenteRetenedor,  
    (select Nombre from retail.Paises c  
   where c.idPais = per.idPais) 'desPais',  
   (select Departamento from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'desDep',  
   (select Distrito from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'desDis',  
   (select Provincia from retail.UbigeoSunat c  
   where c.idUbigeo = per.idUbigeo) 'desPro'  ,


  from retail.Persona per  
  left join retail.UbigeoSunat u  
   on u.idUbigeo = per.idUbigeo 
   
      inner join retail.Cliente cli
   on cli.idPersona= per.IdPersona
  where per.IdPersona = CONVERT(int, @Filtro)  
 end  