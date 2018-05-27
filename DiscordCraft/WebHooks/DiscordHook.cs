// ---------------------------------------------------------
// Copyrights (c) 2014-2018 LeafyDev 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DiscordCraft.WebHooks
{
    internal static class DiscordHook
    {
        private const string _webhookUrl =
            "https://discordapp.com/api/webhooks/448490925472219146/crOKy93rJkoEJeUGai5HJ_wHnCSZJ6IYTooVnbVuVbl3U0Sd0hPFeuCp4KCoCG8iONsE";

        public const string _avatarUrl =
            "https://static.planetminecraft.com/files/resource_media/screenshot/1743/diamond-steve-1508797542.jpg";

        private static HttpClient _httpClient;

        public static async Task Send(WebHookMessage msg)
        {
            _httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");
            var ret = await _httpClient.PostAsync(_webhookUrl, content);

            if (!ret.IsSuccessStatusCode)
            {
                Console.WriteLine($"{ret.StatusCode}: {ret.ReasonPhrase}");
            }
        }
    }
}