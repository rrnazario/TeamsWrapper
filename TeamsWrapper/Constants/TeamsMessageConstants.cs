using System;
using System.Collections.Generic;
using System.Text;

namespace TeamsWrapper.Constants
{
    public class TeamsMessageConstants
    {
        /// <summary>
        /// Default schema
        /// </summary>
        public const string Context = "https://schema.org/extensions";
        public const string MessageCard = "messageCard";
        /// <summary>
        /// Default theme color
        /// </summary>
        public const string ThemeColor = "0072C6";
        public static readonly string UrlTeamsChannel = Environment.GetEnvironmentVariable("UrlTeamsChannel");

        public class TeamsPotencialActionType
        {
            /// <summary>
            /// Open a text area to be sent some information
            /// </summary>
            public const string ActionCard = "actionCard";
            /// <summary>
            /// Open an URL out of Teams
            /// </summary>
            public const string OpenUri = "openUri";
        }
    }
}
