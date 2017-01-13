using System;
using System.ComponentModel;
using DevExpress.XtraTreeList;

namespace SmartClient.Core.ViewModels
{
    /// <summary>
    ///  Базовый класс для данных навигационного дерева
    /// </summary>
    public abstract class NavNode : TreeList.IVirtualTreeListData
    {
        protected NavNode(NavNode parent, object data)
        {
            Parent = parent;
            Data = data;
        }


        [Browsable(false)]
        public object Data { get; }

        [Browsable(false)]
        protected internal NavNode Parent { get; }

        [DisplayName("Описание")]
        public string Caption => GetCaption();

        protected abstract string GetCaption();


        #region Implementation of IVirtualTreeListData

        public abstract void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info);

        public virtual void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var node = (NavNode)info.Node;

            if (info.Column.FieldName == "Caption")
                info.CellData = node.Caption;
            else throw new NotSupportedException("Отображение для колонки не поддерживается");
        }

        public abstract void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info);

        #endregion
    }
}
