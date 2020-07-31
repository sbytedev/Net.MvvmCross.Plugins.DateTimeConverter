using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace SByteDev.MvvmCross.Plugins.DateTimeConverter.Demo
{
    public class MainViewModel : MvxViewModel
    {
        public ICommand RefreshCurrentDateTimeCommand { get; }

        public DateTime CurrentDateTime { get; private set; }
        public DateTime FutureDateTime { get; private set; }
        public DateTime PastDateTime { get; private set; }

        public DateTimeOffset CurrentDateTimeOffset { get; private set; }
        public DateTimeOffset FutureDateTimeOffset { get; private set; }
        public DateTimeOffset PastDateTimeOffset { get; private set; }

        public MainViewModel()
        {
            RefreshCurrentDateTimeCommand = new MvxCommand(RefreshCurrentDateTime);

            RefreshCurrentDateTime();
        }

        private void RefreshCurrentDateTime()
        {
            CurrentDateTime = DateTime.UtcNow;
            FutureDateTime = CurrentDateTime + TimeSpan.FromDays(10);
            PastDateTime = CurrentDateTime - TimeSpan.FromDays(10);

            CurrentDateTimeOffset = DateTimeOffset.UtcNow;
            FutureDateTimeOffset = CurrentDateTimeOffset + TimeSpan.FromDays(10);
            PastDateTimeOffset = CurrentDateTimeOffset - TimeSpan.FromDays(10);

            RaiseAllPropertiesChanged();
        }
    }
}