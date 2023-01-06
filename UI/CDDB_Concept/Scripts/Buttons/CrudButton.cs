using Godot;
using System;

public class CrudButton : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    string operation;

    [Signal]
    delegate void ButtonPressed(string operation);

    [Signal]
    delegate void BindData(string objectName);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void onButtonUp()
    {
        EmitSignal(nameof(ButtonPressed), operation);
        GD.Print($"It seems the {operation}-Button was activated!");
    }
}
