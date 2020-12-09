using Gitune.Api.GraphQL.Types;
using Gitune.Api.Queries;
using GraphQL;
using GraphQL.Types;
using MediatR;
using System;

namespace Gitune.Api.GraphQL
{
    public class GituneQuery : ObjectGraphType
    {
        public GituneQuery(IMediator mediator)
        {
            FieldAsync<ListGraphType<RepositoryType>>(
                "Repositories",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>()
                    {
                        Name = "Path"
                    }
                ),
                resolve: async context =>
                {
                    var path = context.GetArgument<String>( "Path" );

                    var result = await mediator.Send(
                        new RepositoryQuery( path )
                    );

                    return result.Repositories;
                });

            FieldAsync<ListGraphType<BranchType>>(
                "Branches",
                arguments: new QueryArguments(                                        
                    new QueryArgument<StringGraphType>()
                    {
                        Name = "Repository"
                    }
                ),
                resolve: async context =>
                {                       
                    var repository = context.GetArgument<String>("Repository");

                    var result = await mediator.Send(
                        new BranchQuery(repository)
                    );

                    return result.Branches;
                });

            FieldAsync<ListGraphType<CommityType>>(
                "Commits",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>()
                    {
                        Name = "Repository"
                    },
                    new QueryArgument<StringGraphType>()
                    {
                        Name = "Branch"
                    }
                ),
                resolve: async context =>
                {
                    var repository = context.GetArgument<String>("Repository");
                    var branch = context.GetArgument<String>("Branch");

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