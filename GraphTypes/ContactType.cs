using System.Linq;
using GraphQL.Types;
using GraphqlSpike.Function.Models;

namespace GraphqlSpike.Function.GraphTypes
{
    public class ContactType : ObjectGraphType<Contact>
    {
        public ContactType()
        {
            Name = "Contact";
            Description = "A contact.";
            Field("name", c => c.Name, nullable: true).Description("The name of the contact.");

            Field<ListGraphType<InterestType>>(
                "interests",
                resolve: context =>
                {
                    var interests = new Interest[] {
                        new Interest { ID = 1, Percent = 30.0F, InterestType = "WI", ContactId = 1 },
                        new Interest { ID = 2, Percent = 10.0F, InterestType = "RI", ContactId = 1 },
                        new Interest { ID = 3, Percent = 50.0F, InterestType = "WI", ContactId = 2 }
                    };

                    var contact = context.Source;

                    return interests.Where<Interest>(i => i.ContactId == contact.ID);
                });
        }
    }
}
