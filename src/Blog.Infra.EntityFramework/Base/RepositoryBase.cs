using AutoMapper;
using Blog.Domain.Base.Interfaces.Repositories;
using Blog.Domain.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Blog.Infra.EntityFramework.Base.DataModels;

namespace Blog.Infra.EntityFramework.Base
{
    public abstract class RepositoryBase<TContext, TDomainModel, TDataModel, TKey> : IRepository<TDomainModel, TKey>
        where TContext : DbContext
        where TDomainModel : DomainModel<TKey>
        where TDataModel : DataModel<TKey>
        where TKey : IEquatable<TKey>
    {
        protected RepositoryBase(TContext _contextFactory, IMapper mapper)
        {
            ContextFactory = _contextFactory;
            Mapper = mapper;
        }

        protected TContext ContextFactory { get; }

        protected IMapper Mapper { get; }

        protected abstract TContext ConfigureContext();

        protected abstract TDataModel MapDomainToDataModel(TDomainModel domainModel);

        public virtual async Task<TDomainModel> Insert(TDomainModel domainModel)
        {
            var dataModel = MapDomainToDataModel(domainModel);
            using var context = ConfigureContext();

            context.Set<TDataModel>().Add(dataModel);
            await context.SaveChangesAsync();
            return Mapper.Map(dataModel, domainModel);
        }

        public virtual async Task<TDomainModel> Update(TDomainModel domainModel)
        {
            var dataModel = MapDomainToDataModel(domainModel);
            using var context = ConfigureContext();

            context.Set<TDataModel>().Update(dataModel);
            await context.SaveChangesAsync();
            return Mapper.Map(dataModel, domainModel);
        }
    }
}
