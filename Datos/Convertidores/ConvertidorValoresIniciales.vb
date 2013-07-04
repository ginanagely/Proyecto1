Public Class ConvertidorValoresIniciales
    Public Shared Function ConvertirEntidadTipoMarca(ByVal tipoMarcaLista As IEnumerable(Of TIPOMARCA)) As IEnumerable(Of Transversal.TipoMarcaDto)

        Dim tipoMarcaListaDto = New List(Of Transversal.TipoMarcaDto)

        For Each tipoMarca As Object In tipoMarcaLista
            Dim tipoMarcaDto = New Transversal.TipoMarcaDto
            tipoMarcaDto.Codigo = tipoMarca.IDTIPOMARCA
            tipoMarcaDto.DescCodigo = tipoMarca.DESCRIPCION

            tipoMarcaListaDto.Add(tipoMarcaDto)
        Next


        Return tipoMarcaListaDto
    End Function

    Public Shared Function ConvertirEntidadTipoTarjeta(ByVal tipoTarjetaLista As IEnumerable(Of TIPOTARJETA)) As IEnumerable(Of Transversal.TipoTarjetaDto)
        Dim tipoTarjetaListaDto = New List(Of Transversal.TipoTarjetaDto)
        For Each tipoTarjeta As Object In tipoTarjetaLista
            Dim tipoTarjetaDto = New Transversal.TipoTarjetaDto
            tipoTarjetaDto.Codigo = tipoTarjeta.IDTIPOTARJETA
            tipoTarjetaDto.DescCodigo = tipoTarjeta.DESCRIPCION
            tipoTarjetaListaDto.Add(tipoTarjetaDto)
        Next
        Return tipoTarjetaListaDto
    End Function

    Public Shared Function ConvertirEntidadTipoUsuario(ByVal tipoUsuarioLista As IEnumerable(Of TIPOUSUARIO)) As IEnumerable(Of Transversal.TipoUsuarioDto)
        Dim tipoUsuarioListaDto = New List(Of Transversal.TipoUsuarioDto)
        For Each tipoUsuario As Object In tipoUsuarioLista

            Dim tipoUsuarioDto = New Transversal.TipoUsuarioDto

            tipoUsuarioDto.Codigo = tipoUsuario.IDTIPOUSUARIO
            tipoUsuarioDto.DescCodigo = tipoUsuario.DESCRIPCION
            tipoUsuarioListaDto.Add(tipoUsuarioDto)
        Next
        Return tipoUsuarioListaDto
    End Function
End Class
