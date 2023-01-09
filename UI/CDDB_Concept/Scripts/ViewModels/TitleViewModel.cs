using System;
using System.Collections.Generic;
using DataAccess.Infrastructure.Entities;
using Godot;

internal sealed class TitleViewModel : IEntityObject
{
    private int _id;
    private string _name;
    public int Id { get { return this._id; } }
    public static readonly Dictionary<string, Type> Fields = new Dictionary<string, Type>()
    {
        {"Name", typeof(TextEdit)}
    };

    public string Name { get { return this._name; }  set { this._name = value; } }

    private static string _controller = "titles/";
    public static string Controller { get { return _controller; } private set { _controller = value; } }
    private readonly static object lockObject = new object();

    internal TitleViewModel(int id, string name)
    {
        this._id = id;
        this._name = name;
    }

    private TitleViewModel()
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

    public static implicit operator TitleEntity(TitleViewModel viewModel)
    {
        if (viewModel.Id <= 0)
            throw new System.Exception("Id cannot be 0 or negative");

        return new TitleEntity(viewModel.Id, viewModel.Name);
    }

    public static implicit operator TitleViewModel(TitleEntity entity)
    {
        return new TitleViewModel(entity.Id ?? 0, entity.Name);
    }
}