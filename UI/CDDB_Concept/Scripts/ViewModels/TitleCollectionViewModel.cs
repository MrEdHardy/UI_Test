using DataAccess.Infrastructure.Entities;

internal sealed class TitleCollectionViewModel : IEntityObject
{
    private int _id;
    public int Id { get { return this._id; }}
    public int TitleId { get; set; }
    public int ArtistId { get; set; }

    internal TitleCollectionViewModel(int id, int titleId, int artistId)
    {
        _id = id;
        TitleId = titleId;
        ArtistId = artistId;
    }

    private TitleCollectionViewModel()
    {
    }

    public override string ToString()
    {
        return string.Concat(Id, " ArtistId: ", ArtistId, " TitleId: ", TitleId);
    }

    public static implicit operator TitleCollectionEntity(TitleCollectionViewModel viewModel)
    {
        if (viewModel.Id <= 0)
            throw new System.Exception("Id cannot be 0 or negative");

        return new TitleCollectionEntity(viewModel.Id, viewModel.TitleId, viewModel.ArtistId);
    }

    public static implicit operator TitleCollectionViewModel(TitleCollectionEntity entity)
    {
        return new TitleCollectionViewModel(entity.Id ?? 0, entity.TitleId, entity.ArtistId);
    }
}