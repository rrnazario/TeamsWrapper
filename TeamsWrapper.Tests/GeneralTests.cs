using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web;
using TeamsWrapper.Constants;
using TeamsWrapper.Extensions;
using TeamsWrapper.Model;

namespace TeamsWrapper.Tests
{
    [TestClass]
    public class GeneralTests
    {
        const string UrlTeamsChannel = "UrlTeamsChannel";
        const string Term = "Microsoft Teams";

        [TestMethod]
        public async Task SendTeamsAlert()
        {
            //You can use either an environment variable or pass it on TeamMessage constructor.
            Environment.SetEnvironmentVariable(UrlTeamsChannel, "https://outlook.office.com/webhook/SAMPLE@SAMPLE/IncomingWebhook/SAMPLE/SAMPLE");

            var teams = new TeamsMessage(UrlTeamsChannel)
            {
                title = $"Sample Title",
                text = $"Sample Text",
                potentialAction = new TeamsPotencialAction[]
                {
                    new TeamsPotencialAction()
                    {
                        type = TeamsMessageConstants.TeamsPotencialActionType.OpenUri,
                        name = "Search it on StackOverflow",
                        targets = new TeamsTarget[]
                        {
                            new TeamsTarget
                            {
                                uri = HttpUtility.UrlEncode($@"https://stackoverflow.com/search?q={Term}")
                            }
                        }
                    }
                }
            };

            await teams.SendNotificationAsync();
        }

        [TestMethod]
        public async Task SendTeamsAlertUsingExtensions()
        {
            var teams = new TeamsMessage(UrlTeamsChannel)
                .AddLink("Search it on StackOverflow", HttpUtility.UrlEncode($@"https://stackoverflow.com/search?q={Term}"));

            await teams.SendNotificationAsync();
        }
    }
}
