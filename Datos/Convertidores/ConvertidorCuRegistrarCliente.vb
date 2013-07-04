Public Class ConvertidorCuRegistrarCliente

    Public Shared Function ConvertirUsuarioDtoToUsuario(ByVal usuarioDto As Transversal.UsuarioDto) As USUARIO
        Dim usuario = New USUARIO
        usuario.NOMBRES = usuarioDto.Nombres
        usuario.APELLIDOS = usuarioDto.Apellidos
        usuario.FECHANACIMIENTO = usuarioDto.FechaNacimiento
        usuario.TELEFONOFIJO = usuarioDto.TelefonoFijo
        usuario.TELEFONOMOVIL = usuarioDto.TelefonoMovil
        usuario.CORREOELECTRONICO = usuarioDto.CorreoElectronico
        usuario.DNI = usuarioDto.Dni
        usuario.DISTRITO = usuarioDto.Distrito
        usuario.PROVINCIA = usuarioDto.Provincia
        usuario.DEPARTAMENTO = usuarioDto.Departamento
        usuario.CODIGOPOSTAL = usuarioDto.CodigoPostal
        usuario.PAIS = usuarioDto.Pais
        usuario.NUMEROTARJETA = usuarioDto.NumeroTarjeta
        usuario.IDTIPOTARJETA = usuarioDto.IdTipoTarjeta
        usuario.DIRECCION = usuarioDto.Direccion
        usuario.IDTIPOUSUARIO = usuarioDto.IdTipoUsuario

        Return usuario
    End Function

    Public Shared Function ConvertirUsuarioDtoToLogin(ByVal usuarioDto As Transversal.UsuarioDto) As LOGIN
        Dim login = New LOGIN
        login.IDUSUARIO = usuarioDto.IdUsuario
        login.NOMBRE = usuarioDto.NombreUsuario
        login.CLAVE = usuarioDto.Clave

        Return login
    End Function

End Class
