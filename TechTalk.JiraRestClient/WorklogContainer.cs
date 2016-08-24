﻿using System;
using System.Collections.Generic;

namespace TechTalk.JiraRestClient
{
    internal class WorklogContainer
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Worklog> worklogs { get; set; }
    }
}
