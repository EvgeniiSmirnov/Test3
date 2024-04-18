using OpenQA.Selenium;
using Test3.Models;
using Test3.Pages.ProjectPages;
using Test3.Steps;

namespace Test3.Steps;

public class ProjectSteps(IWebDriver driver) : BaseStep(driver)
{
    public ProjectsPage AddProject(Project project)
    {
        AddProjectPage = new AddProjectPage(Driver, true);

        AddProjectPage.NameInput.SendKeys(project.Name);
        AddProjectPage.AnnouncementTextArea.SendKeys(project.Announcement);
        AddProjectPage.TypeRadioButton.SelectByIndex(project.SuiteMode);
        if (project.ShowAnnouncement != null) AddProjectPage.ShowAnnouncementCheckBox.Click();

        AddProjectPage.AddButton.Click();

        return new ProjectsPage(Driver);
    }
}