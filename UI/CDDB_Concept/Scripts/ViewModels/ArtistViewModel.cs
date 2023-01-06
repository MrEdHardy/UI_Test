using System;
using System.Collections.Generic;
using DataAccess.Infrastructure.Entities;
using Godot;

public sealed class ArtistViewModel : IEntityObject
{
    private int id;
    private string name;
    public int Id { get { return this.id; } }
    public static readonly Dictionary<string, Type> Fields = new Dictionary<string, Type>()
    {
        {"Name", typeof(TextEdit)}
    };

    public string Name { get { return this.name; }  set { this.name = value; } }

    public string Controller { get { return "artists/"; } private set { this.Controller = value; } }

    internal ArtistViewModel(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    private ArtistViewModel()
    {
    }

    public override string ToString()
    {
        return string.Concat(Id, " ", Name);
    }

    public void SetController(string controller)
    {
        this.Controller = controller;
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