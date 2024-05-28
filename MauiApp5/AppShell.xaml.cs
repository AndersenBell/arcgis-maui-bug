namespace MauiApp5
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            BindingContext = new AppShellViewModel();
            InitializeComponent();
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            // This is used to block navigation when the current view model is busy
            object? currentViewModel = this?.CurrentPage?.BindingContext;

            if (currentViewModel is MainPage page )
            {
                page.Cancellation.Cancel();
            }
        }
    }

}
