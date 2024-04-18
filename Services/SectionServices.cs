using System.Net;
using RestSharp;
using Test3.Clients;
using Test3.Models;

namespace Test3.Services;

public class SectionServices : ISectionServices, IDisposable
{
    private readonly RestClientExtended _client;

    public SectionServices(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Section> AddSection(string projectId, Section section)
    {
        var request = new RestRequest("index.php?/api/v2/add_section/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(section);

        return _client.ExecuteAsync<Section>(request);
    }

    public HttpStatusCode DeleteSection(string sectionId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_section/{section_id}", Method.Post)
            .AddUrlSegment("section_id", sectionId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}