using System.Text.Json;
using PosLab.Core;
using PosLab.Implementation;
using PosLab.Implementation.SpaceY;
using PosLab.Implementation.SpaceY.Dto;
using PosLab.Infrastructure;
using PosLab.Infrastructure.Enums;

namespace PosLab.Test;

[TestClass]
public class CoreTests
{
    [TestMethod]
    public void CoreServiceWorksTest()
    {
        var container = new PosServiceContainer();
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
        var response = container.PosService.Call(AppName.SpaceYPaymentSystem, ActionName.NewSale.ToString(), request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, MessageStatus.Success);
    }

    [TestMethod]
    public void CoreServiceNotWorksForUnknownActionTest()
    {
        var container = new PosServiceContainer();
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
        var response = container.PosService.Call(AppName.SpaceYPaymentSystem, "Unknown", request);
        Assert.AreEqual(response.Status, MessageStatus.Fail);
    }

    [TestMethod]
    public void CoreServicesCallWorksWithSerializableData()
    {
        var container = new PosServiceContainer();
        var newSaleRequest = new NewSaleRequest
        {
            Amount = 15,
            Commission = 1,
            ApiKey = "some key",
            ApiPass = "1234",
            Hash = "Must calculate",
            InstallmentCount = 1,
            InvoiceStatus = 1,
            MkgID = 1,
            MethodType = 0,
            OrderTime = DateTime.Now,
            OrderType = "Fatura",
            PaymentID = 12345,
            RandomNumber = 23,
            StationCode = 90001,
            TimeSpan = DateTime.Now,
            ViaOrderNumber = 100456,
            ViaRequestID = 1
        };
        var payload = JsonSerializer.Serialize(newSaleRequest).ToString();
        var request = new Request(payload, ContentType.Json);
        var responseData = container.PosService.Call(AppName.SpaceYPaymentSystem, ActionName.NewSale.ToString(), request);
        Assert.AreEqual(responseData.Status, MessageStatus.Success);
    }
}