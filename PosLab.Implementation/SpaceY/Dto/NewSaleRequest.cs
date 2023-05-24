using System.Text.Json.Serialization;

namespace PosLab.Implementation.SpaceY.Dto;
public class NewSaleRequest
{
    public decimal Amount { get; set; }
    public decimal Commission { get; set; }
    public string ApiKey { get; set; }
    [JsonIgnore]
    public string ApiPass { get; set; }
    public byte InvoiceStatus { get; set; }
    public byte MethodType { get; set; }
    public int MkgID { get; set; }
    public DateTime OrderTime { get; set; }
    public string OrderType { get; set; }
    public long PaymentID { get; set; }
    public int RandomNumber { get; set; }
    public long StationCode { get; set; }
    public DateTime TimeSpan { get; set; }
    public long ViaOrderNumber { get; set; }
    public long ViaRequestID { get; set; }
    public int InstallmentCount { get; set; }
    public string Hash { get; set; }
}