using System;

public static class NodeExtensions
{
    public static DataCemetery GetDataCemetery(this Godot.Node node)
    {
        return node.GetNode<DataCemetery>("/root/Interface/DataCemetery");
    }

    public static EntityPanel GetEntityPanel(this Godot.Node node)
    {
        return node.GetNode<EntityPanel>("/root/Interface/UI/EntityPanel");
    }

    public static Settings GetSettings(this Godot.Node node)
    {
        return node.GetNode<Settings>("/root/Interface");
    }

    public static Type GetCurrentType(this Godot.Node node)
    {
        return node.GetEntityPanel().GetCurrentType().GetType();
    }
}