using Godot;
using System;

public class UpdateManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void fillWithDemoDataUpdate();

    [Signal]
    delegate void fillWithDataUpdate();


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
        if(!IsConnected(nameof(fillWithDataUpdate), GetParent().GetNode("ScrollContainer/VBoxContainer/OptionButton"), "fillWithData"))
            Connect(nameof(fillWithDataUpdate), GetParent().GetNode("ScrollContainer/VBoxContainer/OptionButton"), "fillWithData");
    }

    internal void BindData(string name)
    {
        GD.Print($"Binding {name} data...");
        if(this.GetEntityPanel().GetCurrentType().GetType() == typeof(TestObject))
            EmitSignal(nameof(fillWithDemoDataUpdate));
        else
            EmitSignal(nameof(fillWithDataUpdate));
    }
}
