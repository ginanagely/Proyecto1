Public Class ConvertidorCuProcesoReclamoBoleta
    Public Shared Function ConvertirEntidadVenta(ByVal ventaLista As IEnumerable(Of VENTA)) As IEnumerable(Of Transversal.CuProcesoReclamoBoletaDto)

        Dim reclamoListaDto = New List(Of Transversal.CuProcesoReclamoBoletaDto)

        For Each venta As VENTA In ventaLista
            Dim ventaDto = New Transversal.CuProcesoReclamoBoletaDto()

            ventaDto.IdVenta = venta.IDVENTA

            ventaDto.NroBoleta = venta.NUMERO
            ventaDto.Fecha = venta.FECHAHORA
            ventaDto.IdUsuario = venta.IDUSUARIO
            ventaDto.estadoVenta = venta.ESTADO
            reclamoListaDto.Add(ventaDto)
        Next
        Return reclamoListaDto
    End Function
    Public Shared Function ConvertirEntidadReclamo(ByVal reclamoLista As IEnumerable(Of RECLAMO)) As IEnumerable(Of Transversal.CuProcesoReclamoBoletaDto)

        Dim reclamoListaDto = New List(Of Transversal.CuProcesoReclamoBoletaDto)

        For Each reclamo As RECLAMO In reclamoLista
            Dim reclamoDto = New Transversal.CuProcesoReclamoBoletaDto()
            reclamoDto.IdReclamo = reclamo.IDRECLAMO
            reclamoDto.IdVenta = reclamo.IDVENTA
            reclamoDto.estadoReclamo = reclamo.ESTADO
            reclamoDto.Asunto = reclamo.ASUNTO

            reclamoListaDto.Add(reclamoDto)
        Next
        Return reclamoListaDto
    End Function
    Public Shared Function ConvertirEntidadVentaDet(ByVal ventaDetalleLista As IEnumerable(Of VENTADETALLE)) As IEnumerable(Of Transversal.CuProcesoReclamoBoletaDto)

        Dim reclamoListaDto = New List(Of Transversal.CuProcesoReclamoBoletaDto)

        For Each ventaDet As VENTADETALLE In ventaDetalleLista
            Dim ventaDetDto = New Transversal.CuProcesoReclamoBoletaDto()
            ventaDetDto.IdProducto = ventaDet.IDPRODUCTO
            ventaDetDto.Cantidad = ventaDet.CANTIDAD
            ventaDetDto.PrecioTotal = ventaDet.TOTAL
            reclamoListaDto.Add(ventaDetDto)
        Next
        Return reclamoListaDto
    End Function

    Public Shared Function ConvertirReclamoDtoToReclamo(ByVal reclamoDto As Transversal.CuProcesoReclamoBoletaDto) As RECLAMO
        Dim reclamo = New RECLAMO
        reclamo.IDVENTA = reclamoDto.IdVenta
        reclamo.ASUNTO = reclamoDto.Asunto
        reclamo.IDUSUARIO = reclamoDto.IdUsuario
        reclamo.ESTADO = reclamoDto.estadoVenta
        reclamo.ESTADOREGISTRO = True
        Return reclamo
    End Function
End Class
