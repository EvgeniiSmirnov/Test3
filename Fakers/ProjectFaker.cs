using Bogus;
using Test3.Models;

namespace Test3.Fakers;

public class ProjectFaker : Faker<Project>
{
    public ProjectFaker()
    {
        RuleFor(x => x.Name, f => "Project " + f.Random.AlphaNumeric(10));
        RuleFor(x => x.Announcement, f => f.Random.Words(5));
        RuleFor(x => x.SuiteMode, f => f.Random.Number(1, 3));
        RuleFor(x => x.ShowAnnouncement, f => f.Random.Bool());
    }
}