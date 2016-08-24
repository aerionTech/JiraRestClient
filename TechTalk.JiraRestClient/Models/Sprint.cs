using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient.Models
{
    /// <summary>
    /// Sprint Model
    /// </summary>
    public class Sprint
    {
        public string id { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate{ get; set; }
        public string completeDate { get; set; }
        public string originBoardId { get; set; }
    }
}
