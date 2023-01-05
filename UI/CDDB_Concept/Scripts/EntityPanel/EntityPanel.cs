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

    private void Display(string title)
    {
        clear();
        var entityLabel = GetNode<Label>("EntityName");
        entityLabel.Text = title;
        this.Show();
    }

    public IEntityObject GetCurrentType()
    {
        // Implementation folgt
        string currentElement = this.GetNode<Label>("EntityName").Text;
        IEntityObject currentObject = null;
        if(currentElement.ToLower().Contains("artist"))
        {
            currentObject = new ArtistViewModel(default, string.Empty);
        }
        else if(currentElement.ToLower().Contains("title"))
        {
            currentObject = new TitleViewModel(default, string.Empty);
        }
        else
        {
            currentObject = new TestObject(string.Empty, default);
        }

        return currentObject;
    }
}
