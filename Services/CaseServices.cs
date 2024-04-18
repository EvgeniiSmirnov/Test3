using System.Net;
using RestSharp;
using Test3.Clients;
using Test3.Models;

namespace Test3.Services;

public class CaseServices : ICaseServices, IDisposable
{
    private readonly RestClientExtended _client;

    public CaseServices(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Case> GetCase(string caseId)
    {
        var request = new RestRequest("index.php?/api/v2/get_case/{case_id}")
            .AddUrlSegment("case_id", caseId);

        return _client.ExecuteAsync<Case>(request);
    }

    public Task<Case> AddCase(string sectionId, Case newCase)
    {
        var request = new RestRequest("index.php?/api/v2/add_case/{section_id}", Method.Post)
            .AddUrlSegment("section_id", sectionId)
            .AddJsonBody(newCase);

        return _client.ExecuteAsync<Case>(request);
    }

    public Task<Case> UpdateCase(Case caseOriginal, Case caseUpdate)
    {
        var request = new RestRequest("index.php?/api/v2/update_case/{case_id}", Method.Post)
            .AddUrlSegment("case_id", caseOriginal.Id)
            .AddJsonBody(caseUpdate);

        return _client.ExecuteAsync<Case>(request);
    }

    public HttpStatusCode MoveCasesToSection(string sectionId, string newSectionId, string caseIds)
    {
        var request = new RestRequest("index.php?/api/v2/move_cases_to_section/{section_id}", Method.Post)
            .AddUrlSegment("section_id", sectionId)
            .AddJsonBody("{" +
                         $"\"section_id\": {newSectionId}," +
                         $"\"case_ids\": [{caseIds}]" +
                         "}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public HttpStatusCode DeleteCase(string caseId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_case/{case_id}", Method.Post)
            .AddUrlSegment("case_id", caseId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}