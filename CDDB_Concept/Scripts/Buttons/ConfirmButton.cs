using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class ConfirmButton : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    DataCemetery cemetery => this.GetDataCemetery();
    List<TextEdit> textInputs = new List<TextEdit>();

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
        // Implementation für Beispieldaten
        textInputs.Clear();

        // Hier soll der Typ ermittelt werden, ggf im EntityPanel nen Feld mit geradigen Typ hinterlegen und per GetCurrentType aufrufen??!!
        Type type = typeof(TestObject);

        foreach (Node n in GetParent().GetNode("ScrollContainer/VBoxContainer").GetChildren())
        {
            if(n is TextEdit)
                textInputs.Add(n as TextEdit);
        }

        TestObject element = null;
        // Hier soll der Typ ausgewertet werden
        if(type == typeof(TestObject))
        {
            short id = (short)(this.cemetery.GetObjects<TestObject>().Max(to => to.Id) + 1);
            string name = "Könnte fehlgeschlagen sein^^";
            name = (textInputs.Where(ti => ti.Name.Equals("NameValue")).FirstOrDefault())?.Text;
            element = new TestObject(name, id);
            cemetery.SaveObject(element);
        }
        GD.Print("I have created following Element: " + element?.ToString());
    }
}
