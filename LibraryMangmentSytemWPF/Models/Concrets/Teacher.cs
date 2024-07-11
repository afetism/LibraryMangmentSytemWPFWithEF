

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Teacher:BaseEntity
	{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public List<T_Card> T_Card { get; set; }
}

