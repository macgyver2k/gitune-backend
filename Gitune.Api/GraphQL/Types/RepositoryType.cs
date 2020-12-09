using Gitune.Api.Queries;
using GraphQL.Types;
using GraphQL.Types.Relay.DataObjects;
using LibGit2Sharp;
using MediatR;

namespace Gitune.Api.GraphQL.Types
{
    public class RepositoryType : ObjectGraphType<RepositoryInfo>
    {
        public RepositoryType()
        {
            Field(repository => repository.Path);            
        }
    }
}