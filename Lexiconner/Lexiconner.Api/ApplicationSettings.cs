﻿using Lexiconner.Application.ApplicationSettings;
using Lexiconner.Application.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lexiconner.Api
{
    public class ApplicationSettings
    {
        public CorsSettings Cors { get; set; }
        public MongoDbSettings MongoDb { get; set; }
        //public BasicAuthSettings BasicAuth { get; set; }
        public JwtBearerAuthSettings JwtBearerAuth { get; set; }
        public UrlsSettings Urls { get; set; }
        public GoogleSettings Google { get; set; }
        public RapidApiSettings RapidApi { get; set; }
        public TheMovieDatabaseSettings TheMovieDatabase { get; set; }
    }

    public class CorsSettings
    {
        public CorsSettings()
        {
            AllowedOrigins = new List<string>();
        }

        public List<string> AllowedOrigins { get; set; }
    }

    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseIdentity { get; set; }
        public string DatabaseMain { get; set; }
        public string DatabaseSharedCache { get; set; }
    }

    public class BasicAuthSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class JwtBearerAuthSettings
    {
        public string Authority { get; set; }
        public string Audience { get; set; }
    }

    public class UrlsSettings
    {
        public string SelfExternalUrl { get; set; }
    }
}
