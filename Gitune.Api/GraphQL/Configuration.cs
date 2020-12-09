using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gitune.Api.GraphQL
{
    public static class Configuration
    {
        public static IServiceCollection AddCustomGraphQL(this IServiceCollection services)
        {
            services
                .AddSingleton<GituneSchema>()
                .AddGraphQL()
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(GituneSchema));

            return services;
        }

        public static IApplicationBuilder UseCustomGraphQL(this IApplicationBuilder app)
        {
            // this is required for websockets support
            app.UseWebSockets();

            // use websocket middleware for ChatSchema at path /graphql
            app.UseGraphQLWebSockets<GituneSchema>("/graphql");

            // use HTTP middleware for ChatSchema at path /graphql
            app.UseGraphQL<GituneSchema>("/graphql");

            // use graphiQL middleware at default url /ui/graphiql
            app.UseGraphiQLServer(new GraphiQLOptions());

            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use altair middleware at default url /ui/altair
            app.UseGraphQLAltair(new GraphQLAltairOptions());

            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());

            return app;
        }
    }
}