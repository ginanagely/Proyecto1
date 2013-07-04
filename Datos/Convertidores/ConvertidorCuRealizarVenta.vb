Public Class ConvertidorCuRealizarVenta
    Public Shared Function ConvertirVentaDtoToRegDiario(ByVal ventaDto As Transversal.CuRealizarVentaDto) As REGISTRODIARIO
        Dim regDiario = New REGISTRODIARIO
        regDiario.IDPRODUCTO = ventaDto.IdProducto
        regDiario.CANTIDAD = ventaDto.Cantidad
        regDiario.OPERACION = ventaDto.Operacion
        regDiario.FECHA = Date.Now
        regDiario.IDUSUARIO = ventaDto.IdUsuario
        regDiario.ESTADOREGISTRO = True
        regDiario.NUMERODOCUMENTO = ventaDto.NumeroDocumento
        Return regDiario
    End Function

    Public Shared Function ConvertirVentaDtoToVenta(ByVal ventaDto As Transversal.CuRealizarVentaDto) As VENTA
        Dim venta = New VENTA
        venta.NUMERO = ventaDto.NumeroDocumento
        venta.IDUSUARIO = ventaDto.IdCliente
        venta.FECHAHORA = Date.Now
        venta.ESTADO = ventaDto.EstadoVenta
        venta.ESTADOREGISTRO = True
        Return venta
    End Function
    Public Shared Function ConvertirVentaDtoToVentaDetalle(ByVal ventaDto As Transversal.CuRealizarVentaDto) As VENTADETALLE
        Dim ventaDetalle = New VENTADETALLE
        ventaDetalle.IDVENTA = ventaDto.IdVenta
        ventaDetalle.IDPRODUCTO = ventaDto.IdProducto
        ventaDetalle.CANTIDAD = ventaDto.Cantidad
        ventaDetalle.INSOLUTO = ventaDto.PrecioUnitario
        ventaDetalle.IGV = ventaDto.Igv
        ventaDetalle.TOTAL = ventaDto.Total

        ventaDetalle.ESTADOREGISTRO = True
        Return ventaDetalle
    End Function
End Class
