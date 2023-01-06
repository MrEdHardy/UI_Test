using Godot;
using System;
using System.Collections.Generic;

public class SelectableItemListDelete : ItemList
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
        int count = 1337;
        if(cemetery.GetCount<TestObject>() > 0)
        {
            var elementList = cemetery.GetObjects<TestObject>() as List<TestObject>;
            elementList.Sort(new EntityObjectComparer());
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
                this.AddItem(test.ToString());
                cemetery.SaveObject(test);
                test = null;
            }
        }
    }

    public void FillWithData()
    {
        this.Clear();
        var type = this.GetEntityPanel().GetCurrentType().GetType();
        IEnumerable<IEntityObject> elementList = null;

        if(type == typeof(ArtistViewModel))
        {
            elementList = cemetery.GetObjects<ArtistViewModel>();
            (elementList as List<ArtistViewModel>).Sort(new EntityObjectComparer());
            foreach (ArtistViewModel element in elementList)
            {
                this.AddItem(element.ToString());
            }
        }
        else if(type == typeof(TitleViewModel))
        {
            elementList = cemetery.GetObjects<TitleViewModel>();
            (elementList as List<TitleViewModel>).Sort(new EntityObjectComparer());
            foreach (TitleViewModel element in elementList)
            {
                this.AddItem(element.ToString());
            }
        }
    }
}
