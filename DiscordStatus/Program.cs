using DiscordRPC;
using DiscordRPC.Logging;

namespace DiscordStatus;

class Program
{
    public static DiscordRpcClient client;
    
    public static void Main(string[] args)
    {
        client = new DiscordRpcClient(Keys.GetStringKey("id"));			
	
        client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

        client.OnReady += (sender, e) =>
        {
            Console.WriteLine("Received Ready from user {0}", e.User.Username);
        };
		
        client.OnPresenceUpdate += (sender, e) =>
        {
            Console.WriteLine("Received Update! {0}", e.Presence);
        };
	
        client.Initialize();

        client.SetPresence(new RichPresence()
        {
            Details = "Tux is my old discord bot written in java.",
            Buttons = new []
            {
               new Button()
               {
                   Label = "Github",
                   Url = "https://github.com/Bakterio"
               }
            }
        });
        Console.WriteLine("Press any key to close program...");
        Console.ReadKey();
    }
}

