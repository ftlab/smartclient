using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using SmartClient.Core.Attributes;
using SmartClient.Core.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartClient.Core.Controls.DataLayoutControl
{
    public class DataLayoutControlExt : DevExpress.XtraDataLayout.DataLayoutControl, IHasBindingDataProvider
    {
        public IBindingDataProvider BindingDataProvider { get; set; }
        protected internal PropertyDescriptorCollection propertyDescriptors;

        protected override RepositoryItem GetRepositoryItem(LayoutElementBindingInfo bi)
        {
            var treeListLookupAttr = bi.DataInfo.PropertyDescriptor.Attributes[typeof(TreeListLookUpBindingAttribute)] as TreeListLookUpBindingAttribute;
            if (treeListLookupAttr != null)
            {
                bi.EditorType = typeof(TreeListLookUpEdit);
                var ri = new RepositoryItemTreeListLookUpEdit();
                ri.DisplayMember = treeListLookupAttr.DisplayMember;
                ri.ValueMember = treeListLookupAttr.ValueMember;
                ri.TreeList.KeyFieldName = treeListLookupAttr.KeyFieldName;
                ri.TreeList.ParentFieldName = treeListLookupAttr.ParentKeyFieldName;
                return ri;
            }
            var searchLookupAttr = bi.DataInfo.PropertyDescriptor.Attributes[typeof(SearchLookUpBindingAttribute)] as SearchLookUpBindingAttribute;
            if (searchLookupAttr != null)
            {
                bi.EditorType = typeof(SearchLookUpEdit);
                var ri = new RepositoryItemSearchLookUpEdit();
                ri.DisplayMember = searchLookupAttr.DisplayMember;
                ri.ValueMember = searchLookupAttr.ValueMember;
                return ri;
            }
            return base.GetRepositoryItem(bi);
        }

        public override LayoutCreator CreateLayoutCreator()
        {
            return new LayoutCreatorExt(this);
        }
        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }

            set
            {
                base.DataSource = value;
                if (value is BindingSource)
                {
                    BindingSource bs = value as BindingSource;
                    if (bs.Current != null)
                    {
                        propertyDescriptors = TypeDescriptor.GetProperties(bs.Current);
                    }
                }
            }
        }

        public object Current
        {
            get
            {
                if (DataSource != null && DataSource is BindingSource)
                {
                    BindingSource bs = DataSource as BindingSource;
                    return bs.Current;
                }
                return null;
            }
        }
    }
}
