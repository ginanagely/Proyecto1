Public Class ConvertidorVentaCelular
    Public Shared Function ConvertirUsuarioToUsuarioLoginDto(ByVal usuarioLista As IEnumerable(Of USUARIO)) As IEnumerable(Of Transversal.CuUsuarioLoginDto)

        Dim usuarioLoginListaDto = New List(Of Transversal.CuUsuarioLoginDto)

        For Each usuario As USUARIO In usuarioLista
            Dim usuarioLoginDto = New Transversal.CuUsuarioLoginDto
            usuarioLoginDto.IdUsuario = usuario.IDUSUARIO
            usuarioLoginDto.NombreUsuario = usuario.NOMBRES
            usuarioLoginDto.IdTipoUsuario = usuario.IDTIPOUSUARIO
            usuarioLoginDto.NumeroTarjeta = usuario.NUMEROTARJETA
            usuarioLoginListaDto.Add(usuarioLoginDto)
        Next


        Return usuarioLoginListaDto
    End Function

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
End Class
