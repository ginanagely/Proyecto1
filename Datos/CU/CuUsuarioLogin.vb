Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuUsuarioLogin
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerPersonaListaSegunLogin(nombreUsuario As String, clave As String) As List(Of Transversal.CuUsuarioLoginDto)
        Dim usuarioLista = From usuario In Me.ObjectContext.USUARIOs Join login In Me.ObjectContext.LOGINs On
                            usuario.IDUSUARIO Equals login.IDUSUARIO Where login.NOMBRE = nombreUsuario And login.CLAVE = clave Select usuario
        Dim productoListaDto = ConvertidorCuUsuarioLogin.ConvertirUsuarioToUsuarioLoginDto(usuarioLista)
        Return productoListaDto

    End Function

    
End Class
