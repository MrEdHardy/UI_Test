using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

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

        if(cemetery.GetCount<TestObject>() > 0)
        {
            var elementList = cemetery.GetObjects<TestObject>() as List<TestObject>;
            elementList.Sort(new EntityObjectComparer());
            foreach (var element in elementList)
            {
                itemList.AddItem(element.ToString());
            }
        }
        else
        {
            for(int i = 0; i < count; i++)
            {
                var test = new TestObject("Jannice", i);
                itemList.AddItem(test.ToString());
                cemetery.SaveObject(test);
                test = null;
            }
        }
    }
}
