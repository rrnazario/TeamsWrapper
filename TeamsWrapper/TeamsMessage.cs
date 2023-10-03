using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeamsWrapper.Constants;
using TeamsWrapper.Model;

namespace TeamsWrapper
{
    public class TeamsMessage
    {
        public string @context { get; set; } = TeamsMessageConstants.Context;
        public string @type { get; set; } = TeamsMessageConstants.MessageCard;
        public string themeColor { get; set; } = TeamsMessageConstants.ThemeColor;
        public string title { get; set; }
        public string text { get; set; }
        public TeamsPotencialAction[] potentialAction { get; set; }

        private readonly HttpClient _client;

        private string _urlTeamsChannel;
        private string UrlTeamsChannel
        {
            get
            {
                return string.IsNullOrEmpty(_urlTeamsChannel) ? TeamsMessageConstants.UrlTeamsChannel : _urlTeamsChannel;
            }

            set { }
        }

        [JsonConstructor]
        public TeamsMessage()
        {
            _client = new HttpClient();
        }

        public TeamsMessage(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public TeamsMessage(string urlTeamsChannel) 
            : this()
        {
            _urlTeamsChannel = urlTeamsChannel;
        }

        public override string ToString()
        {
            var termsPutAt = new string[] { "context", "type" };

            var result = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            foreach (var item in termsPutAt)
                result = result.Replace(item, $"@{item}");

            return result;
        }

        public async Task SendNotificationAsync() => await _client.PostAsync(UrlTeamsChannel, new StringContent(ToString()));
    }
}
