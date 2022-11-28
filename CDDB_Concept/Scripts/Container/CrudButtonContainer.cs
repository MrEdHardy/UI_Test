using Godot;
using System;

public class CrudButtonContainer : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    [Signal]
    delegate void ShowContent(CrudOperations operation);

    [Signal]
    delegate void ButtonPressed(string operation);

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
        var contentContainer = this.GetParent().GetNode<Node>("Content");
        foreach (Node i in this.GetChildren())
        {
            i.Connect(nameof(ButtonPressed), this, "onButtonPressed");
        }
        
        Connect(nameof(ShowContent), contentContainer, "showContentPanel");
    }

    private void onButtonPressed(string operation)
    {
        if(Enum.TryParse<CrudOperations>(operation, out CrudOperations result))
            EmitSignal(nameof(ShowContent), result);
    }
}
