using System;
using System.Collections.Generic;

namespace Gitune.Api.Queries
{
    public record CommitInfo(
        String Sha1,
        String Message,
        DateTimeOffset Timestamp,
        String AuthorEmail,
        String AuthorName,
        IReadOnlyCollection<String> Parents
    );
}