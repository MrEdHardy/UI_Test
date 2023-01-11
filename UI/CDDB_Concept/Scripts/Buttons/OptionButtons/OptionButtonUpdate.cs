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
    ItemList titleList = null;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        titleList = this.GetParent().GetNodeOrNull<ItemList>("TitleList");
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

    public void fillWithData()
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

            var list = new List<Godot.Object>();
            foreach (var field in ArtistViewModel.Fields)
            {
                if(field.Value == typeof(TextEdit))
                {
                    list.Add(this.GetParent().GetNode<TextEdit>($"{field.Key}Value"));
                }
            }

            if(list.Count >= ArtistViewModel.Fields.Count)
            {
                (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (ArtistViewModel.Fields.First()).Key + "Value")).First().Text = (elementList as List<ArtistViewModel>)[0].Name;
            }

            if(titleList != null)
            {
                var firstArtist = (elementList as List<ArtistViewModel>)[0];
                var titleCollections = cemetery.GetObjects<TitleCollectionViewModel>().Where(tc => tc.ArtistId == firstArtist.Id).ToList();
                titleList.Hide();
                if(titleCollections.Count > 0)
                {
                    var allTitles = cemetery.GetObjects<TitleViewModel>();
                    var artistTitles = new List<TitleViewModel>();
                    foreach (var tc in titleCollections)
                    {
                        foreach (var t in allTitles)
                        {
                            if(tc.TitleId == t.Id)
                                artistTitles.Add(t);
                        }
                    }

                    (allTitles as List<TitleViewModel>).Sort(new EntityObjectComparer());
                    foreach (var title in allTitles)
                    {
                        titleList.AddItem(title.ToString());
                    }

                    artistTitles.Sort(new EntityObjectComparer());
                    foreach (var selectedTitle in artistTitles)
                    {
                        int index = (allTitles as List<TitleViewModel>).FindIndex(t => t.Id == selectedTitle.Id);
                        GD.Print("Index: " + index);
                        if(index != -1)
                        {
                            titleList.Select(index, true);
                        }
                    }

                    titleList.Show();
                }
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

            var list = new List<Godot.Object>();
            foreach (var field in TitleViewModel.Fields)
            {
                if(field.Value == typeof(TextEdit))
                {
                    list.Add(this.GetParent().GetNode<TextEdit>($"{field.Key}Value"));
                }
            }

            if(list.Count >= TitleViewModel.Fields.Count)
            {
                (list.Where(ge => ge is TextEdit).Cast<TextEdit>().Where(te => te.Name == (TitleViewModel.Fields.First()).Key + "Value")).First().Text = (elementList as List<TitleViewModel>)[0].Name;
            }
        }
    }

    private void onItemSelected(int index)
    {
        var id = int.Parse(((this.GetItemText(index)).Split(" "))[0]);
        var ele = this.GetEntityPanel().GetCurrentType();
        var type = ele.GetType();

        if(type == typeof(TestObject))
        {
            var selectedElement = cemetery.GetObject<TestObject>(ElementProps.Id, id);
            this.GetParent().GetNode<TextEdit>("NameValue").Text = selectedElement.Name;
        }
        else if(type == typeof(ArtistViewModel))
        {
            var selectedElement = cemetery.GetObject<ArtistViewModel>(ElementProps.Id, id);
            this.GetParent().GetNode<TextEdit>("NameValue").Text = selectedElement.Name;
        }
        else if(type == typeof(TitleViewModel))
        {
            var selectedElement = cemetery.GetObject<TitleViewModel>(ElementProps.Id, id);
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
