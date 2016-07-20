using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwitchIntegration
{
    public class UserstateArgs : EventArgs
    {
        public enum UserType{
            Moderator,
            GlobalModerator,
            Admin,
            Staff,
            Viewer
        }


        public string raw{ get; private set;}

        public Color color{ get; private set; }
        public string displayName{get;private set;}
        public int[] emoteSet{ get; private set; }
        public bool subscriber {get;private set;}
        public bool mod { get; private set; }
        public bool turbo{ get; private set; }
        public TwitchMessage.UserType userType{ get; private set; }

        public UserstateArgs (string raw, List<KeyValuePair<string,string>> arguments,IrcChannel channel)
        {
            this.raw = raw;
            foreach (KeyValuePair<string,string> arg in arguments) {
                switch (arg.Key) {
                case "color":
                    if(arg.Value.Trim() != "")
                    this.color = ColorUtility.hexToColor (arg.Value);
                    break;
                case "display-name":
                    this.displayName = arg.Value;
                    break;
                case "emote-sets":
                    string[] value = arg.Value.Split (',');
                    emoteSet = new int[value.Length];
                    for (int x = 0; x < value.Length; x++) {
                        emoteSet [x] = int.Parse (value [x]);
                    }

                    break;
                case "mod":
                    this.mod = arg.Value == "1";
                    break;
                case "subscriber":
                    this.subscriber = arg.Value == "1";
                    break;
                case "turbo":
                    this.turbo = arg.Value == "1";
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
                }
            }
        }
    }
}

