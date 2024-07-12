using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Author:BaseEntity
	{
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public List<Book> Books { get; set; }
    }

