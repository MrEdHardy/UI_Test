using DataAccess.Infrastructure.Factories;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class ConfirmButtonUpdate : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    DataCemetery cemetery => this.GetDataCemetery();
    ArtistFactory artistFactory => cemetery.ArtistFactory;
    TitleFactory titleFactory => cemetery.TitleFactory;

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

            var selectedIdInOptionButton = this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").Selected;
            var elementId = int.Parse(((this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").GetItemText(selectedIdInOptionButton)).Split(" "))[0]);
            TestObject testObject = cemetery.GetObject<TestObject>(ElementProps.Id, elementId);

            if(list.Count >= TestObject.Fields.Count)
            {
                testObject.Name = (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TestObject.Fields.First()).Key + "Value")).First().Text;
            }
            cemetery.SaveObject(testObject);
            this.GetParent().GetNode<OptionButtonUpdate>("ScrollContainer/VBoxContainer/OptionButton").fillWithDemoData();
            GD.Print("Confirm in Update was clicked!");
        }
        else if(type == typeof(ArtistViewModel))
        {
            foreach (var field in ArtistViewModel.Fields)
            {
                if(field.Value == typeof(TextEdit))
                {
                    list.Add(this.GetParent().GetNode<TextEdit>($"ScrollContainer/VBoxContainer/{field.Key}Value"));
                }
            }

            var selectedIdInOptionButton = this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").Selected;
            var elementId = int.Parse(((this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").GetItemText(selectedIdInOptionButton)).Split(" "))[0]);
            var element = cemetery.GetObject<ArtistViewModel>(ElementProps.Id, elementId);
            if(list.Count >= ArtistViewModel.Fields.Count)
            {
                element.Name = (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TitleViewModel.Fields.First()).Key + "Value")).First().Text;
            }
            // Danger!!!
            await artistFactory.Update(element.Id, element);
            cemetery.SaveObject(element);
            this.GetParent().GetNode<OptionButtonUpdate>("ScrollContainer/VBoxContainer/OptionButton").fillWithData();
            GD.Print("Confirm in Update was clicked!");
        }
        else if(type == typeof(TitleViewModel))
        {
            foreach (var field in TitleViewModel.Fields)
            {
                if(field.Value == typeof(TextEdit))
                {
                    list.Add(this.GetParent().GetNode<TextEdit>($"ScrollContainer/VBoxContainer/{field.Key}Value"));
                }
            }

            var selectedIdInOptionButton = this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").Selected;
            var elementId = int.Parse(((this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").GetItemText(selectedIdInOptionButton)).Split(" "))[0]);
            var element = cemetery.GetObject<TitleViewModel>(ElementProps.Id, elementId);
            if(list.Count >= TitleViewModel.Fields.Count)
            {
                element.Name = (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TitleViewModel.Fields.First()).Key + "Value")).First().Text;
            }
            // Danger!!!
            await titleFactory.Update(element.Id, element);
            cemetery.SaveObject(element);
            this.GetParent().GetNode<OptionButtonUpdate>("ScrollContainer/VBoxContainer/OptionButton").fillWithData();
            GD.Print("Confirm in Update was clicked!");
        }

        // var selectedIdInOptionButton = this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").Selected;
        // var elementId = int.Parse(((this.GetParent().GetNode<OptionButton>("ScrollContainer/VBoxContainer/OptionButton").GetItemText(selectedIdInOptionButton)).Split(" "))[0]);
        // TestObject testObject = cemetery.GetObject<TestObject>(ElementProps.Id, elementId);

        // if(list.Count >= TestObject.Fields.Count)
        // {
        //     testObject.Name = (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TestObject.Fields.First()).Key + "Value")).First().Text;
        // }
        // cemetery.SaveObject(testObject);
        // this.GetParent().GetNode<OptionButtonUpdate>("ScrollContainer/VBoxContainer/OptionButton").fillWithDemoData();
        // GD.Print("Confirm in Update was clicked!");
    }
}
