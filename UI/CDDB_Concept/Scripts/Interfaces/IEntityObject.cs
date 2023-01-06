using System.Collections;

public interface IEntityObject
{
    int Id { get; }
    string Controller { get; }
    string ToString();
    void SetController(string controller);
}