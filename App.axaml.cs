using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaPdfViewer;
using Novel_Reader.Services;
using Novel_Reader.ViewModels;
using Novel_Reader.Views;

namespace Novel_Reader;

public partial class App : Application
{
    // SettingsService loads the JSON file as soon as the app starts.
    // It applies the saved values directly to ActionSettings.Instance.
    public static SettingsService Settings { get; } = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();

            desktop.MainWindow = new MainWindow { DataContext = new MainWindowViewModel() };

            // Save settings to JSON when the app closes
            desktop.Exit += (_, _) => Settings.Save();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove = BindingPlugins
            .DataValidators.OfType<DataAnnotationsValidationPlugin>()
            .ToArray();

        foreach (var plugin in dataValidationPluginsToRemove)
            BindingPlugins.DataValidators.Remove(plugin);
    }
}
