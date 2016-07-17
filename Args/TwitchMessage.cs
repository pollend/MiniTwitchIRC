using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwitchIntegration
{
    public class TwitchMessage : EventArgs
    {

        public enum UserType{
            Moderator,
            GlobalModerator,
            Admin,
            Staff,
            Viewer
        }

        public string emoteSet { get; private set; }
        public IrcChannel channel { get; private set; }
        public string rawMessage { get; private set; }
        public string displayName{ get; private set; }
        public int userId{ get; private set; }
        public bool turbo{ get; private set; }
        public bool isMod{ get; private set; }
        public string message{ get; private set; }
        public bool subscriber{ get; private set; }
        public Color color { get; private set; }
        public UserType userType { get; private set; }
        public List<KeyValuePair<string,string>> badges { get; private set; }
        public TwitchUser twitchUser { get; private set; }

        public TwitchMessage (string raw, List<KeyValuePair<string,string>> arguments,IrcChannel channel ,TwitchUser twitchUser,string payload)
        {
            
            this.badges = new List<KeyValuePair<string, string>> ();
            this.rawMessage = raw;
            this.twitchUser = twitchUser;
            this.message = payload;
            this.channel = channel;
            foreach (KeyValuePair<string,string> arg in arguments) {
                switch (arg.Key) {
                    case "badges":
                    if(arg.Value.Contains("/"))
                            {
                        if (!arg.Value.Contains(","))
                            this.badges.Add(new KeyValuePair<string, string>(arg.Value.Split('/')[0], arg.Value.Split('/')[1]));
                                else
                            foreach (string badge in arg.Value.Split(','))
                                this.badges.Add(new KeyValuePair<string, string>(arg.Value.Split('/')[0], arg.Value.Split('/')[1]));
                            }
                    break;
                case "color":
                    if(arg.Value.Trim() != "")
                    color = ColorUtility.hexToColor (arg.Value);
                    break;
                case "display-name":
                    this.displayName = arg.Value;
                    break;
                case "emotes":
                    this.emoteSet =arg.Value;
                    break;
                case "subscriber":
                    this.subscriber = arg.Value == "1";
                    break;
                case "turbo":
                    turbo = arg.Value == "1";
                    break;

                case "user-id":
                    userId = int.Parse(arg.Value);
                    break;
                case "user-type":
                    switch (arg.Value)
                    {
                    case "mod":
                        userType = TwitchMessage.UserType.Moderator;
                        break;
                    case "global_mod":
                        userType = TwitchMessage.UserType.GlobalModerator;
                        break;
                    case "admin":
                        userType = TwitchMessage.UserType.Admin;
                        break;
                    case "staff":
                        userType = TwitchMessage.UserType.Staff;
                        break;
                    default:
                        userType = TwitchMessage.UserType.Viewer;
                        break;
                    }
                    break;
                case "mod":
                    isMod =arg.Value == "1";
                    break;

                }
            }
        }
    }
}

