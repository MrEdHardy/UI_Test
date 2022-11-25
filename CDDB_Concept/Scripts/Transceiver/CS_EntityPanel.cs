using Godot;
using System;

public class CS_EntityPanel : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void ShowEntityPanel(string title);
    Control entityPanel = null;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // entityPanel = this.GetNode<Control>("/root/Interface/UI/EntityPanel");
        // registerSignals();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void registerSignals()
    {
        entityPanel = this.GetNode<Control>("/root/Interface/UI/EntityPanel");
        entityPanel.Connect(nameof(ShowEntityPanel), entityPanel, "display");
    }

    public void displayEntity(string mode)
    {
        string entity = mode.Replace("Button", string.Empty);
        var etPanel = (GetNode("/root/Interface/UI/EntityPanel") as Control);
        etPanel.Visible = true;
        (etPanel.GetNode("EntityName") as Label).Text = entity;
        EmitSignal(nameof(ShowEntityPanel), "display");
        GD.Print($"EntityPanel receives Signal from {entity}");
    }
}
