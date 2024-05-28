using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp5
{
    internal class AppShellViewModel : ObservableRecipient
    {
        private bool _isLoggedIn = false;
        private bool _isNotLoggedIn = true;
        private bool _someTimesEnabled;

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                if (value == _isLoggedIn) return;
                _isLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotLoggedIn
        {
            get => _isNotLoggedIn;
            set
            {
                if (value == _isNotLoggedIn) return;
                _isNotLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public bool SomeTimesEnabled
        {
            get => _someTimesEnabled;
            set
            {
                if (value == _someTimesEnabled) return;
                _someTimesEnabled = value;
                OnPropertyChanged();
            }
        }
    }
}
