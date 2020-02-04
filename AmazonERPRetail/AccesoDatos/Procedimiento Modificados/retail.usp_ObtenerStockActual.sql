 
  
  
  
  
CREATE procedure [retail].[usp_ObtenerStockActual]     
  
 @idEmpresa int,      
 @idAlmacen int,      
 @idTipoArticulo int,      
 @idArticulo int,      
 @Anio varchar(4),      
 @Mes varchar(2),      
 @conLote bit,      
 @Lote varchar(20)      
as      
begin      
 declare @EstaComprometido bit      
      
 set @EstaComprometido = isnull((select Comprometido from retail.ven_Parametros      
         where idEmpresa = @idEmpresa), 0)      
 print @EstaComprometido      
 if @EstaComprometido = 0      
  begin      
   if @conLote = 1      
    begin      
     select a.canStock, EsComprometido = 0 from retail.log_AlmacenArticuloLote a      
     inner join retail.ArticuloServ b      
      on a.idEmpresa = b.idEmpresa      
      and a.idArticulo = b.idArticulo      
     left join retail.log_Lote c      
      on a.idEmpresa = c.idEmpresa      
      and a.Lote = c.Lote      
     left join retail.log_MovimientoAlmacen x      
      on x.idEmpresa = c.idEmpresa      
      and x.tipMovimiento = c.tipMovimiento      
      and x.idDocumentoAlmacen = c.idDocumentoAlmacen      
     left join retail.paises o      
      on o.idPais = c.idPaisOrigen      
     left join retail.paises p      
      on p.idPais = c.idPaisProcedencia      
     left join retail.Persona z      
      on z.IdPersona = x.idPersona      
     where a.idEmpresa = @idEmpresa      
     and a.AnioPeriodo = @Anio      
     and a.MesPeriodo = @Mes      
     and a.idAlmacen = @idAlmacen      
     and b.idTipoArticulo = @idTipoArticulo      
     and b.idArticulo = @idArticulo      
     and a.Lote = @Lote      
    end      
   else      
    begin      
     select a.canStock, EsComprometido = 0 from retail.log_AlmacenArticuloLote a       
     inner join retail.ArticuloServ b      
      on a.idEmpresa = b.idEmpresa      
      and a.idArticulo = b.idArticulo      
     where a.idEmpresa = @idEmpresa      
     and a.AnioPeriodo = @Anio      
     and a.MesPeriodo = @Mes      
     and a.idAlmacen = @idAlmacen      
     and b.idTipoArticulo = @idTipoArticulo      
     and b.idArticulo = @idArticulo      
end    
    
   IF @IdTipoArticulo = '333011'      
   SELECT  top 1 a.canStock-isnull((select top 1 (min(AAL.canStock  AK.Cantidad )+2)  
    
    FROM retail.ArticuloKit AK    
  JOIN retail.ArticuloServ Kit ON AK.idArticulo = Kit.idArticulo    
  JOIN retail.ArticuloServ Comp ON AK.idArticuloComponente = Comp.idArticulo    
  JOIN retail.log_AlmacenArticuloLote AAL ON Comp.idArticulo = AAL.idArticulo    
  JOIN retail.ListaPrecioItem li ON Kit.idArticulo = li.idArticulo and Kit.idEmpresa = li.idEmpresa),0)'canStock',EsComprometido = 0  
 from retail.log_AlmacenArticuloLote a     
     inner join retail.ArticuloServ b    
      on a.idEmpresa = b.idEmpresa    
      and a.idArticulo = b.idArticulo    
    
    
 else      
  begin      
    
   if @conLote = 1      
    begin      
     select a.canStock - isnull((select sum(Cantidad) from retail.exp_PedidoDet d  inner join retail.exp_PedidoCab c      
             on d.idPedido = c.idPedido      
             and d.idEmpresa = c.idEmpresa      
             and d.idLocal = c.idLocal      
            where d.idEmpresa = @idEmpresa      
            and d.idTipoArticulo = @idTipoArticulo      
            and d.idArticulo = a.idArticulo      
            and c.Estado = 'P'      
            and d.Lote = a.Lote), 0) 'canStock',       
       EsComprometido = 1      
     from retail.log_AlmacenArticuloLote a      
     inner join retail.ArticuloServ b      
      on a.idEmpresa = b.idEmpresa      
      and a.idArticulo = b.idArticulo      
     left join retail.log_Lote c      
      on a.idEmpresa = c.idEmpresa      
      and a.Lote      = c.Lote      
     left join retail.log_MovimientoAlmacen x      
      on x.idEmpresa = c.idEmpresa      
      and x.tipMovimiento = c.tipMovimiento      
      and x.idDocumentoAlmacen = c.idDocumentoAlmacen      
     left join retail.paises o      
      on o.idPais = c.idPaisOrigen      
     left join retail.paises p      
      on p.idPais = c.idPaisProcedencia      
     left join retail.Persona z      
      on z.IdPersona = x.idPersona      
     where a.idEmpresa = @idEmpresa      
     and a.AnioPeriodo = @Anio      
     and a.MesPeriodo  = @Mes      
     and a.idAlmacen = @idAlmacen      
     and b.idTipoArticulo = @idTipoArticulo      
     and b.idArticulo = @idArticulo      
     and a.Lote = @Lote      
    end      
   else      
    begin      
     select a.canStock  - isnull((select sum(Cantidad) from retail.exp_PedidoDet d       
             inner join retail.exp_PedidoCab c      
              on d.idPedido = c.idPedido      
              and d.idEmpresa = c.idEmpresa      
              and d.idLocal = c.idLocal      
             where d.idEmpresa = @idEmpresa      
             and d.idTipoArticulo = @idTipoArticulo      
             and d.idArticulo = a.idArticulo      
             and c.Estado = 'P'), 0) 'canStock',      
       EsComprometido = 1      
     from retail.log_AlmacenArticuloLote a       
     inner join  retail.ArticuloServ b      
      on a.idEmpresa = b.idEmpresa      
      and a.idArticulo = b.idArticulo      
     where a.idEmpresa   = @idEmpresa      
     and a.AnioPeriodo = @Anio      
     and a.MesPeriodo  = @Mes      
     and a.idAlmacen = @idAlmacen      
     and b.idTipoArticulo =  @idTipoArticulo      
     and b.idArticulo = @idArticulo      
    end      
  end      
  end  
  end