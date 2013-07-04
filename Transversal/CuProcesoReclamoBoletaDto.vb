<Serializable()>
Public Class CuProcesoReclamoBoletaDto
    Public IdReclamo As Integer
    Public IdVenta As Integer
    Public NroBoleta As String
    Public IdUsuario As Integer
    Public NombreUsuario As String
    Public IdProducto As Integer
    Public NombreProducto As String
    Public Cantidad As Integer
    Public PrecioTotal As Decimal
    Public Fecha As Date

    Public Asunto As String

    Public estadoVenta As Integer
    Public descEstadoVenta As String
    Public estadoReclamo As Integer
    Public descEstadoReclamo As String
End Class
