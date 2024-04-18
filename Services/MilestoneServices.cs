using System.Net;
using RestSharp;
using Test3.Clients;
using Test3.Models;

namespace Test3.Services;

public class MilestoneServices : IMilestoneServices, IDisposable
{
    private readonly RestClientExtended _client;

    public MilestoneServices(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Milestone> GetMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestoneId}")
            .AddUrlSegment("milestoneId", milestoneId);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestone> AddMilestone(string projectId, Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestone> UpdateMilestone(Milestone milestone, Milestone milestoneUpdate)
    {
        var request = new RestRequest("index.php?/api/v2/update_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestone.ID)
            .AddJsonBody(milestoneUpdate);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public HttpStatusCode DeleteMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestoneId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public Task<RestResponse> AddMilstoneForFullCheck(string projectId, Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync(request);
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}