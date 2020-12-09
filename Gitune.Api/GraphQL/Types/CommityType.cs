using Gitune.Api.Queries;
using GraphQL.Types;

namespace Gitune.Api.GraphQL.Types
{
    public class CommityType : ObjectGraphType<CommitInfo>
    {       
        public CommityType()
        {
            Field(commit => commit.Sha1);
            Field(commit => commit.Message);
            Field(commit => commit.Timestamp);
            Field(commit => commit.AuthorEmail);
            Field(commit => commit.AuthorName);
            Field(commit => commit.Parents);
        }
    }
}