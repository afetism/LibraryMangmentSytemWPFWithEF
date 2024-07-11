using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;

	public class Faculty:BaseEntity
	{

    public required string Name { get; set; }

    public List<Group> Groups { get; set; }
    }

