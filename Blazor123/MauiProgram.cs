using Microsoft.AspNetCore.Components.WebView.Maui;
using Blazor123.Domain.Repositories.Interfaces;
using Blazor123.Domain.Repositories;
using Blazor123.Application.Services.Interfaces;
using Blazor123.Application.Services;

namespace Blazor123;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
		builder.Services.AddSingleton<IStudentService,StudentService>();

		return builder.Build();
	}
}
