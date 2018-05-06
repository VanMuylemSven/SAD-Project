using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    public class SearchFilterMessage : MvxMessage
    {
        public SearchFilterMessage(object sender, string filterName) : base(sender)
        {
            FilterName = filterName;
        }

        public string FilterName { get; set; }
    }
}
