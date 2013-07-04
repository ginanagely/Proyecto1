Imports System.ServiceModel.DomainServices.EntityFramework

Public Class ValoresIniciales
    Inherits LinqToEntitiesDomainService(Of TIENDAVIRTUALEntities)

    Public Function ObtenerTipoMarca() As List(Of Transversal.TipoMarcaDto)
        Dim tipoMarcaListaDto = New List(Of Transversal.TipoMarcaDto)

        Dim tipoMarcaLista = From dats In Me.ObjectContext.TIPOMARCAs Select dats

        tipoMarcaListaDto = ConvertidorValoresIniciales.ConvertirEntidadTipoMarca(tipoMarcaLista)
        Return tipoMarcaListaDto

    End Function

    Public Function ObtenerTipoUsuario() As List(Of Transversal.TipoUsuarioDto)
        Dim tipoUsuarioListaDto = New List(Of Transversal.TipoUsuarioDto)

        Dim tipoUsuarioLista = From dats In Me.ObjectContext.TIPOUSUARIO Select dats

        tipoUsuarioListaDto = ConvertidorValoresIniciales.ConvertirEntidadTipoUsuario(tipoUsuarioLista)
        Return tipoUsuarioListaDto

    End Function

    Public Function ObtenerTipoTarjeta() As List(Of Transversal.TipoTarjetaDto)
        Dim tipoTarjetaListaDto = New List(Of Transversal.TipoTarjetaDto)
        Dim tipoTarjetaLista = From dats In Me.ObjectContext.TIPOTARJETAs Select dats
        tipoTarjetaListaDto = ConvertidorValoresIniciales.ConvertirEntidadTipoTarjeta(tipoTarjetaLista)
        Return tipoTarjetaListaDto

    End Function
End Class
