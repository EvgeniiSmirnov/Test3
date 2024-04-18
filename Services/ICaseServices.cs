using System.Net;
using Test3.Models;

namespace Test3.Services;

public interface ICaseServices
{
    Task<Case> GetCase(string caseId);
    Task<Case> AddCase(string sectionId, Case newCase);
    Task<Case> UpdateCase(Case caseOriginal, Case caseUpdate);
    HttpStatusCode MoveCasesToSection(string sectionId, string newSectionId, string caseIds);
    HttpStatusCode DeleteCase(string caseId);
}