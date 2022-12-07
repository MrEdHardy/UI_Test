using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public class DataCemetery : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    //doch eher Friedhof->Gräber statt Müllkippe->Müllhaufen
    private Dictionary<object, Type> dataGraves = new Dictionary<object, Type>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void SaveObject<T>(T element)
    where T: IEntityObject
    {
        this.dataGraves.Add(element, typeof(T));
    }

    public void SaveObjectRange(IDictionary<object, Type> elements)
    {
        foreach (KeyValuePair<object, Type> pair in elements)
        {
            var type = pair.Key.GetType();
            this.SaveObject(pair.Key as IEntityObject);
        }
    }

    public IEnumerable<T> GetObjects<T>()
    where T: IEntityObject
    {
        var list = new List<T>();
        foreach (KeyValuePair<object, Type> pair in this.dataGraves)
        {
            if(pair.Key is IEntityObject)
                list.Add((T)pair.Key);
        }

        return list;
    }

    public T GetObject<T>(ElementProps prop, object value, string constraintName = null)
    where T: IEntityObject
    {
        var list = this.GetObjects<T>();
        T result = default(T);
        foreach (T i in list)
        {
            if(prop.Equals(ElementProps.Id) && value != null && i.Id == (int)value)
            {
                return i;
            }
            else if(prop.Equals(ElementProps.Custom) && value != null && !string.IsNullOrEmpty(constraintName) )
            {
                Type type = typeof(T);
                var props = type.GetFields();
                var property = props.Where(p => p.Name.ToLower().Equals(constraintName.ToLower())).FirstOrDefault();
                if(property == null)
                    throw new InvalidOperationException("Constraint not found on Object");

                if(property.GetValue(i).Equals(value))
                    result = i;

                return result;
            }
        }
        return result;
    }

    public void DeleteObject<T>(T element)
    {
        this.dataGraves.Remove(element);
    }

    public void DeleteObjects(IEnumerable<object> elements)
    {
        foreach (var i in elements)
            this.DeleteObject(i);
    }

    public void DeleteAll()
    {
        this.dataGraves.Clear();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
