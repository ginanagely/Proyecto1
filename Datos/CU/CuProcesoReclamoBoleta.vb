Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuProcesoReclamoBoleta
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerVentaSegunNumeroDocumentoLista(ByVal nroBoleta As String) As List(Of Transversal.CuProcesoReclamoBoletaDto)
        Dim ventaLista = From dats In Me.ObjectContext.VENTAs Where dats.NUMERO = nroBoleta Select dats
        Dim productoListaDto = ConvertidorCuProcesoReclamoBoleta.ConvertirEntidadVenta(ventaLista)
        Return productoListaDto

    End Function
    Public Function ObtenerVentaListaSegunId(ByVal idVenta As Integer) As List(Of Transversal.CuProcesoReclamoBoletaDto)
        Dim ventaLista = From dats In Me.ObjectContext.VENTAs Where dats.IDVENTA = idVenta Select dats
        Dim ventaListaDto = ConvertidorCuProcesoReclamoBoleta.ConvertirEntidadVenta(ventaLista)
        Return ventaListaDto

    End Function
    Public Function ObtenerReclamoLista() As List(Of Transversal.CuProcesoReclamoBoletaDto)
        Dim reclamoLista = From recl In ObjectContext.RECLAMOes
                         Select recl
        Dim reclamoListaDto = ConvertidorCuProcesoReclamoBoleta.ConvertirEntidadReclamo(reclamoLista)
        Return reclamoListaDto

    End Function

    Public Function ObtenerProductoSegunId(ByVal idProducto As Integer) As PRODUCTO
        Dim productoLista = From dats In Me.ObjectContext.PRODUCTOes Where dats.IDPRODUCTO = idProducto Select dats
        Dim producto = productoLista.FirstOrDefault()
        Return producto

    End Function

    Public Function ObtenerUsuarioSegunId(ByVal idUsuario As Integer) As USUARIO
        Dim usuarioLista = From dats In Me.ObjectContext.USUARIOs Where dats.IDUSUARIO = idUsuario Select dats
        Dim usuario = usuarioLista.FirstOrDefault()
        Return usuario

    End Function
    Public Function ObtenerVentaDetalleIdVenta(ByVal idVent As Integer) As List(Of Transversal.CuProcesoReclamoBoletaDto)

        Dim ventaDetalleLista = From dats In Me.ObjectContext.VENTADETALLEs Where dats.IDVENTA = idVent Select dats
        Dim ventaDetListaDto = ConvertidorCuProcesoReclamoBoleta.ConvertirEntidadVentaDet(ventaDetalleLista)

        Return ventaDetListaDto

    End Function

    Public Sub RegistrarReclamo(ByVal reclamoDto As Transversal.CuProcesoReclamoBoletaDto)

        Dim reclamo = ConvertidorCuProcesoReclamoBoleta.ConvertirReclamoDtoToReclamo(reclamoDto)
        ObjectContext.RECLAMOes.AddObject(reclamo)
        ObjectContext.SaveChanges()


    End Sub
    Public Sub ActualizarEstadoReclamo(ByVal estadoReclamo As Integer, ByVal idReclamo As Integer)

        Dim reclamoLista = From dats In ObjectContext.RECLAMOes Where dats.IDRECLAMO = idReclamo Select dats
        Dim reclamo = reclamoLista.FirstOrDefault
        reclamo.ESTADO = estadoReclamo
        ObjectContext.SaveChanges()


    End Sub
    Public Sub ActualizarEstadoRegistroDiarioSegunNroDocumento(ByVal estadoRegDiario As Integer, ByVal nroDocumento As String)

        Dim regDiarioLista = From dats In ObjectContext.REGISTRODIARIOs Where dats.NUMERODOCUMENTO = nroDocumento And dats.OPERACION = True Select dats
        Dim regDiario = regDiarioLista.FirstOrDefault
        regDiario.ESTADOREGISTRO = False
        ObjectContext.SaveChanges()


    End Sub
    Public Sub ActualizarEstadoVentaSegunNroDocumento(ByVal estadoVenta As Integer, ByVal nroDocumento As String)

        Dim regDiarioLista = From dats In ObjectContext.VENTAs Where dats.NUMERO = nroDocumento Select dats
        Dim regDiario = regDiarioLista.FirstOrDefault
        regDiario.ESTADO = estadoVenta
        ObjectContext.SaveChanges()


    End Sub

End Class
