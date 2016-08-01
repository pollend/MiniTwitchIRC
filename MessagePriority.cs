using System;
using UnityEngine;
using System.Collections.Generic;

namespace TwitchIntegration
{

    public struct MessagePriority
    {
        public int priority{ get; private set;}
        public DateTime timeStamp{ get; private set;}
        public float messageLifeTime{ get; private set;}
       
        public TimeSpan GetTimeOfMessage()
        {
            return DateTime.Now - timeStamp;
        }

        public bool isTimeExausted()
        {
            return GetTimeOfMessage().TotalSeconds > messageLifeTime;
        }

        public MessagePriority (float messageLifeTime, int priority,DateTime time) : this()
        {
            this.messageLifeTime = messageLifeTime;
            this.priority = priority;
            this.timeStamp = time;
        }
    }

    public class MessageSort : IComparer<MessagePriority>
    {
        
        public int Compare (MessagePriority x, MessagePriority y)
        {
            if (x.priority == -1 && y.priority == -1) {
                if (x.timeStamp > y.timeStamp)
                    return 1;
                else
                    return -1;
            }

            if (x.priority > y.priority || x.priority == -1)
                return -1;
            else if (x.priority < y.priority  || y.priority == -1)
                return 1;
            else if (x.priority == y.priority) {
                if (x.timeStamp > y.timeStamp)
                    return 1;
                else
                    return -1;
            }
            return 0;
        }
    }
}

