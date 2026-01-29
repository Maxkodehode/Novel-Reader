using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace Novel_Reader.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // Constructor - this is where you call LoadTextFile
    public MainWindowViewModel()
    {
        LoadTextFile();
    }

    private async void LoadTextFile()
    {
        try
        {
            string filePath = "/home/eikichi/RiderProjects/Novel-Reader/Neofetch.txt";
            ContentText = await File.ReadAllTextAsync(filePath);
        }
        catch (Exception ex)
        {
            ContentText = $"Could not load file: {ex.Message}";
        }
    }

    // You need the ObservableProperty attribute for binding to work!
    [ObservableProperty]
    private string _contentText = "Loading...";
}