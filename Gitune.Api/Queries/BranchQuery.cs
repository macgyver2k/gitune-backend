using MediatR;
using System;
using System.Collections.Generic;

namespace Gitune.Api.Queries
{
    public record BranchQuery(        
        string Repository
    ) : IRequest<BranchResponse>;

    public record BranchResponse(
        IReadOnlyCollection<BranchInfo> Branches
    );
}