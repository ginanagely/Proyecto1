Public Class ConvertidorCuRegistrarProducto
    Public Shared Function ConvertirEntidadProducto(ByVal productoLista As IEnumerable(Of PRODUCTO)) As IEnumerable(Of Transversal.ProductoDto)

        Dim productoListaDto = New List(Of Transversal.ProductoDto)

        For Each producto As PRODUCTO In productoLista
            Dim productoDto = New Transversal.ProductoDto()
            productoDto.IdProducto = producto.IDPRODUCTO
            productoDto.IdTipoMarca = producto.IDTIPOMARCA
            productoDto.Nombre = producto.NOMBRE
            productoDto.Modelo = producto.MODELO
            productoDto.Precio = producto.PRECIO
            productoDto.Especificaciones = producto.ESPECIFICACIONES
            productoDto.Archivo = producto.ARCHIVO

            productoListaDto.Add(productoDto)
        Next


        Return productoListaDto
    End Function

    Public Shared Function ConvertirProductoDtoToProducto(ByVal productoDto As Transversal.CuRegistrarProductoDto) As PRODUCTO
        Dim producto = New PRODUCTO
        producto.NOMBRE = productoDto.Nombre
        producto.IDTIPOMARCA = productoDto.IdTipoMarca
        producto.MODELO = productoDto.Modelo
        producto.PRECIO = productoDto.Precio
        producto.ESPECIFICACIONES = productoDto.Especificaciones
        producto.ARCHIVO = productoDto.Archivo

        Return producto
    End Function

    Public Shared Function ConvertirProductoDtoToRegDiario(ByVal productoDto As Transversal.CuRegistrarProductoDto) As REGISTRODIARIO
        Dim regDiario = New REGISTRODIARIO
        regDiario.IDPRODUCTO = productoDto.IdProducto
        regDiario.CANTIDAD = productoDto.Cantidad
        regDiario.OPERACION = productoDto.Operacion
        regDiario.FECHA = productoDto.Fecha
        regDiario.IDUSUARIO = productoDto.IdUsuario
        regDiario.ESTADOREGISTRO = productoDto.EstadoRegistro
        regDiario.NUMERODOCUMENTO = productoDto.NumeroDocumento
        Return regDiario
    End Function
End Class
