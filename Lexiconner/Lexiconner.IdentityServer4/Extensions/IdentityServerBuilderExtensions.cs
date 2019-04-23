﻿using IdentityServer4.Services;
using IdentityServer4.Stores;
using Lexiconner.IdentityServer4.Repository;
using Lexiconner.IdentityServer4.Store;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexiconner.IdentityServer4.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
        /// <summary>
        /// Adds IdentityServerConfig to DI
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddConfig(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IdentityServerConfig>();
            return builder;
        }

        /// <summary>
        /// Adds mongo repository (mongodb) for IdentityServer
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddMongoRepository(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IRepository, MongoRepository>();
            return builder;
        }

        /// <summary>
        /// Adds mongodb implementation for the "Asp Net Core Identity" part (saving user and roles)
        /// </summary>
        /// <remarks><![CDATA[
        /// Contains implemenations for
        /// - IUserStore<T>
        /// - IRoleStore<T>
        /// ]]></remarks>
        public static IIdentityServerBuilder AddMongoDbForAspIdentity<TIdentity, TRole>(this IIdentityServerBuilder builder, ApplicationSettings config) 
            where TIdentity : Microsoft.AspNetCore.Identity.MongoDB.IdentityUser 
            where TRole     : Microsoft.AspNetCore.Identity.MongoDB.IdentityRole
        {

            //User Mongodb for Asp.net identity in order to get users stored
            var client = new MongoClient(config.MongoDb.ConnectionString);
            var database = client.GetDatabase(config.MongoDb.Database);

            // Configure Asp Net Core Identity / Role to use MongoDB
            builder.Services.AddSingleton<IUserStore<TIdentity>>(x =>
            {
                var usersCollection = database.GetCollection<TIdentity>(MongoConfig.GetCollectionName<TIdentity>());
                IndexChecks.EnsureUniqueIndexOnNormalizedEmail(usersCollection);
                IndexChecks.EnsureUniqueIndexOnNormalizedUserName(usersCollection);
                return new UserStore<TIdentity>(usersCollection);
            });

            builder.Services.AddSingleton<IRoleStore<TRole>>(x =>
            {
                var rolesCollection = database.GetCollection<TRole>(MongoConfig.GetCollectionName<TRole>());
                IndexChecks.EnsureUniqueIndexOnNormalizedRoleName(rolesCollection);
                return new RoleStore<TRole>(rolesCollection);
            });
            builder.Services.AddIdentity<TIdentity, TRole>();

            return builder;
        }

        /// <summary>
        /// Configure ClientId / Secrets
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configurationOption"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddClients(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IClientStore, CustomClientStore>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();
            return builder;
        }


        /// <summary>
        /// Configure API  &  Resources
        /// Note: Api's have also to be configured for clients as part of allowed scope for a given clientID 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddIdentityApiResources(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IResourceStore, CustomResourceStore>();
            return builder;
        }

        /// <summary>
        /// Configure Grants
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddPersistedGrants(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IPersistedGrantStore, CustomPersistedGrantStore>();
            return builder;
        }

    }
}
