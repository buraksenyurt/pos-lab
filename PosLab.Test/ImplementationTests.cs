using PosLab.Implementation.SpaceY;
using PosLab.Implementation.SpaceY.Actions.CancelSale;
using PosLab.Implementation.SpaceY.Actions.DirectSales;
using PosLab.Infrastructure;
using PosLab.Infrastructure.Enums;
using PosLab.Network;

namespace PosLab.Test;

[TestClass]
public class ImplementationTests
{
    [TestMethod]
    public async Task SpaceYAppWorksTestAsync()
    {
        var rootAddress = "http://localhost:5001/api";
        var restChannel = new RestChannel();

        var newSaleAction = new NewSaleAction()
            .AddName("NewSale")
            .AddDescription("Yeni satış")
            .AddEndpoint($"{rootAddress}/sales")
            .AddCallType(CallType.Post);

        var posApp = new SpaceYApplication(restChannel);
        posApp
            .SetRootAddress(rootAddress)
            .AddAction(newSaleAction);

        var payload = @"{
                          'AccountNumber': 12345,
                          'AccountDate': '2023-2-6T00:00:00',
                          'Currency':'TL',
                          'Items': [
                            {'Title':'Kalem 0.5','Quantity':10,'Amount':34.50},
                            {'Title':'A4 Kağıt Bir Top','Quantity':5,'Amount':150},
                          ]
                        }";

        var request = new Request(payload, ContentType.Json);
        var response = await posApp.CallAction(newSaleAction, request);

        Assert.AreEqual(response.Status, MessageStatus.Success);
        Assert.IsNull(response.Exception);
        Assert.AreNotEqual(response.ExtraData, string.Empty);
    }

    [TestMethod]
    public async Task SpaceYCancelSaleWorksTestAsync()
    {
        var rootAddress = "http://localhost:5001/api";
        var restChannel = new RestChannel();

        var cancelSaleAction = new CancelSaleAction()
            .AddName("CancelSale")
            .AddDescription("Satış iptal")
            .AddEndpoint($"{rootAddress}/sales/cancel")
            .AddCallType(CallType.Post);

        var posApp = new SpaceYApplication(restChannel)
            .SetRootAddress(rootAddress)
            .AddAction(cancelSaleAction);

        var payload = @"{
                          'AccountDate': '2023-2-6T00:00:00',
                          'TransactionId':12345,
                          'Amount':900
                        }";

        var request = new Request(payload, ContentType.Json);
        var response = await posApp.CallAction(cancelSaleAction, request);

        Assert.AreEqual(response.Status, MessageStatus.Success);
        Assert.IsNull(response.Exception);
        Assert.AreNotEqual(response.ExtraData, string.Empty);
    }

    [TestMethod]
    public void SpaceYApplicationFunctionsTest()
    {
        var rootAddress = "http://localhost:5001/api";
        var restChannel = new RestChannel();

        var newSaleAction = new NewSaleAction()
            .AddName("NewSale")
            .AddDescription("Yeni satış")
            .AddEndpoint($"{rootAddress}/sales")
            .AddCallType(CallType.Post);

        var cancelSaleAction = new CancelSaleAction()
            .AddName("CancelSale")
            .AddDescription("Satış iptal")
            .AddEndpoint($"{rootAddress}/sales/cancel")
            .AddCallType(CallType.Post);

        var posApp = new SpaceYApplication(restChannel);
        posApp.SetRootAddress(rootAddress)
            .AddAction(newSaleAction)
            .AddAction(cancelSaleAction);

        Assert.Inconclusive();
    }
}