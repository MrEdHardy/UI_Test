using Godot;
using System;
using System.Collections.Generic;

public class OptionButtonGetById : OptionButton
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

    private void fillWithDemoData()
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
        this.GetParent().GetNode<ItemList>("ItemList").AddItem(testObject.ToString());
    }

    private void fillWithData()
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
            this.GetParent().GetNode<ItemList>("ItemList").AddItem((elementList as List<ArtistViewModel>)[0].ToString());
        }
        else if(type == typeof(TitleViewModel))
        {
            elementList = cemetery.GetObjects<TitleViewModel>();
            (elementList as List<TitleViewModel>).Sort(new EntityObjectComparer());
            foreach (TitleViewModel element in elementList)
            {
                this.AddItem(element.ToString());
            }
            this.GetParent().GetNode<ItemList>("ItemList").AddItem((elementList as List<TitleViewModel>)[0].ToString());
        }
    }

    private void onItemSelected(int index)
    {
        var itemlist = this.GetParent().GetNode<ItemList>("ItemList");
        itemlist.Clear();
        var id = int.Parse(((this.GetItemText(index)).Split(" "))[0]);

        // richtige Implementation von Typen folgt!
        // Beispielimplementation
        var type = this.GetEntityPanel().GetCurrentType().GetType();

        if(type == typeof(ArtistViewModel))
        {
            var element = this.cemetery.GetObject<ArtistViewModel>(ElementProps.Id, id);
            itemlist.AddItem(element.ToString());
        }
        else if(type == typeof(TitleViewModel))
        {
            var element = this.cemetery.GetObject<TitleViewModel>(ElementProps.Id, id);
            itemlist.AddItem(element.ToString());
        }
        else
        {
            var element = this.cemetery.GetObject<TestObject>(ElementProps.Id, id);
            itemlist.AddItem(element.ToString());
        }

    }
}
