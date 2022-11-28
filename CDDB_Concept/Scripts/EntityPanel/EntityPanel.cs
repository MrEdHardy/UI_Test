using Godot;
using System;

public class EntityPanel : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void clear()
    {
        this.GetNode<ContentContainer>("Content").ClearContentPanel();
        this.Hide();
    }

    public void Display(string title)
    {
        clear();
        var entityLabel = GetNode<Label>("EntityName");
        entityLabel.Text = title;
        this.Show();
    }
}
