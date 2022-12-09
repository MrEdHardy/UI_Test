using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class OptionButtonUpdate : OptionButton
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

    public void fillWithDemoData()
    {
        this.Clear();
        TestObject testObject = null;
        int count = 1337;
        if(cemetery.GetCount<TestObject>() > 0)
        {
            var elementList = cemetery.GetObjects<TestObject>() as List<TestObject>;
            elementList.Sort(new EntityObjectComparer());
            testObject = elementList[0];
            foreach (var element in elementList)
            {
                this.AddItem(element.ToString());
            }
        }
        else
        {
            for(int i = 0; i < count; i++)
            {
                var test = new TestObject("Jannice", i);
                if(i <= 0)
                    testObject = test;
                
                this.AddItem(test.ToString());
                cemetery.SaveObject(test);
                test = null;
            }
        }

        // komplett generische Ermittlung von Werten für benötigtes Ui-Elementen und Feld
        // foreach (var field in TestObject.Fields)
        // {
        //     dynamic element = this.GetElementFieldFromParent(field.Key, field.Value);
        //     var value = (((testObject.GetType()).GetFields()).Where(p => p.Name.ToLower().Equals(field.Key.ToLower())).FirstOrDefault()).GetValue(testObject);
        //     element.SetText(value as string);
        // }

        var list = new List<Godot.Object>();
        foreach (var field in TestObject.Fields)
        {
            if(field.Value == typeof(TextEdit))
            {
                list.Add(this.GetParent().GetNode<TextEdit>($"{field.Key}Value"));
            }
        }

        if(list.Count >= TestObject.Fields.Count)
        {
            (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TestObject.Fields.First()).Key + "Value")).First().Text = testObject.Name;
        }
    }

    private void onItemSelected(int index)
    {
        var id = int.Parse(((this.GetItemText(index)).Split(" "))[0]);
        var ele = this.GetEntityPanel().GetCurrentType();
        var type = ele.GetType();

        if(type == typeof(TestObject))
        {
            var selectedElement = cemetery.GetObject<TestObject>(ElementProps.Id, index);
            this.GetParent().GetNode<TextEdit>("NameValue").Text = selectedElement.Name;
        }
    }

    private T GetElementFieldFromParent<T>(string fieldName, T targetObject)
    where T: Godot.Object
    {
        var element = this.GetParent().GetNode<T>($"{fieldName}Value");
        return element;
    }
}
