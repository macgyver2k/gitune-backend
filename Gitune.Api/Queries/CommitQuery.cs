using MediatR;
using System;
using System.Collections.Generic;

namespace Gitune.Api.Queries
{
    public record CommitQuery(        
        String Repository,
        String Branch
    ) 
    : IRequest<CommitResponse>;

    public record CommitResponse(
        IReadOnlyCollection<CommitInfo> Commits
    );
}