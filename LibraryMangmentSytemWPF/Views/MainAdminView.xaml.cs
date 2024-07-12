
using System.Windows;


namespace LibraryMangmentSytemWPF.Views
{
	/// <summary>
	/// Interaction logic for MainAdminView.xaml
	/// </summary>
	public partial class MainAdminView : Window
	{
		public MainAdminView()
		{
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			Environment.Exit(0);
        }
    }
}
