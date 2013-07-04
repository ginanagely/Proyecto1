Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuRegistrarCliente
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function GuardarUsuario(ByVal usuarioDto As Transversal.UsuarioDto) As Integer
        Dim usuario = ConvertidorCuRegistrarCliente.ConvertirUsuarioDtoToUsuario(usuarioDto)
        Me.ObjectContext.USUARIOs.AddObject(usuario)
        Me.ObjectContext.SaveChanges()
        Return usuario.IDUSUARIO

    End Function

    Public Sub GuardarLogin(ByVal usuarioDto As Transversal.UsuarioDto)
        Dim login = ConvertidorCuRegistrarCliente.ConvertirUsuarioDtoToLogin(usuarioDto)
        Me.ObjectContext.LOGINs.AddObject(login)
        Me.ObjectContext.SaveChanges()

    End Sub
End Class
