create procedure retail.usp_EliminarPedidoNacionalDet
	(
	@idEmpresa int,
	@idPedido int
	)
	as
	begin 
	delete from exp_PedidoDet
		where idEmpresa=@idEmpresa
			and idPedido=@idPedido
	end
		
