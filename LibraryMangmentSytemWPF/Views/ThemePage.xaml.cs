using LibraryMangmentSytemWPF.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;

namespace LibraryMangmentSytemWPF.Views;


public partial class ThemePage : Page
{
	public ThemePage()
	{
		InitializeComponent();
		CurrentPage = this;
		CurrentPage.DataContext=new ThemeViewModel();
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
