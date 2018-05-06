﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.ViewModels
{
    public class SearchHistoryFilterViewModel : MvxViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private  MvxSubscriptionToken _token;
        IMvxMessenger _messenger;
        public SearchHistoryFilterViewModel(IMvxMessenger messenger)
        {
            //_token = messenger.Subscribe
            //_messenger = messenger;
            //messenger.Publish<SearchFilterMessage>(FilterByName());
            _messenger = messenger;
        }

        public IMvxCommand FilterCommand
        {
            get
            {
                return new MvxCommand(FilterByName);
            }
        }

        public void FilterByName()
        {
            Debug.WriteLine(Name);
            SearchFilterMessage message = new SearchFilterMessage(this, Name);
            //Send message
            _messenger.Publish<SearchFilterMessage>(message);

        }
    }
}
