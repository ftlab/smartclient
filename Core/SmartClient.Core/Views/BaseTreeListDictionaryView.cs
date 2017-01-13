using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using SmartClient.Core.Interfaces;
using DevExpress.XtraTreeList.Nodes;
using SmartClient.Core.ViewModels;

namespace SmartClient.Core.Views
{
    public partial class BaseTreeListDictionaryView<L, I> : BaseDictionaryView where L : ITreeListViewModel where I : ITreeItemViewModel
    {
        protected L _viewModel;
        public BaseTreeListDictionaryView()
        {
            InitializeComponent();
        }
        protected I FocusedRecord => (I)treeList.GetDataRecordByNode(treeList.FocusedNode);
        public override IEnumerable<DictionaryCommand> GetCommands()
        {
            yield return DictionaryCommand.Add;
            yield return DictionaryCommand.Edit;
            yield return DictionaryCommand.Delete;
            yield return DictionaryCommand.ShowDeleted;
            yield return DictionaryCommand.Restore;
            yield return DictionaryCommand.Refresh;
        }
        public override void RefreshData()
        {
            if (_viewModel.ShowDeleted == (DictionaryCommand.ShowDeleted.Caption == DictionaryCommand.ShowDeleted.DefaultCaption))
                DictionaryCommand.ShowDeleted.SwapCaption();

            _viewModel.Refresh();
            _viewModel.ActiveRow = FocusedRecord;
            EnableEditButtons();
        }
        protected virtual void EnableEditButtons()
        {
            DictionaryCommand.Delete.Enabled =
            DictionaryCommand.Edit.Enabled = ((!FocusedRecord?.IsDeleted) ?? false) && FocusedRecord.Id != -1;

            //отображение кнопки восстановления
            DictionaryCommand.Restore.Enabled = _viewModel.ActiveRow?.IsDeleted ?? false;
            DictionaryCommand.Add.Enabled = !DictionaryCommand.Restore.Enabled;
        }
        public override void Edit()
        {
            OpenEditForm(_viewModel.ActiveRow);
        }
        public override void Delete()
        {
            _viewModel.DeleteActive();
        }
        public override void Restore()
        {
            _viewModel.RestoreActive();
        }
        public override bool CanDelete()
        {
            return !_viewModel.ActiveRow.IsVirtualTreeRoot;
        }
        public override void ShowDeleted()
        {
            _viewModel.ShowDeleted = !_viewModel.ShowDeleted;
            treeList.FilterNodes();

            if (_viewModel.ShowDeleted)
                ExpandDeletedNodes();
        }
        protected void ExpandDeletedNodes()
        {
            treeList.NodesIterator.DoOperation(n =>
            {
                I viewModel = (I)treeList.GetDataRecordByNode(n);
                if (viewModel != null && viewModel.IsDeleted)
                    ExpandTreeNode(n);
            });
        }
        protected void ExpandTreeNode(TreeListNode node)
        {
            while (node != null)
            {
                node.Expanded = true;
                node = node.ParentNode;
            };
        }
        protected TreeListNode GetNodeByItem(I item)
        {
            return treeList.FindNode(n => ((I)treeList.GetDataRecordByNode(n)).Id == item.Id);
        }
        private void treeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var treeList = sender as TreeList;
            if (treeList == null)
                return;
            var info = treeList.CalcHitInfo(e.Location);
            if (info.HitInfoType == HitInfoType.Cell)
            {
                if (treeList.FocusedNode.Level == 0)
                    if (treeList.FocusedNode.Expanded)
                        treeList.FocusedNode.Expanded = true;
                    else
                        treeList.FocusedNode.Expanded = false;
                else
                    Edit();
            }
        }
        private void treeList_FilterNode(object sender, FilterNodeEventArgs e)
        {
            I viewModel = (I)treeList.GetDataRecordByNode(e.Node);
            if (viewModel == null)
                return;

            e.Node.Visible = viewModel.IsVisible && viewModel.IsFiltered(treeList.FindFilterText);

            e.Handled = true;
        }
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            _viewModel.ActiveRow = FocusedRecord;
            EnableEditButtons();
        }

        private void treeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            I viewModel = (I)treeList.GetDataRecordByNode(e.Node);
            if (viewModel == null)
                return;
            if (viewModel.IsDeleted)
                e.Appearance.BackColor = Color.MistyRose;
        }
        private void treeList_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            I drag = (I)treeList.GetDataRecordByNode(e.Node);
            if (drag == null)
                return;
            e.CanDrag = drag.IsEnabled && !drag.IsVirtualTreeRoot;
            if (e.CanDrag)
                e.Node.ExpandAll();
        }
        protected void GetChildren(List<TreeListNode> Nodes, TreeListNode Node, ref int maxHierarchy)
        {
            if (Node.HasChildren)
                maxHierarchy++;
            foreach (TreeListNode thisNode in Node.Nodes)
            {
                Nodes.Add(thisNode);
                GetChildren(Nodes, thisNode, ref maxHierarchy);
            }
        }


        protected virtual void OpenEditForm(ITreeItemViewModel treeItemViewModel)
        {
            throw new NotImplementedException();
        }



    }
}
