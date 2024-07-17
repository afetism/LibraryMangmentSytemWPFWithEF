

using LibraryMangmentSytemWPF.Data;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Windows.Input;

namespace LibraryMangmentSytemWPF.ViewModels;
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public readonly LibraryDbContext libraryDbContext = new();


    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public abstract ICommand OpenPopupCommand { get; set; }
    public abstract ICommand SaveChangesCommand { get; set; }
    public abstract ICommand ClosePopupCommand { get; set; }
    public abstract ICommand UpdateEntityCommand { get; set; }
    public abstract ICommand DeleteEntityCommand { get; set; }

}

