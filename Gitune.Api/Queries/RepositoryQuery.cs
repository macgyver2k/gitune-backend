using Gitune.Api.GraphQL;
using LibGit2Sharp;
using MediatR;
using System;
using System.Collections.Generic;

namespace Gitune.Api.Queries
{
    public record RepositoryQuery(
        String Path
    ) : IRequest<RepositoryResponse>;    
    
    public record RepositoryResponse(
        IReadOnlyCollection<RepositoryInfo> Repositories
    );
}