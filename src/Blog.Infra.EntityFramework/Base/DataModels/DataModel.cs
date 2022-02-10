using Blog.Infra.EntityFramework.Base.DataModels.Interfaces;
using System;

namespace Blog.Infra.EntityFramework.Base.DataModels
{
    public abstract class DataModel<TKey> : IDataModel<TKey>
         where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public abstract class DataModel : DataModel<int>
    {
    }
}
