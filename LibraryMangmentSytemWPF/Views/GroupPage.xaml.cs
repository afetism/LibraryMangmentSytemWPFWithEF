using LibraryMangmentSytemWPF.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;

namespace LibraryMangmentSytemWPF.Views;

/// <summary>
/// Interaction logic for GroupPage.xaml
/// </summary>
public partial class GroupPage : Page
{
	public GroupPage()
	{
		InitializeComponent();
		CurrentPage = this;
		CurrentPage.DataContext=new GroupViewModel();
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
