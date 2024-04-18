using Bogus;
using Test3.Models;

namespace Test3.Fakers;

public class SectionsFaker : Faker<Section>
{
    public SectionsFaker()
    {
        RuleFor(x => x.Name, f => f.Random.AlphaNumeric(15));
        RuleFor(x => x.Description, f => f.Random.AlphaNumeric(5));
    }
}