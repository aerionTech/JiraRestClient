using System;

namespace TechTalk.JiraRestClient
{
    public class Worklog
    {
        public string id { get; set; }
        public string issueId { get; set; }
        public string comment { get; set; }
        public long timeSpentSeconds { get; set; }
        public JiraUser author { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string started { get; set; }
    }
}
