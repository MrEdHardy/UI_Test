using Godot;
using System;

public sealed class ContentContainer : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void BindDataElements(string name);

    [Signal]
    delegate void RelayShowEntityInfoPanelMessage();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void ClearContentPanel(Node target = null)
    {
        foreach (Node item in this.GetChild(0).GetChildren())
        {
            item.QueueFree();
        }
        
        if(target != null && IsConnected(nameof(BindDataElements), target, "BindData"))
            Disconnect(nameof(BindDataElements), target, "BindData");
    }

    private void addModuleToChildContainer(string pathToScene)
    {
        var newPanel = ResourceLoader.Load<PackedScene>(pathToScene);
        ClearContentPanel(newPanel.Instance());
        var instance = newPanel.Instance();
        this.GetChild(0).AddChild(instance);
        Connect(nameof(BindDataElements), instance.GetNode<Node>("SignalManager"), "BindData");
        EmitSignal(nameof(BindDataElements), GetParent().GetNode<Label>("EntityName").Text);
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
            throw new InvalidOperationException("No valid or available CRUD Operation selected");
        }
        addModuleToChildContainer(string.Concat(basePath, path));
    }
}
