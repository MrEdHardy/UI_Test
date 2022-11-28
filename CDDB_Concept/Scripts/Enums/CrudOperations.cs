using System;

[Flags]
public enum CrudOperations : int
{
    None = 0,
    GetAll = 1,
    GetById = 2,
    Add = 4,
    Update = 8,
    Delete = 16
}