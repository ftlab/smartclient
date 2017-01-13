using System;
using System.Windows.Forms;

namespace SmartClient.Core.Services
{
    public interface IWaitService : IService
    {
        IWaitForm Show(string caption, Form parentFom);
   }

    public interface IWaitForm : IDisposable
    {
        void SetDescription(string description);
    }
}
