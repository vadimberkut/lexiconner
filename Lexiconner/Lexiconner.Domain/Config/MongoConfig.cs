﻿using IdentityServer4.Models;
using Lexiconner.Domain.Entitites;
using Lexiconner.Domain.Entitites.Cache;
using Lexiconner.Domain.Entitites.IdentityModel;
using Lexiconner.Domain.Entitites.Testing;
using Lexiconner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexiconner.Domain.Config
{
    public static class MongoConfig
    {
        public const string IdentityUsers = "identityUsers";
        public const string IdentityRoles = "identityRoles";

        private const string IdentityApiResources = "identityApiResources";
        private const string IdentityApiScopes = "identityApiScopes";
        private const string IdentityClients = "identityClients";
        private const string IdentityIdentityResources = "identityIdentityResources";
        private const string IdentityPersistedGrant = "identityPersistedGrant";

        private const string UserInfo = "userInfo";
        private const string Words = "words";
        private const string CustomCollections = "customCollections";
        private const string UserFilms = "userFilms";

        private const string CacheGoogleTranslateApi = "cacheGoogleTranslateApi";
        private const string CacheGoogleTranslateDetectLanguageApi = "cacheGoogleTranslateDetectLanguageApi";
        private const string CacheContextualWebSearchImageSearchApi = "cacheContextualWebSearchImageSearchApi";

        ///// <summary>
        ///// Defines list of allowed collections in database
        ///// </summary>
        //private static Dictionary<string, string> _collectionNameMap = new Dictionary<string, string>
        //{
        //    // Identity
        //    { typeof(ApplicationUserEntity).Name,  IdentityUsers },
        //    { typeof(ApplicationRoleEntity).Name,  IdentityRoles },

        //    // Identity Server
        //    { typeof(ApiResource).Name,      IdentityApiResources },
        //    { typeof(Client).Name,           IdentityClients },
        //    { typeof(IdentityResource).Name, IdentityIdentityResources },
        //    { typeof(PersistedGrant).Name,   IdentityPersistedGrant },

        //    // custom entities
        //    { typeof(WordEntity).Name,   Words },

        //    // cache
        //    { typeof(GoogleTranslateDataCacheEntity).Name,   CacheGoogleTranslateApi },
        //    { typeof(ContextualWebSearchImageSearchDataCacheEntity).Name,   CacheContextualWebSearchImageSearchApi },
        //};

        private static List<MongoCollectionConfig> IdentityDbCollectionConfig = new List<MongoCollectionConfig>
        {
            // Identity
            new MongoCollectionConfig
            {
                CollectionType = typeof(ApplicationUserEntity),
                CollectionName = IdentityUsers,
                Indexes = new List<string> {
                }
            },
             new MongoCollectionConfig
            {
                CollectionType = typeof(ApplicationRoleEntity),
                CollectionName = IdentityRoles,
                Indexes = new List<string> {
                }
            },

            // Identity model
            new MongoCollectionConfig
            {
                CollectionType = typeof(ApiResource),
                CollectionName = IdentityApiResources,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(ApiScope),
                CollectionName = IdentityApiScopes,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(Client),
                CollectionName = IdentityClients,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(IdentityResource),
                CollectionName = IdentityIdentityResources,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(PersistedGrant),
                CollectionName = IdentityPersistedGrant,
                Indexes = new List<string> {
                }
            },

             // Identity model wrappers
            new MongoCollectionConfig
            {
                CollectionType = typeof(ApiResourceEntity),
                CollectionName = IdentityApiResources,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(ApiScopeEntity),
                CollectionName = IdentityApiScopes,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(ClientEntity),
                CollectionName = IdentityClients,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(IdentityResourceEntity),
                CollectionName = IdentityIdentityResources,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(PersistedGrantEntity),
                CollectionName = IdentityPersistedGrant,
                Indexes = new List<string> {
                }
            },
        };

        private static List<MongoCollectionConfig> MainDbCollectionConfig = new List<MongoCollectionConfig>
        {
            // custom entities
            new MongoCollectionConfig
            {
                CollectionType = typeof(UserInfoEntity),
                CollectionName = UserInfo,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(WordEntity),
                CollectionName = Words,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(CustomCollectionEntity),
                CollectionName = CustomCollections,
                Indexes = new List<string> {
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(UserFilmEntity),
                CollectionName = UserFilms,
                Indexes = new List<string>{
                }
            },


            // testing
            new MongoCollectionConfig
            {
                CollectionType = typeof(SimpleTestEntity),
                CollectionName = "simpleTest",
                Indexes = new List<string> {
                }
            },
        };

        private static List<MongoCollectionConfig> SharedCacheDbCollectionConfig = new List<MongoCollectionConfig>
        {
            // cache
             new MongoCollectionConfig
            {
                CollectionType = typeof(GoogleTranslateDetectLangugaeDataCacheEntity),
                CollectionName = CacheGoogleTranslateDetectLanguageApi,
                Indexes = new List<string> {
                    nameof(GoogleTranslateDetectLangugaeDataCacheEntity.CacheKey)
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(GoogleTranslateDataCacheEntity),
                CollectionName = CacheGoogleTranslateApi,
                Indexes = new List<string> {
                    nameof(GoogleTranslateDataCacheEntity.CacheKey)
                }
            },
            new MongoCollectionConfig
            {
                CollectionType = typeof(ContextualWebSearchImageSearchDataCacheEntity),
                CollectionName = CacheContextualWebSearchImageSearchApi,
                Indexes = new List<string> {
                    nameof(ContextualWebSearchImageSearchDataCacheEntity.CacheKey)
                }
            },
        };

        public static string GetCollectionName<T>(ApplicationDb applicationDb)
        {
            var config = GetCollectionConfig<T>(applicationDb);
            return config.CollectionName;
        }

        public static bool IsCollectionConfigExists<T>(ApplicationDb applicationDb)
        {
            return _GetCollectionConfig<T>(applicationDb) != null;
        }

        public static MongoCollectionConfig GetCollectionConfig<T>(ApplicationDb applicationDb)
        {
            MongoCollectionConfig config = _GetCollectionConfig<T>(applicationDb);

            if (config == null)
            {
                throw new InvalidOperationException($"Collection config for type {typeof(T).Name} is not registered!");
            }
            return config;
        }

        public static List<MongoCollectionConfig> GetCollectionsConfig(ApplicationDb applicationDb)
        {
            List<MongoCollectionConfig> config = null;

            switch (applicationDb)
            {
                case ApplicationDb.Identity:
                    config = IdentityDbCollectionConfig;
                    break;
                case ApplicationDb.Main:
                    config = MainDbCollectionConfig;
                    break;
                case ApplicationDb.SharedCache:
                    config = SharedCacheDbCollectionConfig;
                    break;
            }

            if (config == null)
            {
                throw new InvalidOperationException($"Collections config for {nameof(ApplicationDb)} {applicationDb} is not registered!");
            }
            return config;
        }

        private static MongoCollectionConfig _GetCollectionConfig<T>(ApplicationDb applicationDb)
        {
            MongoCollectionConfig config = null;

            switch (applicationDb)
            {
                case ApplicationDb.Identity:
                    config = IdentityDbCollectionConfig.FirstOrDefault(x => x.CollectionType == typeof(T));
                    break;
                case ApplicationDb.Main:
                    config = MainDbCollectionConfig.FirstOrDefault(x => x.CollectionType == typeof(T));
                    break;
                case ApplicationDb.SharedCache:
                    config = SharedCacheDbCollectionConfig.FirstOrDefault(x => x.CollectionType == typeof(T));
                    break;
            }

            return config;
        }
    }

    public class MongoCollectionConfig
    {
        public MongoCollectionConfig()
        {
            Indexes = new List<string>();
        }

        public Type CollectionType { get; set; }
        public string CollectionName { get; set; }
        public List<string> Indexes { get; set; } // only 1 filed for now. add compound if needed
    }
}
