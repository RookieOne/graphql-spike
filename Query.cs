
using GraphQL.Types;
using GraphqlSpike.Function.GraphTypes;
using GraphqlSpike.Function.Resolvers;

namespace GraphqlSpike.Function
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            Name = "Query";
            Field<ListGraphType<ContactType>>("contacts", resolve: GetContact.Resolve);

            Field<ContactType>("contact",
                arguments: new QueryArguments(
                        new QueryArgument<IntGraphType> { Name = "id" }
                    ),
                resolve: GetContact.Resolve);
        }
    }
}