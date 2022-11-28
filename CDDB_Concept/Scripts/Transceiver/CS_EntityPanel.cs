using Godot;
using System;

public class CS_EntityPanel : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void ShowEntityPanel(string title);
    

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
        var entityPanel = this.GetNode<Control>("/root/Interface/UI/EntityPanel");
        Connect(nameof(ShowEntityPanel), entityPanel, "Display");
    }

    public void displayEntity(string mode)
    {
        string entity = mode.Replace("Button", string.Empty);
        EmitSignal(nameof(ShowEntityPanel), entity);
        GD.Print($"EntityPanel receives Signal from {entity}");
    }
}
