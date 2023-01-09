using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Extensions;
using DataAccess.Infrastructure.Factories;
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
    [Signal]
    delegate void ShowEntityInfoPanel(int index);

    // [Signal]
    // delegate void RelayShowEntityInfoPanelMessage();

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        registerSignals();
        var cemetery = this.GetDataCemetery();
        await cemetery.FillWithApiData();
        GD.Print("BaseUrl is: " + this.GetBaseUrl());
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
            i.Connect(nameof(EntityButtonPress), entityPanelScriptManager, "DisplayEntity");
            string name = i.Name;
            GD.Print(name.Replace("Button", string.Empty));
        }
        // var b = IsConnected(nameof(RelayShowEntityInfoPanelMessage), this, "relaySignalShowEntityInfoPanel");
        Connect(nameof(ShowEntityInfoPanel), GetParent().GetNode<Node>("UI/EntityInfoPanel/CS_EntityInfoPanel"), "showEntityInfoPanel");
    }

    private void relaySignalShowEntityInfoPanel(int index)
    {
        var n = GetNode<Node>("/root/Interface/UI/EntityPanel");
        var type = GetNode<EntityPanel>("/root/Interface/UI/EntityPanel").GetCurrentType();
        // var name =  GetNode<Label>("/root/Interface/UI/EntityPanel/EntityName").Text;
        // var test = type.GetType();
        EmitSignal(nameof(ShowEntityInfoPanel), index);
    }
}
