using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class S_Card:BaseEntity
	{
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public TimeOnly DateOut { get; set; }
    public TimeOnly DataIn { get; set; }
    public int LibId { get; set; }

    public Student Student { get; set; }
    public Book Book { get; set; }
    public Lib Lib { get; set; }
}

