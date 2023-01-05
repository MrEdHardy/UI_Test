using DataAccess.Infrastructure.Factories;
using Godot;
using System;

public class ConfirmButtonDelete : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    static string baseUrl = "http://localhost:6969/main.php/";
    ArtistFactory artistFactory = new ArtistFactory(new Uri(baseUrl));
    TitleFactory titleFactory = new TitleFactory(new Uri(baseUrl));
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

    private async void onButtonUp()
    {
        var itemList = this.GetParent().GetNode<ItemList>("VBoxContainer/IdList");
        if(itemList.GetSelectedItems().Length <= 0)
            return;
        var selectedId = itemList.GetSelectedItems()[0];
        var id = int.Parse(itemList.GetItemText(selectedId).Split(" ")[0]);
        var type = this.GetEntityPanel().GetCurrentType().GetType();

        if(type == typeof(TestObject))
        {
            var selectedElement = cemetery.GetObject<TestObject>(ElementProps.Id, id);
            cemetery.DeleteObject(selectedElement);
            (itemList as SelectableItemListDelete).fillWithDemoData();
        }
        else if(type == typeof(ArtistViewModel))
        {
            var selectedElement = cemetery.GetObject<ArtistViewModel>(ElementProps.Id, id);
            // Danger!!!
            await artistFactory.Delete(selectedElement.Id);
            cemetery.DeleteObject(selectedElement);
            (itemList as SelectableItemListDelete).FillWithData();
        }
        else if(type == typeof(TitleViewModel))
        {
            var selectedElement = cemetery.GetObject<TitleViewModel>(ElementProps.Id, id);
            // Danger!!!
            await titleFactory.Delete(selectedElement.Id);
            cemetery.DeleteObject(selectedElement);
            (itemList as SelectableItemListDelete).FillWithData();
        }
    }
}
