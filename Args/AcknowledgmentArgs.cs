using System;

namespace TwitchIntegration
{
    public class AcknowledgmentArgs : EventArgs
    {
        public enum Ack{
            Membership,
            Command,
            tags
        }

        public Ack Acknowledgment{ get; private set;} 

        public AcknowledgmentArgs (Ack ack)
        {
            this.Acknowledgment = ack;
        }
    }
}

