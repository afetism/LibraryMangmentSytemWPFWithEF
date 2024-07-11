using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;

	public class Category:BaseEntity
	{
        public required string Name { get; set; }
        public List<Book> Books { get; set; }
}

