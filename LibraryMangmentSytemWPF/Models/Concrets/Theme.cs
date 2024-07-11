

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;

	public class Theme:BaseEntity
	{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
    }

