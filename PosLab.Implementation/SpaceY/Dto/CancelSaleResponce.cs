namespace PosLab.Implementation.SpaceY.Dto;

public class CancelSaleResponse
{
    public string OrderNo { get; set; }
    public string BankResponseCode { get; set; }
    public string BankResponseMessage { get; set; }
    public int Code { get; set; }
    public string Message { get; set; }
}
