using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Windows;

namespace LibraryMangmentSytemWPF.ViewModels;

public class GroupViewModel : BaseViewModel
{

	private Group _groupdata;
	public Group GroupData
	{
		get { return _groupdata; }
		set
		{
			_groupdata = value;
			OnPropertyChanged(nameof(GroupData));
		}
	}

	private ObservableCollection<Group> groups;
	public ObservableCollection<Group> Groups
	{
		get => groups;
		set
		{
			groups=value;
			OnPropertyChanged(nameof(Groups));
		}
	}

	private ObservableCollection<Faculty> faculties=[];
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

	private Faculty _faculty;
	[Required(ErrorMessage = "Faculty is Required")]
	public Faculty Faculty
	{
		get => _faculty;
		set
		{
			_faculty = value;
			OnPropertyChanged(nameof(Faculty));
			Validate(nameof(Faculty), value);
		}
	}


	public override ICommand OpenPopupCommand { get; set; }
	public override ICommand ClosePopupCommand { get; set; }
	public override ICommand UpdateEntityCommand { get; set; }
	public override ICommand DeleteEntityCommand { get; set; }


	public override RelayCommand SaveChangesCommand { get; set; }

	public GroupViewModel()
	{
		OpenPopupCommand = new RelayCommand(OpenPopup);
		SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
		ClosePopupCommand = new RelayCommand(ClosePopup);
		UpdateEntityCommand = new RelayCommand(UpdateEntity);
		DeleteEntityCommand=new RelayCommand(DeleteEntity);



		Groups = new ObservableCollection<Group>(libraryDbContext.Groups);
		Faculties = new ObservableCollection<Faculty>(libraryDbContext.Faculties);

	}

	private void DeleteEntity(object obj)
	{
		try
		{
			var group = obj as Group;
			if (group is not null)
			{
				var result = MessageBox.Show($"Do you want to delete {group.Name}", "Delete Category", MessageBoxButton.YesNo);
				if (result==MessageBoxResult.Yes)
				{
					libraryDbContext.Remove(group);
					libraryDbContext.SaveChanges();
					Groups=new(libraryDbContext.Groups);

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
		var group = obj as Group;
		if (group != null)
		{
			OpenPopup(group);
		}
	}

	private void ClosePopup(object obj)
	{
		Name = string.Empty;
		Faculty=null;
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


			var group = obj as Group;
			if (group != null)
			{
				if (group.Id == 0)
				{
					group = new () { Name=Name,Faculty=Faculty};
					libraryDbContext.Groups.Add(group);
				}
				else
				{
					group.Name = Name;
					libraryDbContext.Update(group);
				}

				libraryDbContext.SaveChanges();
				isSaved = true;
				Groups=new ObservableCollection<Group>(libraryDbContext.Groups);
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

			if (obj is null || obj is not Group objAsGroup)
				GroupData = new();
			else
			{
				GroupData = objAsGroup;
				Name = GroupData.Name;
				Faculty = GroupData.Faculty;
			}

			IsPopupOpen = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
