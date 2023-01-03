using DataAccess.Infrastructure.Entities;

public sealed class ArtistViewModel : IEntityObject
{
    private int id;
    private string name;
    public int Id { get { return this.id; } }

    public string Name { get { return this.name; }  set { this.name = value; } }

    internal ArtistViewModel(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    private ArtistViewModel()
    {
    }

    public static implicit operator ArtistEntity(ArtistViewModel viewModel)
    {
        if (viewModel.Id <= 0)
            throw new System.Exception("Id cannot be 0 or negative");

        return new ArtistEntity(viewModel.Id, viewModel.Name);
    }

    public static implicit operator ArtistViewModel(ArtistEntity entity)
    {
        return new ArtistViewModel(entity.Id ?? 0, entity.Name);
    }
}