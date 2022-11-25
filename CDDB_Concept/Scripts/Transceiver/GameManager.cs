using Godot;
using System;
using System.Collections.Generic;

public class GameManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void EntityButtonPress(string mode);
    [Signal]
    delegate void ShowEntityPanel(string title);

    // [Signal]
    // delegate void ShowEntityPanel(string title);

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
        // var listOfEntityButtons = new List<Node>();
        var entityPanel = GetNode<Control>("/root/Interface/UI/EntityPanel");
        entityPanel.Connect(nameof(ShowEntityPanel), entityPanel, "display");
        var entityPanelScriptManager = GetNode("/root/Interface/UI/EntityPanel/CS_EntityPanel");
        // listOfEntityButtons.AddRange((IEnumerable<Node>)GetNode("Interface/UI/LeftBar").GetChildren());
        foreach (var item in GetNode("/root/Interface/UI/LeftBar").GetChildren())
        {
            // listOfEntityButtons.Add(item as Node);
            (item as Node).Connect(nameof(EntityButtonPress), entityPanelScriptManager, "displayEntity");
            string name = (item as Node).Name;
            GD.Print(name.Replace("Button", string.Empty));
        }
    }
}
