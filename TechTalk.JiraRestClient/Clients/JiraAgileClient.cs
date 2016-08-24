using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using TechTalk.JiraRestClient.Interfaces;
using TechTalk.JiraRestClient.Models;

namespace TechTalk.JiraRestClient.Clients
{
    /// <summary>
    /// Concrete implementation of the IJiraAgileClient
    /// </summary>
    /// <seealso cref="IJiraAgileClient" />
    public class JiraAgileClient : IJiraAgileClient
    {
        /// <summary>
        /// The username
        /// </summary>
        private readonly string username;

        /// <summary>
        /// The password
        /// </summary>
        private readonly string password;

        /// <summary>
        /// The deserializer
        /// </summary>
        private readonly JsonDeserializer deserializer;

        /// <summary>
        /// The base API URL for the Jira Agile API
        /// </summary>
        private readonly string baseApiUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="JiraAgileClient"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public JiraAgileClient(string baseUrl, string username, string password)
        {
            this.username = username;
            this.password = password;

            baseApiUrl = new Uri(new Uri(baseUrl), "rest/agile/1.0/").ToString();
            deserializer = new JsonDeserializer();
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private RestRequest CreateRequest(Method method, String path)
        {
            var request = new RestRequest { Method = method, Resource = path, RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", username, password))));
            return request;
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private IRestResponse ExecuteRequest(RestRequest request)
        {
            var client = new RestClient(baseApiUrl);
            return client.Execute(request);
        }

        /// <summary>
        /// Asserts the status.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="status">The status.</param>
        /// <exception cref="JiraClientException">
        /// Transport level error:  + response.ErrorMessage
        /// or
        /// JIRA returned wrong status:  + response.StatusDescription
        /// </exception>
        private void AssertStatus(IRestResponse response, HttpStatusCode status)
        {
            if (response.ErrorException != null)
                throw new JiraClientException("Transport level error: " + response.ErrorMessage, response.ErrorException);
            if (response.StatusCode != status)
                throw new JiraClientException("JIRA returned wrong status: " + response.StatusDescription, response.Content);
        }

        /// <summary>
        /// Gets all boards from the API.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="JiraClientException">Could not load boards</exception>
        public IEnumerable<Board> GetBoards()
        {
            try
            {
                var path = "board";
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var data = deserializer.Deserialize<BoardContainer>(response);
                return data.boards ?? Enumerable.Empty<Board>();
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetBoards() error: {0}", ex);
                throw new JiraClientException("Could not load boards", ex);
            }
        }
    }
}
