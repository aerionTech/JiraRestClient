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
        /// <param name="startIndex">The starting index of the returned boards. Base index: 0.</param>
        /// <param name="maxResults">The maximum number of boards to return per page. Default: 50.</param>
        /// <returns>
        /// Returns a list of boards
        /// </returns>
        /// <exception cref="JiraClientException">Could not load boards</exception>
        IEnumerable<Board> GetBoards(int startIndex = 0, int maxResults = 50);

        /// <summary>
        /// Gets sprints within a board.
        /// </summary>
        /// <param name="boardId">The board identifier.</param>
        /// <param name="startIndex">The starting index of the returned boards. Base index: 0.</param>
        /// <param name="maxResults">The maximum number of boards to return per page. Default: 50.</param>
        /// <returns>
        /// Returns a list of Sprints for a given board
        /// </returns>
        /// <exception cref="JiraClientException">Could not load sprints</exception>
        IEnumerable<Sprint> GetSprintsWithinBoard(string boardId, int startIndex = 0, int maxResults = 50);

        /// <summary>
        /// Gets sprints within a board.
        /// </summary>
        /// <typeparam name="TIssueFields">The type of the issue fields.</typeparam>
        /// <param name="sprintId">The sprint identifier.</param>
        /// <param name="jqlQuery">The JQL query.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="startIndex">The starting index of the returned boards. Base index: 0.</param>
        /// <param name="maxResults">The maximum number of boards to return per page. Default: 50.</param>
        /// <returns>
        /// Returns a list of Sprints for a given board
        /// </returns>
        /// <exception cref="JiraClientException">Could not load sprints</exception>
        IEnumerable<Issue<TIssueFields>> GetIssuesWithinSprint<TIssueFields>(string sprintId, string jqlQuery, string[] fields, int startIndex = 0, int maxResults = 50) where TIssueFields : IssueFields, new();
    }
}
