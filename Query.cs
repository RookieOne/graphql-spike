
using GraphQL.Types;
using System.Linq;

namespace GraphqlSpike.Function
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ContactType : ObjectGraphType<Contact>
    {
        public ContactType()
        {
            Name = "Contact";
            Description = "A contact.";
            Field("name", c => c.Name, nullable: true).Description("The name of the contact.");
        }
    }

    public class Query : ObjectGraphType
    {
        public Query()
        {
            Name = "Query";
            Field<ListGraphType<ContactType>>(
              "contacts",
              resolve: context =>
              {
                  var contacts = new Contact[] { new Contact { Name = "Han Solo" }, new Contact { Name = "Luke Skywalker" } };
                  return contacts;
              });

            Field<ContactType>(
                "contact",
                arguments: new QueryArguments(
                        new QueryArgument<IntGraphType> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = (int)context.Arguments["id"].Value;

                    var contacts = new Contact[] { new Contact { ID = 1, Name = "Han Solo" }, new Contact { ID = 2, Name = "Luke Skywalker" } };

                    var contact = contacts.SingleOrDefault<Contact>(c => c.ID == id);

                    return contact;
                });
        }
    }
}