using System.Net;
using Test3.Models;

namespace Test3.Services;

public interface ISectionServices
{
    Task<Section> AddSection(string projectId, Section section);
    HttpStatusCode DeleteSection(string sectionId);
}