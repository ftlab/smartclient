using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartClient.Core.Views
{
    public interface ISupportKeyProcess
    {
        event KeyEventHandler KeyProcess;
    }
}
