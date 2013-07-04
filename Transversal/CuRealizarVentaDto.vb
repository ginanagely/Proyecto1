<Serializable()>
Public Class CuRealizarVentaDto
    Public IdVenta As Integer
    Public IdProducto As Integer
    Public IdCliente As Integer
    Public IdUsuario As Integer
    Public Cantidad As Integer
    Public PrecioUnitario As Decimal
    Public Igv As Decimal
    Public Total As Decimal

    Public claveTarjeta As String
    Public claveUsuario As String

    Public Operacion As Boolean
    Public NumeroDocumento As String
    Public EstadoVenta As Integer

End Class
