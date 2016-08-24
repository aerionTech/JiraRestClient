using System;
using System.Collections.Generic;

namespace TechTalk.JiraRestClient.Models
{
    /// <summary>
    /// COntainer for multiple board results from the API
    /// </summary>
    internal class BoardContainer
    {
        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        public int startAt { get; set; }

        /// <summary>
        /// Gets or sets the maximum results.
        /// </summary>
        public int maxResults { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the boards.
        /// </summary>
        public List<Board> boards { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is last.
        /// </summary>
        public bool isLast { get; set; }
    }
}
