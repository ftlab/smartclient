using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartClient.Core.Controls
{
    public static class WindowsUIViewExtension
    {
        public static WindowsUIView AddDocument(this WindowsUIView view, Control control, Action<BaseDocument> action)
        {
            var document = view.AddDocument(control);

            action?.Invoke(document);

            return view;
        }
    }
}
