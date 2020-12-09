using System;

namespace Gitune.Api.Queries
{
    public record BranchInfo(
        String Repository,
        String Name, 
        String FullName
    );
}