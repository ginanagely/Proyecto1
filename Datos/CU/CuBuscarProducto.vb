Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuBuscarProducto
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerProductoLista() As List(Of Transversal.ProductoDto)
        Dim productoLista = Me.ObjectContext.PRODUCTOes
        Dim productoListaDto = ConvertidorCuRegistrarProducto.ConvertirEntidadProducto(productoLista)
        Return productoListaDto

    End Function


    Public Function ObtenerProductoListaSegunCriterio(ByVal idTipoMarca As Integer, ByVal modelo As String, ByVal nombreProducto As String) As List(Of Transversal.ProductoDto)
        Dim productoLista = From dats In
                            Me.ObjectContext.PRODUCTOes
                            Where dats.IDTIPOMARCA = idTipoMarca And dats.MODELO.Contains(modelo) And dats.NOMBRE.Contains(nombreProducto) Select dats
        Dim productoListaDto = ConvertidorCuRegistrarProducto.ConvertirEntidadProducto(productoLista)
        Return productoListaDto

    End Function

    Public Function ObtenerProductoListaSegunCriterio(ByVal modelo As String, ByVal nombreProducto As String) As List(Of Transversal.ProductoDto)
        Dim productoLista = From dats In
                            Me.ObjectContext.PRODUCTOes
                            Where dats.MODELO.Contains(modelo) And dats.NOMBRE.Contains(nombreProducto) Select dats
        Dim productoListaDto = ConvertidorCuRegistrarProducto.ConvertirEntidadProducto(productoLista)
        Return productoListaDto

    End Function

    Public Function ObtenerTotalProductosVendidos(ByVal idProducto As Integer) As Integer
        Dim totalProductos = (From dats In Me.ObjectContext.REGISTRODIARIOs Where dats.IDPRODUCTO = idProducto Where dats.OPERACION = True And dats.ESTADOREGISTRO Select dats.CANTIDAD).ToList().Sum()

        Return totalProductos

    End Function

    Public Function ObtenerTotalProductosComprados(ByVal idProducto As Integer) As Integer
        Dim totalProductos = (From dats In Me.ObjectContext.REGISTRODIARIOs Where dats.IDPRODUCTO = idProducto Where dats.OPERACION = False And dats.ESTADOREGISTRO Select dats.CANTIDAD).ToList().Sum()

        Return totalProductos

    End Function

    Public Function ObtenerNombreTipoMarcaSegunId(ByVal idTipoMarca As Integer) As String
        Dim nombreTipoMarca = (From dats In Me.ObjectContext.TIPOMARCAs Where dats.IDTIPOMARCA = idTipoMarca Select dats.DESCRIPCION).ToList().FirstOrDefault()

        Return nombreTipoMarca

    End Function

End Class
