using Godot;

internal static class SettingsExtension
{
    internal static string GetConfigFile(this Settings settings)
    {
        File file = new File();
        file.Open("res://ConfigFiles/config.json", File.ModeFlags.Read);
        var jsonFile = file.GetAsText();
        file.Close();
        return jsonFile;
    }

    internal static bool GetDemoModeStatus(this Godot.Node node)
    {
        var boolean = node.GetSettings().isDemoMode;
        return boolean;
    }

    internal static string GetBaseUrl(this Godot.Node node)
    {
        var url = node.GetSettings().baseUrl;
        return url;
    }
}