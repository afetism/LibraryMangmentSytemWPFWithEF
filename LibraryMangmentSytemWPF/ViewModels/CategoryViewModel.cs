using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace LibraryMangmentSytemWPF.ViewModels
{
    public class CategoryViewModel :BaseViewModel
    {

        private Category _categoryData;
        public Category CategoryData
        {
            get { return _categoryData; }
            set
            {
                _categoryData = value;
                OnPropertyChanged(nameof(CategoryData));
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


    

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }

        public override ICommand SaveChangesCommand { get; set; }
        public override ICommand OpenPopupCommand { get; set ; }
        public override ICommand ClosePopupCommand { get; set ; }
        public override ICommand UpdateEntityCommand { get ; set; }


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
            Name = string.Empty;
            IsPopupOpen = false;
            
        }

        private bool CanSaveChanges(object arg)
        {
            return true;
        }

        private void SaveChanges(object obj)
        {
            try {

                var category = obj as Category;
                if (category != null)
                {
                    if (category.Id == 0)
                    {
                        category = new Category() { Name = Name };
                    }
                    libraryDbContext.Categories.Add(category);
                    libraryDbContext.SaveChanges();
                }

            } 
            catch (Exception ex) 
            {
                   MessageBox.Show("Exceptain :"+ex);
            }
            finally
            {
                ClosePopup(obj);

            }
           
           
        }

        private void OpenPopup(object obj)
        {
            try
            {
                if (obj is null || obj is not Category objAsAuthor)
                    CategoryData = new();
                else
                    CategoryData = objAsAuthor;

                IsPopupOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
