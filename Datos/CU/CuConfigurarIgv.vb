Imports System.ServiceModel.DomainServices.EntityFramework

Public Class CuConfigurarIgv
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerValorConfigByCodigo(ByVal codigo As String) As String
        Dim valorLista = From dats In Me.ObjectContext.CONFIGs Where dats.CODIGO = codigo Select dats.VALOR

        Return valorLista.FirstOrDefault

    End Function

    Public Sub ActualizarValorConfigByCodigo(ByVal codigo As String, ByVal valor As String)
        Dim configLista = From dats In Me.ObjectContext.CONFIGs Where dats.CODIGO = codigo Select dats
        Dim config = configLista.FirstOrDefault
        config.VALOR = valor
        Me.ObjectContext.SaveChanges()
    End Sub
End Class
