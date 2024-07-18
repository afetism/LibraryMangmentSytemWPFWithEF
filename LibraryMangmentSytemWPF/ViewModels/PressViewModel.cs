using LibraryMangmentSytemWPF.Data;
using LibraryMangmentSytemWPF.Models.Concrets;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;

namespace LibraryMangmentSytemWPF.ViewModels;

public class PressViewModel : BaseViewModel
{

	private Press _pressData;
	public Press PressData
	{
		get { return _pressData; }
		set
		{
			_pressData = value;
			OnPropertyChanged(nameof(PressData));
		}
	}

	private ObservableCollection<Press> _pressCollecttion;
	public ObservableCollection<Press> PressCollection
	{
		get => _pressCollecttion;
		set
		{
			_pressCollecttion=value;
			OnPropertyChanged(nameof(PressCollection));
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

	public PressViewModel()
	{
		OpenPopupCommand = new RelayCommand(OpenPopup);
		SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
		ClosePopupCommand = new RelayCommand(ClosePopup);
		UpdateEntityCommand = new RelayCommand(UpdateEntity);
		DeleteEntityCommand=new RelayCommand(DeleteEntity);


		PressCollection = new ObservableCollection<Press>(libraryDbContext.Press);

	}

	private void DeleteEntity(object obj)
	{
		try
		{
			var press = obj as Press;
			if (press is not null)
			{
				var result = MessageBox.Show($"Do you want to delete {press.Name}", "Delete Category", MessageBoxButton.YesNo);
				if (result==MessageBoxResult.Yes)
				{
					libraryDbContext.Remove(press);
					libraryDbContext.SaveChanges();
					PressCollection=new(libraryDbContext.Press);

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
		var press = obj as Press;
		if (press != null)
		{
			OpenPopup(press);
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


			var press = obj as Press;
			if (press != null)
			{
				if (press.Id == 0)
				{
					press = new Press() { Name = Name };
					libraryDbContext.Press.Add(press);
				}
				else
				{
					press.Name = Name;
					libraryDbContext.Update(press);
				}

				libraryDbContext.SaveChanges();
				isSaved = true;
				PressCollection=new ObservableCollection<Press>(libraryDbContext.Press);
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

			if (obj is null || obj is not Press objAsPress)
				PressData = new();
			else
			{
				PressData = objAsPress;
				Name = PressData.Name;
			}

			IsPopupOpen = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
