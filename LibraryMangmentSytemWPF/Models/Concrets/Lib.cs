

using LibraryMangmentSytemWPF.Models.Abstracts;


namespace LibraryMangmentSytemWPF.Models.Concrets;
   public class Lib:BaseEntity
	{
    public string FirstName
	{ get; set; }
    public string LastName { get; set; }
    public List<T_Card> T_Cards { get; set; }
    public List<S_Card> S_Cards { get; set; }

}

