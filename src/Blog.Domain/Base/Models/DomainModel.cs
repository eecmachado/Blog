using Blog.Domain.Base.Interfaces.Models;
using System;

namespace Blog.Domain.Base.Models
{
    public abstract class DomainModel<TKey> : IDomainModel<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public abstract class DomainModel : DomainModel<int>
    {
    }
}
