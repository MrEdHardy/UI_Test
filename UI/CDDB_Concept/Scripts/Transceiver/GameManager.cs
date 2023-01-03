using DataAccess.Infrastructure.Entities;
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
    delegate void ShowEntityInfoPanel(Godot.Object displayObject, int index);

    // [Signal]
    // delegate void RelayShowEntityInfoPanelMessage();

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        registerSignals();
        // var test = new TestObject("blub", 1);
        // var node = GetNode<Node>("/root/Interface/DataCemetery");
        // var graveyard = GetNode<Node>("/root/Interface/DataCemetery");

        // var script = graveyard.GetNode<DataCemetery>("./");
        // script.SaveObject(test);
        // var arr = script.GetObjects<TestObject>();
        // var obj = script.GetObject<TestObject>(ElementProps.Id, 1);
        // script.DeleteObject(test);
        // var obj1 = script.GetObject<TestObject>(ElementProps.Id, 1);

        // var dict = new Dictionary<object, Type>();
        // var list = new List<TestObject>();
        // for (int i = 0; i < 10; i++)
        // {   
        //     list.Add(new TestObject("Jannice", i));
        //     dict.Add(list[i], typeof(TestObject));
        // }
        // script.SaveObjectRange(dict);
        // var eleArray = script.GetObjects<TestObject>();
        // var obj2 = script.GetObject<TestObject>(ElementProps.Id, 2);
        // var objNullId = script.GetObject<TestObject>(ElementProps.Id, null);
        // var objNone = script.GetObject<TestObject>(ElementProps.None, null);
        // var objCustomValue = script.GetObject<TestObject>(ElementProps.Custom, "Jannice", "Name");
        // var objCustomValueNull = script.GetObject<TestObject>(ElementProps.Custom, string.Empty);
        // script.DeleteObjects(list);
        // var obj3 = script.GetObject<TestObject>(ElementProps.Id, 2);
        // var eleArray1 = script.GetObjects<TestObject>();

        // string baseUrl = "http://localhost:6969/main.php/";
        // var af = new ArtistFactory(new Uri(baseUrl));
		// var resultAll = await af.GetAll();
        // var resultId = await af.GetById(2);
		// var addResult = await af.Add(new ArtistEntity { Name = "Artist" });
		// addResult.Name = "Changed!";
		// await af.Update(addResult.Id.Value, addResult);
		// await af.Delete(addResult.Id.Value);
        // var resultAll1 = await af.GetAll();
        var cemetery = this.GetDataCemetery();
        await cemetery.FillWithApiData();
        var ele = cemetery.GetObjects<ArtistViewModel>();
        string baseUrl = "http://localhost:6969/main.php/";
        var af = new ArtistFactory(new Uri(baseUrl));
        ArtistViewModel addResult = await af.Add(new ArtistEntity { Name = "Artist" });
        cemetery.SaveObject(addResult);
        var ele1 = cemetery.GetObjects<ArtistViewModel>();
        addResult.Name = "Changed!";
		await af.Update(addResult.Id, addResult);
        cemetery.SaveObject(addResult);
        var ele2 = cemetery.GetObjects<ArtistViewModel>();
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
        EmitSignal(nameof(ShowEntityInfoPanel), type, index);
    }
}
