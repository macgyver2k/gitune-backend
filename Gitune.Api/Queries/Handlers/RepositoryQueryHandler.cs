using Gitune.Api.GraphQL;
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
    public class RepositoryQueryHandler : 
           IRequestHandler<RepositoryQuery, RepositoryResponse>
    {
        public async Task<RepositoryResponse> Handle(
            RepositoryQuery request, 
            CancellationToken cancellationToken
        )
        {            
            var directories = Directory.EnumerateDirectories( 
                request.Path
            );

            var repositories = await Task
                .WhenAll(directories
                    .Select(
                        LoadRepository
                    )
                );

            return new RepositoryResponse( 
                repositories.Where( info => info != null ).ToList()
            );
        }

        private async Task<RepositoryInfo> LoadRepository(
            String directory
        )
        {
            if( !Repository.IsValid( directory ) )
            {
                return await Task.FromResult((RepositoryInfo)null);
            }            
            
            var result = new RepositoryInfo(
                directory                
            );
            
            return await Task.FromResult(
                result
            );
        }
    }
}
