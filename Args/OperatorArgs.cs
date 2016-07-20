using System;

namespace TwitchIntegration
{
    public class OperatorArgs: EventArgs
    {
        public bool isOperator{ get; private set;}
        public IrcChannel channel { get; private set;}
        public TwitchUser user{ get; private set;}

        public OperatorArgs (TwitchUser user, IrcChannel channel, bool isOperator)
        {
            this.user = user;
            this.channel = channel;
            this.isOperator = isOperator;
        }
    }
}

