﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using MongoDB.Driver;

//namespace Lexiconner.IdentityServer4.Repository
//{
//    /// <summary>
//    /// Basic interface with a few methods for adding, deleting, and querying data.
//    /// </summary>
//    public interface IMongoRepository
//    {
//        IMongoDatabase GetDatabase();
//        IQueryable<T> All<T>() where T : class, new();
//        IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class, new();
//        T Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
//        void Add<T>(T item) where T : class, new();
//        void Add<T>(IEnumerable<T> items) where T : class, new();
//        bool CollectionExists<T>() where T : class, new();
//        bool Exists<T>(Expression<Func<T, bool>> expression) where T : class, new();

//        Task DeleteAsync<T>(Expression<Func<T, bool>> expression) where T : class, new();
//        Task DeleteAllAsync<T>() where T : class, new();
//    }
//}
