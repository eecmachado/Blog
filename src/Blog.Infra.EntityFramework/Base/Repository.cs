using AutoMapper;
using Blog.Domain.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Blog.Infra.EntityFramework.Base.DataModels;

namespace Blog.Infra.EntityFramework.Base
{
    public abstract class Repository<TContext, TDomainModel, TDataModel, TKey> : RepositoryBase<TContext, TDomainModel, TDataModel, TKey>
        where TContext : DbContext
        where TDomainModel : DomainModel<TKey>
        where TDataModel : DataModel<TKey>
        where TKey : IEquatable<TKey>
    {
        protected Repository(TContext contextFactory, IMapper mapper) :
            base(contextFactory, mapper)
        {
        }

        protected override TContext ConfigureContext()
        {
            return ContextFactory;
        }

        protected override TDataModel MapDomainToDataModel(TDomainModel domainModel)
        {
            return Mapper.Map<TDataModel>(domainModel);
        }
    }

    public abstract class Repository<TContext, TDomainModel, TDataModel> : Repository<TContext, TDomainModel, TDataModel, int>
        where TContext : DbContext
        where TDomainModel : DomainModel
        where TDataModel : DataModel
    {
        protected Repository(TContext contextFactory, IMapper mapper) :
            base(contextFactory, mapper)
        {
        }
    }
}
