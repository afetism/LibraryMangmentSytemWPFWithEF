using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryMangmentSytemWPF.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

        private Author _authorData;
        public Author AuthorData
        {
            get { return _authorData; }
            set
            {
                _authorData = value;
                OnPropertyChanged(nameof(AuthorData));
            }
        }

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get { return _isPopupOpen; }
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged(nameof(IsPopupOpen));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }

        public ICommand OpenPopupCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }
        public ICommand ClosePopupCommand { get; set; }
        public ICommand UpdateEntityCommand { get; set; }


        public CategoryViewModel()
        {
            OpenPopupCommand = new RelayCommand(OpenPopup);
            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
            ClosePopupCommand = new RelayCommand(ClosePopup);
            UpdateEntityCommand = new RelayCommand(UpdateEntity);
           

        }

        private void UpdateEntity(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClosePopup(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanSaveChanges(object arg)
        {
            return true;
        }

        private void SaveChanges(object obj)
        {
            throw new NotImplementedException();
        }

        private void OpenPopup(object obj)
        {
            try
            {
                if (obj is null || obj is not Author objAsAuthor)
                    AuthorData = new();
                else
                    AuthorData = objAsAuthor;

                IsPopupOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
