using LibraryMangmentSytemWPF.Models.Abstracts;



namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class T_Card:BaseEntity
	{

    public int TeacherId { get; set; }
    public int BookId { get; set; }
    public TimeOnly DateOut { get; set; }
	public TimeOnly DateIn { get; set; }
    public int LibId { get; set; }

    public Teacher Teacher { get; set; }
    public Book Book { get; set; }
    public Lib Lib { get; set; }
}
