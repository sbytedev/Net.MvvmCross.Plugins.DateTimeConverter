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

            var defaultLabel = AddLabel("Default");
            var fullLabel = AddLabel("Converted full");
            var dateLabel = AddLabel("Converted date only");
            var timeLabel = AddLabel("Converted time only");
            var relativeFutureLabel = AddLabel("Converted relative future");
            var relativePastLabel = AddLabel("Converted relative past");

            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Bind(NavigationItem.RightBarButtonItem).For("Click").To(vm => vm.RefreshCurrentDateTimeCommand);
            set.Bind(defaultLabel).To(vm => vm.CurrentDateTime);
            set.Bind(fullLabel).To(vm => vm.CurrentDateTime).WithConversion<DateTimeToMediumDateTimeStringValueConverter>();
            set.Bind(dateLabel).To(vm => vm.CurrentDateTime).WithConversion<DateTimeToMediumDateStringValueConverter>();
            set.Bind(timeLabel).To(vm => vm.CurrentDateTime).WithConversion<DateTimeToMediumTimeStringValueConverter>();
            set.Bind(relativeFutureLabel).To(vm => vm.FutureDateTime).WithConversion<DateTimeToRelativeDateTimeStringValueConverter>();
            set.Bind(relativePastLabel).To(vm => vm.PastDateTime).WithConversion<DateTimeToRelativeDateTimeStringValueConverter>();
            set.Apply();
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