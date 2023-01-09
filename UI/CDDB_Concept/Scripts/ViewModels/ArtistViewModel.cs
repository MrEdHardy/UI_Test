using System;
using System.Collections.Generic;
using DataAccess.Infrastructure.Entities;
using Godot;

public sealed class ArtistViewModel : IEntityObject
{
    private int _id;
    private string _name;
    public int Id { get { return this._id; } }
    public static readonly Dictionary<string, Type> Fields = new Dictionary<string, Type>()
    {
        {"Name", typeof(TextEdit)}
    };

    public string Name { get { return this._name; }  set { this._name = value; } }

    private static string _controller = "artists/";
    public static string Controller { get { return _controller; } private set { _controller = value; } }

    private readonly static object lockObject = new object();

    internal ArtistViewModel(int id, string name)
    {
        this._id = id;
        this._name = name;
    }

    private ArtistViewModel()
    {
    }

    public override string ToString()
    {
        return string.Concat(Id, " ", Name);
    }

    public static void SetController(string controller)
    {
        lock (lockObject)
            Controller = controller;
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