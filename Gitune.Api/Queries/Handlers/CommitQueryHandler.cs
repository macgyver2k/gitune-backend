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
    public class CommitQueryHandler : 
        IRequestHandler<CommitQuery, CommitResponse>
    {
        public async Task<CommitResponse> Handle(
            CommitQuery request,
            CancellationToken cancellationToken
        )
        {
            if (!Repository.IsValid(request.Repository))
            {
                return await Task.FromResult(
                    new CommitResponse(
                        new List<CommitInfo>()
                    )
                );
            }

            var repository = new Repository(
                request.Repository
            );

            var filter = new CommitFilter()
            {
                SortBy = CommitSortStrategies.Topological
            };

            var commitInfos = repository
                .Commits
                .QueryBy(
                    filter
                )
                .Select(
                    commit => new CommitInfo(
                        commit.Sha,
                        commit.Message,
                        commit.Author.When,
                        commit.Author.Email,
                        commit.Author.Name,
                        commit.Parents.Select(parent => parent.Sha).ToList()
                    )
                )
                .ToList();

            return await Task.FromResult(
                new CommitResponse(
                    commitInfos
                )
            );
        }
    }
}
