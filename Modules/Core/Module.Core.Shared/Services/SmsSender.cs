using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Module.Core.Shared.Options;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Module.Core.Shared
{
    public class SmsSender : ISmsSender
    {
        private readonly SmsOptions _smsOptions;
        private readonly ILogger<SmsSender> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public SmsSender(
            ILogger<SmsSender> logger,
            IOptionsMonitor<SmsOptions> options,
            IHttpClientFactory clientFactory)
        {
            _smsOptions = options.CurrentValue;
            _logger = logger;
            _clientFactory = clientFactory;
        }
      
        public async Task SendAsync(string to, string message)
        {
            if(_smsOptions != null && _smsOptions.Enabled)
            {
                var url = $"{_smsOptions.Url}?api_key={_smsOptions.ApiKey}&type=text&contacts={to}&senderid={_smsOptions.SenderId}&msg={message}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);
            }
        }
    }
}
