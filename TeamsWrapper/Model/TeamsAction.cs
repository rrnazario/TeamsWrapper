using System;
using System.Collections.Generic;
using System.Text;

namespace TeamsWrapper.Model
{
    public class TeamsAction
    {
        public string @type { get; set; }
        public string name { get; set; }
        public bool isPrimary { get; set; }
        public string target { get; set; }
    }
}
