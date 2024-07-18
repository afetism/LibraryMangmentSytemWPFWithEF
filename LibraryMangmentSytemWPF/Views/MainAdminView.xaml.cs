using System.ComponentModel;
using System.Windows;


namespace LibraryMangmentSytemWPF.Views;


public partial class MainAdminView : Window
{
	public MainAdminView()
	{
		InitializeComponent();
            DataContext = this;
		
	}
     
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
		Environment.Exit(0);
        }

      


}
