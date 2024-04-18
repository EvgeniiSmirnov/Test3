using NLog;
using Test3.Clients;
using System.Net;
using Test3.Services;
using Test3.Models;

namespace Test3.Tests.API;

public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectService? ProjectService;
    protected MilestoneServices? MilestoneServices;
    protected SectionServices? SectionServices;
    protected CaseServices? CaseServices;


    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
        MilestoneServices = new MilestoneServices(restClient);
        SectionServices = new SectionServices(restClient);
        CaseServices = new CaseServices(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectService.Dispose();
        MilestoneServices.Dispose();
        SectionServices.Dispose();
        CaseServices.Dispose();
    }

    public Project CreateBaseProject(Project project)
    {
        var actualProject = ProjectService!.AddProject(project);

        _logger.Info(actualProject.Result.ToString());
        return actualProject.Result;
    }

    public HttpStatusCode DeleteBaseProject(string id)
    {
        return ProjectService!.DeleteProject(id);
    }

    public Section CreateBaseSection(string projectId, Section section)
    {
        var actualSection = SectionServices!.AddSection(projectId, section);

        _logger.Info(actualSection.Result.ToString());
        return actualSection.Result;
    }
}