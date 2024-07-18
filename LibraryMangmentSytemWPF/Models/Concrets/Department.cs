

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;

	public class Department:BaseEntity
	{
	public string Name { get; set; } = null!;
    public List<Teacher> Teachers { get; set; }
}

