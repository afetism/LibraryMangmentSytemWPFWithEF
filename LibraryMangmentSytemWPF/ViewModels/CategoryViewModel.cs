using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		private ObservableCollection<Category> categories;
		public ObservableCollection<Category> Categories { get => categories; set { categories=value; OnPropertyChanged(nameof(Categories)); } }

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
		public override ICommand DeleteEntityCommand { get; set; }

		public CategoryViewModel()
        {
            OpenPopupCommand = new RelayCommand(OpenPopup);
            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
            ClosePopupCommand = new RelayCommand(ClosePopup);
            UpdateEntityCommand = new RelayCommand(UpdateEntity);
            DeleteEntityCommand=new RelayCommand(DeleteEntity);
			List<Category> listCategories = libraryDbContext.Categories.ToList();

		
			Categories = new ObservableCollection<Category>(listCategories);

		}

		private void DeleteEntity(object obj)
		{
            try
            {
                var category = obj as Category;
                if (category is not null)
                {
                    var result = MessageBox.Show($"Do you want to delete {category.Name}", "Delete Category", MessageBoxButton.YesNo);
                    if (result==MessageBoxResult.Yes)
                    {
                        libraryDbContext.Remove(category);
                        libraryDbContext.SaveChanges();
                        Categories=new(libraryDbContext.Categories);

                    }
                }
            }
            catch(Exception ex) { 
            
            
            MessageBox.Show("Error:"+ex.Message);
            }
		}

		private void UpdateEntity(object obj)
        {
            var category = obj as Category;
            if (category != null)
            {
                OpenPopup(category);
            }
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
						libraryDbContext.Categories.Add(category);
					}
                    else
                    {
                        category.Name = Name;
                        libraryDbContext.Update(category);
                    }
                    
                    libraryDbContext.SaveChanges();
                    Categories=new ObservableCollection<Category>(libraryDbContext.Categories);
                }

            } 
            catch (Exception) 
            {
                MessageBox.Show("ERROR","Error Message",MessageBoxButton.OK) ;
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
                if (obj is null || obj is not Category objAsCategory)
                    CategoryData = new();
                else
                {
                    CategoryData = objAsCategory;
                    Name = CategoryData.Name;
                }

                IsPopupOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
