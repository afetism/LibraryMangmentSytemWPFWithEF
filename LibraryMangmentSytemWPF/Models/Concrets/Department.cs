

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;

	public class Department:BaseEntity
	{
    public required string Name { get; set; }
    public List<Teacher> Teachers { get; set; }
}

