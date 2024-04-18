using Bogus;
using Test3.Models;

namespace Test3.Fakers;

public class MilestoneFaker : Faker<Milestone>
{
    public MilestoneFaker()
    {
        RuleFor(x => x.Name, f => f.Random.AlphaNumeric(20));
        RuleFor(x => x.Description, f => f.Random.AlphaNumeric(15));
    }
}