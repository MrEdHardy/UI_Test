using Godot;
using System;

public class CS_EntityInfoPanel : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void DisplayContentInEntityInfoPanel(int index);

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
        Connect(nameof(DisplayContentInEntityInfoPanel), GetParent().GetNode("Content"), "fillPanels");
    }

    public void showEntityInfoPanel(int index)
    {
        GetParent<Control>().Show();
        var t = IsConnected(nameof(DisplayContentInEntityInfoPanel), GetParent().GetNode("Content"), "fillPanels");
        EmitSignal(nameof(DisplayContentInEntityInfoPanel), index);
        GD.Print("Hello EntityInfoPanel here!");
    }
}
