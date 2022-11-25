using Godot;
using System;

public class EntityButton : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void EntityButtonPress(string mode);
    [Signal]
    delegate void ShowEntityPanel(string title);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void _on_ArtistButton_button_up()
    {
        EmitSignal("EntityButtonPress", this.Name);
        EmitSignal(nameof(ShowEntityPanel), "banane");
    }

    private void _on_TitleButton_button_up()
    {
        EmitSignal("EntityButtonPress", this.Name);
    }

    private void _on_AlbumButton_button_up()
    {
        EmitSignal("EntityButtonPress", this.Name);
    }
}
