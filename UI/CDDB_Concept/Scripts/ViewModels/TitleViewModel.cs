using System;
using System.Collections.Generic;
using DataAccess.Infrastructure.Entities;
using Godot;

internal sealed class TitleViewModel : IEntityObject
{
    private int id;
    private string name;
    public int Id { get { return this.id; } }
    public static readonly Dictionary<string, Type> Fields = new Dictionary<string, Type>()
    {
        {"Name", typeof(TextEdit)}
    };

    public string Name { get { return this.name; }  set { this.name = value; } }

    internal TitleViewModel(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    private TitleViewModel()
    {
    }

    public override string ToString()
    {
        return string.Concat(Id, " ", Name);
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