using System;
using System.Collections.Generic;
using TwitchIntegration;

namespace MiniTwitchIRC
{
    public class RoomStateArgs: EventArgs
    {
        public string broadcasterLang { get; private set; }
        public bool r9kMode { get; private set; }
        public bool subscribersOnly{ get; private set; }
        public int slowDelay{ get; private set; }

        public IrcChannel channel{ get; private set; }
        public string raw{ get; private set; }

        public RoomStateArgs (string raw, List<KeyValuePair<string,string>> arguments,IrcChannel channel)
        {
            this.raw = raw;
            this.channel = channel;
            foreach (KeyValuePair<string,string> arg in arguments) {
                switch (arg.Key) {
                case "broadcaster-lang":
                    this.broadcasterLang = arg.Value;
                    break;
                case "r9k":
                    this.r9kMode = arg.Value == "1";
                    break;
                case "slow":
                    this.slowDelay = int.Parse( arg.Value);
                    break;
                case "subs-only":
                    this.subscribersOnly = arg.Value == "1";
                    break;
                }
            }
        }
    }
}

