/****** Object:  StoredProcedure [retail].[usp_ActualizarPedidoCabNacional]    Script Date: 27/01/2020 11:37:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [retail].[usp_ActualizarPedidoCabNacional]
    @idEmpresa int, 
	@idLocal int,
	@idPedido int,
	@codPedidoCad varchar(20),
	@FecCotizacion smalldatetime,
	@FecEntrega smalldatetime = null,
	@idNotificar int = null,
	@idFacturar int = null,
	@idMoneda varchar(2), 
	@Observacion varchar(500), 
	@Indicaciones varchar(500),
	@idFormaPago int = null,
	@idTipCondicion int = null,
	@idCondicion int = null,
	@idVendedor int = null,
	@idEstablecimiento int = null,
	@idZona int = null,
	@Tipo bit, -- 0 = Nacional --- 1 = Exportación
	@totsubTotal decimal(12, 2),
	@totDscto1 decimal(12, 2),
	@totDscto2 decimal(12, 2),
	@totDscto3 decimal(12, 2),
	@totIsc decimal(12, 2),
	@totIgv decimal(12, 2),
	@totTotal decimal(12, 2),
	@idSucursalCliente int = null,
	@PuntoPartida varchar(400),
	@PuntoLlegada varchar(400),
	@TipoDoc int = null,
	@idTransporte int = null,
	@indCotPed char(1), --P=Pedido C=Cotización
	@idPedidoEnlace int,
	@idDivision int = 0,
	@UsuarioModificacion varchar(30)
as
begin
	update exp_PedidoCab
		set codPedidoCad = @codPedidoCad,
			FecCotizacion = @FecCotizacion,
			FecEntrega = @FecEntrega,
			idNotificar = @idNotificar, 
			idFacturar = @idFacturar, 
			idMoneda = @idMoneda, 
			Observacion = @Observacion, 
			Indicaciones = @Indicaciones,
			idFormaPago = @idFormaPago, 
			idTipCondicion = @idTipCondicion, 
			idCondicion = @idCondicion, 
			idVendedor = @idVendedor,
			idEstablecimiento = @idEstablecimiento, 
			idZona = @idZona, 
			Tipo = @Tipo, -- 0 = Nacional --- 1 = Exportación
			totsubTotal = @totsubTotal, 
			totDscto1 = @totDscto1, 
			totDscto2 = @totDscto2, 
			totDscto3 = @totDscto3, 
			totIsc = @totIsc, 
			totIgv = @totIgv, 
			totTotal = @totTotal, 
			idSucursalCliente = @idSucursalCliente,
			PuntoPartida = @PuntoPartida,
			PuntoLlegada = @PuntoLlegada,
			TipoDoc = @TipoDoc,
			idTransporte = @idTransporte,
			indCotPed = @indCotPed, --P=Pedido C=Cotización
			idPedidoEnlace = @idPedidoEnlace,
			idDivision = @idDivision,
			UsuarioModificacion = @UsuarioModificacion, 
			fechaModificacion = GETDATE()
	where idPedido = @idPedido
	and idEmpresa = @idEmpresa
	and idLocal = @idLocal
end

GO


