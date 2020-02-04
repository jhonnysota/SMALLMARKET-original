exec sp_helptext 'retail.usp_RecuperarPedidoCabNacional'
CREATE procedure retail.usp_RecuperarPedidoCabNacional      
    @idEmpresa int,       
 @idLocal int,      
 @idPedido int      
as      
begin      
 set nocount on      
      
 select ped.idEmpresa, ped.idLocal, ped.idPedido, ped.codPedidoCad,       
   convert(varchar(10), ped.FecCotizacion, 103) 'FecCotizacion',      
   convert(varchar(10), ped.FecEntrega, 103) 'FecEntrega',      
   convert(varchar(10), ped.FecPedido, 103) 'FecPedido',      
   ped.idNotificar,       
   ped.indicaciones,      
   (select RUC from retail.ClienteAsociados ca      
   where ca.IdAsociado = ped.idNotificar       
   and ca.IdPersona = ped.idNotificar) 'RucNotificador',      
      
   (select RazonSocial from retail.ClienteAsociados ca      
   where ca.IdAsociado = ped.idNotificar       
   and ca.IdPersona = ped.idNotificar) 'desNotificador',      
      
   (select ca.Direccion from retail.ClienteAsociados ca      
   where ca.IdAsociado = ped.idNotificar      
   and ca.IdPersona = ped.idNotificar) 'dirNotificador',      
      
   ped.idFacturar,       
   aux.RUC 'RucCliente',      
   aux.RazonSocial 'desFacturar',      
      
   coalesce(aux.DireccionCompleta + ' ' + u.Departamento + '-' + u.Provincia + '-' + u.Distrito, aux.DireccionCompleta) 'DireccionCompleta',      
      
   ped.idMoneda, ped.Observacion, ped.NroGuia, ped.FecFactura, ped.nroFactura,      
   ped.idVendedor,       
   (select RazonSocial from retail.Persona      
   where Persona.IdPersona = ped.idVendedor) 'Vendedor',      
      
   (select RUC from retail.Persona      
   where Persona.IdPersona = ped.idVendedor) 'numDocVendedor',      
      
   (select telefonos from retail.Persona      
   where Persona.IdPersona = ped.idVendedor) 'telVendedor',      
      
   (select Correo from retail.Persona      
   where Persona.IdPersona = ped.idVendedor) 'EmailVendedor',      
      
   ped.idEstablecimiento, ped.idZona, ped.Tipo, ped.Estado,      
      
   (select m.desAbreviatura from retail.Monedas m      
   where m.idMoneda = ped.idMoneda) 'desMoneda',      
      
   ped.idFormaPago, ped.idTipCondicion, ped.idCondicion,      
      
   (select c.desCondicion from retail.Condicion c      
   where c.idTipCondicion = ped.idTipCondicion      
   and c.idCondicion = ped.idCondicion) 'desCondicion',      
      
   ped.totsubTotal, ped.totDscto1, ped.totDscto2, ped.totDscto3, ped.totIsc, ped.totIgv, ped.totTotal,       
   ped.idSucursalCliente, ped.PuntoPartida, ped.PuntoLlegada, ped.TipoDoc, ped.idTransporte,      
      
   (select vt.RazonSocial from retail.ven_Transporte vt      
   where vt.idTransporte = ped.idTransporte) 'RazonSocialTransporte',      
      
   (select vt.Ruc from retail.ven_Transporte vt      
   where vt.idTransporte = ped.idTransporte) 'RucTransporte',      
      
   (select t.Nemotecnico from retail.ParTabla t      
   where t.IdParTabla = ped.TipoDoc) 'NemoTipoDoc',      
   indCotPed = isnull(ped.indCotPed, 'P'),      
   ped.idPedidoEnlace,      
   ped.idDivision,    
     
   (select top 1 det.idTipoPrecio from retail.exp_PedidoDet det  
  where  det.idPedido=ped.idPedido)'idTipoPrecio',  


   ped.UsuarioRegistro, ped.fechaRegistro, ped.UsuarioModificacion, ped.fechaModificacion,      
   DesEstado = (case ped.Estado      
       when 'C' then 'COTIZADO'      
       when 'P' then 'PEDIDO'      
       when 'F' then 'FACTURADO'      
      end)      
      
 from retail.exp_PedidoCab ped      
 inner join retail.Persona aux      
  on ped.idFacturar = aux.IdPersona     
      
  --inner join retail.Cliente cli    
  --on aux.IdPersona= cli.idPersona    
   
  
 left join retail.UbigeoSunat u      
  on u.idUbigeo = aux.idUbigeo   
    
   
  
    where ped.idEmpresa = @idEmpresa      
 and ped.idLocal = @idLocal      
 and ped.idPedido = @idPedido      
end 



