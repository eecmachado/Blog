using System;

namespace Blog.Domain.Base.Interfaces.Models
{
    public interface IDomainModel<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
