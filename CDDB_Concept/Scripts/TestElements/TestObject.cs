using Godot;

public class TestObject : Reference, IEntityObject
{
    public string Name = string.Empty;
    public int Id { get; set; }

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