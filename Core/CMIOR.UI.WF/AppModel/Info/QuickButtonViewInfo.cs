using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIOR.UI.WF.AppModel.Info
{
    public sealed class QuickButtonViewInfo : BaseInfo
    {
        public QuickButtonViewInfo(string name)
            : base(null, name)
        {
        }

        public Action Click { get; set; }
    }
}
