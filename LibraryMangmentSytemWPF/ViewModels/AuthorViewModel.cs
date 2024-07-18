
using global::LibraryMangmentSytemWPF.Data;
using global::LibraryMangmentSytemWPF.Models.Concrets;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;

using System.Windows.Input;

namespace LibraryMangmentSytemWPF.ViewModels;
public class AuthorViewModel : BaseViewModel
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

	private ObservableCollection<Author> authors;
	public ObservableCollection<Author> Authors
	{
		get => authors;
		set
		{
			authors=value;
			OnPropertyChanged(nameof(Authors));
		}
	}


	private string firstName;
	private string lastName;

	[Required(ErrorMessage = "FirstName is Required")]
	public string FirstName
	{
		get => firstName;
		set
		{
			firstName = value;
			OnPropertyChanged(nameof(FirstName));
			Validate(nameof(FirstName), value);
		}
	}
	[Required(ErrorMessage = "LastName is Required")]
	public string LastName
	{
		get => lastName;
		set
		{
			lastName=value;
			OnPropertyChanged(nameof(LastName));
			Validate(nameof(FirstName), value);

		}
	}


	public override ICommand OpenPopupCommand { get; set; }
	public override ICommand ClosePopupCommand { get; set; }
	public override ICommand UpdateEntityCommand { get; set; }
	public override ICommand DeleteEntityCommand { get; set; }


	public override RelayCommand SaveChangesCommand { get; set; }

	public AuthorViewModel()
	{
		OpenPopupCommand = new RelayCommand(OpenPopup);
		SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChanges);
		ClosePopupCommand = new RelayCommand(ClosePopup);
		UpdateEntityCommand = new RelayCommand(UpdateEntity);
		DeleteEntityCommand=new RelayCommand(DeleteEntity);



		Authors = new ObservableCollection<Author>(libraryDbContext.Authors);

	}

	private void DeleteEntity(object obj)
	{
		try
		{
			var author = obj as Author;
			if (author is not null)
			{
				var result = MessageBox.Show($"Do you want to delete {author.FirstName +" "+author.LastName}", "Delete Author", MessageBoxButton.YesNo);
				if (result==MessageBoxResult.Yes)
				{
					libraryDbContext.Remove(author);
					libraryDbContext.SaveChanges();
					Authors=new(libraryDbContext.Authors);

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
		var author = obj as Author;
		if (author != null)
		{
			OpenPopup(author);
		}
	}

	private void ClosePopup(object obj)
	{
		FirstName = string.Empty;
		LastName = string.Empty;
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


			var author = obj as Author;
			if (author != null)
			{
				if (author.Id == 0)
				{
					author = new Author() { FirstName=FirstName,LastName=LastName };
					libraryDbContext.Add(author);
				}
				else
				{
					author.FirstName = FirstName;
					author.LastName = LastName;
					libraryDbContext.Update(author);
				}

				libraryDbContext.SaveChanges();
				isSaved = true;
				Authors=new ObservableCollection<Author>(libraryDbContext.Authors);
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

			if (obj is null || obj is not Author objAsAuthor)
				AuthorData = new();
			else
			{
				AuthorData = objAsAuthor;
				FirstName = AuthorData.FirstName;
				LastName= AuthorData.LastName;

			}

			IsPopupOpen = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
