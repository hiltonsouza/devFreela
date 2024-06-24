using DevFreela.Core.Services;
using DevFreela.Core.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private readonly string QUEUE_NAME = "Payments";
        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }
        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);
            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    //}public class PaymentService : IPaymentService
    //{
    //    private readonly IHttpClientFactory _httpClientFactory;
    //    private readonly string _paymentsBaseUrl;
    //    public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    //    {
    //        _httpClientFactory = httpClientFactory;
    //        _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
    //    }
    //    public async Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
    //    {
    //        // implementar logica de pagamento com gateway de pagamento
    //        var url = $"{_paymentsBaseUrl}/api/payments";
    //        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);
    //        var paymentInfoContent  = new StringContent(
    //            paymentInfoJson,
    //            Encoding.UTF8,
    //            "application/json"
    //            );

    //        var httpClient = _httpClientFactory.CreateClient("Payments");

    //        var response = await httpClient.PostAsync(url, paymentInfoContent);

    //        return response.IsSuccessStatusCode;
    //    }
    }
}
