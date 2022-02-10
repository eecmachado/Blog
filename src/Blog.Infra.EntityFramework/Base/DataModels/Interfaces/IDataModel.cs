using System;

namespace Blog.Infra.EntityFramework.Base.DataModels.Interfaces
{
    public interface IDataModel<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
