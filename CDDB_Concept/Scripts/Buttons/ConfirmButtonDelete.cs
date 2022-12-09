using Godot;
using System;

public class ConfirmButtonDelete : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    DataCemetery cemetery => this.GetDataCemetery();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void onButtonUp()
    {
        var itemList = this.GetParent().GetNode<ItemList>("VBoxContainer/IdList");
        if(itemList.GetSelectedItems().Length <= 0)
            return;
        var selectedId = itemList.GetSelectedItems()[0];
        var type = this.GetEntityPanel().GetCurrentType().GetType();

        if(type == typeof(TestObject))
        {
            var selectedElement = cemetery.GetObject<TestObject>(ElementProps.Id, selectedId);
            cemetery.DeleteObject(selectedElement);
            (itemList as SelectableItemListDelete).fillWithDemoData();
        }
    }
}
