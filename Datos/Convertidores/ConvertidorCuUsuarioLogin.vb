Public Class ConvertidorCuUsuarioLogin
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
End Class
