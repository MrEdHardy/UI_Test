using Godot;
using System;

public class EntityInfoPanelContainer : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void DisplayObject(int index);

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
        Connect(nameof(DisplayObject), GetNode<Node>("InnerContent/Element/SignalManager"), "displayContent");
    }

    private void fillPanels(int index)
    {
        // GetNode("InnerContent/Element/VBoxContainer/");
        GD.Print("Signal reached EntityInfoPanel/Content");
        var t = IsConnected(nameof(DisplayObject), GetNode<Node>("InnerContent/Element/SignalManager"), "displayContent");
        EmitSignal(nameof(DisplayObject), index);
    }
}
