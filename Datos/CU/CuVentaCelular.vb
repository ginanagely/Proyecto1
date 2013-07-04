Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuVentaCelular
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerPersonaListaSegunLogin(nombreUsuario As String, clave As String) As List(Of Transversal.CuUsuarioLoginDto)
        Dim usuarioLista = From usuario In Me.ObjectContext.USUARIOs Join login In Me.ObjectContext.LOGINs On
                            usuario.IDUSUARIO Equals login.IDUSUARIO Where login.NOMBRE = nombreUsuario And login.CLAVE = clave Select usuario
        Dim usuarioListaDto = ConvertidorVentaCelular.ConvertirUsuarioToUsuarioLoginDto(usuarioLista)
        Return usuarioListaDto

    End Function
    
    Public Function ObtenerProductoSegunIdLista(ByVal idProducto As Integer) As List(Of Transversal.ProductoDto)
        Dim productoLista = From dats In Me.ObjectContext.PRODUCTOes Where dats.IDPRODUCTO = idProducto
        Dim productoListaDto = ConvertidorVentaCelular.ConvertirEntidadProducto(productoLista)
        Return productoListaDto

    End Function
End Class
