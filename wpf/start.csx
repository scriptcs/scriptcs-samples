#r "PresentationCore"
#r "PresentationFramework"
#r "WindowsBase"
#r "System.Xaml"
#r "System.Xml"

#load utilities.csx
#load mvvm.csx

#load viewmodels.csx
#load views.csx

using System.Windows;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

public class App : Application 
{ 
    protected override void OnStartup(StartupEventArgs e)
	{
		var viewModel = new CalculatorViewModel();

		var window = new CalculatorView
		{
			DataContext = viewModel, 
			SizeToContent = SizeToContent.WidthAndHeight
		};

		window.Show();
	}
}

Utilities.RunInSTAThread(() => new App().Run());