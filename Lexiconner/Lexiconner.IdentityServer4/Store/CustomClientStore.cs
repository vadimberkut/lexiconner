﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Lexiconner.Domain.Entitites.IdentityModel;
using Lexiconner.Persistence.Repositories;

namespace Lexiconner.IdentityServer4.Store
{
    public class CustomClientStore : IClientStore
    {
        protected IDataRepository _dataRepository;

        public CustomClientStore(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = await _dataRepository.GetOneAsync<ClientEntity>(c => c.Client.ClientId == clientId);
            return client.Client;
        }
    }
}
