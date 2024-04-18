using Bogus;
using NLog;
using Test3.Models;

namespace Test3.Tests;

public class ProjectTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    // для связанных тестов выносим сущность в класс, чтобы сюда подтягивалась изменния после каждго теста
    private Project _project = null;

    [Test]
    [Order(1)]
    public void AddProjectTest()
    {
        _project = new Project
        {
            Name = "WP Test 1",
            Announcement = "Some description!!!",
            ShowAnnouncement = true,
            SuiteMode = 1
        };

        var actualProject = ProjectService!.AddProject(_project);

        // Блок проверок
        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Result.Name, Is.EqualTo(_project.Name));
            Assert.That(actualProject.Result.Announcement, Is.EqualTo(_project.Announcement));
            Assert.That(actualProject.Result.SuiteMode, Is.EqualTo(_project.SuiteMode));
        });

        _project = actualProject.Result;
        _logger.Info(_project.ToString());
    }
}