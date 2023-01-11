public interface IEntityObject
{
    int Id { get; }
    string Controller { get; set; }
    string ToString();
}