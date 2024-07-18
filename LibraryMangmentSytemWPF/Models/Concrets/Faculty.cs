using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;

	public class Faculty:BaseEntity
	{

    public string Name { get; set; } = null!;

    public List<Group> Groups { get; set; }
    }

