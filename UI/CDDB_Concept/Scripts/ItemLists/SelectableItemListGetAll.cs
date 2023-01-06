using Godot;
using System;
using System.Collections;

public class SelectableItemListGetAll : ItemList, IItemList
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal]
    delegate void RelayShowEntityInfoPanelMessage(int id);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if(!IsConnected(nameof(RelayShowEntityInfoPanelMessage), GetNode("/root/Interface/GameManager"), "relaySignalShowEntityInfoPanel"))
            Connect(nameof(RelayShowEntityInfoPanelMessage), GetNode("/root/Interface/GameManager"), "relaySignalShowEntityInfoPanel");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void onItemActivated(int index)
    {
        GD.Print($"Something was activated! Index: {index}");
        // var n = GetNode<Node>("/root/Interface/GameManager");
        // var j = IsConnected(nameof(RelayShowEntityInfoPanelMessage), GetNode<Node>("/root/Interface/GameManager"), "relaySignalShowEntityInfoPanel");
        var splitString = this.GetItemText(index).Split(" ");
        // var i = int.Parse(splitString[0]); 
        EmitSignal(nameof(RelayShowEntityInfoPanelMessage), splitString[0]);
    }
}
