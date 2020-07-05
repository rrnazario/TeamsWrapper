using System;
using System.Collections.Generic;
using System.Text;

namespace TeamsWrapper.Model
{
    public class TeamsPotencialAction
    {
        public string @type { get; set; }
        public string name { get; set; }
        public TeamsInput[] inputs { get; set; }
        public TeamsAction[] actions { get; set; }
        public TeamsTarget[] targets { get; set; }
    }
}
