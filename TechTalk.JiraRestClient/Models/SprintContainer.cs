using System;
using System.Collections.Generic;

namespace TechTalk.JiraRestClient.Models
{
    /// <summary>
    /// Container for multiple sprints results from the API
    /// </summary>
    internal class SprintContainer
    {
        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        public int startAt { get; set; }

        /// <summary>
        /// Gets or sets the total
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the boards.
        /// </summary>
        public List<Sprint> sprints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is last.
        /// </summary>
        public bool isLast { get; set; }
    }
}
