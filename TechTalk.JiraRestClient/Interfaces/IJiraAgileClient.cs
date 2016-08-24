using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.JiraRestClient.Models;

namespace TechTalk.JiraRestClient.Interfaces
{
    /// <summary>
    /// Jira Agile Client Interface
    /// </summary>
    public interface IJiraAgileClient
    {
        /// <summary>
        /// Gets all boards from the API.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="JiraClientException">Could not load boards</exception>
        IEnumerable<Board> GetBoards();
    }
}
