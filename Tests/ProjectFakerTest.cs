using System.Diagnostics;
using Bogus;
using NLog;
using Test3.Fakers;
using Test3.Models;

namespace Test3.Tests;

public class ProjectFakerTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project;
    private static Faker<Project> Project => new ProjectFaker();

    [Test]
    [Order(1)]
    public void AddProjectTest()
    {
        _project = Project.Generate();

        var actualProject = ProjectService!.AddProject(_project);

        // Блок проверок
        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Result.Name, Is.EqualTo(_project.Name));
            Assert.That(actualProject.Result.SuiteMode, Is.EqualTo(_project.SuiteMode));
        });

        _project = actualProject.Result;
        _logger.Info(_project.ToString);
    }

    [Test]
    [Order(2)]
    public void DeleteProjectTest()
    {
        Debug.Assert(ProjectService != null, nameof(ProjectService) + " != null");
        _logger.Info(ProjectService.DeleteProject(_project.Id.ToString()));
    }
}