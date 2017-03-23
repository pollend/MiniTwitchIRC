# MiniTwitchIRC

### Overview

This is suppose to be a very simple twitch integration library for unity and supports versions of unity as low as 5.3.1f1.


## Features

- Simple event system for handeling messages
- A threaded message processing and sending pipeline

## Planned

- need a more robust way to track what channels the bot has subscribed to
- event handlers for message errors are missing

## Usage

```
namespace TwitchIntegration
{
    public class TwitchIntegration : MonoBehaviour
    {
      void Start()
      {
            IrcChannel channel;
            TwitchIrcClient client = new TwitchIrcClient ();

            //event when the client connects to the channel
            client.OnConnected += (object sender, EventArgs e) => {
                //enable twitch IRC features
                client.EnableTags();
                client.EnableMembership();
                client.EnableCommands();

                //join channel
                channel = client.joinChannel("channel");
            
            };

            client.OnMessage += (object sender, TwitchMessage e) => {
                Console.WriteLine(e.message);
            };
            client.Connect (true, "channel", "oath_token");

      }
    
    }
}
```

# Licence

GNU
