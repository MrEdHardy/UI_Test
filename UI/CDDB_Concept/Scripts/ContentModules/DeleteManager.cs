using Godot;
using System;

public class DeleteManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void fillWithDemoDataDelete();


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        registerSignals();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void registerSignals()
    {
        if(!IsConnected(nameof(fillWithDemoDataDelete), GetParent().GetNode("VBoxContainer/IdList"), "fillWithDemoData"))
            Connect(nameof(fillWithDemoDataDelete), GetParent().GetNode("VBoxContainer/IdList"), "fillWithDemoData");
    }

    internal void BindData(string name)
    {
        EmitSignal(nameof(fillWithDemoDataDelete));
        GD.Print($"Binding {name} data...");
    }
}
