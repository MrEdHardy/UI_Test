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
}