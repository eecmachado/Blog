using Next.Blog.Infra.Data.Base.Interfaces;
using System;

namespace Next.Blog.Infra.Data.Base.DataModels
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
