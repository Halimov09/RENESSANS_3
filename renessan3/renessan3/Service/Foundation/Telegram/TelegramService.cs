using System.Net.Http;
using System.Threading.Tasks;

namespace renessan3.Service.Foundation.Telegram
{
    public class TelegramService
    {
        private readonly HttpClient _httpClient;

        public TelegramService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMessageAsync(string chatId, string message)
        {
            string botToken = "7845781687:AAFCT8XzM8ZhKQkZJT2pKbtUERvuKn2VETc";
            string url = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={message}";

            await _httpClient.GetAsync(url);
        }
    }
}
