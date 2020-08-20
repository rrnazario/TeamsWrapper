using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeamsWrapper.Constants;

namespace TeamsWrapper.Model
{
    public class TeamsMessage
    {
        public string @context { get; set; } = TeamsMessageConstants.Context;
        public string @type { get; set; } = TeamsMessageConstants.MessageCard;
        public string themeColor { get; set; } = TeamsMessageConstants.ThemeColor;
        public string title { get; set; }
        public string text { get; set; }
        public TeamsPotencialAction[] potentialAction { get; set; }

        private readonly HttpClient _client = new HttpClient();

        private string _urlTeamsChannel;
        private string UrlTeamsChannel
        {
            get
            {
                return string.IsNullOrEmpty(TeamsMessageConstants.UrlTeamsChannel) ? _urlTeamsChannel : TeamsMessageConstants.UrlTeamsChannel;
            }

            set { }
        }

        public TeamsMessage() { }

        public TeamsMessage(string urlTeamsChannel)
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
