using System.Linq;
using GraphQL;
using GraphqlSpike.Function.Models;

namespace GraphqlSpike.Function.Resolvers
{
    public class GetContact
    {
        public static Contact Resolve(IResolveFieldContext context)
        {
            var id = (int)context.Arguments["id"].Value;

            var contacts = new Contact[] {
                        new Contact { ID = 1, Name = "Han Solo" },
                        new Contact { ID = 2, Name = "Luke Skywalker" }
                    };

            var contact = contacts.SingleOrDefault<Contact>(c => c.ID == id);

            return contact;
        }
    }
}