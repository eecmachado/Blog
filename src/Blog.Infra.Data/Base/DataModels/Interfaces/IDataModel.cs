using System;

namespace Next.Blog.Infra.Data.Base.Interfaces
{
    public interface IDataModel<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
