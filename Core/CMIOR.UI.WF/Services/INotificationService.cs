using System;

namespace CMIOR.UI.WF.Services
{
    public interface INotificationService
    {
        void Subscribe<TNotification>(Action<TNotification> handler);

        void Notify<TNotification>(TNotification message);
    }
}