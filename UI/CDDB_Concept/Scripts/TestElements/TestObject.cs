using System;
using System.Collections.Generic;
using Godot;

public class TestObject : Reference, IEntityObject
{
    public string Name = string.Empty;
    public int Id { get; set; }

    public string Controller { get { return ""; } set { this.Controller = value; }}

    public static readonly Dictionary<string, Type> Fields = new Dictionary<string, Type>()
    {
        {"Name", typeof(TextEdit)}
    };

    public TestObject(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    private TestObject()
    {
    }

    public override string ToString()
    {
        return string.Concat(Id, " ", Name);
    }
} 