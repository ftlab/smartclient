using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClient.Core.Messages
{
    public sealed class IncomingMessageEvent
    {
        public int Count { get; set; }
    }

    public sealed class DualWcfMessageEvent
    {
        public bool Enabled { get; set; }
    }
}
