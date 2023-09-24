namespace Blazor123;

public partial class App : IApplication
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
