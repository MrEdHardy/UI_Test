using DataAccess.Infrastructure.Entities;
using DataAccess.Infrastructure.Factories;
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
    ArtistFactory artistFactory => cemetery.ArtistFactory;
    TitleFactory titleFactory => cemetery.TitleFactory;
    ItemList titleList = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        titleList = this.GetParent().GetNodeOrNull<ItemList>("ScrollContainer/VBoxContainer/TitleList");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private async void onButtonUp()
    {
        // Implementation für Beispieldaten
        textInputs.Clear();
        IEntityObject debugElement = null;
        var type = this.GetEntityPanel().GetCurrentType().GetType();

        // Hier soll der Typ ermittelt werden, ggf im EntityPanel nen Feld mit geradigen Typ hinterlegen und per GetCurrentType aufrufen??!!
        if(type == typeof(TestObject))
        {
            foreach (Node n in GetParent().GetNode("ScrollContainer/VBoxContainer").GetChildren())
            {
                if(n is TextEdit)
                    textInputs.Add(n as TextEdit);
            }

            TestObject element = null;
            // Hier soll der Typ ausgewertet werden
            if(type == typeof(TestObject))
            {   
                short id = 0;
                if(this.cemetery.GetObjects<TestObject>().Count() > 0)
                    id = (short)(this.cemetery.GetObjects<TestObject>().Max(to => to.Id) + 1);
                string name = "Könnte fehlgeschlagen sein^^";
                name = (textInputs.Where(ti => ti.Name.Equals("NameValue")).FirstOrDefault())?.Text;
                element = new TestObject(name, id);
                debugElement = element;
                cemetery.SaveObject(element);
            }
        }
        else if(type == typeof(ArtistViewModel))
        {
            foreach (Node n in GetParent().GetNode("ScrollContainer/VBoxContainer").GetChildren())
            {
                if(n is TextEdit)
                    textInputs.Add(n as TextEdit);
            }

            string name = "Könnte fehlgeschlagen sein^^";
            name = (textInputs.Where(ti => ti.Name.Equals("NameValue")).FirstOrDefault())?.Text;
            // Danger!!!
            ArtistViewModel viewModel = await artistFactory.Add(new ArtistEntity(id: null, name: name));
            debugElement = viewModel;
            cemetery.SaveObject(viewModel);
        }
        else if(type == typeof(TitleViewModel))
        {
            foreach (Node n in GetParent().GetNode("ScrollContainer/VBoxContainer").GetChildren())
            {
                if(n is TextEdit)
                    textInputs.Add(n as TextEdit);
            }

            string name = "Könnte fehlgeschlagen sein^^";
            name = (textInputs.Where(ti => ti.Name.Equals("NameValue")).FirstOrDefault())?.Text;
            // Danger!!!
            TitleViewModel viewModel = await titleFactory.Add(new TitleEntity(id: null, name: name));
            debugElement = viewModel;
            cemetery.SaveObject(viewModel);
        }

        GD.Print("I have created following Element: " + debugElement?.ToString());
    }
}
