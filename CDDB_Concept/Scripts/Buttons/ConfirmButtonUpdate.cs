using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class ConfirmButtonUpdate : Button
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

    private void onButtonUp()
    {
        var type = this.GetEntityPanel().GetCurrentType().GetType();

        var list = new List<Godot.Object>();
        if(type == typeof(TestObject))
        {
            foreach (var field in TestObject.Fields)
            {
                if(field.Value == typeof(TextEdit))
                {
                    list.Add(this.GetParent().GetNode<TextEdit>($"ScrollContainer/VBoxContainer/{field.Key}Value"));
                }
            }
        }

        var selectedIdInOptionButton = this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").Selected;
        var elementId = int.Parse(((this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").GetItemText(selectedIdInOptionButton)).Split(" "))[0]);
        TestObject testObject = this.GetDataCemetery().GetObject<TestObject>(ElementProps.Id, elementId);

        if(list.Count >= TestObject.Fields.Count)
        {
            testObject.Name = (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TestObject.Fields.First()).Key + "Value")).First().Text;
        }
        this.GetDataCemetery().SaveObject(testObject);
        this.GetParent().GetNode<OptionButtonUpdate>("ScrollContainer/VBoxContainer/OptionButton").fillWithDemoData();
        GD.Print("Confirm in Update was clicked!");
    }
}
