using System.Net;
using Test3.Models;

namespace Test3.Services;

public interface IMilestoneServices
{
    Task<Milestone> GetMilestone(string milestoneId);
    Task<Milestone> AddMilestone(string projectId, Milestone milestone);
    Task<Milestone> UpdateMilestone(Milestone milestone, Milestone milestoneUpdate);
    HttpStatusCode DeleteMilestone(string milestoneId);
}