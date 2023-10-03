using System.Linq;
using TeamsWrapper.Constants;
using TeamsWrapper.Model;

namespace TeamsWrapper.Extensions
{
    public static class TeamsMessageExtension
    {
        /// <summary>
        /// Add a button that contains an url to current teams message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="text">Text that will appear at button</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static TeamsMessage AddLink(this TeamsMessage message, string text, string url)
        {
            if (message.potentialAction == null)
                message.potentialAction = new TeamsPotencialAction[] { };

            var potential = message.potentialAction.ToList();

            potential.Add(new TeamsPotencialAction()
            {
                type = TeamsMessageConstants.TeamsPotencialActionType.OpenUri,
                name = text,
                targets = new TeamsTarget[]
                        {
                            new()         
                            {
                                uri = url
                            }
                        }
            });

            message.potentialAction = potential.ToArray();

            return message;
        }
    }
}
