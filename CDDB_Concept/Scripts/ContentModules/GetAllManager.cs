using Godot;
using System;

public class GetAllManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    string name = string.Empty;
    ItemList itemList = null;
    struct DemoObject
    {
        int Id;
        string Name;

        public DemoObject(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Concat(Id, " ", Name);
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        itemList = GetParent().GetNode("ScrollContainer/VBoxContainer/SelectableItemList") as ItemList;
        // registerSignals();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void BindData(string name)
    {
        GD.Print($"Binding {name} data...");
        fillItemListWithDemoData();
    }

    private void fillItemListWithDemoData()
    {
        var cemetery = GetNode<DataCemetery>("/root/Interface/DataCemetery");
        itemList.Clear();
        int count = 1337;
        for(int i = 0; i < count; i++)
        {
            // DemoObject demoData = new DemoObject(i, "Jannice");
            var test = new TestObject("Jannice", i);
            itemList.AddItem(test.ToString());
            cemetery.SaveObject(test);
            test = null;
        }
    }
}
