using DiscordRPC;
using DiscordRPC.Logging;

namespace DiscordStatus;

class Program
{
    public static DiscordRpcClient client;
    
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        
        Console.Write("First line: ");
        string firstLine = Console.ReadLine();
        Console.Write("Second line: ");
        string secondLine = Console.ReadLine();
        
        Connect();
        client.Initialize();
        
        client.SetPresence(new RichPresence()
        {
            Details = firstLine,
            State = secondLine,
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
    
    private static void Connect()
    {
        client = new DiscordRpcClient(Keys.GetStringKey("id"));			
	
        client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

        client.OnReady += (sender, e) =>
        {
            Console.WriteLine("Connected to user: {0}", e.User.Username);
        };
		
        client.OnPresenceUpdate += (sender, e) =>
        {
            Console.WriteLine("New update: {0}", e.Presence);
        };
    }
}

