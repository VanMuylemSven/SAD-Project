using Messages;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    public class HistoryItemMessage : MvxMessage
    {
        public HistoryItemMessage(object sender, HistoryItem historyItem):base(sender)
        {
            NewHistoryItem = historyItem;
        }

        public HistoryItem NewHistoryItem { get; set; }
    }
}
