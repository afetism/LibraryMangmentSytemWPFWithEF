
using LibraryMangmentSytemWPF.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace LibraryMangmentSytemWPF.Views
{
	/// <summary>
	/// Interaction logic for MainAdminView.xaml
	/// </summary>
	public partial class MainAdminView : Window,INotifyPropertyChanged
	{
		public MainAdminView()
		{
			InitializeComponent();
            DataContext = this;
			
		}
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Page currentPage;

        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			Environment.Exit(0);
        }

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
           
            CurrentPage=new CategoryPage();
            CurrentPage.DataContext = new CategoryViewModel();
        }
    }
}
