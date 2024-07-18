

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Group:BaseEntity
	{
    public string Name { get; set; } = null!;
      public  int FacultyId { get; set; }
      public Faculty Faculty { get; set; } = null!;

      public List<Student> Students { get; set; }


    }

