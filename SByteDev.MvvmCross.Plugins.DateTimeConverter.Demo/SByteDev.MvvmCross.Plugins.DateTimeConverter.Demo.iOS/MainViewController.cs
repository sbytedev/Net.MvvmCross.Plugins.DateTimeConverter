using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace SByteDev.MvvmCross.Plugins.DateTimeConverter.Demo.iOS
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : MvxViewController<MainViewModel>
    {
        private UIStackView _stackView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Date and Time Converters";

            NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Refresh);

            View.BackgroundColor = UIColor.White;

            _stackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 8
            };

            View.AddSubview(_stackView);
            View.AddConstraints(new[]
            {
                _stackView.LeadingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeadingAnchor, 16),
                _stackView.TrailingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TrailingAnchor, -16),
                _stackView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 16)
            });

            AddHeaderLabel("DateTime");

            var defaultDateTimeLabel = AddLabel("Default");
            var fullDateTimeLabel = AddLabel("Converted full");
            var dateDateTimeLabel = AddLabel("Converted date only");
            var timeDateTimeLabel = AddLabel("Converted time only");
            var relativeFutureDateTimeLabel = AddLabel("Converted relative future");
            var relativePastDateTimeLabel = AddLabel("Converted relative past");

            AddHeaderLabel("DateTimeOffset");

            var defaultDateTimeOffsetLabel = AddLabel("Default");
            var fullDateTimeOffsetLabel = AddLabel("Converted full");
            var dateDateTimeOffsetLabel = AddLabel("Converted date only");
            var timeDateTimeOffsetLabel = AddLabel("Converted time only");
            var relativeFutureDateTimeOffsetLabel = AddLabel("Converted relative future");
            var relativePastDateTimeOffsetLabel = AddLabel("Converted relative past");

            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Bind(NavigationItem.RightBarButtonItem).For("Click").To(vm => vm.RefreshCurrentDateTimeCommand);
            set.Bind(defaultDateTimeLabel).To(vm => vm.CurrentDateTime);
            set.Bind(fullDateTimeLabel).To(vm => vm.CurrentDateTime).WithConversion<DateTimeToMediumDateTimeStringValueConverter>();
            set.Bind(dateDateTimeLabel).To(vm => vm.CurrentDateTime).WithConversion<DateTimeToMediumDateStringValueConverter>();
            set.Bind(timeDateTimeLabel).To(vm => vm.CurrentDateTime).WithConversion<DateTimeToMediumTimeStringValueConverter>();
            set.Bind(relativeFutureDateTimeLabel).To(vm => vm.FutureDateTime).WithConversion<DateTimeToRelativeDateTimeStringValueConverter>();
            set.Bind(relativePastDateTimeLabel).To(vm => vm.PastDateTime).WithConversion<DateTimeToRelativeDateTimeStringValueConverter>();
            set.Bind(defaultDateTimeOffsetLabel).To(vm => vm.CurrentDateTimeOffset);
            set.Bind(fullDateTimeOffsetLabel).To(vm => vm.CurrentDateTimeOffset).WithConversion<DateTimeOffsetToMediumDateTimeStringValueConverter>();
            set.Bind(dateDateTimeOffsetLabel).To(vm => vm.CurrentDateTimeOffset).WithConversion<DateTimeOffsetToMediumDateStringValueConverter>();
            set.Bind(timeDateTimeOffsetLabel).To(vm => vm.CurrentDateTimeOffset).WithConversion<DateTimeOffsetToMediumTimeStringValueConverter>();
            set.Bind(relativeFutureDateTimeOffsetLabel).To(vm => vm.FutureDateTimeOffset).WithConversion<DateTimeOffsetToRelativeDateTimeStringValueConverter>();
            set.Bind(relativePastDateTimeOffsetLabel).To(vm => vm.PastDateTimeOffset).WithConversion<DateTimeOffsetToRelativeDateTimeStringValueConverter>();
            set.Apply();
        }

        private void AddHeaderLabel(string title)
        {
            var label = new UILabel
            {
                Text = title,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
                Font = UIFont.PreferredHeadline
            };

            _stackView.AddArrangedSubview(label);
        }

        private UILabel AddLabel(string title)
        {
            var titleLabel = new UILabel
            {
                Text = title + ":",
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.SystemGrayColor,
                TextAlignment = UITextAlignment.Right
            };

            var label = new UILabel
            {
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
                TextColor = UIColor.DarkTextColor
            };

            var stackView = new UIStackView(new UIView[] {titleLabel, label})
            {
                Axis = UILayoutConstraintAxis.Horizontal,
                Spacing = 8
            };

            _stackView.AddArrangedSubview(stackView);

            return label;
        }
    }
}