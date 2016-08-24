using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient.Models
{
    /// <summary>
    /// Board Model
    /// </summary>
    public class Board
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
