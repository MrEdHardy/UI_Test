using Godot;
using System;
using System.Collections.Generic;

public class CS_SimpleElement : Node
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

    private void displayContent(Godot.Object testObject, int index)
    {
        var cemetery = GetNode<DataCemetery>("/root/Interface/DataCemetery");
        var obj = testObject as TestObject;
        var type = obj.GetType();
        
        // var objects = cemetery.GetObjects<TestObject>();
        // var selectedElement = (objects as List<TestObject>)[index];

        var selectedElement = cemetery.GetObject<TestObject>(ElementProps.Id, index);


        GetParent().GetNode<TextEdit>("VBoxContainer/IdValue").Text = selectedElement.Id.ToString();
        GetParent().GetNode<TextEdit>("VBoxContainer/NameValue").Text = selectedElement.Name;
    }
}
