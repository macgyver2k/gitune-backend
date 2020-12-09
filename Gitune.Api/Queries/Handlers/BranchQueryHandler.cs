using LibGit2Sharp;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gitune.Api.Queries.Handlers
{
    public class BranchQueryHandler : IRequestHandler<BranchQuery, BranchResponse>
    {
        public async Task<BranchResponse> Handle(
            BranchQuery request, 
            CancellationToken cancellationToken
        )
        {
            if ( !Repository.IsValid(request.Repository) )
            {
                return await Task.FromResult( 
                    new BranchResponse( 
                        new List<BranchInfo>() 
                    )
                );
            }

            var repository = new Repository(
                request.Repository
            );            

            var branchInfos = repository
                .Branches
                .Select(branch =>
                   new BranchInfo(
                       request.Repository,
                       branch.FriendlyName,
                       branch.CanonicalName
                   )
                )
                .ToList();

            return await Task.FromResult(
                new BranchResponse(
                    branchInfos
                )
            );
        }
    }
}
