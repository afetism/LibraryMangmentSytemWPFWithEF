using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Windows;

namespace LibraryMangmentSytemWPF.ViewModels;

public class DepartmentViewModel : BaseViewModel
{

	private Department _departmentData;
	public Department DepartmentData
	{
		get { return _departmentData; }
		set
		{
			_departmentData = value;
			OnPropertyChanged(nameof(DepartmentData));
		}
	}

	private ObservableCollection<Department> departments;
	public ObservableCollection<Department> Departments
	{
		get => departments;
		set
		{
			departments=value;
			OnPropertyChanged(nameof(Departments));
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

	public DepartmentViewModel()
	{
		OpenPopupCommand = new RelayCommand(OpenPopup);
		SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
		ClosePopupCommand = new RelayCommand(ClosePopup);
		UpdateEntityCommand = new RelayCommand(UpdateEntity);
		DeleteEntityCommand=new RelayCommand(DeleteEntity);



		Departments = new ObservableCollection<Department>(libraryDbContext.Departments);

	}

	private void DeleteEntity(object obj)
	{
		try
		{
			var department = obj as Department;
			if (department is not null)
			{
				var result = MessageBox.Show($"Do you want to delete {department.Name}", "Delete Department", MessageBoxButton.YesNo);
				if (result==MessageBoxResult.Yes)
				{
					libraryDbContext.Remove(department);
					libraryDbContext.SaveChanges();
					Departments=new(libraryDbContext.Departments);

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
		var department = obj as Department;
		if (department != null)
		{
			OpenPopup(department);
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


			var department = obj as Department;
			if (department != null)
			{
				if (department.Id == 0)
				{
					department = new Department() { Name = Name };
					libraryDbContext.Add(department);
				}
				else
				{
					department.Name = Name;
					libraryDbContext.Update(department);
				}

				libraryDbContext.SaveChanges();
				isSaved = true;
				Departments=new ObservableCollection<Department>(libraryDbContext.Departments);
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

			if (obj is null || obj is not Department objAsDepartment)
				DepartmentData = new();
			else
			{
				DepartmentData = objAsDepartment;
				Name = DepartmentData.Name;
			}

			IsPopupOpen = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
