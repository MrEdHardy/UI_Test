using Godot;
using System;

public class UpdateManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void fillWithDemoDataUpdate();

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
        if(!IsConnected(nameof(fillWithDemoDataUpdate), GetParent().GetNode("ScrollContainer/VBoxContainer/OptionButton"), "fillWithDemoData"))
            Connect(nameof(fillWithDemoDataUpdate), GetParent().GetNode("ScrollContainer/VBoxContainer/OptionButton"), "fillWithDemoData");
    }

    internal void BindData(string name)
    {
        GD.Print($"Binding {name} data...");
        EmitSignal(nameof(fillWithDemoDataUpdate));
    }
}
