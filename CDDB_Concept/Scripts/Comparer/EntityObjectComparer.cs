using System.Collections;
using System.Collections.Generic;

public sealed class EntityObjectComparer : IComparer<IEntityObject>
{
    public int Compare(IEntityObject x, IEntityObject y)
    {
        return x.Id.CompareTo(y.Id);
    }
}