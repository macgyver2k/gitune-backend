using Gitune.Api.Queries;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace Gitune.Api.GraphQL.Types
{
    public class BranchType : ObjectGraphType<BranchInfo>
    {
        public BranchType( IMediator mediator )
        {
            Field(branch => branch.Name);
            Field(branch => branch.FullName);

            FieldAsync<ListGraphType<CommityType>>(
                "Commits",                
                resolve: async context =>
                {
                    var repository = context.Source.Repository;
                    var branch = context.Source.FullName;

                    var result = await mediator.Send(
                        new CommitQuery(
                            repository,
                            branch
                        )
                    );

                    return result.Commits;
                });
        }
    }
}