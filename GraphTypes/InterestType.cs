
using GraphQL.Types;
using GraphqlSpike.Function.Models;

namespace GraphqlSpike.Function.GraphTypes
{
    public class InterestType : ObjectGraphType<Interest>
    {
        public InterestType()
        {
            Name = "Interest";
            Description = "An interest.";
            Field("percent", i => i.Percent, nullable: true).Description("The percent on interest.");
            Field("interestType", i => i.InterestType, nullable: true).Description("The interest type of interest.");
        }
    }
}
