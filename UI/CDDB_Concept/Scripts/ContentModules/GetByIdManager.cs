using Godot;
using System;

public class GetByIdManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    DataCemetery cemetery => this.GetDataCemetery();

    [Signal]
    delegate void fillWithDemoData();

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
        if(!IsConnected(nameof(fillWithDemoData), GetParent().GetNode("ScrollContainer/VBoxContainer/OptionButton"), "fillWithDemoData"))
            Connect(nameof(fillWithDemoData), GetParent().GetNode("ScrollContainer/VBoxContainer/OptionButton"), "fillWithDemoData");
    }

    internal void BindData(string name)
    {
        GD.Print($"Binding {name} data...");
        EmitSignal(nameof(fillWithDemoData));
    }
}
