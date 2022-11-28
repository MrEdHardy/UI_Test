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
        var entityPanelScriptManager = GetNode("/root/Interface/UI/EntityPanel/CS_EntityPanel");
        foreach (Node i in GetNode("/root/Interface/UI/LeftBar").GetChildren())
        {
            i.Connect(nameof(EntityButtonPress), entityPanelScriptManager, "displayEntity");
            string name = i.Name;
            GD.Print(name.Replace("Button", string.Empty));
        }
    }
}
