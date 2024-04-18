using Bogus;
using Test3.Models;

namespace Test3.Fakers;

public class CaseFaker : Faker<Case>
{
    public CaseFaker()
    {
        RuleFor(x => x.Title, f => f.Random.AlphaNumeric(20));
    }
}