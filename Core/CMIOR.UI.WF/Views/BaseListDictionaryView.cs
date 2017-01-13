using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Windows.Forms;
using System;
using CMIOR.UI.WF.ViewModels;
using DevExpress.XtraGrid;

namespace CMIOR.UI.WF.Views
{
    public partial class BaseListDictionaryView<T> : BaseDictionaryView where T : class
    {
        public BaseListDictionaryView()
        {
            InitializeComponent();
        }

        public void BaseListDictionaryView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid?.MainView as GridView;
            if (view == null) return;
            var p = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.RowCell)
            {
                Edit();
            }
        }

        public override void RefreshData()
        {
            EnableEditButtons();
        }


        protected virtual void EnableEditButtons()
        {
            DictionaryCommand.Add.Enabled = true;
            // отображение кнопок редактирования
            DictionaryCommand.Delete.Enabled =
                DictionaryCommand.Edit.Enabled = FocusedRecord != null;
        }


        public override void ClearData()
        {

        }

        public T FocusedRecord
        {
            get
            {
                var view = (GridView)mainGridControl.MainView;
                var handle = view.FocusedRowHandle;

                if (view.IsDataRow(handle))
                    return view.GetRow(handle) as T;

                return null;
            }
        }
    }
}
