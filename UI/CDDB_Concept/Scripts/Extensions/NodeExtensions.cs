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

    public static bool GetDemoModeStatus(this Godot.Node node)
    {
        var boolean = node.GetNode<Settings>("/root/Interface").isDemoMode;
        return boolean;
    }

    public static string GetBaseUrl(this Godot.Node node)
    {
        var url = node.GetNode<Settings>("/root/Interface").baseUrl;
        return url;
    }
}