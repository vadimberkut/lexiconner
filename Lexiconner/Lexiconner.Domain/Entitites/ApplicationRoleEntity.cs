﻿using AspNetCore.Identity.MongoDbCore.Models;
using Lexiconner.Domain.Config;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using NUlid;
using NUlid.Rng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexiconner.Domain.Entitites
{
    [CollectionName(MongoConfig.IdentityRoles)]
    public class ApplicationRoleEntity : MongoIdentityRole<string>
    {
        
        public ApplicationRoleEntity()
        {
            // // Contrib.Microsoft.AspNetCore.Identity.MongoDB by thrixton (uses Mongo ObjectId)
            // don't use custom id because BsonRepresentation(BsonType.ObjectId) applied in base class
            // and it must be 24 digit hex string that is generated by MongoDb
            // Id = Ulid.NewUlid().ToString();

            // AspNetCore.Identity.MongoDbCore by Alexandre Spieser (allows to set custom Ids)
            // uses IdGenerator to generate Id of type TKEY. Supported types: Guid, Int16, Int32, Int64, String (Guid), ObjectId
            // we can rewrite Id in constructor as it is intialised in base constructor
            Id = Ulid.NewUlid(new SimpleUlidRng()).ToString();
        }
    }
}
