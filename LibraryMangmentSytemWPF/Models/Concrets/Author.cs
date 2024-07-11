using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Author:BaseEntity
	{
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<Book> Books { get; set; }
    }

