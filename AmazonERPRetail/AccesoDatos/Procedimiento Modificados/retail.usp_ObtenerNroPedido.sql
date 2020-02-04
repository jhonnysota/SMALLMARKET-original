---exec retail.usp_ObtenerNroPedido   1,1,'C'
alter procedure retail.usp_ObtenerNroPedido  
 @idEmpresa int,  
 @idLocal int,  
 @indCotPed char(1)  
as  
begin  
 declare @Anio varchar(4), @Codigo varchar(20), @num bigint, @Sigla varchar(50), @codRetorno varchar(20)  
   
 --// PEDIDOS  
 if @indCotPed = 'P'  
 begin  
  set @Sigla = (select Siglas from retail.[Local]  
      where IdEmpresa = @idEmpresa  
      and IdLocal = @idLocal)  
   
  if @Sigla is not null or @Sigla <> ''  
  begin  
   set @codRetorno = (left(@Sigla, 3) + '-')  
  end  
  
  set @Anio = right(convert(varchar(4), year(getdate())), 2)  
  set @Codigo = (select max(codPedidoCad) from retail.exp_PedidoCab   
      where idEmpresa = @idEmpresa  
      and idLocal = @idLocal  
      and indCotPed = 'P'  
      and right(codPedidoCad, 2) = @anio)  
  
  if @Codigo is null  
  begin  
   set @codRetorno = CONCAT(@codRetorno, '0001-', @Anio)  
  end  
  else  
  begin  
   if (select Count(*) from dbo.fn_SplitPedidos(@Codigo, '-')) = 3  
   begin  
    set @Codigo = (select Elemento from dbo.fn_SplitPedidos(@Codigo, '-')  
        where ID = 2)  
   end  
   else  
   begin  
    set @Codigo = (select Elemento from dbo.fn_SplitPedidos(@Codigo, '-')  
        where ID = 1)  
   end  
  
   set @num = Convert(int, @Codigo) + 1  
   set @codRetorno = CONCAT(@codRetorno, right('0000' + convert(varchar(4), @num), 4), '-', @Anio)  
  end  
 end  
 else --// COTIZACIONES  
 begin  
  
  set @Anio = convert(varchar(4), year(getdate()))  
  set @Codigo = (select max(codPedidoCad) from retail.exp_PedidoCab  
      where idEmpresa = @idEmpresa  
      and idLocal = @idLocal  
      and indCotPed = 'V'  
      and left(codPedidoCad, 4) = @anio)  
  
  if @Codigo is null  
  begin  
   set @codRetorno = CONCAT(@Anio, '-00001')  
  end  
  else  
  begin  
   set @Codigo = (select Elemento from dbo.fn_SplitPedidos(@Codigo, '-')  
       where ID = 2)  
  
   set @num = Convert(int, @Codigo) + 1  
   set @codRetorno = concat(@Anio, '-', right('00000' + convert(varchar(5), @num), 5))  
  end  
 end  
  
 select @codRetorno  
end  
  


