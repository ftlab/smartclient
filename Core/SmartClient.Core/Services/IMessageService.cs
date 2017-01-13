using System;

namespace SmartClient.Core.Services
{
    public interface IMessageService : IService
    {
        void ShowInfo(string text);

        void ShowInfo(string text, string caption);

        void ShowError(Exception exception);

        void ShowError(string text);

        void ShowError(string text, string caption);

        void ShowWarning(string text);

        void ShowWarning(string text, string caption);
    }
}
