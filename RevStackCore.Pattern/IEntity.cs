using System;

namespace RevStackCore.Pattern
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
