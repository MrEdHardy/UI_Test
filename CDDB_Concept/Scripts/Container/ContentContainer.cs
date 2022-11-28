using Godot;
using System;

public sealed class ContentContainer : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void ClearContentPanel()
    {
        foreach (Node item in this.GetChild(0).GetChildren())
        {
            item.QueueFree();
        }
    }

    private void addModuleToChildContainer(string pathToScene)
    {
        ClearContentPanel();
        var newPanel = ResourceLoader.Load<PackedScene>(pathToScene);
        this.GetChild(0).AddChild(newPanel.Instance());
    }

    private void showContentPanel(CrudOperations operation)
    {
        var path = string.Empty;
        var basePath = "res://CDDB_Concept/Testscenes/EntityPanel/MenuContentScenes/";
        if(operation == CrudOperations.GetAll)
        {
            path = "GetAll.tscn";
        }
        else if(operation == CrudOperations.GetById)
        {
            path = "GetById.tscn";
        }
        else if(operation == CrudOperations.Add)
        {
            path = "Add.tscn";
        }
        else if(operation == CrudOperations.Update)
        {
            path = "Update.tscn";
        }
        else if(operation == CrudOperations.Delete)
        {
            path = "Delete.tscn";
        }
        else
        {
            throw new InvalidOperationException("No valid or available Crud Operation selected");
        }
        addModuleToChildContainer(string.Concat(basePath, path));
    }
}
