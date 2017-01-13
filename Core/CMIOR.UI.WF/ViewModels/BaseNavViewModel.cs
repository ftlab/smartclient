using DevExpress.XtraTreeList;

namespace CMIOR.UI.WF.ViewModels
{
	public class BaseNavViewModel : BaseViewModel
	{
		private TreeList.IVirtualTreeListData _navData;

		public TreeList.IVirtualTreeListData NavData
		{
			get { return _navData; }
			set { Set(()=> NavData, ref _navData, value); }
		}
	}
}
