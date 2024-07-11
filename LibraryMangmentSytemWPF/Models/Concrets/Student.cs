

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Student:BaseEntity
	{
       public string FirstName { get;    set; }
       public string LastName { get;    set; }
       public int GroupId { get; set; }
       public Group Group { get; set; }
       public List<S_Card> S_Cards { get; set; }
}

