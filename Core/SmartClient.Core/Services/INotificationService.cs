using System;

namespace SmartClient.Core.Services
{
    public interface INotificationService
    {
        void Subscribe<TNotification>(Action<TNotification> handler);

        void Notify<TNotification>(TNotification message);
    }
}