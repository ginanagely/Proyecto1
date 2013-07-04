Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuRealizarVenta
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Sub ActualizarValorConfigByCodigo(ByVal codigo As String, ByVal valor As String)
        Dim configLista = From dats In Me.ObjectContext.CONFIGs Where dats.CODIGO = codigo Select dats
        Dim config = configLista.FirstOrDefault
        config.VALOR = valor
        Me.ObjectContext.SaveChanges()
    End Sub
    
    Public Function GuardarRegDiario(ByVal ventaDto As Transversal.CuRealizarVentaDto) As Integer
        Dim regDiario = ConvertidorCuRealizarVenta.ConvertirVentaDtoToRegDiario(ventaDto)
        Me.ObjectContext.REGISTRODIARIOs.AddObject(regDiario)
        Me.ObjectContext.SaveChanges()
        Return regDiario.IDREGISTRODIARIO
    End Function

    Public Function GuardarVenta(ByVal ventaDto As Transversal.CuRealizarVentaDto) As Integer
        Dim venta = ConvertidorCuRealizarVenta.ConvertirVentaDtoToVenta(ventaDto)
        Me.ObjectContext.VENTAs.AddObject(venta)
        Me.ObjectContext.SaveChanges()
        Return venta.IDVENTA
    End Function

    Public Function GuardarVentaDetalle(ByVal ventaDto As Transversal.CuRealizarVentaDto) As Integer
        Dim ventaDetalle = ConvertidorCuRealizarVenta.ConvertirVentaDtoToVentaDetalle(ventaDto)
        Me.ObjectContext.VENTADETALLEs.AddObject(ventaDetalle)
        Me.ObjectContext.SaveChanges()
        Return ventaDetalle.IDVENTADETALLE
    End Function

    Public Function ObtenerValorConfigByCodigo(ByVal codigo As String) As String
        Dim valorLista = From dats In Me.ObjectContext.CONFIGs Where dats.CODIGO = codigo Select dats.VALOR

        Return valorLista.FirstOrDefault

    End Function

    Public Function ObtenerTotalProductosVendidos(ByVal idProducto As Integer) As Integer
        Dim totalProductos = (From dats In Me.ObjectContext.REGISTRODIARIOs Where dats.IDPRODUCTO = idProducto Where dats.OPERACION = True And dats.ESTADOREGISTRO Select dats.CANTIDAD).ToList().Sum()

        Return totalProductos

    End Function
    
    Public Function ObtenerTotalProductosComprados(ByVal idProducto As Integer) As Integer
        Dim totalProductos = (From dats In Me.ObjectContext.REGISTRODIARIOs Where dats.IDPRODUCTO = idProducto Where dats.OPERACION = False And dats.ESTADOREGISTRO Select dats.CANTIDAD).ToList().Sum()

        Return totalProductos

    End Function
    Public Function ObtenerNombreUsuarioLoginSegunIdUsuario(ByVal idUsuario As Integer) As String
        Dim loginLista = From usuarioEntidad In Me.ObjectContext.USUARIOs
                        Join loginEntidad In Me.ObjectContext.LOGINs On
                        usuarioEntidad.IDUSUARIO Equals loginEntidad.IDUSUARIO
                         Where usuarioEntidad.IDUSUARIO = idUsuario Select loginEntidad

        Dim login = loginLista.FirstOrDefault()
        Return login.NOMBRE
    End Function
End Class
