using System;

namespace DataAccess.Infrastructure.Enums
{
    [Flags]
    public enum ApiCallType : int
    {
        Simple = 1,
        Id = 2,
        JSON = 4,
        CustomSimpleField = 8
    }
}
