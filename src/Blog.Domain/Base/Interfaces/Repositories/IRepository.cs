using Blog.Domain.Base.Interfaces.Models;
using Blog.Domain.Base.Models;
using System;
using System.Threading.Tasks;

namespace Blog.Domain.Base.Interfaces.Repositories
{
    public interface IRepository<TDomainModel, TKey>
        where TDomainModel : IDomainModel<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TDomainModel> Insert(TDomainModel domainModel);

        Task<TDomainModel> Update(TDomainModel domainModel);
    }

    public interface IRepository<TDomainModel> : IRepository<TDomainModel, int>
        where TDomainModel : DomainModel<int>
    {
    }
}
