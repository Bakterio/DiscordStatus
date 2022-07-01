using Newtonsoft.Json.Linq;

namespace DiscordStatus;

public class Keys
{
    private static string jsonString = File.ReadAllText("keys.json");
    private static JObject json = JObject.Parse(jsonString);
    
    public static string GetStringKey(string key)
    {
        return (string) json[key];
    }
}