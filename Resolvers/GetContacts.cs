using GraphQL;
using GraphqlSpike.Function.Models;

namespace GraphqlSpike.Function.Resolvers
{
    public class GetContacts
    {
        public static Contact[] Resolve(IResolveFieldContext context)
        {
            var contacts = new Contact[] {
                new Contact {ID = 1, Name = "Han Solo" },
                new Contact { ID = 2, Name = "Luke Skywalker" }
                };

            return contacts;
        }
    }
}