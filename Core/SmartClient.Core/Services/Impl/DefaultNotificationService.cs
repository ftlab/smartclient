using System;
using System.Collections.Generic;

namespace SmartClient.Core.Services.Impl
{
    public class DefaultNotificationService : INotificationService
    {
        public void Subscribe<TNotification>(Action<TNotification> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            EventManager<TNotification>.Add(handler);
        }

        public void Notify<TNotification>(TNotification message)
        {
            EventManager<TNotification>.Raise(message);
        }

        private static class EventManager<TNotification>
        {
            private static readonly List<Action<TNotification>> Handlers = new List<Action<TNotification>>();

            public static void Add(Action<TNotification> handler)
            {
                Handlers.Add(handler);
            }

            public static void Raise(TNotification message)
            {
                foreach (var handler in Handlers)
                {
                    handler(message);
                }
            }
        }
    }
}
