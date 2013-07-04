Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuRegistrarProducto
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerProductoLista() As List(Of Transversal.ProductoDto)
        Dim productoLista = Me.ObjectContext.PRODUCTOes
        Dim productoListaDto = ConvertidorCuRegistrarProducto.ConvertirEntidadProducto(productoLista)
        Return productoListaDto

    End Function

    Public Function ObtenerProductoListaSegunCodigo(ByVal codigo As Integer) As List(Of Transversal.ProductoDto)
        Dim productoLista = From dats In Me.ObjectContext.PRODUCTOes Where dats.IDPRODUCTO = codigo
        Dim productoListaDto = ConvertidorCuRegistrarProducto.ConvertirEntidadProducto(productoLista)
        Return productoListaDto

    End Function

    Public Function GuardarProducto(ByVal productoDto As Transversal.CuRegistrarProductoDto) As Integer

        Dim producto = ConvertidorCuRegistrarProducto.ConvertirProductoDtoToProducto(productoDto)
        Me.ObjectContext.PRODUCTOes.AddObject(producto)
        Me.ObjectContext.SaveChanges()
        Return producto.IDPRODUCTO

    End Function

    Public Function GuardarRegistroDiario(ByVal productoDto As Transversal.CuRegistrarProductoDto) As Integer

        Dim regDiario = ConvertidorCuRegistrarProducto.ConvertirProductoDtoToRegDiario(productoDto)
        Me.ObjectContext.REGISTRODIARIOs.AddObject(regDiario)
        Me.ObjectContext.SaveChanges()
        Return regDiario.IDPRODUCTO

    End Function

End Class
