using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.Components
{
    public partial class IndicatorNumerator : Component
    {
        public IndicatorNumerator()
        {
            InitializeComponent();
        }

        public IndicatorNumerator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private GridView _gridView;
        public GridView GridView
        {
            get
            {
                return _gridView;
            }
            set
            {
                if (_gridView!= null)
                {
                    _gridView.RowCountChanged -= _gridView_RowCountChanged;
                    _gridView.CustomDrawRowIndicator -= _gridView_CustomDrawRowIndicator;
                }
                _gridView = value;
                _gridView.RowCountChanged += _gridView_RowCountChanged;
                _gridView.CustomDrawRowIndicator += _gridView_CustomDrawRowIndicator;

            }
        }

        private void _gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void _gridView_RowCountChanged(object sender, EventArgs e)
        {
            var graphics = _gridView.GridControl.CreateGraphics();
            _gridView.IndicatorWidth = (int)graphics.MeasureString((_gridView.RowCount).ToString() + "X", _gridView.GridControl.Font).Width;
            _gridView.GridControl.Refresh();
        }
    }
}
