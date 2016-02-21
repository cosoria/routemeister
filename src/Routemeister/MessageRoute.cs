﻿using System;
using System.Linq;

namespace Routemeister
{
    public class MessageRoute : IEquatable<MessageRoute>
    {
        public Type MessageType { get; }
        public Action<object>[] Actions { get; }

        public MessageRoute(Type messageType, Action<object>[] actions)
        {
            if (messageType == null)
                throw new ArgumentNullException(nameof(messageType));
            if (actions == null)
                throw new ArgumentNullException(nameof(actions));
            if(!actions.Any())
                throw new ArgumentException("A message route must have actions. No actions were passed.");

            MessageType = messageType;
            Actions = actions;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MessageRoute);
        }

        public bool Equals(MessageRoute other)
        {
            return other != null
                && (ReferenceEquals(this, other) || MessageType == other.MessageType);
        }

        public override int GetHashCode()
        {
            return MessageType.GetHashCode();
        }
    }
}