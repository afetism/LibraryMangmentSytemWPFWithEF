

using System.ComponentModel;
using System.Windows.Input;

namespace LibraryMangmentSytemWPF.ViewModels;

    public class MainAdminViewModel : INotifyPropertyChanged
     {

      public event PropertyChangedEventHandler? PropertyChanged;

       protected void OnPropertyChanged(string propertyName)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }

    public ICommand  Cate { get; set; }
    public MainAdminViewModel()
    {
        
    }


}
