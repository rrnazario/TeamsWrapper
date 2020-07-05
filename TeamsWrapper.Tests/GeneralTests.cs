using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TeamsWrapper.Constants;
using TeamsWrapper.Model;

namespace TeamsWrapper.Tests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public async Task SendTeamsAlert()
        {
            const string UrlTeamsChannel = "UrlTeamsChannel";
            const string Term = "Microsoft Teams";

            Environment.SetEnvironmentVariable(UrlTeamsChannel, "PUT THE CHANNEL URL HERE");

            var teams = new TeamsMessage()
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
                            new TeamsTarget()
                            {
                                os = "default",
                                uri = $@"https://stackoverflow.com/search?q={Term.Replace(' ', '+')}"
                            }
                        }
                    }
                }
            };

            await teams.SendNotificationAsync();
        }
    }
}
