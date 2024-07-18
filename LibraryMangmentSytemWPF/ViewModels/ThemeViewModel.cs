using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Windows;

namespace LibraryMangmentSytemWPF.ViewModels;

public class ThemeViewModel : BaseViewModel
{

	private Theme themeData;
	public Theme ThemeData
	{
		get { return themeData; }
		set
		{
			themeData = value;
			OnPropertyChanged(nameof(ThemeData));
		}
	}

	private ObservableCollection<Theme> themes;
	public ObservableCollection<Theme> Themes
	{
		get => themes;
		set
		{
			themes=value;
			OnPropertyChanged(nameof(Themes));
		}
	}


	private string name;
	[Required(ErrorMessage = "Name is Required")]
	public string Name
	{
		get => name;
		set
		{
			name = value;
			OnPropertyChanged(nameof(Name));
			Validate(nameof(Name), value);
		}
	}


	public override ICommand OpenPopupCommand { get; set; }
	public override ICommand ClosePopupCommand { get; set; }
	public override ICommand UpdateEntityCommand { get; set; }
	public override ICommand DeleteEntityCommand { get; set; }


	public override RelayCommand SaveChangesCommand { get; set; }

	public ThemeViewModel()
	{
		OpenPopupCommand = new RelayCommand(OpenPopup);
		SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
		ClosePopupCommand = new RelayCommand(ClosePopup);
		UpdateEntityCommand = new RelayCommand(UpdateEntity);
		DeleteEntityCommand=new RelayCommand(DeleteEntity);



		Themes = new ObservableCollection<Theme>(libraryDbContext.Themes);

	}

	private void DeleteEntity(object obj)
	{
		try
		{
			var theme = obj as Theme;
			if (theme is not null)
			{
				var result = MessageBox.Show($"Do you want to delete {theme.Name}", "Delete Category", MessageBoxButton.YesNo);
				if (result==MessageBoxResult.Yes)
				{
					libraryDbContext.Remove(theme);
					libraryDbContext.SaveChanges();
					Themes=new(libraryDbContext.Themes);

				}
			}
		}
		catch (Exception ex)
		{


			MessageBox.Show("Error:"+ex.Message);
		}
	}

	private void UpdateEntity(object obj)
	{
		var theme = obj as Theme;
		if (theme != null)
		{
			OpenPopup(theme);
		}
	}

	private void ClosePopup(object obj)
	{
		Name = string.Empty;
		IsPopupOpen = false;

	}

	private bool CanSaveChanges(object arg)
	{
		return Validator.TryValidateObject(this, new ValidationContext(this), null);
	}

	private void SaveChanges(object obj)
	{
		bool isSaved = false;
		try
		{


			var theme = obj as Theme;
			if (theme != null)
			{
				if (theme.Id == 0)
				{
					theme = new Theme() { Name = Name };
					libraryDbContext.Themes.Add(theme);
				}
				else
				{
					theme.Name = Name;
					libraryDbContext.Update(theme);
				}

				libraryDbContext.SaveChanges();
				isSaved = true;
				Themes=new ObservableCollection<Theme>(libraryDbContext.Themes);
			}

		}
		catch (Exception)
		{


		}
		finally
		{
			if (isSaved)
				ClosePopup(obj);

		}


	}


	private void OpenPopup(object obj)
	{
		try
		{

			if (obj is null || obj is not Theme objAsTheme)
				ThemeData = new();
			else
			{
				ThemeData = objAsTheme;
				Name = ThemeData.Name;
			}

			IsPopupOpen = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
