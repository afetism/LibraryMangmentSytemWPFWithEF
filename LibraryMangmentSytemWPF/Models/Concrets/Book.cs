

using LibraryMangmentSytemWPF.Models.Abstracts;

namespace LibraryMangmentSytemWPF.Models.Concrets;
	public class Book:BaseEntity
	{
    public string Name { get; set; }
    public int Pages { get; set; }
    public int YearPress { get; set; }
    public int ThemeId { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int PressId { get; set; }
    public int Quantity { get; set; }

    public Theme Theme { get; set; }
    public Category Category { get; set; }
    public Author Author { get; set; }
    public Press Press { get; set; }
    public List<T_Card> T_Cards { get; set; }
    public List<S_Card> S_Cards{ get; set; }
}
