using LibraryMangmentSytemWPF.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;

namespace LibraryMangmentSytemWPF.Views;

public partial class CategoryPage : Page, INotifyPropertyChanged
{
    public CategoryPage()
    {
        InitializeComponent();
        CurrentPage = this;
        CurrentPage.DataContext=new CategoryViewModel();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private Page currentPage;

    public Page CurrentPage
    {
        get => currentPage; set { currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }



    }
}
