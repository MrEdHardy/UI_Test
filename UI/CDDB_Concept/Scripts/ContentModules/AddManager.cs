using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class AddManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
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

    public void BindData(string name)
    {
        GD.Print($"Binding {name} data...");

        var currentType = this.GetCurrentType();
        if(currentType == typeof(ArtistViewModel))
        {
            if(titleList != null)
            {
                var titles = this.GetDataCemetery().GetObjects<TitleViewModel>();
                foreach (var title in titles)
                {
                    titleList.AddItem(title.ToString());
                }
            }
        }
    }
}
