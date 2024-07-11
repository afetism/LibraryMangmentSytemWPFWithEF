

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Group:BaseEntity
	{
      public required string Name { get; set; }
      public required int FacultyId { get; set; }
      public Faculty Faculty { get; set; }

      public List<Student> Students { get; set; }


    }

