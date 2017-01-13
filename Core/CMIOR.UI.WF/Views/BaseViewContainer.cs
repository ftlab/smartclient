using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CMIOR.CommonContracts.DataModel;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace CMIOR.UI.WF.Views
{
    public partial class BaseViewContainer : FlatView
    {
        private IEmbeddableView _activeView;

        public BaseViewContainer()
        {
            InitializeComponent();
            windowsUIView1.NavigationBarsShowing += WindowsUIView1_NavigationBarsShowing;
        }

        public event EventHandler ActiveViewChanged;

        public IEmbeddableView ActiveView
        {
            get
            {
                return _activeView;
            }
        }

        public void ShowView(Type viewType)
        {
            var document = windowsUIView1.Documents.FirstOrDefault(x => x.Control.GetType() == viewType);

            if (document == null)
            {
                document = windowsUIView1.AddDocument((Control)Activator.CreateInstance(viewType));
                pageGroup1.Items.Add((Document)document);
            }
            windowsUIView1.ActivateDocument(document);

            _activeView = document.Control as IEmbeddableView;
            if (_activeView == null)
                throw new NullReferenceException("Представление должно реализовывать IEmbeddableView");

            ActiveViewChanged?.Invoke(this, EventArgs.Empty);
        }

        private void WindowsUIView1_NavigationBarsShowing(object sender, DevExpress.XtraBars.Docking2010.Views.WindowsUI.NavigationBarsCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
