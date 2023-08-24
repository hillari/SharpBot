using Discord;
using Discord.WebSocket;

// THIS WILL BE GOING AWAY SOON it's just proof of concept for creating a connection and a starting point for a repo. See https://discordnet.dev/guides/getting_started/installing.html?tabs=vs-install%2Ccore2-1

public class Program
{

	private DiscordSocketClient _client;
	public static Task Main(string[] args) => new Program().MainAsync();

	public async Task MainAsync()
	{
		
    _client = new DiscordSocketClient();

    _client.Log += Log;

    //  You can assign your bot token to a string, and pass that in to connect.
    //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
    var token = "token";

    // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
    // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
    // var token = File.ReadAllText("token.txt");
    // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

    await _client.LoginAsync(TokenType.Bot, token);
    await _client.StartAsync();

    // Block this task until the program is closed.
    await Task.Delay(-1);
	}

    private Task Log(LogMessage msg)
{
	Console.WriteLine(msg.ToString());
	return Task.CompletedTask;
}


}