﻿using Microsoft.Extensions.DependencyInjection;
using LiteraDO.DataAccess.Repositories.Contracts;
using System;

namespace LiteraDO.DataAccess.Repositories
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        private readonly IServiceProvider services;

        public DataRepositoryFactory() { }

        public DataRepositoryFactory(IServiceProvider services)
        {
            this.services = services;
        }

        public IDataRepository<TEntity> GetDataRepository<TEntity>() where TEntity : class, new()
        {
            var instance = services.GetService<IDataRepository<TEntity>>();

            return instance;
        }

        public TRepository GetCustomDataRepository<TRepository>() where TRepository : IDataRepository
        {
            var instance = services.GetService<TRepository>();

            return instance;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            var instance = services.GetService<IUnitOfWork>();

            return instance;
        }
    }
}
