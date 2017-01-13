using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using SmartClient.Core.Attributes;
using DevExpress.Data.Filtering;

namespace SmartClient.Core.Controls.DataLayoutControl
{
    public class LayoutCreatorExt : LayoutCreator
    {
        protected DataLayoutControlExt _dataLayoutControlExt;
        public LayoutCreatorExt(DataLayoutControlExt dataLayoutControlExt)
            : base(dataLayoutControlExt)
        {
            _dataLayoutControlExt = dataLayoutControlExt;
        }

        protected override Control CreateBindableControlRunTime(LayoutElementBindingInfo elementBi)
        {
            Control ctrl = base.CreateBindableControlRunTime(elementBi);
            if (ctrl is SearchLookUpEdit)
            {
                var searchLookupEdit = ctrl as SearchLookUpEdit;
                searchLookupEdit.Popup -= LookupEdit_Popup;
                searchLookupEdit.Popup += LookupEdit_Popup;

                var searchLookupAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof(SearchLookUpBindingAttribute)] as
                        SearchLookUpBindingAttribute;
                if (searchLookupAttr != null && _dataLayoutControlExt.BindingDataProvider != null)
                    searchLookupEdit.Properties.DataSource =
                        _dataLayoutControlExt.BindingDataProvider.GetData(searchLookupAttr.DataSourceType);
            }
            if (ctrl is TreeListLookUpEdit)
            {
                var treeListLookupEdit = ctrl as TreeListLookUpEdit;
                treeListLookupEdit.Popup -= LookupEdit_Popup;
                treeListLookupEdit.Popup += LookupEdit_Popup;

                var treeListLookupAttr =
                    elementBi.DataInfo.PropertyDescriptor.Attributes[typeof(TreeListLookUpBindingAttribute)] as
                        TreeListLookUpBindingAttribute;
                if (treeListLookupAttr != null && _dataLayoutControlExt.BindingDataProvider != null)
                {
                    treeListLookupEdit.Properties.DataSource =
                             _dataLayoutControlExt.BindingDataProvider.GetData(treeListLookupAttr.DataSourceType);
                }
            }
            return ctrl;
        }

        private void LookupEdit_Popup(object sender, EventArgs e)
        {
            LookUpEditBase lookupEdit = sender as LookUpEditBase;
            if (lookupEdit.DataBindings.Count == 0 || _dataLayoutControlExt.propertyDescriptors == null) return;

            var field = lookupEdit.DataBindings[0].BindingMemberInfo.BindingField;
            var pd = _dataLayoutControlExt.propertyDescriptors[field];

            var customFilterAttr = pd.Attributes[typeof(CustomFilterAttribute)] as
                        CustomFilterAttribute;
            if (customFilterAttr != null)
            {
                CriteriaOperator criteriaOperator = null;
                if (!string.IsNullOrEmpty(customFilterAttr.Parameters))
                {
                    var paramList = customFilterAttr.Parameters.Split(',');
                    List<object> values = new List<object>();
                    foreach (var param in paramList)
                    {
                        var fpd = _dataLayoutControlExt.propertyDescriptors[param];

                        var value = fpd.GetValue(_dataLayoutControlExt.Current);
                        values.Add(value);
                    }
                    criteriaOperator = CriteriaOperator.Parse(customFilterAttr.FilterString, values.ToArray());
                }
                else
                    criteriaOperator = CriteriaOperator.Parse(customFilterAttr.FilterString);

                if (lookupEdit is SearchLookUpEdit)
                    (lookupEdit as SearchLookUpEdit).Properties.View.ActiveFilterCriteria = criteriaOperator;
                else if (lookupEdit is TreeListLookUpEdit)
                    (lookupEdit as TreeListLookUpEdit).Properties.TreeList.ActiveFilterCriteria = criteriaOperator;
            }
        }
    }
}
