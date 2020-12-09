using GraphQL.Types;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Gitune.Api.GraphQL
{
    public class GituneSchema : Schema
    {
        public GituneSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetService<GituneQuery>();
        }
    }
}