namespace PercentageCalculator;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window(new MainPage()) { Title = "% Calculator" };

#if WINDOWS
		window.Width = 420;
		window.Height = 840;
#endif

		return window;
	}
}
