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

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }).Replace("context", "@context").Replace("type", "@type");

        public async Task SendNotificationAsync() => await _client.PostAsync(TeamsMessageConstants.UrlTeamsChannel, new StringContent(ToString()));
    }
}
