using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Windows;

namespace LibraryMangmentSytemWPF.ViewModels;

public class FacultyViewModel : BaseViewModel
{

	private Faculty _facultyData;
	public Faculty FacultyData
	{
		get { return _facultyData; }
		set
		{
			_facultyData = value;
			OnPropertyChanged(nameof(FacultyData));
		}
	}

	private ObservableCollection<Faculty> faculties;
	public ObservableCollection<Faculty> Faculties
	{
		get => faculties;
		set
		{
			faculties=value;
			OnPropertyChanged(nameof(Faculties));
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

	public FacultyViewModel()
	{
		OpenPopupCommand = new RelayCommand(OpenPopup);
		SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
		ClosePopupCommand = new RelayCommand(ClosePopup);
		UpdateEntityCommand = new RelayCommand(UpdateEntity);
		DeleteEntityCommand=new RelayCommand(DeleteEntity);



		Faculties = new ObservableCollection<Faculty>(libraryDbContext.Faculties);

	}

	private void DeleteEntity(object obj)
	{
		try
		{
			var faculty = obj as Faculty;
			if (faculty is not null)
			{
				var result = MessageBox.Show($"Do you want to delete {faculty.Name}", "Delete Faculty", MessageBoxButton.YesNo);
				if (result==MessageBoxResult.Yes)
				{
					libraryDbContext.Remove(faculty);
					libraryDbContext.SaveChanges();
					Faculties=new(libraryDbContext.Faculties);

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
		var faculty = obj as Faculty;
		if (faculty != null)
		{
			OpenPopup(faculty);
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


			var faculty = obj as Faculty;
			if (faculty != null)
			{
				if (faculty.Id == 0)
				{
					faculty = new Faculty() { Name = Name };
					libraryDbContext.Add(faculty);
				}
				else
				{
					faculty.Name = Name;
					libraryDbContext.Update(faculty);
				}

				libraryDbContext.SaveChanges();
				isSaved = true;
				Faculties=new ObservableCollection<Faculty>(libraryDbContext.Faculties);
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

			if (obj is null || obj is not Faculty objAsFaculty)
				FacultyData = new();
			else
			{
				FacultyData = objAsFaculty;
				Name = FacultyData.Name;
			}

			IsPopupOpen = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
