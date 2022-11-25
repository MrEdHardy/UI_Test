using Godot;
using System;

public class EntityPanel : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void ShowEntityPanel(string title);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Connect("ShowEntityPanel", this, "banane");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void clear()
    {
        foreach (Node item in this.GetChild(6).GetChild(0).GetChildren())
        {
            item.QueueFree();
        }
        this.Hide();
    }

    public void banane(string title)
    {
        GD.Print("I am here");
        clear();
        var entityLabel = GetNode<Label>("EntityName");
        entityLabel.Text = title;
        this.Show();
    }
}
