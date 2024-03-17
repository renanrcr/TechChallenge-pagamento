using Domain.Adapters.MercadoPagoQrCode;
using Domain.Configuration;
using Domain.Entities.MercadoPagoQrCode;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Repositories.MercadoPagoQrCode
{
    public class MercadoPagoRequestRepository : IMercadoPagoRequestRepository
    {
        private readonly SettingsMercadoPago _settingsMercadoPago;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public MercadoPagoRequestRepository(IOptions<SettingsMercadoPago> optionsSettingsMercadoPago)
        {
            _settingsMercadoPago = optionsSettingsMercadoPago.Value;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<string?> ObterQrCode(MercadoPagoOrder orderDto)
        {
            orderDto.AtualizarUrlNotificacao(_settingsMercadoPago.Notification_url);
            var json = JsonSerializer.Serialize(orderDto, _jsonSerializerOptions);

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{_settingsMercadoPago.MercadoPagoUserId}/pos/{_settingsMercadoPago.External_Pos_Id}/qrs");
            request.Headers.Add("Authorization", $"Bearer {_settingsMercadoPago.AccesToken}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await new HttpClient().SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var qrResponse = JsonSerializer.Deserialize<MercadoPagoQrResponse>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
                return (qrResponse ?? new MercadoPagoQrResponse()).Qr_data;
            }

            return string.Empty;
        }

        public async Task<MercadoPagoOrderStatus> ObterStatusPedido(long id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.mercadopago.com/merchant_orders/{id}");
            request.Headers.Add("Authorization", $"Bearer {_settingsMercadoPago.AccesToken}");

            using var response = await new HttpClient().SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var statusResponse = JsonSerializer.Deserialize<MercadoPagoOrderStatus>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
                return statusResponse ?? new MercadoPagoOrderStatus();
            }

            return new MercadoPagoOrderStatus();
        }
    }

}
